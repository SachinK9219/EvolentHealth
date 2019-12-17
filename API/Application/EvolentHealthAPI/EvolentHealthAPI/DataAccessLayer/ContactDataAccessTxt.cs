using EvolentHealthAPI.Interface;
using EvolentHealthAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EvolentHealthAPI.DataAccessLayer
{
    public class ContactDataAccessTxt : IContact
    {
        string FilePathAppData = HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data");
        log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(ContactDataAccessTxt));


        public bool AddData(Contact contact)
        {
            try
            {
                string FilePath = FilePathAppData + "\\sample.txt";
                var ID = Guid.NewGuid();
                string Data = ID.ToString() + "&" + contact.FirstName + "&" + contact.LastName + "&" + contact.Email + "&" + contact.PhoneNumber + "&" + contact.Status;
                File.AppendAllText(FilePath, Data + Environment.NewLine);

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("Exception occured in Getall Data : " + ex.Message);
                if (!string.IsNullOrEmpty(ex.InnerException.Message.ToString()))
                {
                    Logger.Error("Exception in Getall Data innerMessage : " + ex.InnerException.Message.ToString());
                }

            }
            return false;
        }

        public bool DeleteData(string Id)
        {
            try
            {
                string FilePath = FilePathAppData + "\\sample.txt";
                var FileLineData = File.ReadAllLines(FilePath).ToList();
                var FileAllData = File.ReadAllText(FilePath);
                var read = FileAllData.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in read.Where(x => x.Contains(Convert.ToString(Id))))
                {
                    int index = FileLineData.IndexOf(item);
                    FileLineData.RemoveAt(index);
                    File.WriteAllLines(FilePath, FileLineData);

                }
                return true;
            }

            catch (Exception ex)
            {

                Logger.Error("Exception occured in DeleteData Data : " + ex.Message);
                if (!string.IsNullOrEmpty(ex.InnerException.Message.ToString()))
                {
                    Logger.Error("Exception in DeleteData Data innerMessage : " + ex.InnerException.Message.ToString());
                }

            }
            return false;
        }

        public List<Contact> GetAllData()
        {
            try
            {
                Logger.Info("Call GetALLData");
                string FilePath = FilePathAppData + "\\sample.txt";
                List<Contact> constantList = new List<Contact>();
                Contact contact;

                int Count = 0;
                string line;
                StreamReader file = new StreamReader(FilePath);
                while ((line = file.ReadLine()) != null)
                {
                    if (Count == 0)
                    {
                        Count++;
                        continue;
                    }
                    if (line != null)
                    {
                        var Data = line.Split('\n');
                        foreach (var item in Data)
                        {
                            var ResultData = item.Split('&');
                            contact = new Contact();
                            contact.ID = ResultData[0];
                            contact.FirstName = ResultData[1];
                            contact.LastName = ResultData[2];
                            contact.Email = ResultData[3];
                            contact.PhoneNumber = ResultData[4];
                            contact.Status = Convert.ToBoolean(ResultData[5]);

                            constantList.Add(contact);
                        }
                    }
                }
                file.Close();
                return constantList;
            }
            catch (Exception ex)
            {

                Logger.Error("Exception occured in DeleteData Data : " + ex.Message);
                if (!string.IsNullOrEmpty(ex.InnerException.Message.ToString()))
                {
                    Logger.Error("Exception in DeleteData Data innerMessage : " + ex.InnerException.Message.ToString());
                }

            }
            return null;
        }

        public bool UpdateData(Contact constant)
        {
            try
            {
                string FilePath = FilePathAppData + "\\sample.txt";
                var text = File.ReadAllLines(FilePath).ToList();

                var filedata = File.ReadAllText(FilePath);
                var AllData = filedata.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string UpdatedData = constant.ID + "&" + constant.FirstName + "&" + constant.LastName + "&" + constant.Email + "&" + constant.PhoneNumber + "&" + constant.Status;
                foreach (var item in AllData.Where(x => x.Contains(constant.ID)))
                {
                    int index = text.IndexOf(item);
                    text.Insert(index, UpdatedData);
                    text.RemoveAt(index + 1);
                    File.WriteAllLines(FilePath, text);

                }
                return true;

            }
            catch (Exception ex)
            {

                Logger.Error("Exception occured in UpdateData Data : " + ex.Message);
                if (!string.IsNullOrEmpty(ex.InnerException.Message.ToString()))
                {
                    Logger.Error("Exception in UpdateData Data innerMessage : " + ex.InnerException.Message.ToString());
                }
                return false;
            }
        }
    }
}