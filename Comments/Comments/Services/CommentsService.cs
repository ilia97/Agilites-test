using Comments.Interfaces;
using Comments.Models;
using Comments.Repository;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Comments.Services
{
	class CommentsService: ICommentService
	{
		private ICommentsRepository repository;

		public CommentsService()
		{
			repository = new CommentsRepository();
		}

		public void AddComment(AddCommentModel addCommentModel, HttpServerUtilityBase server)
		{
			var file = addCommentModel.File;
			string filePath = $@"~/Pictures/";
			if (addCommentModel.Gender == Gender.Female)
			{
				filePath += "FemaleDefault.png";
			}
			else
			{
				filePath += "MaleDefault.png";
			}
			if (file != null)
			{
				filePath = GenerateFilePath(file, server);
				file.SaveAs(server.MapPath(filePath));
			}

			var comment = new Comment()
			{
				Date = addCommentModel.Date,
				Gender = addCommentModel.Gender,
				PictureLink = filePath,
				Text = addCommentModel.Text,
				UserName = addCommentModel.UserName
			};

			repository.AddComment(comment);
		}

		public IEnumerable<Comment> GetComments()
		{
			return repository.GetComments().OrderByDescending(x => x.Date);
		}

		/// <summary>
		/// Generates file name.
		/// </summary>
		/// <returns>File name.</returns>
		private string GenerateFilePath(HttpPostedFileBase file, HttpServerUtilityBase server)
		{
			string fileExtention = file.FileName.Substring(file.FileName.LastIndexOf('.'));
			string fileName = (Directory.GetFiles(server.MapPath($@"~/Pictures/")).Length + 1).ToString();
			return $@"~/Pictures/" + fileName + fileExtention;
		}
	}
}
