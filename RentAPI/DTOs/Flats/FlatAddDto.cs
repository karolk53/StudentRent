namespace RentAPI.DTOs.Flats;

public class FlatAddDto
{
    public string Street { get; set; }
    public string BuildingNumber { get; set; }
    public string FlatNumber { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public int RoomsNumber { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public int NumberOfPeople { get; set; }
    public string Status { get; set; }
}