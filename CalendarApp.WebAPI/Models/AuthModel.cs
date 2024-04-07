using CalendarApp.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Repositories.Entities
{
    public class AuthModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int Tz {  get; set; }
        public string FirstName {  get; set; }
        public string LastName { get ; set; }
        public string PhoneNumbar { get; set; }
        public DateTime BornDate { get; set; }
        public string GroupName { get; set; }

        private UserDTO _user;
        private SiteUserDTO _siteUser;
        private CalenderDTO _calender;

        public UserDTO User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserDTO(Tz, FirstName, LastName, BornDate, PhoneNumbar, Email);
                }
                return _user;
            }
        }

        public SiteUserDTO SiteUser
        {
            get
            {
                if (_siteUser == null)
                {
                    _siteUser = new SiteUserDTO(FirstName, LastName, Email, Password);
                }
                return _siteUser;
            }
        }

        public CalenderDTO Calender
        {
            get
            {
                if (_calender == null)
                {
                    _calender = new CalenderDTO();
                    _calender.GroupName = GroupName;
                }
                return _calender;
            }
        }
    }
}
