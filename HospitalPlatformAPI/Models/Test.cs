namespace HospitalPlatformAPI.Models;



public class Test : BaseEntity
{
    public string Name { get; set; }
    public string? RefDoctor { get; set; }
    public double? Price { get; set; }
    public TestResult? TestResult { get; set; }

    public Test()
    {
        TestResult = new TestResult();
    }
}
public class TestResult : BaseEntity
{
    public ICollection<TestNameAndResultEntry>? TestNameAndResultEntries { get; set; }
    public string? TestImageUrl { get; set;}
    public string? TestConclusion { get; set; }
}
public class TestNameAndResultEntry
{
    public int Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }

    // Define a foreign key to the TestResult
    public int TestResultId { get; set; }
    public TestResult TestResult { get; set; }
}
