using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Lifena.Models.Entity;
using Lifena.Repositories;

namespace Lifena.Repositories
{
	public class GenericRepository<T> where T : class, new()
	{
		DbNexLumoEntities db = new DbNexLumoEntities();

		// Listeleme İşlemi
		public List<T> List()
		{
			return db.Set<T>().ToList();
		}

		// Ekleme İşlemi
		public void TAdd(T p)
		{
			db.Set<T>().Add(p);
			db.SaveChanges();
		}

		// Silme İşlemi
		public void TDelete(T p)
		{
			db.Set<T>().Remove(p);
			db.SaveChanges();
		}

		// ID'e Göre Getirme İşlemi
		public T TGet(int id)
		{
			return db.Set<T>().Find(id);
		}

		// Güncelleme İşlemi
		public void TUpdate(T p)
		{
			db.SaveChanges();
		}

		// ID'ye göre bulma metodu eklendi
		public T FindById(int id)
		{
			return db.Set<T>().Find(id); // ID'ye göre bulma işlemi
		}

		public T Find(Expression<Func<T, bool>> filter)
		{
			return db.Set<T>().FirstOrDefault(filter);
		}
	}
}