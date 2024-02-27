using Business.Requests.Applications;
using Business.Responses.Applications;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IApplicationService
    {
        Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request);
        Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request);
        Task<IDataResult<DeleteApplicationResponse>> DeleteAsync(DeleteApplicationRequest request);
        Task<IDataResult<GetByIdApplicationResponse>> GetByIdAsync(GetByIdApplicationRequest request);
        Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync();
    }
}
