using AutoMapper;
using Business.Abstracts;
using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using Business.Rules;
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
        private readonly ApplicationStateBusinessRules _applicationStateBusinessRules;

        public ApplicationStateManager(IApplicationStateRepository applicationstateRepository, IMapper mapper, ApplicationStateBusinessRules applicationStateBusinessRules)
        {
            _applicationStateRepository = applicationstateRepository;
            _mapper = mapper;
            _applicationStateBusinessRules = applicationStateBusinessRules;
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

            await _applicationStateBusinessRules.CheckIfApplicationStateExists(applicationState);

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

            await _applicationStateBusinessRules.CheckIfApplicationStateExists(applicationState);

            var response = _mapper.Map<GetByIdApplicationStateResponse>(applicationState);

            return new SuccessDataResult<GetByIdApplicationStateResponse>(response, "Showed Successfully");
        }

        public async Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request)
        {
            var applicationState = await _applicationStateRepository.GetByIdAsync(predicate: applicationState => applicationState.Id == request.Id);

            await _applicationStateBusinessRules.CheckIfApplicationStateExists(applicationState);

            _mapper.Map(request, applicationState);

            await _applicationStateRepository.UpdateAsync(applicationState);

            var response = _mapper.Map<UpdateApplicationStateResponse>(applicationState);

            return new SuccessDataResult<UpdateApplicationStateResponse>(response, "Updated Successfully");
        }
    }
}
