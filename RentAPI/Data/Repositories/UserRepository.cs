using Microsoft.EntityFrameworkCore;
using RentAPI.Interfaces;
using RentAPI.Models;

namespace RentAPI.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<AppUser> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }
}