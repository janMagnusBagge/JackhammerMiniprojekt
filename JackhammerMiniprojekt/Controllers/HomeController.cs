using JackhammerMiniprojekt.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JackhammerMiniprojekt.Controllers
{
	public class HomeController : Controller
	{
		JackhammerRepository _JHRepo = new JackhammerRepository();
		public ActionResult Index()
		{
			var q = _JHRepo.GetQuestion(1);
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}