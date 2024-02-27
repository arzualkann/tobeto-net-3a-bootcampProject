using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class ApplicationState : BaseEntity<int>
    {
        //id,name
        public string Name { get; set; }
        public virtual Application? Application { get; set; }
    }
}
