using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPIAuthenitication.Models
{
    public class Status
    {
        public bool Successeded { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}
