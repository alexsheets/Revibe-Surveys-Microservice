using AutoMapper;
using Surveys.Models;
using Surveys.Dtos;

namespace Surveys.Profiles
{
    public class ArtistsProfile : Profile
    {
        public ArtistsProfile()
        {
            CreateMap<ArtistOfTheWeek, ArtistReadDto>();
            CreateMap<ArtistReadDto, ArtistOfTheWeek>();
            CreateMap<ArtistOfTheWeek, ArtistApplicationDto>();
            CreateMap<ArtistApplicationDto, ArtistOfTheWeek>();
        }
    }
}