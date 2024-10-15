using Lifena.Models.Entity;
using Lifena.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;

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
			// GET: Blog
			GenericRepository<TblBlogs> repo = new GenericRepository<TblBlogs>();

			var blog = repo.List();
			return View(blog);
		}

		[HttpGet]
		public ActionResult Admin_NewBlog()
		{
			// GET: New Blog
			GenericRepository<TblBlogs> repo = new GenericRepository<TblBlogs>();
			return View();
		}
		[HttpPost]
		public ActionResult Admin_NewBlog(TblBlogs p)
		{
			// GET: New Blog
			GenericRepository<TblBlogs> repo = new GenericRepository<TblBlogs>();
			repo.TAdd(p);
			return RedirectToAction("Admin_Blog");

		}
		// Blog silme işlemi
		public ActionResult DeleteBlog(int id)
		{
			// GenericRepository'den ilgili blogu buluyoruz.
			GenericRepository<TblBlogs> repo = new GenericRepository<TblBlogs>();

			// Blogu ID'ye göre bul
			TblBlogs blogToDelete = repo.TGet(id);

			// Blog var mı kontrolü
			if (blogToDelete != null)
			{
				repo.TDelete(blogToDelete); // Blogu sil
			}

			return RedirectToAction("Admin_Blog"); // Listeleme sayfasına dön
		}
		public ActionResult Admin_User()
		{
			return View();
		}
	}
}