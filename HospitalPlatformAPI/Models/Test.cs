namespace HospitalPlatformAPI.Models;



public class Test : BaseEntity
{
    public string Name { get; set; }
    public string RefDoctor { get; set; }
    public double? Price { get; set; }
    public TestResult? TestResult { get; set; }

    public Test()
    {
        TestResult = new TestResult();
    }
}
public class TestResult : BaseEntity
{
    public Dictionary<string, string>? TestNameAndResult { get; set; }
    public TestResult()
    {
        TestNameAndResult = new Dictionary<string, string>();
    }
    
    public string? TestImageUrl { get; set;}
    public string? TestConclusion { get; set; }
}
