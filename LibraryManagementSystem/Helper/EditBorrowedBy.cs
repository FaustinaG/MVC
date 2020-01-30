using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystem.DAL;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Helper
{
    public class EditBorrowedBy : IBorrowBook, IReturnBook
    {
        private LibraryManagementContext db = new LibraryManagementContext();
        
        public void IncreaseBookCountAvailability(BorrowedBy borrowedBy)
        {
            var books = db.Books.Find(borrowedBy.BookId);
            books.AvailableCount += 1;
            books.BorrowedCount -= 1;
            db.SaveChanges();
        }

        public void ReduceBookCountAvailability(BorrowedBy borrowedBy)
        {
            var books = db.Books.Find(borrowedBy.BookId);
            books.AvailableCount -= 1;
            books.BorrowedCount += 1;
            db.SaveChanges();
        }
    }
}