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
        public string RoleName { get; set; }
        

        public UserViewModel(User user)
        {
            Id = user.Id;
            FullName = GetFullName(user.FirstName, user.LastName);
            FromRussia = GetFromRussiaValue(user.Email);
            RoleName = GetRoleName(user.Role);
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

        public string GetRoleName(Role role)
        {
            return role.Name;
        }
    }
}
