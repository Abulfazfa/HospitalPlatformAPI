using AutoMapper;
using HospitalPlatformAPI.DTOs;
using HospitalPlatformAPI.DTOs.Group;
using HospitalPlatformAPI.Models;

namespace HospitalPlatformAPI.Profiles;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<Group, GroupCreateDto>().ReverseMap();
        CreateMap<Group, GroupReturnDto>().ReverseMap();
        CreateMap<GroupCreateDto, IEnumerable<Group>>();
        CreateMap<RegisterDto, AppUser>();
        // CreateMap<SliderVM, Slider>()
        //     .ForMember(dest => dest.ImgUrl, opt => opt.Ignore());

    }
}