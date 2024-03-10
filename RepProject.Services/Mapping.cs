using AutoMapper;
using Repository.Entities;
using Repproject.Repositories.Entities;
using RepProject.Common.DTOs;
using System;

namespace RepProject.Services
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<YearEvent, YearEventDTO>().ReverseMap();   
            CreateMap<UserType, UserTypeDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Level, LevelDTO>().ReverseMap();
            CreateMap<Event, EventDTO>().ReverseMap();
            CreateMap<Calender, CalenderDTO>().ReverseMap();
            CreateMap<CalenderUser, CalenderUserDTO>().ReverseMap();
            CreateMap<CalenderYear, CalenderYearDTO>().ReverseMap();
        }
    }
}
