using LibraryManagementSystem.DAL;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {

        private LibraryManagementContext db = new LibraryManagementContext();

        public ActionResult Index()
        {
            if (Session["LoginId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


        public ActionResult Login()
        {
            if (Session["LoginId"] != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginDetail objUser)
        {
            if (ModelState.IsValid)
            {
                using (LibraryManagementContext db = new LibraryManagementContext())
                {
                    var obj = db.LoginDetails.Where(a => a.LoginName.Equals(objUser.LoginName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["LoginId"] = obj.Id.ToString();
                        Session["TypeofUser"] = obj.TypeofUser.ToString();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Login Credentials");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult CreateLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLogin([Bind(Include = "Id,LoginName,Password,IsActive,TypeofUser")] LoginDetail logindetail)
        {
            bool ErrorFlag = false;
            if (ModelState.IsValid)
            {
                db.LoginDetails.Add(logindetail);
                int NumCount = 0;
                int splCharCount = 0;
                int Uppercase = 0;
                int Lowercase = 0;
                foreach (char c in logindetail.Password)
                {
                    if (Regex.IsMatch(c.ToString(), @"[A-Z]")) Uppercase++;
                    if (Regex.IsMatch(c.ToString(), @"[a-z]")) Lowercase++;
                    if (Regex.IsMatch(c.ToString(), @"[0-9]")) NumCount++;
                    if (Regex.IsMatch(c.ToString(), @"[^a-zA-Z0-9]")) splCharCount++;
                }
                if (logindetail.Password.Length < 4 || Uppercase < 1 || Lowercase < 1 || NumCount < 1 || splCharCount < 1)
                {
                    ErrorFlag = true;
                    ModelState.AddModelError("Password", "Passwords must be at least 4 characters and contain the following: upper case (A - Z), lower case (a - z), number(0 - 9) and special character(e.g. !@#$%^&*)");
                }
                if (!ErrorFlag)
                {
                    db.SaveChanges();
                }
                else
                {
                    return View(logindetail);
                }
                return RedirectToAction("Login");
            }

            return View(logindetail);
        }

        public ActionResult LogOut()
        {
            Session["LoginId"] = null;
            Session["TypeofUser"] = null;
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login", "Home");
        }

    }
}