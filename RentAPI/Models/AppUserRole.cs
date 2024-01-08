using Microsoft.AspNetCore.Identity;

namespace RentAPI.Models;

public class AppUserRole : IdentityUserRole<int>
{
    public AppUser User { get; set; }
    public AppRole Role { get; set; }
}