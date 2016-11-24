using AutoMapper;
using Commands.AutoMapper;
using Domain.AutoMapper;

namespace DsSpeeds.Infrastructure.Automapper
{
    public static class AutoMapperMappings
    {
        public static void BootAutoMapper()
        {
            Mapper.Initialize(mapper => 
                mapper.AddProfiles(
                    typeof(CommandsToEvents), 
                    typeof(EventsToDomain)));
        }
    }
}