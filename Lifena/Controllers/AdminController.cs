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
		[HttpGet]
		public ActionResult Admin_NewTeam()
		{
			// GET: New Team
			GenericRepository<TblTeams> repo = new GenericRepository<TblTeams>();
			return View();
		}
		[HttpPost]
		public ActionResult Admin_NewTeam(TblTeamMembers p)
		{
			// GET: New Team
			GenericRepository<TblTeamMembers> repo = new GenericRepository<TblTeamMembers>();
			repo.TAdd(p);
			return RedirectToAction("Admin_Team");

		}
		// Ekip üyesi silme işlemi
		public ActionResult DeleteTeamMember(int id)
		{
			// GenericRepository'den ilgili TeamMember buluyoruz.
			GenericRepository<TblTeamMembers> repo = new GenericRepository<TblTeamMembers>();

			// TeamMember ID'ye göre bul
			TblTeamMembers teamToDelete = repo.TGet(id);

			// ID'yi kontrol edelim
			if (teamToDelete == null)
			{
				// Eğer ID bulunamazsa bir hata mesajı gösterelim
				TempData["Error"] = "Silinmek istenen takım üyesi bulunamadı.";
				return RedirectToAction("Admin_Team");
			}

			// TeamMember var mı kontrolü
			repo.TDelete(teamToDelete); // TeamMember sil
			return RedirectToAction("Admin_Team"); // Listeleme sayfasına dön
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
			// GET: User
			GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();

			var user = repo.List();
			return View(user);
		}

		[HttpGet]
		public ActionResult Admin_NewUser()
		{
			// GET: New Admin
			GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();
			return View();
		}
		[HttpPost]
		public ActionResult Admin_NewUser(TblAdmin p)
		{
			// GET: New Admin
			GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();
			repo.TAdd(p);
			return RedirectToAction("Admin_User");

		}
		// Admin silme işlemi
		public ActionResult DeleteUser(int id)
		{
			// GenericRepository'den ilgili Admini buluyoruz.
			GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();

			// Admin ID'ye göre bul
			TblAdmin adminToDelete = repo.TGet(id);

			// Admin var mı kontrolü
			if (adminToDelete == null)
			{
				// Admin bulunamadıysa hata mesajı ekleyelim
				TempData["Error"] = "Silinmek istenen admin bulunamadı.";
				return RedirectToAction("Admin_User");
			}

			// Admin bulunduysa silme işlemi
			repo.TDelete(adminToDelete);

			// Başarılı bir şekilde silindi
			TempData["Success"] = "Admin başarıyla silindi.";
			return RedirectToAction("Admin_User");
		}
	}
}