using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Models
{
	class DatabaseContext: DbContext
	{
		public DatabaseContext() : base("DatabaseConnection")
		{ }

		public DbSet<Comment> Comments { set; get; }
	}
}
