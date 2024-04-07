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
        private readonly ICalenderService _calender;
        private readonly ICalenderUserRepository _calenderUser;

        public SiteUserService(ISiteUserRepository siteUser, IUserService user, ICalenderService calender, ICalenderUserRepository calenderUser, IMapper mapper)
        {
            _siteUser = siteUser;
            _user = user;
            _calender = calender;
            _calenderUser = calenderUser;
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
            
            return _mapper.Map<SiteUserDTO>(await _siteUser.AddAsync(user.FirstName, user.LastName, user.Email,user.Password));
        }

        public async Task<SiteUserDTO> UpdateAsync(SiteUserDTO user)
        {
            return _mapper.Map<SiteUserDTO>(await _siteUser.UpdateAsync(_mapper.Map<SiteUser>(user)));
        }

        public async Task DeleteAsync(int id)
        {
            await _siteUser.DeleteAsync(id);
        }

        public async Task<SiteUserDTO> GetByEmailAndPassword(string email, string password)
        {
            return _mapper.Map<SiteUserDTO>(await _siteUser.GetByEmailAndPassword(email, password));
        }

        public async Task<SiteUserDTO> FindByEmailAsync(string email)
        {
            return _mapper.Map<SiteUserDTO>(await _siteUser.FindByEmailAsync(email));
        }

        public async Task<SiteUserDTO> Register(SiteUserDTO siteUser, UserDTO user, CalenderDTO calender)
        {
            var newSiteUser = await AddAsync(siteUser);

            user.SiteUserId = newSiteUser.Id;
            var newUser = await _user.AddAsync(user);

            calender.DirectorId = newUser.Id;
            var newCalendar = await _calender.AddAsync(calender);

            await _calenderUser.AddAsync(newUser.Id, newCalendar.Id, UserType.Admin);
            return newSiteUser;
        }
    }
}
