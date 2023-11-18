using Microsoft.AspNetCore.Identity;

namespace HospitalPlatformAPI.Models;

public class AppUser : IdentityUser
{
    public string FullName { get; set; }
    public int? GroupId { get; set; }
    public Group? Group { get; set; }
    public bool IsBlocked { get; set; }
    public List<Test> Tests { get; set; }

    public AppUser()
    {
        IsBlocked = false;
        Tests = new List<Test>();
    }
}