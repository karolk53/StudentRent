using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentAPI.Models;

namespace RentAPI.Data;

public class DataContext : IdentityDbContext<AppUser, AppRole, int, 
                                            IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, 
                                            IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    public DataContext(DbContextOptions options) : base(options){}

    public DbSet<Address> Addresses { get; set; }
    public DbSet<FlatStatus> FlatStatus { get; set; }
    public DbSet<Flat> Flats { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<AppUser>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();

        modelBuilder.Entity<AppRole>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();

        modelBuilder.Entity<AppUser>()
            .HasMany(x => x.Flats)
            .WithOne(f => f.Owner)
            .HasForeignKey(fk => fk.OwnerId)
            .IsRequired();

        modelBuilder.Entity<Flat>()
            .HasOne(o => o.Owner)
            .WithMany(f => f.Flats)
            .HasForeignKey(fk => fk.OwnerId)
            .IsRequired();

    }
}