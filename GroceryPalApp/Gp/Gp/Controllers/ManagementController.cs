using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Gp.Models;

namespace Gp.Controllers
{
    public class ManagementController : Controller
    {
        ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();

        public ActionResult Inventory()
        {
            List<Item_Info> i = new List<Item_Info>();

            var email = (String)Session["email"];
            var passw = (String)Session["passw"];

            /*var email = "nn";
            var passw = "nn";*/

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

    }
}