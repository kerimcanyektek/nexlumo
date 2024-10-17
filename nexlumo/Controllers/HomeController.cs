using Lifena.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lifena.Controllers
{
	public class HomeController : Controller
	{
		DbNexLumoEntities db = new DbNexLumoEntities();
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			var values = db.TblAbout.ToList();
			return View(values);
		}

		public ActionResult Team()
		{
			var members = db.TblTeamMembers.ToList();
			return View(members);
		}

		public ActionResult Services()
		{
			return View();
		}

		public ActionResult SuccessStories()
		{
			return View();
		}

		public ActionResult Blog()
		{
			var blogs = db.TblBlogs.ToList();
			return View(blogs);
		}

		public ActionResult Contact()
		{
			return View();
		}
	}
}