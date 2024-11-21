using API.DataEntities;

namespace API.services;

public interface ITokenService
{
    string CreateToken(AppUser user);
}