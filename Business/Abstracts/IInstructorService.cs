using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IInstructorService
    {
        public IDataResult<CreateInstructorResponse> Add(CreateInstructorRequest request);
        public IDataResult<UpdateInstructorResponse> Update(UpdateInstructorRequest request);
        public IDataResult<DeleteInstructorResponse> Delete(DeleteInstructorRequest request);
        public IDataResult<List<GetAllInstructorResponse>> GetAll();
        public IDataResult<GetInstructorByIdResponse> GetById(GetInstructorByIdRequest request);
    }
}
