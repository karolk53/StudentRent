using RentAPI.Models;

namespace RentAPI.DTOs.Flats;

public class FlatResponseDto
{
    public string OwnerEmail { get; set; }
    public int RoomsNumber { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public int NumberOfPeople { get; set; }
    public float Surface { get; set; }
    public string CurrentStatus { get; set; }
    public Address Address { get; set; }
}