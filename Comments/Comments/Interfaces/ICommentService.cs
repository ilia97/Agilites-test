using Comments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Comments.Interfaces
{
	interface ICommentService
	{
		void AddCommentAsync(AddCommentModel comment, HttpServerUtilityBase server);

		IEnumerable<Comment> GetComments();
	}
}
