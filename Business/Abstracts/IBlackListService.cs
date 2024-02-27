
using Business.Requests.BlackList;

using Business.Responses.BlackList;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IBlackListService
{
    Task<IDataResult<CreateBlackListResponse>> AddAsync(CreateBlackListRequest request);
    Task<IDataResult<UpdateBlackListResponse>> UpdateAsync(UpdateBlackListRequest request);
    Task<IDataResult<DeleteBlackListResponse>> DeleteAsync(DeleteBlackListRequest request);
    Task<IDataResult<List<GetAllBlackListResponse>>> GetAllAsync();
    Task<IDataResult<GetByIdBlackListResponse>> GetByIdAsync(int id);
    
}
