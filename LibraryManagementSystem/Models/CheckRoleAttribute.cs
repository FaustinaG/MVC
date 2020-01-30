using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Models
{
    public class CheckRoleAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            Controller controller = filterContext.Controller as Controller;

            if (controller != null)
            {
                if (session["TypeofUser"].ToString() != LoginDetail.UserTypes.Admin.ToString())
                {
                    filterContext.Result = new RedirectResult("~/Home/Index");
                    return;
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}