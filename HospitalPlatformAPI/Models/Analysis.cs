namespace HospitalPlatformAPI.Models;

public class Analysis : BaseEntity
{
    public string Name { get; set; }
    public string About { get; set; }
    public string Preparation { get; set; }
    public double? Price { get; set; }
    public AnalysisResult? AnalysisResult { get; set; }
}
public class AnalysisResult : BaseEntity
{
    public List<AnalysisNameAndResultEntry>? TestNameAndResultEntry { get; set; }
    public AnalysisResult()
    {
        TestNameAndResultEntry = new List<AnalysisNameAndResultEntry>();
    }
}

public class AnalysisNameAndResultEntry
{
    public int Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public string? Desc { get; set; }
    public int AnalysisResultId { get; set; }
    public AnalysisResult AnalysisResult { get; set; }
}
