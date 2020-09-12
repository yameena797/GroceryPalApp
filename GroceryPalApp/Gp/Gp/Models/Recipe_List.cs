using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gp.Models
{
    public class Recipe_List
    {
        public string ITEM_NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public int user_id { get; set; }
        public string EXPIRY_DATE { get; set; }
        public string Ingredients { get; set; }
        public DateTime expiry { get; set; }
        public string Recipe_name { get; set; }
    }
}