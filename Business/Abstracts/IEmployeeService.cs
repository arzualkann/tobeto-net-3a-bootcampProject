using Business.Requests.Applicants;
using Business.Requests.ApplicationStates;
using Business.Requests.Employees;
using Business.Responses.Applicants;
using Business.Responses.ApplicationStates;
using Business.Responses.Employees;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IEmployeeService
    {
        public IDataResult<AddEmployeeResponse> Add(AddEmployeeRequest request);
        public IDataResult<UpdateEmployeeResponse> Update(UpdateEmployeeRequest request);
        public IDataResult<DeleteEmployeeResponse> Delete(DeleteEmployeeRequest request);
        public IDataResult<List<GetAllEmployeeResponse>> GetAll();
        public IDataResult<GetEmployeeByIdResponse> GetById(GetEmployeeByIdRequest request);
    }
}
