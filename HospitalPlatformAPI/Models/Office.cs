namespace HospitalPlatformAPI.Models;

public class Office : BaseEntity
{
    public string Name { get; set; }
    public List<Group> Services { get; set; }
}