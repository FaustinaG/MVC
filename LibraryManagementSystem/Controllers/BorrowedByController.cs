using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.DAL;
using LibraryManagementSystem.Helper;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    [SessionTimeout]
    public class BorrowedByController : Controller
    {
        private LibraryManagementContext db = new LibraryManagementContext();

        public ActionResult Index()
        {
            var borrowedBies = db.borrowedBies.Include(b => b.Book).Include(b => b.Member);
            return View(borrowedBies.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BorrowedBy borrowedBy = db.borrowedBies.Find(id);
            if (borrowedBy == null)
            {
                return HttpNotFound();
            }
            return View(borrowedBy);
        }

        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(db.Books, "Id", "Title");
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IssueDate,ReturnDate,IsReturned,MemberId,BookId")] BorrowedBy borrowedBy)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.borrowedBies.Add(borrowedBy);
                    db.SaveChanges();
                    var createBorrowedBy = new CreateBorrowedBy();
                    createBorrowedBy.ReduceBookCountAvailability(borrowedBy);
                    return RedirectToAction("Index");
                }
                

                ViewBag.BookId = new SelectList(db.Books, "Id", "Title", borrowedBy.BookId);
                ViewBag.MemberId = new SelectList(db.Members, "Id", "Id", borrowedBy.MemberId);
                return View(borrowedBy);
            }
            catch(Exception ex)
            {
                return View("Error",new HandleErrorInfo(ex,"BorrowedBy","Create"));
            }

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BorrowedBy borrowedBy = db.borrowedBies.Find(id);
            if (borrowedBy == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookId = new SelectList(db.Books, "Id", "Title", borrowedBy.BookId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Id", borrowedBy.MemberId);
            return View(borrowedBy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IssueDate,ReturnDate,IsReturned,MemberId,BookId")] BorrowedBy borrowedBy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(borrowedBy).State = EntityState.Modified;
                db.SaveChanges();
                var editBorrowedBy = new EditBorrowedBy();
                if (!borrowedBy.IsReturned)
                {
                    editBorrowedBy.ReduceBookCountAvailability(borrowedBy);
                }
                else
                {
                    editBorrowedBy.IncreaseBookCountAvailability(borrowedBy);
                }
                return RedirectToAction("Index");
            }
            ViewBag.BookId = new SelectList(db.Books, "Id", "Title", borrowedBy.BookId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Id", borrowedBy.MemberId);
            return View(borrowedBy);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BorrowedBy borrowedBy = db.borrowedBies.Find(id);
            if (borrowedBy == null)
            {
                return HttpNotFound();
            }
            return View(borrowedBy);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BorrowedBy borrowedBy = db.borrowedBies.Find(id);
            db.borrowedBies.Remove(borrowedBy);
            db.SaveChanges();
            var deleteBorrowedBy = new DeleteBorrowedBy();
            deleteBorrowedBy.IncreaseBookCountAvailability(borrowedBy);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
