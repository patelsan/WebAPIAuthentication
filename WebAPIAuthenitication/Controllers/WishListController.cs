using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPIAuthenitication.Controllers
{
    public class WishListController : ApiController
    {
        public IList<string> Get()
        {
            return new List<string>() { "FitBit" };
        }
    }
}
