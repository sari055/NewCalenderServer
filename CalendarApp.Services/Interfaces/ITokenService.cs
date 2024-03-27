using CalendarApp.Repositories.Entities;

namespace CalendarApp.Services.Interfaces
{
    public interface ITokenService
    {
        object GenerateToken(UserDTO user);
    }
}