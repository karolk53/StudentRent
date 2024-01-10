using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentAPI.Models;

namespace RentAPI.Data;

public class Seed
{
    public static async Task SeedRoles(RoleManager<AppRole> roleManager)
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

    public static async Task SeedStatus(DataContext context)
    {
        if(await context.FlatStatus.AnyAsync()) return;
        
        var statuses = new List<FlatStatus>
        {
            new FlatStatus { Name = "FOR_RENT" },
            new FlatStatus { Name = "RENTED" }
        };

        foreach (var status in statuses)
        {
            await context.FlatStatus.AddAsync(status);
        }

        await context.SaveChangesAsync();
    }
}