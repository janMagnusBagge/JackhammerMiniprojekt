using JackhammerMiniprojekt.Repositories;
using JackhammerMiniprojekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JackhammerMiniprojekt.Controllers
{
    public class ColorController : Controller
    {
		JackhammerRepository _JHRepo = new JackhammerRepository();
		// GET: Color
		public ActionResult Index()
		{
			var q = _JHRepo.GetColorQuestion();
			return View(q);
		}
		[HttpPost]
		public ActionResult Index(string question, string answer)
		{
			ColorQuestionViewModel result = new ColorQuestionViewModel();
			if (question.Equals(answer, StringComparison.OrdinalIgnoreCase))
				result.AnswerCorrect = true;
			else
				result.AnswerCorrect = false;
			return View(result);

		}
	}
}