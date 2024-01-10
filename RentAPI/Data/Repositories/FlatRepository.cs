using RentAPI.Interfaces;
using RentAPI.Models;

namespace RentAPI.Data.Repositories;

public class FlatRepository : IFlatRepository
{
    private readonly DataContext _context;

    public FlatRepository(DataContext context)
    {
        _context = context;
    }
    
    public void AddNewFlat(Flat flat)
    {
        _context.Flats.Add(flat);
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}