using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using PagedList.Mvc;

namespace Comments.Models
{
	public class CommentsListModel
	{
		public CommentsListModel()
		{
			Comments = new List<Comment>().ToPagedList(1, 1);
		}

		public IPagedList<Comment> Comments{ set; get;}

		public string SearchValue { set; get; }
	}
}
