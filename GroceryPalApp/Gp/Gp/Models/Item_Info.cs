using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gp.Models
{
    public class Item_Info
    {
            public string item_img { get; set; }
            public Int64 BARCODE_NO { get; set; }
            public string EXPIRY_DATE { get; set; }
            public string BRAND { get; set; }
    }
}