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
            // string p = "Hello, world!";
            // string fp = new string(p.TakeWhile(c => !Char.IsPunctuation(c)).ToArray());
            string s = "sxrdct?fvzguh,bij.";
            var sb = new StringBuilder();

            foreach (char c in s)
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
            s = sb.ToString();
            return View();
        }
    }
}