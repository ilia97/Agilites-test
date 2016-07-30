using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Models
{
	/// <summary>
	/// Class containing information about current comments' list.
	/// </summary>
	public static class PagedListState
	{
		/// <summary>
		/// The page size in the application.
		/// </summary>
		public const int pageSize = 10;

		/// <summary>
		/// The full comments list.
		/// </summary>
		public static IEnumerable<Comment> Comments { set; get; }

		/// <summary>
		/// The search value. If the search isn't held, this value will be equal to empty string.
		/// </summary>
		public static string SearchValue { set; get; }
	}
}
