using AutoMapper;
using Business.Requests.BlackList;
using Business.Responses.Applicants;
using Business.Responses.BlackList;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.BlackLists
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<BlackList, CreateBlackListRequest>().ReverseMap();
            CreateMap<BlackList, DeleteBlackListRequest>().ReverseMap();
            CreateMap<BlackList, UpdateBlackListRequest>().ReverseMap();

            CreateMap<BlackList, CreateBlackListResponse>().ReverseMap();
            CreateMap<BlackList, UpdateBlackListResponse>().ReverseMap();
            CreateMap<BlackList, GetAllBlackListResponse>().ReverseMap();
            CreateMap<BlackList, GetByIdBlackListResponse>().ReverseMap();
            CreateMap<BlackList, GetApplicantByIdResponse>().ReverseMap();
        }
    }
}
