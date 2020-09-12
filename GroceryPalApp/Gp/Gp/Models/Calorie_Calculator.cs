using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gp.Models
{
    public class Calorie_Calculator
    {
        public int USER_ID { get; set; }
        public int sedentary { get; set; }
        public int lightly_active { get; set; }
        public int moderately_active { get; set; }
        public int very_active { get; set; }
        public int extra_active { get; set; }
        public int BMR { get; set; }
    }
}