using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNS.Controllers
{
    public class GuideController : BaseController
    {
        // GET: Guide
        public ActionResult Index()
        {
            return View();
        }
    }
}