using AutoMapper;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduler
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<UserDto, User>();
                //.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));
                //.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
        }
    }
}
