using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JackhammerMiniprojekt.Models
{
	public class Question
	{
		[Key]
		public int ID { get; set; }
		public string QuestionString { get; set; }
		public string Answer { get; set; }
		public int Category { get; set; } //test
	}
}