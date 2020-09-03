using AutoMapper;
using Musical.Entity.Models;
using musicalog_api.Model;

namespace musicalog_api.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Album, AlbumRequest>();
        }
    }
}
