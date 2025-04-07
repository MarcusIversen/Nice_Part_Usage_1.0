using Application.Services.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;

namespace NicePartUsage_API.Configs;

public static class DependencyInjectionConfig
{
    public static void ConfigureDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
    {
        // Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICreationRepository, CreationRepository>();
        services.AddScoped<IScoreRepository, ScoreRepository>();
        
        
        // Services
        services.AddScoped<IUserService, Application.Services.UserService>();
        services.AddScoped<ICreationService, Application.Services.CreationService>();
        services.AddScoped<IScoreService, Application.Services.ScoreService>();

        // Automapper

        services.AddSingleton(AutoMapperConfig.ConfigureAutoMapper());
    }
}