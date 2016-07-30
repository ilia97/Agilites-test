using Comments.Interfaces;
using Comments.Models;
using Comments.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Configuration;

namespace Comments.Controllers
{
    public class SearchController : Controller
    {
		private int pageSize = PagedListState.pageSize;

		ISearchService searchService = new SearchService();

		[HttpPost]
		public ActionResult GetCommentsList(string searchQuery)
		{
			PagedListState.Comments = searchService.GetComments(searchQuery);
			PagedListState.SearchValue = searchQuery;
			return RedirectToAction("Index", "Paging");
		}
    }
}