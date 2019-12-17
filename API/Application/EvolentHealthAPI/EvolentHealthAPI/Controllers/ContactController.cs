using EvolentHealthAPI.Interface;
using EvolentHealthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace EvolentHealthAPI.Controllers
{
    public class ContactController : ApiController
    {

        private readonly IContact iContact;
        public ContactController(IContact icontact)
        {
            iContact = icontact;
        }

        [HttpGet]
        public HttpResponseMessage GetAllContact()
        {
            try
            {
                var Data = iContact.GetAllData();

                if (Data.Count > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, Data);
                else
                    return Request.CreateResponse(HttpStatusCode.OK, "Data Not Found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        public HttpResponseMessage InsertContact([FromBody] Contact contact)
        {
            try
            {
                bool Data = iContact.AddData(contact);
                APISuccess Api = new APISuccess();
                if (Data)
                {
                    Api.Message = "Data Inserted Successfully";

                    Api.Status = "Success";
                }

                else
                {
                    Api.Message = "Data Not Inserted";

                    Api.Status = "Error";

                }

                //if (Data)
                return Request.CreateResponse(HttpStatusCode.OK, Api);
                //else
                //    return Request.CreateErrorResponse(HttpStatusCode.NotModified, "Error Occured");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpDelete]
        public HttpResponseMessage DeleteContact(string Id)
        {
            try
            {
                if (string.IsNullOrEmpty(Id))
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                var Data = iContact.DeleteData(Id);
                APISuccess Api = new APISuccess();
                if (Data)
                {
                    Api.Message = "Data Deleted Successfully";

                    Api.Status = "Success";
                }

                else
                {
                    Api.Message = "Data Not Deleted";

                    Api.Status = "Error";

                }


                return Request.CreateResponse(HttpStatusCode.OK, Api);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPatch]
        public HttpResponseMessage UpdateContact([FromBody] Contact contact)
        {
            try
            {
                if (string.IsNullOrEmpty(contact.ID))
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                var Data = iContact.UpdateData(contact);


                APISuccess Api = new APISuccess();
                if (Data)
                {
                    Api.Message = "Data Updated Successfully";

                    Api.Status = "Success";
                }

                else
                {
                    Api.Message = "Data Not Updated";

                    Api.Status = "Error";

                }
                return Request.CreateResponse(HttpStatusCode.OK, Api);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}