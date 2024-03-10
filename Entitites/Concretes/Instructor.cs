using Core.Utilities.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Instructor:User
    {
        public string CompanyName { get; set; }

        public virtual ICollection<Bootcamp> Bootcamps { get; set; }

        public Instructor(int id, string username, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string email, byte[] passwordHash, byte[] passwordSalt, string companyName) : this()
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
            CompanyName = companyName;
        }

        public Instructor()
        {
            Bootcamps = new HashSet<Bootcamp>();
        }
    }
}
