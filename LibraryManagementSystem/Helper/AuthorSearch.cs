using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Helper
{
    public class AuthorSearch : SearchFilterColumn
    {
        public override IQueryable<Book> Result(IQueryable<Book> books, string author)
        {
            if (!string.IsNullOrEmpty(author))
            {
                books = books.Where(x => x.Author.Name.Contains(author));
                return books;
            }
            return books;
        }
    }
}