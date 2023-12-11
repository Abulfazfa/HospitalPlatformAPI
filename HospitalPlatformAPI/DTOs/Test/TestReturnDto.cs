using HospitalPlatformAPI.DTOs.Analysis;

namespace HospitalPlatformAPI.DTOs.Test;

public class TestReturnDto
{
    public string AnalysisName { get; set; }
    public string RefDoctor { get; set; }
    public double? TestPrice { get; set; }
    public List<string>? TestImageUrl { get; set;}
    public string? TestConclusion { get; set; }
    public List<TestNameAndResultEntryDto>? TestNameAndResultEntry { get; set; }
    public DateTime? CreateDate { get; set; }
}