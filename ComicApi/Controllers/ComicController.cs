using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using ComicApi.Models;

namespace ComicApi.Controllers
{
	[RoutePrefix("api/comic")] //route and route prefix this is one of the first thing to think about in a new controller
    public class ComicController : ApiController
    {
		// the job of a controller is to get the work over to a service and the service will do all the actual work

		// create a method
		[HttpGet, Route("getall")]
		public List<Comic> GetAllComics() 
		{
			// the controller is just do whatever you have to do to get this thing over to the service


			// go over to the service return the result back
			ComicService comicService = new ComicService();
			return comicService.GetAllComics();

		}

	 
    }
}
