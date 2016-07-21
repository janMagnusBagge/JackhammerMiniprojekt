using JackhammerMiniprojekt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JackhammerMiniprojekt.DataAccess
{
	public class JackhammerContext : DbContext
	{
		public DbSet<Question> Questions { get; set; }
		public DbSet<Highscore> Highscores { get; set; }

		public JackhammerContext() : base("JackhammerConnection")
		{

		}
	}
}