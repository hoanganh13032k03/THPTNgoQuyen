using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBModel;
using System.Web.Routing;
using Common;
using Models;

namespace Website.Areas.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)

        {
            var session = (UserLogin)Session[SystemConsts.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Login", Action = "Index" }));

            }
            base.OnActionExecuted(filterContext);
        }
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "danger")
            {
                TempData["AlertType"] = "alert-danger";
                TempData["IconMessage"] = "fa-ban";
            }
            else
                  if (type == "info")
            {
                TempData["AlertType"] = "alert-info";
                TempData["IconMessage"] = "fa-info";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
                TempData["IconMessage"] = "fa-warning";
            }
            else if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
                TempData["IconMessage"] = "fa-check";
            }

        }
    }
}