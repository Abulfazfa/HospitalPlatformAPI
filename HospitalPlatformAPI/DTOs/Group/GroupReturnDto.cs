using HospitalPlatformAPI.Models;

namespace HospitalPlatformAPI.DTOs.Group;

public class GroupReturnDto
{
    public string Name { get; set; }
    public string AdministratorName { get; set;}
    public List<AppUser> GroupMembers { get; set; }
}