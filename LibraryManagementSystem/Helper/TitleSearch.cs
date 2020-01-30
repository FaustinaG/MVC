using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Helper
{
    public class TitleSearch : SearchFilterColumn
    {
        public override IQueryable<Book> Result(IQueryable<Book> books, string searchstring)
        {
            if (!string.IsNullOrEmpty(searchstring))
            {
                books = books.Where(x => x.Title.Contains(searchstring));
                return books;
            }
            return books;
        }
    }
}