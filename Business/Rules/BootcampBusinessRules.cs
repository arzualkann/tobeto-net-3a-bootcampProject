using Business.Constans;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules;

public class BootcampBusinessRules:BaseBusinessRules
{
    private readonly IBootcampRepository _bootcampRepository;
    public BootcampBusinessRules(IBootcampRepository bootcampRepository)
    {
        _bootcampRepository = bootcampRepository;
    }
    public async Task CheckİfBootcampNameNotExist(string bootcampName)
    {
        var isExists = await _bootcampRepository.GetAllAsync(bootcamp=>bootcamp.Name==bootcampName);
        if (isExists is not null) throw new BusinessException(BootcampMessages.BootcampNameCheck);      

    }
}
