using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace JackhammerMiniprojekt.Controllers
{
    public class PunctuationController : Controller
    {
        // GET: Arbitration
        public ActionResult Index()
        {
            // string fp = new string(p.TakeWhile(c => !Char.IsPunctuation(c)).ToArray());
            
            string originalString = "Hej! Hur mår du?";
            string modifiedString;


            var sb = new StringBuilder();

            foreach (char c in originalString)
            {
                if (!char.IsPunctuation(c))
                {
                    sb.Append(c);
                }
                else
                {
                    sb.Append('*');

                }
            }
            modifiedString = sb.ToString();

            @ViewBag.Original = originalString;
            @ViewBag.Modified = modifiedString;


            return View();
        }
    }
}