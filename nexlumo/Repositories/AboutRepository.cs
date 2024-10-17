using Lifena.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lifena.Repositories
{
	public class AboutRepository : GenericRepository<TblAbout>
	{
		DbNexLumoEntities db = new DbNexLumoEntities();
	}
}