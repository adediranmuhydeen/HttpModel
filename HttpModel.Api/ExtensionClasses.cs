using AutoMapper;
using HttpModel.Api.Model;

namespace HttpModel.Api
{
    public static class ExtensionClasses
    {
        
    }

    public class MapInitializer : Profile
    {
        public MapInitializer()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
        }
    }

}
