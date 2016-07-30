using Comments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Comments.Controllers
{
    public class PagingController : Controller
    {
        public ActionResult Index(int? page)
        {
			var commentsList = new CommentsListModel()
			{
				Comments = PagedListState.Comments.ToPagedList(page ?? 1, PagedListState.pageSize),
				SearchValue = PagedListState.SearchValue
			};
			return View("_CommentsList", commentsList);
		}
    }
}