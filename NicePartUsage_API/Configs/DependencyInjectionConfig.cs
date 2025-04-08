using Application.Services;
using Application.UseCases.Creation;
using Application.UseCases.Score;
using Application.UseCases.User;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Validation;
using Infrastructure.MongoDB;
using Infrastructure.Repositories;

namespace NicePartUsage_API.Configs;

public static class DependencyInjectionConfig
{
    public static void ConfigureDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
    {
        //DB 
        services.AddDbContext<DatabaseContext>();
        
        // Automapper
        services.AddSingleton(AutoMapperConfig.ConfigureAutoMapper());
        
        // Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICreationRepository, CreationRepository>();
        services.AddScoped<IScoreRepository, ScoreRepository>();
        
        // Services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICreationService, CreationService>();
        services.AddScoped<IScoreService, ScoreService>();
        
        // Validators
        services.AddScoped<UserValidator>();
        services.AddScoped<CreationValidator>(); 
        services.AddScoped<ScoreValidator>();

        // Use cases
        services.AddScoped<AddCreationUseCase>();
        services.AddScoped<DeleteCreationUseCase>();
        services.AddScoped<GetCreationByIdUseCase>();
        services.AddScoped<GetCreationsByElementNameUseCase>();
        services.AddScoped<GetCreationsUseCase>();
        services.AddScoped<UpdateCreationUseCase>();
        
        services.AddScoped<AddScoreUseCase>();
        services.AddScoped<DeleteScoreUseCase>();
        services.AddScoped<GetScoresUseCase>();
        
        services.AddScoped<AddUserUseCase>();
        services.AddScoped<DeleteUserUseCase>();
        services.AddScoped<GetUserByIdUseCase>();
        
    }
}