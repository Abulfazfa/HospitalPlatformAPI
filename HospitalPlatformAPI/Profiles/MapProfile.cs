using AutoMapper;
using HospitalPlatformAPI.DTOs;
using HospitalPlatformAPI.DTOs.Analysis;
using HospitalPlatformAPI.DTOs.Doctor;
using HospitalPlatformAPI.DTOs.Group;
using HospitalPlatformAPI.DTOs.Office;
using HospitalPlatformAPI.DTOs.Test;
using HospitalPlatformAPI.Models;

namespace HospitalPlatformAPI.Profiles;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<GroupCreateDto, Group>().ForMember(ds => ds.OfficeId, map => map.Ignore()).ReverseMap();
        CreateMap<Group, GroupReturnDto>().ReverseMap();
        CreateMap<GroupCreateDto, IEnumerable<Group>>();
        CreateMap<Test, TestReturnDto>().ReverseMap();
        CreateMap<Analysis, AnalysisCreateDto>().ReverseMap();
        CreateMap<Doctor, DoctorReturnDto>().ReverseMap();
        CreateMap<Doctor, DoctorCreateDto>().ReverseMap();
        CreateMap<Office, CreateOfficeDto>().ReverseMap();
        CreateMap<Office, ReturnOfficeDto>().ReverseMap();

        CreateMap<RegisterDto, AppUser>();
        // CreateMap<SliderVM, Slider>()
        //     .ForMember(dest => dest.ImgUrl, opt => opt.Ignore());

    }
}