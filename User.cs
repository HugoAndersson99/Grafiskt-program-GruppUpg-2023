using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSFashion
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }

        public User(string userName, string password, string firstName, string lastName, string email, string street, string zip, string city)
        {
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Street = street;
            City = city;
            Zip = zip;
        }

        public string GetCSV()
        {
            return UserName + ";" + Password + ";" + FirstName + ";" + LastName + ";" + Email + ";" + Street + ";" + Zip + ";" + City ;
        }
    }
}
