using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Comments.Models
{
	public class Comment
	{
		[HiddenInput]
		public int Id { set; get; }

		[Required]
		public string UserName { set; get; }

		public DateTime Date { set; get; }

		public Gender Gender { set; get; }

		public string Picture { set; get; }

		[Required]
		public string Text { set; get; }
	}

	public enum Gender
	{
		Male,
		Female
	}
}
