using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Helper
{
    public abstract class SearchFilterColumn
    {
        public abstract IQueryable<Book> Result(IQueryable<Book> books, string searchstring);
    }
}