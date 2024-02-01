using RentAPI.Models;

namespace RentAPI.Interfaces;

public interface IFlatStatusRepository
{
    Task<FlatStatus> GetStatusByName(string name);
}