using Gp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gp.Controllers
{
    public class MeterController : Controller
    {
        ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();

        public ActionResult Nutrition()
        {
            List<Nutrition_Meter> i = new List<Nutrition_Meter>();

            var email = (String)Session["email"];
            var passw = (String)Session["passw"];

            /*var email = "n";
            var passw = "n";*/

            var l = s.ListOfNutritions(email,passw);

            foreach (var b in l)
            {
                Nutrition_Meter ii = new Nutrition_Meter();
                ii.ITEM_BARCODE_NO = b.ItemBarcodeNo;
                ii.ITEM_NAME = b.ItemName;
                ii.CARBOHYDRATE = b.Carbohydrate;
                ii.FIBRE = b.Fibre;
                ii.SATURATED_FAT = b.SaturatedFat;
                ii.SODIUM = b.Sodium;
                ii.SUGAR = b.Sugar;

                i.Add(ii);

            }

            return View(i);
        }
    }
}