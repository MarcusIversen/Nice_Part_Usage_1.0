using AutoMapper;
using Core.Entities;
using NicePartUsage_API.Controllers.DTOs.Creation;
using NicePartUsage_API.Controllers.DTOs.Score;
using NicePartUsage_API.Controllers.DTOs.User;

namespace NicePartUsage_API.Configs;

public class AutoMapperConfig
{
    public static IMapper ConfigureAutoMapper()
    {
        var mapperConfig = new MapperConfiguration(config =>
        {
            // DTO to Core Entity
            // Creation
            config.CreateMap<AddCreationDto, Creation>();
            config.CreateMap<UpdateCreationDto, Creation>();
            
            // User
            config.CreateMap<AddUserDto, User>();
            config.CreateMap<AddUserDto, User>();
            
            // Score
            config.CreateMap<AddScoreDto, Score>();
        });

        return mapperConfig.CreateMapper();
    }
}