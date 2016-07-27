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
		[Key]
		[HiddenInput(DisplayValue = false)]
		public int Id { set; get; }

		public string UserName { set; get; }

		public DateTime Date { set; get; }

		public Gender Gender { set; get; }

		public string PictureLink { set; get; }

		public string Text { set; get; }

		public string GetPostedTimeString()
		{
			DateTime currentDate = DateTime.Now;
			var dateDifference = currentDate - this.Date;
			if (dateDifference.Days > 0)
			{
				return String.Format("Posted {0} days ago", dateDifference.Days);
			}
			else if (dateDifference.Hours > 0)
			{
				return String.Format("Posted {0} hours ago", dateDifference.Hours);
			}
			else if (dateDifference.Minutes > 0)
			{
				return String.Format("Posted {0} minutes ago", dateDifference.Minutes);
			}
			else
			{
				return String.Format("Posted {0} seconds ago", dateDifference.Seconds);
			}
		}
	}

	public enum Gender
	{
		Male,
		Female
	}
}
