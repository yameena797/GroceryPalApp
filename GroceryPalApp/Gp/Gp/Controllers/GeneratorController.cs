using Gp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gp.Controllers
{
    public class GeneratorController : Controller
    {
        ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();

        public ActionResult Recipe()
        {
            List<Recipe_List> i = new List<Recipe_List>();

            var email = (String)Session["email"];
            var passw = (String)Session["passw"];

            
            /*var email = "sairapaks20@gmail.com";
            var passw = "saira";*/

            var l = s.GetRecipes(email, passw);

            foreach (var b in l)
            {
                Recipe_List ii = new Recipe_List();
                ii.DESCRIPTION = b.Description;
                ii.EXPIRY_DATE=b.EXPIRYDATE;
                ii.Ingredients = b.ingredients;
                ii.ITEM_NAME = b.ITEMNAME;
                ii.Recipe_name = b.Recipename;
                i.Add(ii);
            }

            return View(i);
        }
    }
}