using Core.Models.Identities;

namespace Core.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
