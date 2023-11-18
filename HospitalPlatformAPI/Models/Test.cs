namespace HospitalPlatformAPI.Models;

public class Test : BaseEntity
{
    public string AnalysisName { get; set; }
    public double? AnalysisPrice { get; set; }
    public string? RefDoctor { get; set; }
    public AnalysisResult? AnalysisResult { get; set; }
    public bool IsReady { get; set; } = false;
}
