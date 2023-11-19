namespace HospitalPlatformAPI.Models;

public class Analysis : BaseEntity
{
    public string Name { get; set; }
    public double? Price { get; set; }
    public AnalysisResult? AnalysisResult { get; set; }
}
public class AnalysisResult : BaseEntity
{
    public List<AnalysisNameAndResultEntry>? TestNameAndResultEntry { get; set; }
    public List<string>? AnalysisImageUrl { get; set;}
    public string? TestConclusion { get; set; }
    public AnalysisResult()
    {
        AnalysisImageUrl = new List<string>();
        TestNameAndResultEntry = new List<AnalysisNameAndResultEntry>();
    }
}

public class AnalysisNameAndResultEntry
{
    public int Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }

    public int AnalysisResultId { get; set; }
    public AnalysisResult AnalysisResult { get; set; }
}
