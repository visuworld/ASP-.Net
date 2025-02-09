using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JeecUp.Models
{
    public class RegisterModel
    {
        public string name { get; set;}
        public string fathername { get; set;}

        public string mothername { get; set;}

        public string dob {  get; set;}

        public string gender { get; set; }

        public string mobile { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string confirmpassword { get; set; }

        public string msg { get; set; }  
    }
}