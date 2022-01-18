using System.Collections.Generic;

namespace AuthService.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetByLogin(string login);

    }
}
