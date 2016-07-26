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
	class SearchService: ISearchService
	{
		ICommentsRepository repository;

		public SearchService()
		{
			repository = new CommentsRepository();
		}

		public IEnumerable<Comment> GetComments(string text)
		{
			return repository.GetComments().Where(x =>
				x.Text.Contains(text) ||
				x.UserName.Contains(text));
		}
	}
}
