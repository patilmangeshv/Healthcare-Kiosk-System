using server_api.Entities;

namespace server_api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}