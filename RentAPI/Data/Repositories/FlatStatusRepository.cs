using Microsoft.EntityFrameworkCore;
using RentAPI.Interfaces;
using RentAPI.Models;

namespace RentAPI.Data.Repositories;

public class FlatStatusRepository : IFlatStatusRepository
{
    private readonly DataContext _context;

    public FlatStatusRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<FlatStatus> GetStatusByName(string name)
    {
        return await _context.FlatStatus.FirstOrDefaultAsync(x => x.Name.Equals(name));
    }
}