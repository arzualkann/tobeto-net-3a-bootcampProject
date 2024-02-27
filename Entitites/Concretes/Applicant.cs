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

    }
}
