using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lifena.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Admin_About()
        {
            return View();
        }

		public ActionResult Admin_Blog()
		{
			return View();
		}

		public ActionResult Admin_User()
		{
			return View();
		}
	}
}