using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JackhammerMiniprojekt.ViewModels
{
	public class FiveQuestionsViewModel
	{
		[Display(Name = "Question")]
		public string QuestionString { get; set; }
		[Display(Name = "Answer")]
		public string Answer { get; set; }
		[Display(Name = "Category")]
		public int Category { get; set; } //test

		public int QuestionDone { get; set; }
		public int Points { get; set; }
		public int LastQuestion { get; set; }
		public int CurrentQuestion { get; set; }

	}
}