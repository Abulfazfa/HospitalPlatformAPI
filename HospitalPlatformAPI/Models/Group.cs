namespace HospitalPlatformAPI.Models;

public class Group : BaseEntity
{
    public string AdministratorName { get; set;}
    public string GroupName { get; set; }
    public List<AppUser> GroupMembers { get; set; }
    
}