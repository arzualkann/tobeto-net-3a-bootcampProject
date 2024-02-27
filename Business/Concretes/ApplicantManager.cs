using AutoMapper;
using Azure;
using Business.Abstracts;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class ApplicantManager : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IMapper _mapper;

        public ApplicantManager(IApplicantRepository applicantRepository, IMapper mapper)
        {
            _applicantRepository = applicantRepository;
            _mapper = mapper;
        }

        public IDataResult<AddApplicantResponse> Add(AddApplicantRequest request)
        {
            Applicant applicant = _mapper.Map<Applicant>(request);

            _applicantRepository.Add(applicant);

            AddApplicantResponse response = _mapper.Map<AddApplicantResponse>(applicant);

            return new SuccessDataResult<AddApplicantResponse>(response, "Added Successfully");
        }

        public IDataResult<DeleteApplicantResponse> Delete(DeleteApplicantRequest request)
        {
            Applicant deleteToApplicant = _applicantRepository.GetById(predicate: applicant => applicant.Id == request.Id);

            if (deleteToApplicant != null)
            {
                var deletedApplicant = _applicantRepository.Delete(deleteToApplicant);

                var response = _mapper.Map<DeleteApplicantResponse>(deletedApplicant);

                return new SuccessDataResult<DeleteApplicantResponse>(response, "Deleted Successfully");
            }
            else
            {
                return new ErrorDataResult<DeleteApplicantResponse>("Applicant not found");
            }

        }

        public IDataResult<List<GetAllApplicantResponse>> GetAll()
        {
            List<Applicant> applicants = _applicantRepository.GetAll();

            List<GetAllApplicantResponse> responses = _mapper.Map<List<GetAllApplicantResponse>>(applicants);

            return new SuccessDataResult<List<GetAllApplicantResponse>>(responses, "Listed Successfully");
        }

        public IDataResult<GetApplicantByIdResponse> GetById(GetApplicantByIdRequest request)
        {
            Applicant applicant = _applicantRepository.GetById(predicate: applicant => applicant.Id == request.Id);

            if (applicant != null)
            {
                GetApplicantByIdResponse response = _mapper.Map<GetApplicantByIdResponse>(applicant);

                return new SuccessDataResult<GetApplicantByIdResponse>(response, "Showed Successfully");
            }
            else
            {
                return new ErrorDataResult<GetApplicantByIdResponse>("Applicant not found");
            }
        }

        public IDataResult<UpdateApplicantResponse> Update(UpdateApplicantRequest request)
        {
            Applicant updateToApplicant = _applicantRepository.GetById(predicate: applicant => applicant.Id == request.Id);

            if (updateToApplicant != null)
            {
                _mapper.Map(request, updateToApplicant);

                _applicantRepository.Update(updateToApplicant);

                var response = _mapper.Map<UpdateApplicantResponse>(updateToApplicant);

                return new SuccessDataResult<UpdateApplicantResponse>(response, "Updated Successfully");
            }
            else
            {
                return new ErrorDataResult<UpdateApplicantResponse>("Applicant not found");
            }
        }
    }
}
