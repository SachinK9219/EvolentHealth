using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Filters;

namespace EvolentHealthAPI.Models
{
    public class BasicAuthentication : AuthorizationFilterAttribute
    {

        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                // Gets header parameters  
                string authenticationString = actionContext.Request.Headers.Authorization.Parameter;
                string originalString = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationString));

                // Gets username and password  
                string usrename = originalString.Split(':')[0];
                string password = originalString.Split(':')[1];

                // Validate username and password  
                if (!VaidateUser(usrename, password))
                {
                    // returns unauthorized error  
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Incorrect username or passowrd");
                    //actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }

            base.OnAuthorization(actionContext);
        }

        public static bool VaidateUser(string username, string password)
        {

            if (username == "Admin" && password == "Admin@123")
                return true;

            else
            {
                return false;
            }
        }
    }
}