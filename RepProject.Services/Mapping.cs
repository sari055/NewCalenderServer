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
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Permission, PermissionDTO>().ReverseMap();
            CreateMap<Claim, ClaimDTO>().ReverseMap();
        }
    }
}
