using Application.Repositories;
using Application.Services;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;


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
        //services.AddScoped<IUserService, UserService>();
        //services.AddScoped<ICreationService, CreationService>();
        //services.AddScoped<IScoreService, ScoreService>();

        // Automapper
        services.AddSingleton(AutoMapperConfig.ConfigureAutoMapper());
    }
}