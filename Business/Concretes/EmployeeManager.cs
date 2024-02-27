using AutoMapper;
using Azure;
using Business.Abstracts;
using Business.Requests.Employees;
using Business.Responses.Applicants;
using Business.Responses.Employees;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public IDataResult<AddEmployeeResponse> Add(AddEmployeeRequest request)
        {
            Employee employee = _mapper.Map<Employee>(request);

            _employeeRepository.Add(employee);

            AddEmployeeResponse response = _mapper.Map<AddEmployeeResponse>(employee);

            return new SuccessDataResult<AddEmployeeResponse>(response, "Added Successfully.");
        }

        public IDataResult<DeleteEmployeeResponse> Delete(DeleteEmployeeRequest request)
        {
            Employee deleteToEmployee = _employeeRepository.GetById(predicate: employee => employee.Id == request.Id);

            if (deleteToEmployee != null)
            {
                var deletedEmployee = _employeeRepository.Delete(deleteToEmployee);

                var response = _mapper.Map<DeleteEmployeeResponse>(deletedEmployee);

                return new SuccessDataResult<DeleteEmployeeResponse>(response, "Deleted Successfully.");
            }
            else
            {
                return new ErrorDataResult<DeleteEmployeeResponse>("Employee not found");
            }
        }

        public IDataResult<List<GetAllEmployeeResponse>> GetAll()
        {
            List<Employee> employees = _employeeRepository.GetAll();

            List<GetAllEmployeeResponse> responses = _mapper.Map<List<GetAllEmployeeResponse>>(employees);

            return new SuccessDataResult<List<GetAllEmployeeResponse>>(responses, "Listed Successfully.");
        }

        public IDataResult<GetEmployeeByIdResponse> GetById(GetEmployeeByIdRequest request)
        {
            Employee employee = _employeeRepository.GetById(predicate: employee => employee.Id == request.Id);

            if (employee != null)
            {
                GetEmployeeByIdResponse response = _mapper.Map<GetEmployeeByIdResponse>(employee);

                return new SuccessDataResult<GetEmployeeByIdResponse>(response,"Showed Successfully.");
            }
            else
            {
                return new ErrorDataResult<GetEmployeeByIdResponse>("Employee not found");
            }
        }

        public IDataResult<UpdateEmployeeResponse> Update(UpdateEmployeeRequest request)
        {
            Employee updateToEmployee = _employeeRepository.GetById(predicate: employee => employee.Id == request.Id);

            if (updateToEmployee != null)
            {
                _mapper.Map(request, updateToEmployee);

                _employeeRepository.Update(updateToEmployee);

                var response = _mapper.Map<UpdateEmployeeResponse>(updateToEmployee);

                return new SuccessDataResult<UpdateEmployeeResponse>(response, "Updated Successfully");
            }
            else
            {
                return new ErrorDataResult<UpdateEmployeeResponse>("Employee not found");
            }
        }
    }
}
