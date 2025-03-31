using AutoMapper;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO;
using NZWalk.API.Models.DTO.DifficultyDtos;
using NZWalk.API.Models.DTO.ImageDTOs;
using NZWalk.API.Models.DTO.WalkDto;

namespace NZWalk.API.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            /* Mapping for Region Model to Region DTO && Vice-Versa is defined */
            CreateMap<Region, RegionDto>().ReverseMap();

            /* Mapping For Create Region From DTO to Model and Vice-Versa */
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();

            /* Mapping For Update Region Request DTO to Model and Vice-Versa */
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();

            /* Mapping For Walk Model to Walk DTO && Vice-Versa */
            CreateMap<Walk, WalkDto>()
                .ForMember(
                    destination => destination.DifficultyDto, 
                    option => option.MapFrom(source => source.Difficulty)
                )
                .ForMember(
                    destination => destination.RegionDto, 
                    option => option.MapFrom(source => source.Region)
                )
                .ReverseMap();

            /* Mapping for Add Walk DTO to Walk Model && Vice-Versa */
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();

            /* Mapping For Update Walk Request DTO to Walk Model && Vice-Versa */
            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();

            /* Mapping For Difficulty Model to Difficulty DTO && Vice-Versa */
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();

            /* Mapping For Image Model to Image DTO && Vice-Versa */
            CreateMap<Image, ImageDto>()
                .ForMember(
                    destination => destination.Id,
                    option => option.MapFrom(source => source.Id)
                )
                .ReverseMap();

            /* Mapping For Image upload request DTO to Image Model && Vice-Versa */
            CreateMap<ImageUploadRequestDto, Image>().ReverseMap();
        }
    }
}
