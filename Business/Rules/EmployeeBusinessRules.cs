using Business.Constans;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules
{
    public class EmployeeBusinessRules : BaseBusinessRules
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeBusinessRules(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void CheckIfEmployeeExists(Employee? employee)
        {
            if (employee is null) throw new NotFoundException(EmployeeMessages.EmployeeNotExists);
        }

        public async Task CheckIfEmailRegistered(string? email)
        {
            var employee = _employeeRepository.GetById(predicate: employee => employee.Email == email);

            if (employee is not null) throw new BusinessException(EmployeeMessages.EmailCheck); ;
        }

    }
}