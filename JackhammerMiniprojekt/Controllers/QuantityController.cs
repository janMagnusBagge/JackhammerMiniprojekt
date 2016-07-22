using JackhammerMiniprojekt.Repositories;
using JackhammerMiniprojekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JackhammerMiniprojekt.Controllers
{
    public class QuantityController : Controller
    {
		JackhammerRepository _JHRepo = new JackhammerRepository();
        // GET: Quantity
		public ActionResult Index()
		{
			return View(_JHRepo.GetWordQuestion());
		}
		[HttpPost]
		public ActionResult Index(WordsQuestionViewModel model)
		{
			if (model == null) return View(_JHRepo.GetWordQuestion());
			return View(_JHRepo.CheckWordsAnswer(model));
		}
	}
}