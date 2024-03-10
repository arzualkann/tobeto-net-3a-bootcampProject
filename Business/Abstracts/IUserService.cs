using Core.Utilities.Results;
using Core.Utilities.Security.Entities;

namespace Business.Abstracts;

public interface IUserService
{
    Task<DataResult<User>> GetById(int id);
    Task<DataResult<User>> GetByMail(string email);

}
