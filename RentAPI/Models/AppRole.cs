using Microsoft.AspNetCore.Identity;

namespace RentAPI.Models;

public class AppRole : IdentityRole<int>
{
    public ICollection<AppUserRole> UserRoles { get; set; }
}