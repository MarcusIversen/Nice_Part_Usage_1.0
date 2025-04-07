using AutoMapper;

namespace NicePartUsage_API.Configs;

public class AutoMapperConfig
{
    public static IMapper ConfigureAutoMapper()
    {
        var mapperConfig = new MapperConfiguration(config =>
        {
            // DTO to Core Entity
            // config.CreateMap<AddCreationDto, Creation>();
        });

        return mapperConfig.CreateMapper();
    }
}