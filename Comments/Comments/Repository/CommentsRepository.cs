using Comments.Interfaces;
using Comments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Repository
{
	class CommentsRepository: ICommentsRepository
	{
		private DatabaseContext databaseContext;

		public CommentsRepository()
		{
			databaseContext = new DatabaseContext();
		}

		public void AddComment(Comment comment)
		{
			databaseContext.Comments.Add(comment);
			databaseContext.SaveChanges();
		}

		public IEnumerable<Comment> GetComments()
		{
			return databaseContext.Comments;
		}
	}
}
