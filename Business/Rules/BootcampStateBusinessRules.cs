using Business.Constans;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules;

public class BootcampStateBusinessRules : BaseBusinessRules
{
    private readonly IBootcampStateRepository _repository;
    public BootcampStateBusinessRules(IBootcampStateRepository repository)
    {
        _repository = repository;
    }
    public async Task CheckIfBootcampStateExists(BootcampState? bootcampState)
    {
        if (bootcampState is null) throw new NotFoundException(BootcampStateMessages.BootcampStateNotFound);
    }
}
