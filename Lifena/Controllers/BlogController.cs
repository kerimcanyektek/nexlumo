using Lifena.Models.Entity;
using Lifena.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lifena.Controllers
{
    public class BlogController : Controller
	{
		// GET: Blog
		GenericRepository<TblBlogs> repo = new GenericRepository<TblBlogs>();
		public ActionResult Blog()
        {
			var blog = repo.List();
			return View(blog);
		}
		public ActionResult Blog1()
		{
			return View();
		}

		public ActionResult Blog2()
		{
			return View();
		}

		public ActionResult Blog3()
		{
			return View();
		}

		public ActionResult Blog4()
		{
			return View();
		}

		public ActionResult Blog5()
		{
			return View();
		}
	}
}