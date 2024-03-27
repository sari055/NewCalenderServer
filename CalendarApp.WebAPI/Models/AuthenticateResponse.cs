using CalendarApp.Repositories.Entities;
using Repository.Entities;

namespace CalendarApp.WebAPI.Models
{
    public class AuthenticateResponse
    {
        public UserModel User { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(UserModel user, string token)
        {
            User = user;
            Token = token;
        }
    }
}
