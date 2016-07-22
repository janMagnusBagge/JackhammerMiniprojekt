using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JackhammerMiniprojekt.ViewModels
{
	public class WordsQuestionViewModel
	{
		public List<string> Words { get; set; }
		public string Answer { get; set; }
		public int Points { get; set; }
		public bool ShowResult { get; set; }
	}
}