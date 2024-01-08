using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentAPI.Models;

namespace RentAPI.Data;

public class Seed
{
    public static async Task SeedUsers(RoleManager<AppRole> roleManager)
    {
        if(await roleManager.Roles.AnyAsync()) return;
        
        var roles = new List<AppRole>
        {
            new AppRole{Name = "Member"},
            new AppRole{Name = "Admin"},
            new AppRole{Name = "Moderator"}
        };

        foreach(var role in roles)
        {
            await roleManager.CreateAsync(role);
        }
    }
}