using AuthService.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private ILogger _logger;    
        private IMapper _mapper;    

        public UserController( ILogger logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;

            logger.WriteEvent("Сообщение о событии в программе");
            logger.WriteError("Сообщение об ошибки в программе");
        }

        [HttpGet]

        public User GetUser()
        {
            return new User { 
                Id = Guid.NewGuid(), 
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "ivan@mail.com",
                Password = "Ivan123",
                Login = "ivanov"
            };
        }

        [HttpGet]
        [Route("viewmodel")]
        public UserViewModel GetUserViewModel()
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Иван",
                LastName = "Иванов",
                Email = "ivan@gmail.com",
                Password = "11111122222qq",
                Login = "ivanov"
            };

            var userViewModel = _mapper.Map<UserViewModel>(user);
            
            //UserViewModel userViewModel = new UserViewModel(user); замена на строке выше

            return userViewModel;
        }
    }
}
