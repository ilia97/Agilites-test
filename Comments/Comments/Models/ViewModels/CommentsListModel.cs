using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Models
{
	public class CommentsListModel
	{
		public CommentsListModel()
		{
			Comments = new List<Comment>();
		}

		public IEnumerable<Comment> Comments{ set; get;}

		public bool IsSearchResult { set; get; }

		public string SearchValue { set; get; }
	}
}
