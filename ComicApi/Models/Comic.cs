using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;


// this is just a holder for some data
namespace ComicApi.Models
{
	public class Comic
	{
		//id, comic_name, comic_company, comic_style, introduction
		public int Id { get; set; }
		public string ComicName { get; set; }
		public string ComicCompany { get; set; }
		public string ComicStyle { get; set; }	
		public string Introduction { get; set; }	
	}
}