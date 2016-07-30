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
				string fileName = Path.GetFileName(file.FileName);
				filePath = $@"~/Pictures/" + fileName;
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
	}
}
