using AutoMapper;
using HospitalPlatformAPI.DTOs;
using HospitalPlatformAPI.DTOs.Analysis;
using HospitalPlatformAPI.DTOs.Group;
using HospitalPlatformAPI.DTOs.Test;
using HospitalPlatformAPI.Models;

namespace HospitalPlatformAPI.Profiles;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<Group, GroupCreateDto>().ReverseMap();
        CreateMap<Group, GroupReturnDto>().ReverseMap();
        CreateMap<GroupCreateDto, IEnumerable<Group>>();
        CreateMap<Test, TestReturnDto>().ReverseMap();
        CreateMap<Analysis, AnalysisCreateDto>().ReverseMap();
        
        CreateMap<RegisterDto, AppUser>();
        // CreateMap<SliderVM, Slider>()
        //     .ForMember(dest => dest.ImgUrl, opt => opt.Ignore());

    }
}