using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace loginentityF.Models
{
    public class user
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string designation { get; set; }
    }
}