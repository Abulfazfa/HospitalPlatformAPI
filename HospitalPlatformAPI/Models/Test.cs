namespace HospitalPlatformAPI.Models;

public class Test : BaseEntity
{
    public string Name { get; set; }
    public string RefDoctor { get; set; }
    public double? Price { get; set; }
}
public class TestResult : BaseEntity
{
    public Dictionary<string, string>? TestNameAndResult { get; set; }
    public string? TestImageUrl { get; set;}
    public string? TestConclusion { get; set; }
}
