using Lifena.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Lifena.Controllers
{
	public class LoginController : Controller
    {
		DbNexLumoEntities db = new DbNexLumoEntities();
		[HttpGet]
		public ActionResult Admin_Login()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Admin_Login(TblAdmin p)
		{
			DbNexLumoEntities db = new DbNexLumoEntities();
			var info = db.TblAdmin.FirstOrDefault(x => x.username == p.username && x.password == p.password);
			if (info != null)
			{
				FormsAuthentication.SetAuthCookie(info.username, false);
				Session["username"] = info.username.ToString();
				return RedirectToAction("Admin_About", "Admin");
			}
			else
			{
				return RedirectToAction("Admin_Login", "Login");
			}
		}
		public ActionResult LogOut()
		{
			FormsAuthentication.SignOut();
			Session.Abandon();
			return RedirectToAction("Admin_Login", "Login");
		}

	}
}