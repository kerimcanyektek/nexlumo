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
		[HttpGet]
		public ActionResult EditAbout(int id)
		{
			GenericRepository<TblAbout> repo = new GenericRepository<TblAbout>();
			var about = repo.TGet(id);
			if (about == null)
			{
				return HttpNotFound();
			}

			return View(about); // View'a Model gönderiyoruz.
		}

		// Düzenleme işlemi (POST)
		[HttpPost]
		public ActionResult EditAbout(TblAbout about)
		{
			GenericRepository<TblAbout> repo = new GenericRepository<TblAbout>();
			var aboutToUpdate = repo.TGet(about.id); // Veritabanından kaydı getir.
			if (aboutToUpdate != null)
			{
				aboutToUpdate.title = about.title;
				aboutToUpdate.description = about.description;

				repo.TUpdate(aboutToUpdate); // Kaydı güncelle.
				return RedirectToAction("Admin_About"); // Düzenleme sonrası listeleme sayfasına yönlendir.
			}

			return View(about);
		}






		public ActionResult Admin_Team()
		{
			// GET: Ekip Üyesi
			GenericRepository<TblTeamMembers> repo = new GenericRepository<TblTeamMembers>();

			var teammember = repo.List();
			return View(teammember);
		}
		[HttpGet]
		public ActionResult Admin_NewTeam()
		{
			// GET: Ekip üyesi ekleme
			GenericRepository<TblTeams> repo = new GenericRepository<TblTeams>();
			return View();
		}
		[HttpPost]
		public ActionResult Admin_NewTeam(TblTeamMembers p)
		{
			// GET: Ekip üyesi ekleme
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
		[HttpGet]
		public ActionResult EditTeamMember(int id)
		{
			// Veritabanından düzenlenecek üyenin bilgilerini alıyoruz.
			GenericRepository<TblTeamMembers> repo = new GenericRepository<TblTeamMembers>();
			TblTeamMembers teamMember = repo.TGet(id);

			if (teamMember == null)
			{
				TempData["Error"] = "Düzenlenmek istenen takım üyesi bulunamadı.";
				return RedirectToAction("Admin_Team");
			}

			// Düzenleme sayfasına mevcut üyenin bilgilerini gönderiyoruz.
			return View(teamMember);
		}

		[HttpPost]
		public ActionResult EditTeamMember(TblTeamMembers p)
		{
			// Veritabanında değişiklikleri kaydetme işlemi
			GenericRepository<TblTeamMembers> repo = new GenericRepository<TblTeamMembers>();
			TblTeamMembers teamMember = repo.TGet(p.id);

			if (teamMember != null)
			{
				// Mevcut değerleri güncelliyoruz
				teamMember.fullname = p.fullname;
				teamMember.mission = p.mission;
				teamMember.img = p.img;  // Resmi değiştirmek isterseniz bunu ayarlayabilirsiniz.
				teamMember.socialMediaLink1 = p.socialMediaLink1;
				teamMember.socialMediaLink2 = p.socialMediaLink2;
				teamMember.socialMediaLink3 = p.socialMediaLink3;
				teamMember.website = p.website;

				// Veritabanına güncellenen verileri kaydet
				repo.TUpdate(teamMember);
			}

			return RedirectToAction("Admin_Team");
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
			// GET: Yeni Blog
			GenericRepository<TblBlogs> repo = new GenericRepository<TblBlogs>();
			return View();
		}
		[HttpPost]
		public ActionResult Admin_NewBlog(TblBlogs p)
		{
			// GET: Yeni Blog
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
			// GET: Kullanıcı
			GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();

			var user = repo.List();
			return View(user);
		}

		[HttpGet]
		public ActionResult Admin_NewUser()
		{
			// GET: Yeni Admin
			GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();
			return View();
		}
		[HttpPost]
		public ActionResult Admin_NewUser(TblAdmin p)
		{
			// GET: Yeni Admin
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