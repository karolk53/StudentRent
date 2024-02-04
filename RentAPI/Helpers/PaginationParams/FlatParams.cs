namespace RentAPI.Helpers.PaginationParams;

public class FlatParams : PaginationParams
{
    public float Surface { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}