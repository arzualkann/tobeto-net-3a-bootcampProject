using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.BlackList;

public class DeleteBlackListResponse
{
    public string Reason { get; set; }
    public DateTime Date { get; set; }
    public int Applicant_id { get; set; }
    public DateTime DeletedTime { get; set; }

}
