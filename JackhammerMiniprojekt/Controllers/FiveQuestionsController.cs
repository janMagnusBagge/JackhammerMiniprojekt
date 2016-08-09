using JackhammerMiniprojekt.Models;
using JackhammerMiniprojekt.Repositories;
using JackhammerMiniprojekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JackhammerMiniprojekt.Controllers
{
    public class FiveQuestionsController : Controller
    {
		JackhammerRepository _JHRepo = new JackhammerRepository();
		// GET: FiveQuestions
		public ActionResult Index()
		{
			return RedirectToAction("Index", "Home");
		}

		public ActionResult FiveQuestions(int Category = 99, int QuestionDone = 0, int Points = 0, int LastQuestion = 0)
		{
			if (Category > 0 && QuestionDone < 5)
			{
				var q = _JHRepo.GetQuestion(Category);
				if (LastQuestion > 0)
				{
					while (q.ID == LastQuestion)
					{
						q = _JHRepo.GetQuestion(Category);
					}
				}
				FiveQuestionsViewModel model = new FiveQuestionsViewModel();
				model.Category = Category;
				model.Answer = "";
				model.QuestionDone = QuestionDone;
				model.Points = Points;
				model.LastQuestion = LastQuestion;
				model.QuestionString = q.QuestionString;
				model.LastQuestion = LastQuestion;
				model.CurrentQuestion = q.ID;
				return View(model);
			}

			if (QuestionDone > 4)
				return RedirectToAction("AddHighscore", new { Category = Category, Points = Points });
			else
				return Redirect("Index");
		}

		[HttpPost]
		public ActionResult FiveQuestions(int Category = 1, int QuestionDone = 0, int Points = 0, int LastQuestion = 0, int CurrentQuestion = 0, string Answer = "", string QuestionString = "")
		{

			if (QuestionDone < 5)
			{
				var model = _JHRepo.FiveQuestionGetNext(Category, QuestionDone, Points, LastQuestion, CurrentQuestion, Answer, QuestionString);
				return RedirectToAction("FiveQuestions", new { Category = model.Category, QuestionDone = model.QuestionDone, Points = model.Points, LastQuestion = model.LastQuestion });
				//return View(model);
			}
			else
				return RedirectToAction("AddHighscore", new { Category = Category, Points = Points });
			//return Redirect("Index");
		}

		public ActionResult AddHighscore(int Category, int Points)
		{
			Highscore model = new Highscore();
			model.Score = Points;
			model.Category = Category;
			return View(model);
		}

		[HttpPost]
		public ActionResult AddHighscore(string Name, int Category, int Score)
		{
			_JHRepo.AddHighscore(Name, Category, Score);
			return Redirect("Index");
		}

		public ActionResult ShowHighscore(int Category)
		{
			var model = _JHRepo.ShowHighscore(Category);

			return View(model);
		}
    }
}