using JackhammerMiniprojekt.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JackhammerMiniprojekt.Controllers
{
    public class ImageController : Controller
    {
		JackhammerRepository _JHRepo = new JackhammerRepository();
        // GET: Image
        public ActionResult Index()
        {
			return RedirectToAction("Index", "Home");
        }

		public ActionResult ImageQuestion()
		{
			var q = _JHRepo.GetQuestion(1);
			return View(q);
		}

		[HttpPost]
		public ActionResult ImageQuestion(int ID, string myAnswer, string Answer)
		{
			if (myAnswer.Trim().ToLower() == Answer.Trim().ToLower())
				ViewBag.AnswerMessage = "You answered correctly.";
			else
				ViewBag.AnswerMessage = "Correct answer is " + Answer;
			var q = _JHRepo.GetQuestionByID(ID);
			return View(q);
		}
    }
}