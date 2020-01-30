using LibraryManagementSystem.DAL;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Helper
{
    public class CreateBorrowedBy : IBorrowBook
    {
        private LibraryManagementContext db = new LibraryManagementContext();

        public void ReduceBookCountAvailability(BorrowedBy borrowedBy)
        {
            var books = db.Books.Find(borrowedBy.BookId);
            books.AvailableCount -= 1;
            books.BorrowedCount += 1;
            db.SaveChanges();
        }
    }
}