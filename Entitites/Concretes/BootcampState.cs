using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class BootcampState : BaseEntity<int>
    {
        
        public string Name { get; set; }
        public virtual Bootcamp Bootcamp { get; set; }
        public BootcampState(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public BootcampState()
        {

        }
    }
}
