using AutoMapper;
using Business.Abstracts;
using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class ApplicationStateManager : IApplicationStateService
    {
        private readonly IApplicationStateRepository _applicationStateRepository;
        private readonly IMapper _mapper;

        public ApplicationStateManager(IApplicationStateRepository applicationstateRepository, IMapper mapper)
        {
            _applicationStateRepository = applicationstateRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request)
        {
            ApplicationState applicationState = _mapper.Map<ApplicationState>(request);

            await _applicationStateRepository.AddAsync(applicationState);

            CreateApplicationStateResponse response = _mapper.Map<CreateApplicationStateResponse>(applicationState);

            return new SuccessDataResult<CreateApplicationStateResponse>(response, "Added Successfully");
        }

        public async Task<IDataResult<DeleteApplicationStateResponse>> DeleteAsync(DeleteApplicationStateRequest request)
        {
            var applicationState = await _applicationStateRepository.GetByIdAsync(predicate: applicationState => applicationState.Id == request.Id);

            if (applicationState == null)
            {
                return new ErrorDataResult<DeleteApplicationStateResponse>("ApplicationState not found");
            }

            await _applicationStateRepository.DeleteAsync(applicationState);

            var response = _mapper.Map<DeleteApplicationStateResponse>(applicationState);

            return new SuccessDataResult<DeleteApplicationStateResponse>(response, "Deleted Successfully");
        }


        public async Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAllAsync()
        {
            List<ApplicationState> applicationStates = await _applicationStateRepository.GetAllAsync(include: x => x.Include(x => x.Application).Include(x => x.Application.Bootcamp));
            
            List<GetAllApplicationStateResponse> responses = _mapper.Map<List<GetAllApplicationStateResponse>>(applicationStates);
            
            return new SuccessDataResult<List<GetAllApplicationStateResponse>>(responses, "Listed Successfully");
        }

        public async Task<IDataResult<GetByIdApplicationStateResponse>> GetByIdAsync(GetByIdApplicationStateRequest request)
        {
            var applicationState = await _applicationStateRepository.GetByIdAsync(predicate: applicationState => applicationState.Id == request.Id);

            if (applicationState == null)
            {
                return new ErrorDataResult<GetByIdApplicationStateResponse>("ApplicationState not found");
            }

            await _applicationStateRepository.DeleteAsync(applicationState);

            var response = _mapper.Map<GetByIdApplicationStateResponse>(applicationState);

            return new SuccessDataResult<GetByIdApplicationStateResponse>(response, "Showed Successfully");
        }

        public async Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request)
        {
            var applicationState = await _applicationStateRepository.GetByIdAsync(predicate: applicationState => applicationState.Id == request.Id);

            if (applicationState == null)
            {
                return new ErrorDataResult<UpdateApplicationStateResponse>("ApplicationState not found");
            }

            _mapper.Map(request, applicationState);

            await _applicationStateRepository.UpdateAsync(applicationState);

            var response = _mapper.Map<UpdateApplicationStateResponse>(applicationState);

            return new SuccessDataResult<UpdateApplicationStateResponse>(response, "Updated Successfully");
        }
    }
}
