namespace HospitalPlatformAPI.Models;

public class Office : BaseEntity
{
    public string Name { get; set; }
    public string Location { get; set; }
    public string Tel { get; set; }
    public List<string> WorkingTimes { get; set; }
    public List<Group> Groups { get; set; }
    public string ImageUrl { get; set; }

    public Office()
    {
        WorkingTimes = new List<string>();
        Groups = new List<Group>();
    }
}