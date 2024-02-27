using AutoMapper;
using Business.Abstracts;
using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class BootcampManager : IBootcampService
    {
        private readonly IBootcampRepository _bootcampRepository;
        private readonly IMapper _mapper;

        public BootcampManager(IBootcampRepository bootcampRepository, IMapper mapper)
        {
            _bootcampRepository = bootcampRepository;
            _mapper = mapper;
        }


        public async Task<IDataResult<CreateBootcampResponse>> AddAsync(CreateBootcampRequest request)
        {
            Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
            await _bootcampRepository.AddAsync(bootcamp);

            CreateBootcampResponse response = _mapper.Map<CreateBootcampResponse>(bootcamp);

            return new SuccessDataResult<CreateBootcampResponse>(response, "Added Successfully");
        }

        public async Task<IDataResult<DeleteBootcampResponse>> DeleteAsync(DeleteBootcampRequest request)
        {
            var bootcamp = await _bootcampRepository.GetByIdAsync(predicate: bootcamp => bootcamp.Id == request.Id);

            if (bootcamp == null)
            {
                return new ErrorDataResult<DeleteBootcampResponse>("Bootcamp not found");
            }

            await _bootcampRepository.DeleteAsync(bootcamp);

            var response = _mapper.Map<DeleteBootcampResponse>(bootcamp);

            return new SuccessDataResult<DeleteBootcampResponse>(response, "Deleted Successfully");
        }

        public async Task<IDataResult<List<GetAllBootcampResponse>>> GetAllAsync()
        {
            List<Bootcamp> bootcamps = await _bootcampRepository.GetAllAsync(include: x => x.Include(x => x.Instructor.UserName).Include(x => x.BootcampState.Name));

            List<GetAllBootcampResponse> responses = _mapper.Map<List<GetAllBootcampResponse>>(bootcamps);

            return new SuccessDataResult<List<GetAllBootcampResponse>>(responses, "Listed Successfully");
        }

        public async Task<IDataResult<GetByIdBootcampResponse>> GetByIdAsync(GetByIdBootcampRequest request)
        {
            var bootcamp = await _bootcampRepository.GetByIdAsync(predicate: bootcamp => bootcamp.Id == request.Id);

            if (bootcamp == null)
            {
                return new ErrorDataResult<GetByIdBootcampResponse>("Bootcamp not found");
            }

            await _bootcampRepository.DeleteAsync(bootcamp);

            var response = _mapper.Map<GetByIdBootcampResponse>(bootcamp);

            return new SuccessDataResult<GetByIdBootcampResponse>(response, "Showed Successfully");
        }

        public async Task<IDataResult<UpdateBootcampResponse>> UpdateAsync(UpdateBootcampRequest request)
        {
            var bootcamp = await _bootcampRepository.GetByIdAsync(predicate: bootcamp => bootcamp.Id == request.Id);

            if (bootcamp == null)
            {
                return new ErrorDataResult<UpdateBootcampResponse>("Bootcamp not found");
            }

            _mapper.Map(request, bootcamp);

            await _bootcampRepository.UpdateAsync(bootcamp);

            var response = _mapper.Map<UpdateBootcampResponse>(bootcamp);

            return new SuccessDataResult<UpdateBootcampResponse>(response, "Updated Successfully");
        }

    }
}
