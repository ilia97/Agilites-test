using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Comments.Models
{
	public class AddCommentModel
	{
		[Required(ErrorMessage = "User Name field is required.")]
		[Display(Name = "User Name")]
		[DataType(DataType.Text)]
		public string UserName { set; get; }

		[Required(ErrorMessage = "Date field is required.")]
		[Display(Name = "Date")]
		[DataType(DataType.Date)]
		public DateTime Date { set; get; }

		[Required(ErrorMessage = "Gender field is required.")]
		[Display(Name = "Gender")]
		public Gender Gender { set; get; }

		[Required(ErrorMessage = "Text field is required.")]
		[MaxLength(300, ErrorMessage = "Text field length must be lower than 300 symbols.")]
		[DataType(DataType.MultilineText)]
		public string Text { set; get; }

		public HttpPostedFileBase File { set; get; }
	}
}
