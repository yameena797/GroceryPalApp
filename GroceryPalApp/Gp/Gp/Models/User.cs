using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gp.Models
{
    public class User
    { 
           
            public int User_Id { get; set; }

            public string first_name { get; set; }

            public string email_address { get; set; }

            public string user_password { get; set; }

            public long barcode_no { get; set; }

            public int age { get; set; }
            public string gender { get; set; }
            public float height { get; set; }
            public float weight { get; set; }
    }
}