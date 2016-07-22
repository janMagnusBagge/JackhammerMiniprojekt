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
		[Display(Name = "Question")]
		public string QuestionString { get; set; }
		[Display(Name = "Answer")]
		public string Answer { get; set; }
		[Display(Name = "Category")]
		public int Category { get; set; } //test
	}
}