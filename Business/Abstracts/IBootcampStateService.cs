﻿using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;
using Core.Utilities.Results;


namespace Business.Abstracts
{
    public interface IBootcampStateService
    {
        Task<IDataResult<CreateBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request);
        Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request);
        Task<IDataResult<DeleteBootcampStateResponse>> DeleteAsync(DeleteBootcampStateRequest request);
        Task<IDataResult<GetByIdBootcampStateResponse>> GetByIdAsync(GetByIdBootcampStateRequest request);
        Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAllAsync();
    }
}
