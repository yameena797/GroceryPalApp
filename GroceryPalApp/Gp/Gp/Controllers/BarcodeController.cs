using Gp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gp.Controllers
{
    public class BarcodeController : Controller
    {
        ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();

        public ActionResult Barcode_Scanner()
        {
            List<Item_Info> i = new List<Item_Info>();

            var email = (String)Session["email"];
            var passw = (String)Session["passw"];

            /*var email = "n";
            var passw = "n";*/

            var l = s.ListOfBarcodes(email, passw);

            foreach (var b in l)
            {
                Item_Info ii = new Item_Info();
                ii.BARCODE_NO = b.barcode;
                ii.BRAND = b.brand;
                ii.EXPIRY_DATE = b.EXPIRYDATE;
                ii.item_img = b.itemImg;
                i.Add(ii);
            }

            return View(i);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Delete( long b)
        {
            var email = (String)Session["email"];
            var passw = (String)Session["passw"];

            /*var email = "nn";
            var passw = "nn";*/

            s.RemoveBarcode(email, passw, b);
            return RedirectToAction("Barcode_Scanner", "Barcode");
        }

        [HttpPost]
        public ActionResult Add(User m)
        {
            User u = new User();
            var email = (String)Session["email"];
            var passw = (String)Session["passw"];

            /*var email = "nn";
            var passw = "nn";*/

            u.barcode_no = m.barcode_no;
            s.AddBarcode(email, passw, u.barcode_no);

            return RedirectToAction("Barcode_Scanner", "Barcode");
        }
    }
}