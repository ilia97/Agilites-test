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
	public class HomeController : Controller
	{
		ICommentService commentService = new CommentsService();

		public ActionResult Index()
		{
			ViewBag.CommentsListModel = new CommentsListModel()
			{
				Comments = commentService.GetComments(),
				IsSearchResult = false
			};
			return View();
		}

		[HttpPost]
		public ActionResult AddComment(Comment model)
		{
			if (ModelState.IsValid)
			{
				commentService.AddCommentAsync(model);
			}

			var commentsListModel = new CommentsListModel()
			{
				Comments = commentService.GetComments(),
				IsSearchResult = false
			};
			return PartialView("_CommentsList", commentsListModel);
		}
	}
}