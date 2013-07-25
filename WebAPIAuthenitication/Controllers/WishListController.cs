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
            return new List<string>() { "Atomos Ninja 2 Video Recorder", 
                                        "Funko Creature from the Black Lagoon Funko Force", 
                                        "Teva Men's Dozer III Closed Toe Sandal",
                                        "ThinkGeek: Star Trek Command Tee",
                                        "ASUS Professional Graphics Monitor" };
        }
    }
}
