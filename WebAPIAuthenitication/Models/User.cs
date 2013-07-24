using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPIAuthenitication.Models
{
    public class User
    {
        /// <summary>
        /// Initializes a new instance of the User class.
        /// </summary>
        public User(string userId, string password)
        {
            UserId = userId;
            Password = password;
        }

        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
