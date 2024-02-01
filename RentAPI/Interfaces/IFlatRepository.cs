using RentAPI.DTOs.Flats;
using RentAPI.Models;

namespace RentAPI.Interfaces;

public interface IFlatRepository
{
    void AddNewFlat(Flat flat);
    Task<IEnumerable<FlatResponseDto>> GetUsersFlatsListAsync(int userId);
    Task<bool> SaveAllAsync();
}