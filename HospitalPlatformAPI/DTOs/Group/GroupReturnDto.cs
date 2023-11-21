using HospitalPlatformAPI.DTOs.Doctor;
using HospitalPlatformAPI.Models;

namespace HospitalPlatformAPI.DTOs.Group;

public class GroupReturnDto
{
    public string Name { get; set; }
    public List<DoctorReturnDto> Doctors { get; set; }
    public int OfficeId { get; set; }
    public string OfficeName { get; set; }

    public GroupReturnDto()
    {
        Doctors = new List<DoctorReturnDto>();
    }
}



