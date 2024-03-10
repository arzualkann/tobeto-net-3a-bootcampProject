using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Employee : User
    {
        public string Position { get; set; }

        public Employee(int id, string userName, string firstName, string lastName, DateTime dateOfBirth,
            string nationalIdentity, string email, string password, string position)
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            NationalIdentity = nationalIdentity;
            Email = email;
            Password = password;
            Position = position;
        }

        public Employee()
        {

        }
    }
}