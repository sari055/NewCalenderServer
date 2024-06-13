using AutoMapper;
using Repository.Entities;
using CalendarApp.Repositories.Entities;
using CalendarApp.Repositories.Interfaces;
using CalendarApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using CalendarApp.Common.DTOs;


namespace CalendarApp.Services.Services
{
    public class SiteUserService : ISiteUserService
    {
        private readonly ISiteUserRepository _siteUser;
        private readonly IMapper _mapper;
        private readonly IUserService _user;
        private readonly ICalendarService _calendar;
        private readonly ICalendarUserRepository _calendarUser;

        public SiteUserService(ISiteUserRepository siteUser, IUserService user, ICalendarService calendar, ICalendarUserRepository calendarUser, IMapper mapper)
        {
            _siteUser = siteUser;
            _user = user;
            _calendar = calendar;
            _calendarUser = calendarUser;
            _mapper = mapper;
        }

        public async Task<SiteUserDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<SiteUserDTO>(await _siteUser.GetByIdAsync(id));
        }

        public async Task<SiteUserDTO> GetOrderIdAsync(int id)
        {
            return _mapper.Map<SiteUserDTO>(await _siteUser.GetByIdAsync(id));
        }
        public async Task<IEnumerable<SiteUserDTO>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<SiteUserDTO>>(await _siteUser.GetAllAsync());
        }

        public async Task<SiteUserDTO> AddAsync(SiteUserDTO user)
        {

            return _mapper.Map<SiteUserDTO>(await _siteUser.AddAsync(user.FirstName, user.LastName, user.Tz, user.Password));
        }

        public async Task<SiteUserDTO> UpdateAsync(SiteUserDTO user)
        {
            return _mapper.Map<SiteUserDTO>(await _siteUser.UpdateAsync(_mapper.Map<SiteUser>(user)));
        }

        public async Task DeleteAsync(int id)
        {
            await _siteUser.DeleteAsync(id);
        }

        public async Task<SiteUserDTO> GetByTzAndPassword(int tz, string password)
        {
            return _mapper.Map<SiteUserDTO>(await _siteUser.GetByTzAndPassword(tz, password));
        }

        public async Task<SiteUserDTO> FindByTzAsync(int tz)
        {
            return _mapper.Map<SiteUserDTO>(await _siteUser.FindByTzAsync(tz));
        }




        public async Task<SiteUserDTO> Register(SiteUserDTO siteUser, UserDTO user, CalendarDTO calendar)
        {

            SiteUserDTO existUser = await FindByTzAsync(siteUser.Tz);
            if (existUser == null)
            {
                existUser = await AddAsync(siteUser);
            }
            user.SiteUserId = existUser.Id;
            var newUser = await _user.AddAsync(user);



            calendar.DirectorId = newUser.Id;
            var newCalendar = await _calendar.AddAsync(calendar);

            await _calendarUser.AddAsync(newUser.Id, newCalendar.Id, UserType.Admin);
            return existUser;
        }
    }
}
