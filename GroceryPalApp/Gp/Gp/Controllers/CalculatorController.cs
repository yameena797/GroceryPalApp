using Gp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gp.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator

        ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();

        public static Calorie_Calculator c = new Calorie_Calculator();


        public ActionResult Calorie_Calculator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calorie_Calculator(User m)
        {

            var email = (String)Session["email"];
            var passw = (String)Session["passw"];

            /*var email = "n";
            var passw = "n";*/
          
            var l = s.SetCalories(email, passw, m.age, m.gender, m.height, m.weight);

            c.BMR = Convert.ToInt32(l.bmr);
            c.extra_active = Convert.ToInt32(l.Extra_active);
            c.lightly_active = Convert.ToInt32(l.Lightly_active);
            c.moderately_active = Convert.ToInt32(l.Moderatetely_active);
            c.sedentary =Convert.ToInt32(l.Sedentary);
            c.very_active = Convert.ToInt32(l.Very_active);

            return RedirectToAction("Result", "Calculator");
        }

        public ActionResult Result()
        {
            ViewBag.Message = c;
            return View();
        }
    }
}