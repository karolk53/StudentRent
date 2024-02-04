using RentAPI.DTOs.Flats;
using RentAPI.Helpers.PaginationParams;
using RentAPI.Models;

namespace RentAPI.Interfaces;

public interface IFlatRepository
{
    void AddNewFlat(Flat flat);
    Task<IEnumerable<FlatResponseDto>> GetUsersFlatsListAsync(int userId);
    Task<IEnumerable<FlatResponseDto>> GetListOfFlatsAsync(FlatParams flatParams);
    Task<bool> SaveAllAsync();
}