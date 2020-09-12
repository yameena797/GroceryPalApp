using Gp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gp.Controllers
{
    public class NotifyController : Controller
    {
        ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();

        public ActionResult Expiry()
        {
            DateTime d1, d2;
            List<Item_Info> i = new List<Item_Info>();

            var email = (String)Session["email"];
            var passw = (String)Session["passw"];

            /*var email = "sairapaks20@gmail.com";
            var passw = "saira";*/

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

                if (d1<= d2)
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