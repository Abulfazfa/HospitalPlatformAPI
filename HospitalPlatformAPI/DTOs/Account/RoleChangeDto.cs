using HospitalPlatformAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace HospitalPlatformAPI.DTOs;

public class RoleChangeDto
{
    public AppUser User { get; set; }
    public List<IdentityRole> Roles { get; set; }
    public IList<string> UserRoles { get; set; }
}