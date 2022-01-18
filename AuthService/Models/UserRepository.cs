using System.Collections.Generic;
using System.Linq;

namespace AuthService.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;

        IEnumerable<User> IUserRepository.GetAll()
        {
            return _userContext.Users.ToList();
        }

        User IUserRepository.GetByLogin(string login)
        {
            return _userContext.Users.FirstOrDefault(x => x.Login == login);
             
        }
    }
}
