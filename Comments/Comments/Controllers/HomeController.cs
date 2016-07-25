using Comments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Comments.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddComment(Comment model)
		{
			if (ModelState.IsValid)
			{
				// Adding data.
			}
			return PartialView("_CommentsList");
		}
	}
}