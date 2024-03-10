﻿using Business.Abstracts;
using Core.Utilities.Results;
using Core.Utilities.Security.Entities;
using DataAccess.Abstracts;

namespace Business.Concretes;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<DataResult<User>> GetById(int id)
    {
        return new SuccessDataResult<User>(await _userRepository.GetByIdAsync(x => x.Id == id));
    }

    public async Task<DataResult<User>> GetByMail(string email)
    {
        return new SuccessDataResult<User>(await _userRepository.GetByIdAsync(x => x.Email == email));
    }
}
