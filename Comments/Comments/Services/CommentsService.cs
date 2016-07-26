using Comments.Interfaces;
using Comments.Models;
using Comments.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Services
{
	class CommentsService: ICommentService
	{
		private ICommentsRepository repository;

		public CommentsService()
		{
			repository = new CommentsRepository();
		}

		public void AddCommentAsync(Comment comment)
		{
			// Some changes with model.

			repository.AddComment(comment);
		}

		public IEnumerable<Comment> GetComments()
		{
			return repository.GetComments().OrderBy(x => x.Date);
		}
	}
}
