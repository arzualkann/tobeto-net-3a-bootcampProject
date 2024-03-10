using AutoMapper;
using Business.Responses.Users;
using Core.Utilities.Security.Entities;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Users
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, GetAllUserResponse>().ReverseMap();
            CreateMap<User, GetByIdUserResponse>().ReverseMap();
        }
    }
}
