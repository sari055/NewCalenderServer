﻿using Repository.Entities;
using CalendarApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Repositories.Interfaces
{
    public interface ISiteUserRepository
    {
        Task<List<SiteUser>> GetAllAsync();

        Task<SiteUser> GetByIdAsync(int id);

        Task<SiteUser> GetByEmailAndPassword(string email, string password);

        Task<SiteUser> AddAsync(string firstName, string lastName, string email, string password);

        Task<SiteUser> UpdateAsync(SiteUser user);
        

        Task DeleteAsync(int id);
        Task<SiteUser> FindByEmailAsync(string email);
    }
}

