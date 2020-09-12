using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gp.Models
{
    public class Nutrition_Meter
    {
            public Int64 ITEM_BARCODE_NO { get; set; }
            public float SATURATED_FAT { get; set; }
            public float SODIUM { get; set; }
            public float CARBOHYDRATE { get; set; }
            public float FIBRE { get; set; }
            public float SUGAR { get; set; }
            public string ITEM_NAME { get; set; }
        
    }
}