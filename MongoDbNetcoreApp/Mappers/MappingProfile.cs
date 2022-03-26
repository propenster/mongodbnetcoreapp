using AutoMapper;
using MongoDbNetcoreApp.Dtos;
using MongoDbNetcoreApp.Models;

namespace MongoDbNetcoreApp.Mappers
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<FeedbackDto, Feedback>().ReverseMap();
            CreateMap<WebsiteTableDto, WebsiteTable>().ReverseMap();
        }

    }
}
