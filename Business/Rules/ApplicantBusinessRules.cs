using Business.Constans;
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
        if (applicant is null) throw new NotFoundException(ApplicantMessages.ApplicantNotFound);
    }

    public void CheckIfEmailExists(string? email)
    {
        var applicant =  _applicantRepository.GetById(predicate: applicant => applicant.Email == email);
        if (applicant == null) throw new BusinessException(ApplicantMessages.EmailCheck);
    }
}
