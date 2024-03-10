using Business.Constans;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules;

public class ApplicationBusinessRules:BaseBusinessRules
{
    private readonly IApplicationRepository _applicationRepository;
    public ApplicationBusinessRules(IApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }
    public async Task CheckIfApplicationExists(Application? application)
    {
        if (application is not null) throw new NotFoundException(ApplicationMessages.AlreadyExists);
    }

    public async Task CheckIfApplicationMaked(int? applicantId, int? bootcampId)
    {
        var application = await _applicationRepository
            .GetByIdAsync(predicate: application => application.ApplicantId == applicantId && application.BootcampId == bootcampId);

        if (application is not null) throw new BusinessException(ApplicationMessages.ApplicationMaked); 
    }
}
