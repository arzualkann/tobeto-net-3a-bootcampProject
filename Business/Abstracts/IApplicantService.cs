using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IApplicantService
    {
        public IDataResult<AddApplicantResponse> Add(AddApplicantRequest request);
        public IDataResult<UpdateApplicantResponse> Update(UpdateApplicantRequest request);
        public IDataResult<DeleteApplicantResponse> Delete(DeleteApplicantRequest request);
        public IDataResult<List<GetAllApplicantResponse>> GetAll();
        public IDataResult<GetApplicantByIdResponse> GetById(GetApplicantByIdRequest request);
    }
}
