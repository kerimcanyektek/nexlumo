using Lifena.Models.Entity;
using Lifena.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 
namespace Lifena.Controllers
{
	[AllowAnonymous]
	public class BlogController : Controller
	{
		// GET: Blog
		GenericRepository<TblBlogs> repo = new GenericRepository<TblBlogs>();

		public ActionResult Blog()
		{
			var blog = repo.List();
			return View(blog);
		}

		public ActionResult Blogs(int id)
		{
			var blog = repo.FindById(id); // Burada yeni metodu kullanıyoruz
			if (blog == null)
			{
				return RedirectToAction("Blog"); // Bulunamazsa 'Blog' sayfasına yönlendir
			}
			return View(blog); // Bulunan blogu döndür
		}

		public ActionResult BlogPartial()
		{
			// Veritabanından blog yazılarını çek
			var blogList = repo.List();  // Tüm blog yazılarını çek
			return PartialView(blogList);  // PartialView döndürüyoruz
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
