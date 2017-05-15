using QLNS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QLNS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            var adminInfo = Session[Constant.USER_SESSION];
            return PartialView(adminInfo);
        }

        [ChildActionOnly]
        public ActionResult Navigation()
        {
            var adminInfo = Session[Constant.USER_SESSION];
            return PartialView(adminInfo);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}