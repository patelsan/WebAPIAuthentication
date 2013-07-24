using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPIAuthenitication.Models;
using System.Net;
using System.Net.Http;
using WebAPIAuthenitication.Security;
using WebAPIAuthenitication.Helpers;

namespace WebAPIAuthenitication.Controllers
{
    public class UsersController : ApiController
    {
        public Status Authenticate(User user)
        {
            if (user == null)
                throw new HttpResponseException(new HttpResponseMessage() { StatusCode = HttpStatusCode.Unauthorized, Content = new StringContent("Please provide the credentials.") });

            if (IdentityStore.IsValidUser(user))
            {
                Token token = new Token(user.UserId, Request.GetClientIP());
                return new Status { Successeded = true, Token = token.Encrypt(), Message = "Successfully signed in." };
            }
            else
            {
                throw new HttpResponseException(new HttpResponseMessage() { StatusCode = HttpStatusCode.Unauthorized, Content = new StringContent("Invalid user name or password.") });
            }
        }
    }
}
