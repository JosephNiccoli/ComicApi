using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using ComicApi.Models;

namespace ComicApi
{
	public class ComicService
	{
		//	//needs a model a class that holds data using ComicAPI.models
		// now that the model is created you can be more specific with the method so it should be public List<Comic> GetAllComics(){}

		public List<Comic> GetAllComics()
		{
			// ADO.NET goes in here // connect to the database

			using (SqlConnection con = new SqlConnection("data source=.; database=ComicApi; integrated security=SSPI"))
				// the using statment says once you go past the closing curly brace close the connection
			{
				con.Open(); // open the connection to the database

				//now that the connection is open you want to run a command

				SqlCommand cmd = con.CreateCommand();
				// properties on the command u have to fill out
				cmd.CommandText = "Comics_GetAll"; // stored proc name goes here
												   // there are no prameters to send because we are not asking for a specific person so all it needs to know is get all

				// create a data reader to loop through all the rows 

				using (SqlDataReader dr = cmd.ExecuteReader())
				{
					// at this point it gives you a data reader object and loop over it // every time there is a row available your going to stuff it into this list and once your done u return that list

					List<Comic> results = new List<Comic>(); // u need to create the list outside of the loop because if u create it in the loop your going to get a new list for every row which you dont want
					while (dr.Read())
					// this loop is going to happen once for every row this database is spitting back out at u
					{
						// the purpose of this loop is to 
						// create a new Comic object 
						Comic comic = new Comic();
						// need to grab each column // Note needs to be in the order that it shows on the sql Stored Proc
						// id,comic_name,comic_company,comic_style,introduction
						comic.Id = dr.GetInt32(0);
						comic.ComicName = dr.GetString(1);
						comic.ComicCompany = dr.GetString(2);
						comic.ComicStyle = dr.GetString(3);
						comic.Introduction = dr.GetString(4);
						// and then add that Comic to the list
						results.Add(comic);
					}

					return results;
				}

			}

		}
	}
}