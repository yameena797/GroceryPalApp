using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace wcfservice
{

    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetUserId")]
        List<User> GetUserId();


        [OperationContract]
        [WebGet(UriTemplate = "GetImage")]
        void GetImage();


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Register", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int Register(string name, string email, string password);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AddUserId", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int AddUserId(int user_id);

        //  [OperationContract]
        //  [WebInvoke(Method = "POST", UriTemplate = "AddBarcode", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //  Item_Info AddBarcode(Int64 barcode,  string email, string password);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ListOfBarcodes", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Item_Info> ListOfBarcodes(string email, string password);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Login", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string Login(string email, string password);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AddBarcode", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string AddBarcode(string email, string password, Int64 barcode);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "RemoveBarcode", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string RemoveBarcode(string email, string password, Int64 barcode);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetUser", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int GetUser(string email, string password);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ListOfNutritions", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<NUTRITION_METER> ListOfNutritions(string email, string password);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "SetCalories", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Calorie_Calculator SetCalories(string email, string password, int age, string gender, float height, float weight);//km w and cm height


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetRecipes", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Recipe_List> GetRecipes(string email, string password);//km w and cm height

    }

    [DataContract]
    public class User
    {

        public int User_Id;
        public string email_addresss;
        public string user_password;
        public string first_name;



        [DataMember]
        public int Userid
        {
            get { return User_Id; }
            set { User_Id = value; }
        }

        [DataMember]
        public string email
        {
            get { return email_addresss; }
            set { email_addresss = value; }
        }

        [DataMember]
        public string password
        {
            get { return user_password; }
            set { user_password = value; }
        }

        [DataMember]
        public string firstName
        {
            get { return first_name; }
            set { first_name = value; }
        }

    }


    [DataContract]
    public class Item_Info
    {
        public string item_img;
        public Int64 BARCODE_NO;
        public string EXPIRY_DATE;
        public string BRAND;


        [DataMember]
        public string itemImg
        {
            get { return item_img; }
            set { item_img = value; }
        }
        [DataMember]
        public string EXPIRYDATE
        {
            get { return EXPIRY_DATE; }
            set { EXPIRY_DATE = value; }
        }

        [DataMember]
        public string brand
        {
            get { return BRAND; }
            set { BRAND = value; }
        }
        [DataMember]
        public Int64 barcode
        {
            get { return BARCODE_NO; }
            set { BARCODE_NO = value; }
        }
    }



    [DataContract]
    public class NUTRITION_METER
    {

        public Int64 ITEM_BARCODE_NO;
        public float SATURATED_FAT;
        public float SODIUM;
        public float CARBOHYDRATE;
        public float FIBRE;
        public float SUGAR;
        public string ITEM_NAME;





        [DataMember]
        public Int64 ItemBarcodeNo
        {
            get { return ITEM_BARCODE_NO; }
            set { ITEM_BARCODE_NO = value; }
        }
        [DataMember]
        public float SaturatedFat
        {
            get { return SATURATED_FAT; }
            set { SATURATED_FAT = value; }
        }

        [DataMember]
        public float Sodium
        {
            get { return SODIUM; }
            set { SODIUM = value; }
        }
        [DataMember]
        public float Carbohydrate
        {
            get { return CARBOHYDRATE; }
            set { CARBOHYDRATE = value; }
        }
        [DataMember]
        public float Fibre
        {
            get { return FIBRE; }
            set { FIBRE = value; }
        }
        [DataMember]
        public float Sugar
        {
            get { return SUGAR; }
            set { SUGAR = value; }
        }

        [DataMember]
        public string ItemName
        {
            get { return ITEM_NAME; }
            set { ITEM_NAME = value; }
        }
    }


    [DataContract]
    public class Calorie_Calculator
    {

        public int USER_ID;
        public double sedentary;
        public double lightly_active;
        public double moderatetely_active;
        public double very_active;
        public double extra_active;
        public double BMR;





        [DataMember]
        public int USERID
        {
            get { return USER_ID; }
            set { USER_ID = value; }
        }
        [DataMember]
        public double Sedentary
        {
            get { return sedentary; }
            set { sedentary = value; }
        }

        [DataMember]
        public double Lightly_active
        {
            get { return lightly_active; }
            set { lightly_active = value; }
        }
        [DataMember]
        public double Moderatetely_active
        {
            get { return moderatetely_active; }
            set { moderatetely_active = value; }
        }
        [DataMember]
        public double Very_active
        {
            get { return very_active; }
            set { very_active = value; }
        }
        [DataMember]
        public double Extra_active
        {

            get { return extra_active; }
            set { extra_active = value; }
        }
        [DataMember]
        public double bmr
        {
            get { return BMR; }
            set { BMR = value; }
        }
    }

    [DataContract]
    public class Recipe_List
    {
        public string ITEM_NAME;
        public string DESCRIPTION;
        public int user_id;
        public string EXPIRY_DATE;
        public string Ingredients;
        public DateTime expiry;
        public string Recipe_name;


        [DataMember]
        public string ITEMNAME
        {
            get { return ITEM_NAME; }
            set { ITEM_NAME = value; }
        }
        [DataMember]
        public string Description
        {
            get { return DESCRIPTION; }
            set { DESCRIPTION = value; }
        }

        [DataMember]
        public int userid
        {
            get { return user_id; }
            set { user_id = value; }
        }
        [DataMember]
        public string ingredients
        {
            get { return Ingredients; }
            set { Ingredients = value; }
        }
        [DataMember]
        public string Recipename
        {
            get { return Recipe_name; }
            set { Recipe_name = value; }
        }
        [DataMember]
        public string EXPIRYDATE
        {
            get { return EXPIRY_DATE; }
            set { EXPIRY_DATE = value; }
        }

    }
}