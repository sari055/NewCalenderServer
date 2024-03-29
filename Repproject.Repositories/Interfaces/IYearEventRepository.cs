﻿using Repository.Entities;
using Repproject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repproject.Repositories.Interfaces
{
    public interface IYearEventRepository
    {
        Task<List<YearEvent>> GetAllAsync();

        Task<YearEvent> GetByIdAsync(int id);
    
        Task<YearEvent> AddAsync(int eventId,int calenderId,DateTime gregorianDate);

       // Task<int> GetByDetailsAsync(string name, string adress);
        Task<YearEvent> UpdateAsync(YearEvent yearEvent);

        Task DeleteAsync(int id);
    }
}

