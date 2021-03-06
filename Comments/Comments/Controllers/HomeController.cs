﻿using Comments.Interfaces;
using Comments.Models;
using Comments.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Configuration;

namespace Comments.Controllers
{
	public class HomeController : Controller
	{
		ICommentService commentService = new CommentsService();

		public ActionResult Index()
		{
			PagedListState.SearchValue = "";
			PagedListState.Comments = commentService.GetComments();
			ViewBag.CommentsListModel = new CommentsListModel()
			{
				Comments = PagedListState.Comments.ToPagedList(1, PagedListState.pageSize)
			};
			return View();
		}

		[HttpPost]
		public ActionResult AddComment(AddCommentModel model)
		{
			if (Request.Files.Count > 0)
			{
				model.File = Request.Files[0];
			}
			if (ModelState.IsValid)
			{
				commentService.AddComment(model, Server);
				PagedListState.Comments = commentService.GetComments();
				PagedListState.SearchValue = "";
				return RedirectToAction("Index", "Paging");
			}
			else
			{
				Dictionary<string, string> errors = new Dictionary<string, string>();
				for (int i = 0; i < ModelState.Count; i++)
				{
					if (ModelState.ElementAt(i).Value.Errors.Any())
					{
						errors.Add(ModelState.ElementAt(i).Key, ModelState.ElementAt(i).Value.Errors[0].ErrorMessage);
						Response.StatusCode = (int)HttpStatusCode.BadRequest;
					}
				}
				return new JsonResult() { Data = errors };
			}
		}
	}
}