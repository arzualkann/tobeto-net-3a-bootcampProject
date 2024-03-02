using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;

namespace Business.Rules;

public class ApplicantBusinessRules:BaseBusinessRules
{
    private readonly IApplicantRepository _applicantRepository;

    public ApplicantBusinessRules(IApplicantRepository applicantRepository)
    {
        _applicantRepository = applicantRepository;
    }

    public void CheckIfApplicantExists(Applicant? applicant)
    {
        if (applicant is null) throw new NotFoundException("Applicant not found.");
    }

    public async Task CheckIfEmailRegistered(string? email)
    {
        var applicant = await _applicantRepository.GetByIdAsync(predicate: applicant => applicant.Email == email);

        if (applicant is not null) throw new BusinessException("There is already a user with this email."); ;
    }
}
