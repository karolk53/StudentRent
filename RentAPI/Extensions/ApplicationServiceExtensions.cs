using RentAPI.Data.Repositories;
using RentAPI.Interfaces;
using RentAPI.Services;

namespace RentAPI.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddCors();
        services.AddScoped<ITokenService, TokenService>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IFlatRepository, FlatRepository>();
        services.AddScoped<IFlatStatusRepository, FlatStatusRepository>();

        return services;
    }
}