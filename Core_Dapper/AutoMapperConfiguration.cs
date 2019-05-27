using AutoMapper;
using Core_Dapper.Models;
using Dapper_DAL.Models;


namespace Core_Dapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<IArtistDto, ArtistDto>();
            CreateMap<Artist, IArtistDto>();
        }
    }
}
