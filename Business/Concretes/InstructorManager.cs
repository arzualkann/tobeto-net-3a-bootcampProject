using AutoMapper;
using Azure;
using Business.Abstracts;
using Business.Requests.Instructors;
using Business.Responses.Employees;
using Business.Responses.Instructors;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;


namespace Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IMapper _mapper;

        public InstructorManager(IInstructorRepository instructorRepository, IMapper mapper)
        {
            _instructorRepository = instructorRepository;
            _mapper = mapper;
        }

        public IDataResult<CreateInstructorResponse> Add(CreateInstructorRequest request)
        {
            Instructor instructor = _mapper.Map<Instructor>(request);

            _instructorRepository.Add(instructor);

            CreateInstructorResponse response = _mapper.Map<CreateInstructorResponse>(request);

            return new SuccessDataResult<CreateInstructorResponse>(response, "Added Successfully.");
        }

        public IDataResult<DeleteInstructorResponse> Delete(DeleteInstructorRequest request)
        {
            Instructor deleteToInstructor = _instructorRepository.GetById(predicate: instructor => instructor.Id == request.Id);

            if (deleteToInstructor != null)
            {
                var deletedInstructor = _instructorRepository.Delete(deleteToInstructor);

                var response = new DeleteInstructorResponse { DeletedTime = deletedInstructor.DeletedDate, UserName = deletedInstructor.UserName, Id = deletedInstructor.Id };

                return new SuccessDataResult<DeleteInstructorResponse>(response, "Deleted Successfully.");
            }
            else
            {
                return new ErrorDataResult<DeleteInstructorResponse>("Instructor not found");
            }
        }

        public IDataResult<List<GetAllInstructorResponse>> GetAll()
        {
            List<Instructor> instructors = _instructorRepository.GetAll();

            var responses = _mapper.Map<List<GetAllInstructorResponse>>(instructors);

            return new SuccessDataResult<List<GetAllInstructorResponse>>(responses, "Listed Successfully.");
        }

        public IDataResult<GetInstructorByIdResponse> GetById(GetInstructorByIdRequest request)
        {
            Instructor instructor = _instructorRepository.GetById(predicate: instructor => instructor.Id == request.Id);

            if (instructor != null)
            {
                GetInstructorByIdResponse response = _mapper.Map<GetInstructorByIdResponse>(instructor);

                return new SuccessDataResult<GetInstructorByIdResponse>(response, "Showed Successfully.");
            }
            else
            {
                return new ErrorDataResult<GetInstructorByIdResponse>("Instructor not found");
            }
        }

        public IDataResult<UpdateInstructorResponse> Update(UpdateInstructorRequest request)
        {
            Instructor updateToInstructor = _instructorRepository.GetById(predicate: instructor => instructor.Id == request.Id);

            if (updateToInstructor != null)
            {
                _mapper.Map(request, updateToInstructor);

                _instructorRepository.Update(updateToInstructor);

                var response = _mapper.Map<UpdateInstructorResponse>(updateToInstructor);

                return new SuccessDataResult<UpdateInstructorResponse>(response, "Updated Successfully");
            }
            else
            {
                // Handle Instructor not found error
                return new ErrorDataResult<UpdateInstructorResponse>("Instructor not found");
            }
        }
    }
}
