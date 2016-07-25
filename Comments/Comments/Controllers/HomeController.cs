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
			ViewBag.CommentsList = commentService.GetComments(0, 10).ToList();
			return View();
		}

		[HttpPost]
		public ActionResult AddComment(Comment model)
		{
			if (ModelState.IsValid)
			{
				commentService.AddCommentAsync(model);
			}
			var comments = commentService.GetComments(0, 10);
			return PartialView("_CommentsList", comments);
		}
	}
}