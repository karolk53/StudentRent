using RentAPI.Models;

namespace RentAPI.Interfaces;

public interface IFlatRepository
{
    void AddNewFlat(Flat flat);
    Task<bool> SaveAllAsync();
}