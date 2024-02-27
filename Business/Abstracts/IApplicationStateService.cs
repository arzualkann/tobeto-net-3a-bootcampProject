using Business.Requests.Applications;
using Business.Requests.ApplicationStates;
using Business.Responses.Applications;
using Business.Responses.ApplicationStates;
using Core.Utilities.Results;


namespace Business.Abstracts
{
    public interface IApplicationStateService
    {
        Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request);
        Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request);
        Task<IDataResult<DeleteApplicationStateResponse>> DeleteAsync(DeleteApplicationStateRequest request);
        Task<IDataResult<GetByIdApplicationStateResponse>> GetByIdAsync(GetByIdApplicationStateRequest request);
        Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAllAsync();
    }
}
