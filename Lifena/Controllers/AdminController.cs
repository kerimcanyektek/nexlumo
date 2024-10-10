using Lifena.Models.Entity;
using Lifena.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lifena.Controllers
{
    public class AdminController : Controller
    {
		public ActionResult Admin_Login()
		{
			return View();
		}

		// GET: Admin
		public ActionResult Admin_About()
        {
			// GET: About
			GenericRepository<TblAbout> repo = new GenericRepository<TblAbout>();
			
				var about = repo.List();
				return View(about);
        }

		public ActionResult Admin_Team()
		{
			// GET: Team Member
			GenericRepository<TblTeamMembers> repo = new GenericRepository<TblTeamMembers>();

			var teammember = repo.List();
			return View(teammember);
		}

		public ActionResult Admin_Blog()
		{
			return View();
		}

		public ActionResult Admin_NewBlog()
		{
			return View();
		}

		public ActionResult Admin_User()
		{
			return View();
		}
	}
}