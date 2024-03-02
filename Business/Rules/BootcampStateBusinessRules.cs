using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules;

public class BootcampStateBusinessRules : BaseBusinessRules
{
    private readonly IBootcampStateRepository _repository;
    public BootcampStateBusinessRules(IBootcampStateRepository repository)
    {
        _repository = repository;
    }
    public async Task CheckIfBootcampStateNotExists(int id)
    {
        var isExists=await _repository.GetAllAsync(b=>b.Id==id);
        if (isExists is not null) throw new BusinessException("BoocampState is not exists");       
        
    }
}
