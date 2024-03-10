using Core.Utilities.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Applicant : User
    {
        public string About { get; set; }

        public virtual ICollection<Application>? Applications { get; set; }
        public virtual BlackList? BlackList { get; set; }

       
        public Applicant()
        {
            Applications = new HashSet<Application>();
        }

        public Applicant(int id, string username, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string email, byte[] passwordHash, byte[] passwordSalt, string about) : this()
        {
            Id = id;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            NationalIdentity = nationalIdentity;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            About = about;
        }
    }
}