namespace HospitalPlatformAPI.Models;

public class Test : BaseEntity
{
    public string AnalysisName { get; set; }
    public double? TestPrice { get; set; }
    public string? RefDoctor { get; set; }
    public TestResult? TestResult { get; set; }
    public bool IsReady { get; set; } = false;
}
public class TestResult : BaseEntity
{
    public List<TestNameAndResultEntry>? TestNameAndResultEntry { get; set; }
    public List<string>? TestImageUrl { get; set; }
    public string? TestConclusion { get; set; }
    public TestResult()
    {
        TestImageUrl = new List<string>();
        TestNameAndResultEntry = new List<TestNameAndResultEntry>();
    }
}
public class TestNameAndResultEntry
{
    public int Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public int TestResultId { get; set; }
    public TestResult TestResult { get; set; }
}
