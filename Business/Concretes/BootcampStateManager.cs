using AutoMapper;
using Business.Abstracts;
using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class BootcampStateManager : IBootcampStateService
    {
        private readonly IBootcampStateRepository _bootcampStateRepository;
        private readonly IMapper _mapper;

        public BootcampStateManager(IBootcampStateRepository bootcampStateRepository, IMapper mapper)
        {
            _bootcampStateRepository = bootcampStateRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<CreateBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request)
        {
            BootcampState bootcampState = _mapper.Map<BootcampState>(request);

            await _bootcampStateRepository.AddAsync(bootcampState);

            CreateBootcampStateResponse response = _mapper.Map<CreateBootcampStateResponse>(bootcampState);

            return new SuccessDataResult<CreateBootcampStateResponse>(response, "Added Successfully");
        }

        public async Task<IDataResult<DeleteBootcampStateResponse>> DeleteAsync(DeleteBootcampStateRequest request)
        {
            var bootcampState = await _bootcampStateRepository.GetByIdAsync(predicate: bootcampState => bootcampState.Id == request.Id);

            if (bootcampState == null)
            {
                return new ErrorDataResult<DeleteBootcampStateResponse>("BootcampState not found");
            }

            await _bootcampStateRepository.DeleteAsync(bootcampState);

            var response = _mapper.Map<DeleteBootcampStateResponse>(bootcampState);

            return new SuccessDataResult<DeleteBootcampStateResponse>(response, "Deleted Successfully");
        }

        public async Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAllAsync()
        {
            List<BootcampState> bootcampStates = await _bootcampStateRepository.GetAllAsync(include: x => x.Include(x => x.Bootcamp.Instructor).Include(x => x.Bootcamp));

            List<GetAllBootcampStateResponse> responses = _mapper.Map<List<GetAllBootcampStateResponse>>(bootcampStates);

            return new SuccessDataResult<List<GetAllBootcampStateResponse>>(responses, "Listed Successfully");
        }

        public async Task<IDataResult<GetByIdBootcampStateResponse>> GetByIdAsync(GetByIdBootcampStateRequest request)
        {
            var bootcampState = await _bootcampStateRepository.GetByIdAsync(predicate: bootcampState => bootcampState.Id == request.Id);

            if (bootcampState == null)
            {
                return new ErrorDataResult<GetByIdBootcampStateResponse>("BootcampState not found");
            }

            await _bootcampStateRepository.DeleteAsync(bootcampState);

            var response = _mapper.Map<GetByIdBootcampStateResponse>(bootcampState);

            return new SuccessDataResult<GetByIdBootcampStateResponse>(response, "Showed Successfully");
        }

        public async Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request)
        {
            var bootcampState = await _bootcampStateRepository.GetByIdAsync(predicate: bootcampState => bootcampState.Id == request.Id);

            if (bootcampState == null)
            {
                return new ErrorDataResult<UpdateBootcampStateResponse>("BootcampState not found");
            }

            _mapper.Map(request, bootcampState);

            await _bootcampStateRepository.UpdateAsync(bootcampState);

            var response = _mapper.Map<UpdateBootcampStateResponse>(bootcampState);

            return new SuccessDataResult<UpdateBootcampStateResponse>(response, "Updated Successfully");
        }

    }
}
