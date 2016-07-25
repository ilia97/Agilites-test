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

		[Required]
		[Display(Name = "User Name")]
		[DataType(DataType.Text)]
		public string UserName { set; get; }

		[Required]
		[Display(Name = "Date")]
		[DataType(DataType.Date)]
		public DateTime Date { set; get; }

		[Required]
		[Display(Name = "Gender")]
		public Gender Gender { set; get; }

		public string Picture { set; get; }

		[Required]
		[MaxLength(300)]
		[DataType(DataType.MultilineText)]
		public string Text { set; get; }
	}

	public enum Gender
	{
		Male,
		Female
	}
}
