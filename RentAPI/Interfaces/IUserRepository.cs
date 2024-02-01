using RentAPI.Models;

namespace RentAPI.Interfaces;

public interface IUserRepository
{
    Task<AppUser> GetUserByIdAsync(int id);
}