namespace HospitalPlatformAPI.Models;

public class Group : BaseEntity
{
    public string Name { get; set;}
    public List<Doctor> Doctors { get; set; }
    public int? OfficeId { get; set; }
    public Office Office { get; set; }

    public Group()
    {
        Doctors = new List<Doctor>();
    }
}