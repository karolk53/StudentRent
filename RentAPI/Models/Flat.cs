namespace RentAPI.Models;

public class Flat
{
    public int Id { get; set; }
    public int RoomsNumber { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public int NumberOfPeople { get; set; }
    public FlatStatus Status { get; set; }
    public Address Address { get; set; }
}