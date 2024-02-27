using AutoMapper;
using Business.Abstracts;
using Business.Requests.Applications;
using Business.Responses.Applications;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class ApplicationManager : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request)
        {
            Application application = _mapper.Map<Application>(request);
            
            await _applicationRepository.AddAsync(application);

            CreateApplicationResponse response = _mapper.Map<CreateApplicationResponse>(application);
            
            return new SuccessDataResult<CreateApplicationResponse>(response, "Added Successfully");
        }

        public async Task<IDataResult<DeleteApplicationResponse>> DeleteAsync(DeleteApplicationRequest request)
        {
            var application = await _applicationRepository.GetByIdAsync(predicate: application => application.Id == request.Id);
            
            if (application == null)
            {
                return new ErrorDataResult<DeleteApplicationResponse>("Application not found");
            }

            await _applicationRepository.DeleteAsync(application);

            var response = _mapper.Map<DeleteApplicationResponse>(application);
            
            return new SuccessDataResult<DeleteApplicationResponse>(response, "Deleted Successfully");
        }

        public async Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync()
        {
            List<Application> applications = await _applicationRepository.GetAllAsync(include: x => x.Include(x => x.Bootcamp.Name).Include(x => x.Applicant.UserName));
            
            List<GetAllApplicationResponse> responses = _mapper.Map<List<GetAllApplicationResponse>>(applications);
            
            return new SuccessDataResult<List<GetAllApplicationResponse>>(responses, "Listed Successfully");
        }

        public async Task<IDataResult<GetByIdApplicationResponse>> GetByIdAsync(GetByIdApplicationRequest request)
        {
            var application = await _applicationRepository.GetByIdAsync(predicate: application => application.Id == request.Id);

            if (application == null)
            {
                return new ErrorDataResult<GetByIdApplicationResponse>("Application not found");
            }

            await _applicationRepository.DeleteAsync(application);

            var response = _mapper.Map<GetByIdApplicationResponse>(application);

            return new SuccessDataResult<GetByIdApplicationResponse>(response, "Showed Successfully");
        }

        public async Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request)
        {
            var application = await _applicationRepository.GetByIdAsync(predicate: application => application.Id == request.Id);

            if (application == null)
            {
                return new ErrorDataResult<UpdateApplicationResponse>("Application not found");
            }

            _mapper.Map(request, application); // Burada application nesnesinin verileri request nesnesindeki veriler ile güncelleniyor.

            // application = _mapper.Map<Application>(request); şeklinde yazsaydık request nesnesinin verileriyle Application
            // türünde yeni bir nesne oluşturulacaktı. Biz yeni nesne oluşturmak değil olanı güncellemek istiyoruz.

            await _applicationRepository.UpdateAsync(application);

            var response = _mapper.Map<UpdateApplicationResponse>(application);

            return new SuccessDataResult<UpdateApplicationResponse>(response, "Updated Successfully");
        }
    }
}
