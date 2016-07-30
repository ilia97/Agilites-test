using Comments.Interfaces;
using Comments.Models;
using Comments.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Comments.Controllers
{
    public class SearchController : Controller
    {
		ISearchService searchService = new SearchService();

		[HttpPost]
		public ActionResult GetCommentsList(string searchQuery)
		{
			var commentsList = new CommentsListModel()
			{
				Comments = searchService.GetComments(searchQuery),
				IsSearchResult = true,
				SearchValue = searchQuery
			};
			return View("_CommentsList", commentsList);
		}
    }
}