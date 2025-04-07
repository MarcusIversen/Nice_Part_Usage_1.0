using Application.Repositories;
using Application.Services;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Validation;


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
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICreationService, CreationService>();
        services.AddScoped<IScoreService, ScoreService>();
        
        // Validators
        services.AddScoped<UserValidator>(); // Register UserValidator
        services.AddScoped<CreationValidator>(); // Register CreationValidator
        services.AddScoped<ScoreValidator>(); // Register ScoreValidator

        // Automapper
        services.AddSingleton(AutoMapperConfig.ConfigureAutoMapper());
    }
}