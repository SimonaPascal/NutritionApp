using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProiectPDMXamarin.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public byte[] ProfileImage { get; set; }


        public User()
        {

        }
    }
}
