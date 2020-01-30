using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Helper
{
    public class PublisherSearch : SearchFilterColumn
    {
        public override IQueryable<Book> Result(IQueryable<Book> books, string publisher)
        {
            if (!string.IsNullOrEmpty(publisher))
            {
                books = books.Where(x => x.Publisher.Name.Contains(publisher));
                return books;
            }
            return books;
        }
    }
}