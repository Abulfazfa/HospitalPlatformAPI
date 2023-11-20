namespace HospitalPlatformAPI.Models;

public class Group : BaseEntity
{
    public string Name { get; set;}
    public List<Doctor> Doctors { get; set; }
    public List<Group> Services { get; set; }
}