using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mail;
using System.Security.Authentication;

namespace AuthService.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public bool FromRussia { get; set; }

        private readonly UserRepository _userRepository;
        private readonly MappingProfile _mapper;

        public UserViewModel(User user)
        {
            Id = user.Id;
            FullName = GetFullName(user.FirstName, user.LastName);
            FromRussia = GetFromRussiaValue(user.Email);
        }

        public string GetFullName(string firstName, string lastName)
        {
            return String.Concat(firstName, " ", lastName);
        }

        public bool GetFromRussiaValue(string email)
        {
            MailAddress mailAddress = new MailAddress(email);

            if (mailAddress.Host.Contains(".ru"))
                return true;
            return false;
        }

        [HttpPost]
        [Route("authenticate")]
        public UserViewModel Authenticate(string login, string password)
        {
            if (String.IsNullOrEmpty(login) ||
                String.IsNullOrEmpty(password))
                throw new ArgumentNullException("Запрос не корректен");

            User user = _userRepository.GetByLogin(login);
            if (user is null)
                throw new AuthenticationException("Пользователь на найден");

            if (user.Password != password)
                throw new AuthenticationException("Введенный пароль не корректен");

            return _mapper.CreateMap<UserViewModel>(user);

        }
    }
}
