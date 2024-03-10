using Business.Constans;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules;

public class ApplicationStateBusinessRules : BaseBusinessRules
{
    private readonly IApplicationStateRepository _applicationStateRepository;

    public ApplicationStateBusinessRules(IApplicationStateRepository applicationStateRepository)
    {
        _applicationStateRepository = applicationStateRepository;
    }


    public async Task CheckIfApplicationStateExists(ApplicationState? applicationState)
    {
        if (applicationState is null) throw new NotFoundException(ApplicationStateMessages.ApplicationStateCheck);
    }
}
