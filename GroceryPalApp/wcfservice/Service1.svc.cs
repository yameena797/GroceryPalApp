using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Drawing;

namespace wcfservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    public class Service1 : IService1
    {   //connection string
        static int id = 0;
        DBHelper dbh = new DBHelper();
        private string conStr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        //with dbhelper
        public List<User> GetUserId()
        {
            List<User> UserList = new List<User>();
            DataTable dt = new DataTable();
            dt = dbh.ExecuteDataTable("select USER_ID from USER_ACCOUNT");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                User u = new User();
                u.User_Id = Convert.ToInt32(dt.Rows[i]["USER_ID"]);
                UserList.Add(u);
            }
            return UserList.ToList();

        }

        public void GetImage()
        {
            byte[] bytes;
            string fileName;
            SqlConnection conn = new SqlConnection(this.conStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from item_dictionary where image_id=1", conn);
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            bytes = ((byte[])sdr["item_img"]);
            fileName = sdr["Item_name"].ToString();

            String dirPath = "C:\\img\\";
            String imgName = "my_mage_name.jpg";


            File.WriteAllBytes(dirPath + imgName, bytes);


        }

        //without dbhelper
        /*   public List<User> GetUserId()
           {
               List<User> UserList = new List<User>();

               SqlConnection conn = new SqlConnection(this.conStr);
               conn.Open();
               SqlCommand cmd = new SqlCommand("select USER_ID from USER_ACCOUNT", conn);
               cmd.CommandType = System.Data.CommandType.Text;
               SqlDataReader sdr = cmd.ExecuteReader();

               while (sdr.Read())
               {
                   User user = new User();
                  user.User_Id = (int)sdr["USER_ID"];
                   UserList.Add(user);
               }
               return UserList.ToList();
           }
           */


        //with dbhelper
        public int GetUser(string email, string password)
        {
            int status = 1000000;
            SqlConnection conn = new SqlConnection(this.conStr);
            SqlCommand cmd = new SqlCommand();
            try
            {


                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                cmd = new SqlCommand("select user_id from USER_ACCOUNT where (email_address=@email) and (user_password=@password)", conn);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {

                    int user = Convert.ToInt32(sdr["USER_ID"]);
                    return user;
                }




            }
            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return status;


        }


        /*   public Item_Info AddBarcode(Int64 barcode,string email,string password)
          {
              int user_id =  GetUser(email, password);

              Item_Info i = new Item_Info();

              int status = 0;
              SqlConnection conn = new SqlConnection(this.conStr);
              SqlCommand cmd = new SqlCommand();
              try
              {


                  if (conn.State == System.Data.ConnectionState.Closed)
                      conn.Open();

                   cmd = new SqlCommand("select EXPIRY_DATE,BRAND from ITEM_INVENTORY i , ITEM_INFO info where (i.INVENTORY_BARCODE_NO=info.BARCODE_NO) and (i.INVENTORY_USER_ID=@user_id) and (i.INVENTORY_BARCODE_NO=@barcode);", conn);

                  cmd.CommandType = System.Data.CommandType.Text;
                  cmd.Parameters.AddWithValue("@user_id", user_id);
                  cmd.Parameters.AddWithValue("@barcode", barcode);

                  SqlDataReader sdr = cmd.ExecuteReader();


                  while (sdr.Read())
                  {
                      i.EXPIRY_DATE = (DateTime)sdr["EXPIRY_DATE"];
                      i.BRAND = (string)sdr["BRAND"];

                  }




                  status = 1;
              }
              catch (Exception e)
              {
                  throw e;

              }
              finally
              {
                  conn.Close();
                  cmd.Dispose();
              }
              return i;


          }*/


        public String AddBarcode(string email, string password, Int64 barcode)
        {
            int user_id = GetUser(email, password);
            bool info = dbh.ExecuteNonQuery("insert into ITEM_INFO(BARCODE_NO,ITEM_NAME) values (@barcode,'UNKNOWN');", barcode);
            bool inventory = dbh.ExecuteNonQuery("insert into ITEM_INVENTORY (INVENTORY_BARCODE_NO,INVENTORY_USER_ID) values (@barcode,@user_id);", barcode, user_id);
            if (info && inventory == true)
                return info.ToString();
            else
                return "false";
        }

        public String RemoveBarcode(string email, string password, Int64 barcode)
        {
            int user_id = GetUser(email, password);
            bool inventory = dbh.ExecuteNonQuery("delete from ITEM_INVENTORY where INVENTORY_BARCODE_NO=@barcode;", barcode);
            bool n = dbh.ExecuteNonQuery("delete from NUTRITION_METER where ITEM_BARCODE_NO=@barcode;", barcode);
            bool info = dbh.ExecuteNonQuery("delete from ITEM_INFO where BARCODE_NO=@barcode;", barcode);
            
            if (info && n && inventory == true)
                return info.ToString();
            else
                return "false";
        }


        public List<Item_Info> ListOfBarcodes(string email, string password)
        {
            int user_id = GetUser(email, password);
            List<Item_Info> items = new List<Item_Info>();


            int status = 0;
            SqlConnection conn = new SqlConnection(this.conStr);
            SqlCommand cmd = new SqlCommand();
            try
            {


                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                cmd = new SqlCommand("select * from ITEM_INVENTORY i , ITEM_INFO info, ITEM_DICTIONARY d where  (info.BARCODE_NO =i.INVENTORY_BARCODE_NO) and(i.INVENTORY_USER_ID=@user_id)  AND (info.ITEM_NAME=d.ITEM_NAME); ", conn);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@user_id", user_id);

                SqlDataReader sdr = cmd.ExecuteReader();


                while (sdr.Read())
                {
                    Item_Info i = new Item_Info();
                    //  string s=(string)sdr["EXPIRY_DATE"];
                    if (!sdr.IsDBNull(8))
                    {

                        DateTime d = (DateTime)sdr["EXPIRY_DATE"];
                        i.EXPIRY_DATE = Convert.ToString(d.ToShortDateString());
                    }
                    else
                    {
                        i.EXPIRY_DATE = Convert.ToString(DateTime.Now.ToShortDateString());
                    }

                    if (!sdr.IsDBNull(15))
                    {
                        i.BRAND = (string)sdr["BRAND"];
                    }
                    else
                    {
                        i.BRAND = "UNKNOWN";
                    }

                    if (!sdr.IsDBNull(19))
                    {


                        i.item_img = Convert.ToBase64String((byte[])sdr["item_img"], 0, ((byte[])sdr["item_img"]).Length);
                    }
                    else
                    {
                        byte[] bytes;
                        string filenameWithPath = "D:\\sem7\\ipt\\grocerpal new proj\\images\\no.jpg";

                        ImageConverter imgCon = new ImageConverter();
                        bytes = (byte[])imgCon.ConvertTo(filenameWithPath, typeof(byte[]));
                        i.item_img = Convert.ToBase64String(bytes, 0, bytes.Length);


                    }

                    i.BARCODE_NO = Convert.ToInt64(sdr["BARCODE_NO"]);
                    items.Add(i);

                }




                status = 1;
            }
            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return items.ToList();


        }



        public List<NUTRITION_METER> ListOfNutritions(string email, string password)
        {
            int user_id = GetUser(email, password);
            List<NUTRITION_METER> items = new List<NUTRITION_METER>();


            int status = 0;
            SqlConnection conn = new SqlConnection(this.conStr);
            SqlCommand cmd = new SqlCommand();
            try
            {


                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                cmd = new SqlCommand("select * from ITEM_INVENTORY i, NUTRITION_METER n,ITEM_INFO info where  (n.ITEM_BARCODE_NO =i.INVENTORY_BARCODE_NO)  and(i.INVENTORY_USER_ID=@user_id) and (i.INVENTORY_BARCODE_NO=info.BARCODE_NO); ", conn);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@user_id", user_id);

                SqlDataReader sdr = cmd.ExecuteReader();


                while (sdr.Read())
                {
                    NUTRITION_METER i = new NUTRITION_METER();
                    //  string s=(string)sdr["EXPIRY_DATE"];
                    if (!sdr.IsDBNull(6))
                    {
                        i.SATURATED_FAT = (float)sdr["SATURATED_FAT"];
                    }
                    else
                    {
                        i.SATURATED_FAT = 0;
                    }

                    if (!sdr.IsDBNull(7))
                    {
                        i.SODIUM = (float)sdr["SODIUM"];
                    }
                    else
                    {
                        i.SODIUM = 0;
                    }

                    if (!sdr.IsDBNull(9))
                    {


                        i.CARBOHYDRATE = (float)sdr["CARBOHYDRATE"];
                    }
                    else
                    {
                        i.CARBOHYDRATE = 0;

                    }


                    if (!sdr.IsDBNull(10))
                    {


                        i.FIBRE = (float)sdr["FIBRE"];
                    }
                    else
                    {
                        i.FIBRE = 0;

                    }


                    if (!sdr.IsDBNull(12))
                    {


                        i.SUGAR = (float)sdr["SUGAR"];
                    }
                    else
                    {
                        i.SUGAR = 0;

                    }
                    i.ITEM_NAME = (string)sdr["ITEM_NAME"];
                    i.ITEM_BARCODE_NO = Convert.ToInt64(sdr["ITEM_BARCODE_NO"]);
                    items.Add(i);

                }




                status = 1;
            }
            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return items.ToList();


        }


        //add userid
        public int AddUserId(int user_id)
        {
            int status = 0;
            SqlConnection conn = new SqlConnection(this.conStr);
            SqlCommand cmd = new SqlCommand();
            try
            {


                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                cmd = new SqlCommand("Insert into User_Account (User_Id) values (@user_id)", conn);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.ExecuteReader();
                status = 1;
            }
            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return status;
        }



        public string Login(string email, string password)
        {

            string status = "false";
            User user = new User();


            SqlConnection conn = new SqlConnection(this.conStr);
            SqlCommand cmd = new SqlCommand();
            try
            {


                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                cmd = new SqlCommand("select user_id from USER_ACCOUNT where (email_address=@email) and (user_password=@password)", conn);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader sdr = cmd.ExecuteReader();
                user.User_Id = 100000000;
                while (sdr.Read())
                {

                    user.User_Id = Convert.ToInt32(sdr["USER_ID"]);

                }
                List<User> UserList = new List<User>();
                UserList = GetUserId();


                foreach (User u in UserList)
                {
                    if (user.User_Id == u.User_Id)
                    {
                        status = "true";
                    }

                }



            }
            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return status;


        }




        public int Register(string name, string email, string password)
        {

            int status = 0;
            User user = new User();
            user.User_Id = ++id;
            user.first_name = name;
            user.email_addresss = email;
            user.user_password = password;
            SqlConnection conn = new SqlConnection(this.conStr);
            SqlCommand cmd = new SqlCommand();
            try
            {


                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                cmd = new SqlCommand("Insert into User_Account (USER_ID,FIRST_NAME,EMAIL_ADDRESS,USER_PASSWORD) values (@id, @name,@email,@password)", conn);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.ExecuteReader();
                status = 1;
            }
            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return status;


        }

        public Calorie_Calculator SetCalories(string email, string password, int age, string gender, float height, float weight)
        {
            int user_id = GetUser(email, password);
            Calorie_Calculator c = new Calorie_Calculator();
            //Mifflin-St Jeor Equation for bmr calculation
            c.USERID = user_id;
            if (gender.Equals("Female"))
            {
                c.BMR = ((10 * weight) + (6.25 * height) - (5 * age) - 161);

            }
            else
            {
                c.BMR = ((10 * weight) + (6.25 * height) - (5 * age) + 5);

            }

            c.sedentary = c.BMR * 1.2;
            c.lightly_active = c.BMR * 1.375;
            c.moderatetely_active = c.BMR * 1.55;
            c.very_active = c.BMR * 1.725;
            c.extra_active = c.BMR * 1.9;
            int status = 0;
            SqlConnection conn = new SqlConnection(this.conStr);
            SqlCommand cmd = new SqlCommand();
            try
            {


                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                cmd = new SqlCommand("insert into Calorie_Calculator (USER_ID,BMR,sedentary,lightly_active,moderatetely_active,very_active,extra_active) values (@user_id,@BMR,@sedentary,@lightly_active,@moderatetely_active,@very_active,@extra_active);", conn);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@user_id", c.USER_ID);
                cmd.Parameters.AddWithValue("@BMR", c.BMR);
                cmd.Parameters.AddWithValue("@sedentary", c.sedentary);
                cmd.Parameters.AddWithValue("@lightly_active", c.lightly_active);
                cmd.Parameters.AddWithValue("@moderatetely_active", c.moderatetely_active);
                cmd.Parameters.AddWithValue("@very_active", c.very_active);
                cmd.Parameters.AddWithValue("@extra_active", c.extra_active);
                cmd.ExecuteReader();
                status = 1;
            }
            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return c;




        }






        public List<Recipe_List> GetRecipes(string email, string password)
        {
            int user_id = GetUser(email, password);
            List<Recipe_List> r = new List<Recipe_List>();
            List<Item_Info> items = ListOfBarcodes(email, password);
            List<Recipe_List> s = new List<Recipe_List>();
            int status = 0;
            SqlConnection conn = new SqlConnection(this.conStr);
            SqlCommand cmd = new SqlCommand();
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                cmd = new SqlCommand("select * from Recipe_List r where (r.user_id=@user_id);", conn);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@user_id", user_id);
                SqlDataReader sdr = cmd.ExecuteReader();


                while (sdr.Read())
                {
                    Recipe_List i = new Recipe_List();
                    //  string s=(string)sdr["EXPIRY_DATE"];
                    if (!sdr.IsDBNull(0))
                    {
                        i.ITEM_NAME = (string)sdr["ITEM_NAME"];
                    }
                    else
                    {
                        i.ITEM_NAME = "";
                    }

                    if (!sdr.IsDBNull(1))
                    {
                        i.DESCRIPTION = (string)sdr["DESCRIPTION"];
                    }
                    else
                    {
                        i.DESCRIPTION = "";
                    }

                    if (!sdr.IsDBNull(2))
                    {


                        i.user_id = Convert.ToInt32(sdr["user_id"]);
                    }
                    else
                    {
                        i.user_id = 0;

                    }


                    if (!sdr.IsDBNull(3))
                    {


                        i.Recipe_name = (string)sdr["Recipe_name"];
                    }
                    else
                    {
                        i.Recipe_name = "";

                    }


                    if (!sdr.IsDBNull(4))
                    {


                        i.Ingredients = (string)sdr["Ingredients"];
                    }
                    else
                    {
                        i.Ingredients = null;

                    }


                    if (!sdr.IsDBNull(5))
                    {

                        DateTime d = (DateTime)sdr["EXPIRY_DATE"];
                        i.EXPIRY_DATE = Convert.ToString(d.ToShortDateString());
                        i.expiry = d.Date;
                    }
                    else
                    {
                        i.EXPIRY_DATE = Convert.ToString(DateTime.Now.ToShortDateString());
                        i.expiry = DateTime.Now.Date;
                    }

                    r.Add(i);

                }

                DateTime now = DateTime.Now;
                //  var qry = from n in r
                //        orderby (now - n.expiry)
                //     select new Recipe_List();
                s = r.OrderBy(x => x.expiry).ToList<Recipe_List>();
                s.Reverse();
                //   r = r.OrderBy(n => (now - n.expiry).Duration()).Select(new Recipe_List());
                // r = (List < Recipe_List >) ordered;
                //  r = qry.ToList();
                // r.Sort((x, y) => DateTime.Compare(x.expiry, y.expiry));
                status = 1;
            }
            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return s;
        }


    }
}
