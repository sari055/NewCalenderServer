using AutoMapper;
using Repproject.Repositories.Entities;
using RepProject.Common.DTOs;
using System;

namespace RepProject.Services
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Child, ChildDTO>().ReverseMap();
            CreateMap<Parent, ParentDTO>().ReverseMap();
        }
    }
}
