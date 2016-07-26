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
		public ActionResult GetCommentsList(string text)
		{
			var commentsList = new CommentsListModel()
			{
				Comments = searchService.GetComments(text),
				IsSearchResult = true,
				SearchValue = text
			};
			return View("_CommentsList", commentsList);
		}
    }
}