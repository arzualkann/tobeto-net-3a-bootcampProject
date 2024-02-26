using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.BlackList;

public class UpdateBlackListRequest
{
    public int Id { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
    public int Applicant_id { get; set; }
}
