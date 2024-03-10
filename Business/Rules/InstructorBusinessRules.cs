using Business.Constans;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules;

public class InstructorBusinessRules:BaseBusinessRules
{
    private readonly IInstructorRepository _instructorRepository;

    public InstructorBusinessRules(IInstructorRepository instructorRepository)
    {
        _instructorRepository = instructorRepository;
    }

    public void CheckIfInstructorExists(Instructor? instructor)
    {
        if (instructor is null) throw new NotFoundException(InstructorMessages.InstructorCheck);
    }

    public async Task CheckIfEmailRegistered(string? email)
    {
        var instructor = _instructorRepository.GetById(predicate: instructor => instructor.Email == email);

        if (instructor is not null) throw new BusinessException(InstructorMessages.EmailCheck); ;
    }
}
