using EvolentHealthAPI.Interface;
using EvolentHealthAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EvolentHealthAPI.DataAccessLayer
{
    public class ContactDataAccessSQL : IContact
    {
        log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(ContactDataAccessSQL));
        string connStr = string.Empty;


        public ContactDataAccessSQL()
        {
            connStr = ConfigurationManager.ConnectionStrings["ContactConnection"].ConnectionString;
        }


        public List<Contact> GetAllData()
        {
            try
            {
                Logger.Info("Call GetAllData");
                List<Contact> contactList = new List<Contact>();
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    string Proc = "SP_GetAllContact";
                    SqlCommand command = new SqlCommand(Proc, connection);
                    connection.Open();
                    SqlDataReader oReader = command.ExecuteReader();

                    while (oReader.Read())
                    {
                        Contact contact = new Contact();
                        contact.ID = Convert.ToString(oReader["ID"]);
                        contact.FirstName = Convert.ToString(oReader["FirstName"]);
                        contact.LastName = Convert.ToString(oReader["LastName"]);
                        contact.PhoneNumber = Convert.ToString(oReader["PhoneNumber"]);
                        contact.Email = Convert.ToString(oReader["Email"]);

                        contact.Status = Convert.ToBoolean(oReader["Status"]);
                        contactList.Add(contact);
                    }

                }

                return contactList;

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

        public bool AddData(Contact contact)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    string Proc = "SP_InsertContact";
                    SqlCommand command = new SqlCommand(Proc, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("FirstName", contact.FirstName);
                    command.Parameters.AddWithValue("LastName", contact.LastName);
                    command.Parameters.AddWithValue("PhoneNumber", contact.PhoneNumber);
                    command.Parameters.AddWithValue("Email", contact.Email);
                    command.Parameters.AddWithValue("Status", contact.Status);
                    connection.Open();
                    int Result = command.ExecuteNonQuery();
                    if (Result > 0)
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
            }
            return false;
        }



        public bool UpdateData(Contact contact)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    string Proc = "SP_UpdateContact";
                    SqlCommand command = new SqlCommand(Proc, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id", contact.ID);
                    command.Parameters.AddWithValue("FirstName", contact.FirstName);
                    command.Parameters.AddWithValue("LastName", contact.LastName);
                    command.Parameters.AddWithValue("PhoneNumber", contact.PhoneNumber);
                    command.Parameters.AddWithValue("Email", contact.Email);
                    command.Parameters.AddWithValue("Status", contact.Status);
                    connection.Open();
                    int Result = command.ExecuteNonQuery();
                    if (Result > 0)
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

            }
            return false;
        }




        public bool DeleteData(string Id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    string Proc = "SP_DeleteContact";
                    SqlCommand command = new SqlCommand(Proc, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id", Id);
                    connection.Open();
                    int Result = command.ExecuteNonQuery();
                    if (Result > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {

                Logger.Error("Exception occured in Delete Data : " + ex.Message);
                if (!string.IsNullOrEmpty(ex.InnerException.Message.ToString()))
                {
                    Logger.Error("Exception in Delete Data innerMessage : " + ex.InnerException.Message.ToString());
                }

            }
            return false;
        }

    }
}