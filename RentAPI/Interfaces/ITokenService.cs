using RentAPI.Models;

namespace RentAPI.Interfaces;

public interface ITokenService
{
    Task<string> CreateToken(AppUser user);
}