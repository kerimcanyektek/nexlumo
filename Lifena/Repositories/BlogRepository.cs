using Lifena.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lifena.Repositories
{
	public class BlogRepository : GenericRepository<TblBlogs>
	{
		DbNexLumoEntities db = new DbNexLumoEntities();
	}
}