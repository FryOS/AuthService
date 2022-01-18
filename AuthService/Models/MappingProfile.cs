using AutoMapper;
using System;

namespace AuthService.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>()
                .ConstructUsing(v => new UserViewModel(v));
        }

        internal T CreateMap<T>(User user)
        {
            throw new NotImplementedException();
        }
    }
}
