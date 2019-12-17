using EvolentHealthUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace EvolentHealthUI.DataAccessLayer
{
    public class ContactDataAccess
    {
        string URL = "http://localhost/EvolentAPI/api/Contact/";

        //string URL = "http://localhost:1406/api/Contact/";
        log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(ContactDataAccess));
        public bool DeleteData(string Id)
        {
            try
            {
                string APIURL = URL + "/DeleteContact?id=" + Id;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(APIURL);
                request.Method = "DELETE";
                request.ContentType = "application/json";
                request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("Admin:Admin@123"));
                WebResponse response = request.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var ApiResult = reader.ReadToEnd();

                    var Data = JsonConvert.DeserializeObject<APISuccess>(ApiResult);

                    if (Data.Status.Contains("Success"))
                        return true;
                    else
                        return false;

                }
            }
            catch (Exception ex)
            {
                Logger.Error("Exception occured in Getall Data : " + ex.Message);
                if (!string.IsNullOrEmpty(ex.InnerException.Message.ToString()))
                {
                    Logger.Error("Exception in Getall Data innerMessage : " + ex.InnerException.Message.ToString());
                }
                return false;
            }
        }

        public List<Contact> GetALL()
        {
            try
            {
                Logger.Info("Call GetALL");
                string APIURL = URL + "/GetAllContact";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(APIURL);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("Admin:Admin@123"));
                List<Contact> _ListCon = new List<Contact>();
                WebResponse response = request.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var ApiResult = reader.ReadToEnd();

                    if (ApiResult.Contains("Data Not Found"))
                    {
                        return _ListCon;
                    }
                    else
                    {
                        _ListCon = JsonConvert.DeserializeObject<List<Contact>>(ApiResult);

                        return _ListCon;
                    }


                }
            }
            catch (Exception ex)
            {

                Logger.Error("Exception occured in Getall Data : " + ex.Message);
                if (!string.IsNullOrEmpty(ex.InnerException.Message.ToString()))
                {
                    Logger.Error("Exception in Getall Data innerMessage : " + ex.InnerException.Message.ToString());
                }
                return null;
            }
        }


        public bool InsertData(Contact _ObjCon)
        {
            try
            {

                string APIURL = URL + "/InsertContact";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(APIURL);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("Admin:Admin@123"));

                var SerialData = JsonConvert.SerializeObject(_ObjCon);

                byte[] byteArray = Encoding.UTF8.GetBytes(SerialData);

                request.ContentLength = byteArray.Length;

                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                WebResponse response = request.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var ApiResult = reader.ReadToEnd();

                    var Data = JsonConvert.DeserializeObject<APISuccess>(ApiResult);

                    if (Data.Status.Contains("Success"))
                        return true;
                    else
                        return false;

                }
            }
            catch (Exception ex)
            {

                Logger.Error("Exception occured in Insert Data : " + ex.Message);
                if (!string.IsNullOrEmpty(ex.InnerException.Message.ToString()))
                {
                    Logger.Error("Exception in Insert Data innerMessage : " + ex.InnerException.Message.ToString());
                }
                return false;
            }
        }

        public bool UpdateData(Contact _ObjCon)
        {
            try
            {

                string APIURL = URL + "/UpdateContact";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(APIURL);
                request.Method = "PATCH";
                request.ContentType = "application/json";
                request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("Admin:Admin@123"));

                var d = JsonConvert.SerializeObject(_ObjCon);

                byte[] byteArray = Encoding.UTF8.GetBytes(d);

                request.ContentLength = byteArray.Length;

                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                WebResponse response = request.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var ApiResult = reader.ReadToEnd();

                    var Data = JsonConvert.DeserializeObject<APISuccess>(ApiResult);

                    if (Data.Status.Contains("Success"))
                        return true;
                    else
                        return false;

                }
            }
            catch (Exception ex)
            {

                Logger.Error("Exception occured in Update Data : " + ex.Message);
                if (!string.IsNullOrEmpty(ex.InnerException.Message.ToString()))
                {
                    Logger.Error("Exception in Update Data innerMessage : " + ex.InnerException.Message.ToString());
                }
                return false;
            }
        }
    }
}