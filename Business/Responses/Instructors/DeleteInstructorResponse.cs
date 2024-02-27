using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Instructors
{
    public class DeleteInstructorResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime DeletedTime { get; set; }
    }
}
