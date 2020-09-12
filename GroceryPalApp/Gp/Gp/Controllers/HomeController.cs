using Gp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gp.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Slide()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User m)
        {

            User u = new User();
            u.first_name = m.first_name;
            u.email_address = m.email_address;
            u.user_password = m.user_password;
            s.Register(u.first_name, u.email_address, u.user_password);
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public ActionResult Login(User m)
        {
            User u = new User();
            u.email_address = m.email_address;
            u.user_password = m.user_password;

            Session["email"] = m.email_address;
            Session["passw"] = m.user_password;

            string k= s.Login(u.email_address, u.user_password);

            if (k == "true")
            {
                return RedirectToAction("Menu", "Home");
            }

            else
            {
                ViewBag.NotValidUser = "User Does not Exist";
            }

            return View("Login");
        }

        public ActionResult Menu()
        {
            DateTime d1, d2;
            List<Item_Info> i = new List<Item_Info>();

            var email = (String)Session["email"];
            var passw = (String)Session["passw"];

            /*var email = "n";
            var passw = "n";*/

            var l = s.ListOfBarcodes(email, passw);

            foreach (var b in l)
            {
                Item_Info ii = new Item_Info();

                var d = DateTime.Now;
                int y = d.Year;
                int m = d.Month;
                int dd = d.Day;

                string ds = string.Format("{0}/{1}/{2}", m, dd, y);

                d1 = DateTime.Parse(ds);
                d2 = DateTime.Parse(b.EXPIRYDATE);

                if (d1 <= d2)
                {

                    if ((d2 - d1).Days <= 7)
                    {
                        ii.BARCODE_NO = b.barcode;
                        ii.BRAND = b.brand;
                        ii.EXPIRY_DATE = b.EXPIRYDATE;
                        ii.item_img = b.itemImg;
                        i.Add(ii);
                    }
                }

            }
            return View(i);
        }
    }
}