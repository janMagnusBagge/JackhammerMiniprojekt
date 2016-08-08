using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JackhammerMiniprojekt.Models
{
	public class Highscore
	{
		[Key]
		public int ID { get; set; }
		public string Name { get; set; }
		public int Score { get; set; }
		public int Rank { get; set; }
		public int Category { get; set; }
		public DateTime Date { get; set; }
	}
}