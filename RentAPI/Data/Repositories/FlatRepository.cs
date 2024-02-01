using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RentAPI.DTOs.Flats;
using RentAPI.Interfaces;
using RentAPI.Models;

namespace RentAPI.Data.Repositories;

public class FlatRepository : IFlatRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public FlatRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public void AddNewFlat(Flat flat)
    {
        _context.Flats.Add(flat);
    }

    public async Task<IEnumerable<FlatResponseDto>> GetUsersFlatsListAsync(int userId)
    {
        return await _context.Flats
            .Where(x => x.OwnerId.Equals(userId))
            .ProjectTo<FlatResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}