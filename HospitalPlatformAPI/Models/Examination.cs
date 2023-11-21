namespace HospitalPlatformAPI.Models;

public class Examination : BaseEntity
{
    public string Name { get; set; }
    public double Price { get; set; }
    public Group Group { get; set; }
    public int GroupId { get; set; }
}