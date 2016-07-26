using Comments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Interfaces
{
	interface ISearchService
	{
		IEnumerable<Comment> GetComments(string text);
	}
}
