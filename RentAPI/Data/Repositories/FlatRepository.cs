using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RentAPI.DTOs.Flats;
using RentAPI.Helpers;
using RentAPI.Helpers.PaginationParams;
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

    public async Task<IEnumerable<FlatResponseDto>> GetListOfFlatsAsync(FlatParams flatParams)
    {
        var query = _context.Flats.AsQueryable();

        if (!flatParams.City.IsNullOrEmpty())
        {
            query = query.Where(x => x.Address.City.Equals(flatParams.City));
        }

        var flats = query.ProjectTo<FlatResponseDto>(_mapper.ConfigurationProvider);

        return await PagedList<FlatResponseDto>.CreateAsync(flats, flatParams.PageNumber, flatParams.PageSize);
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}