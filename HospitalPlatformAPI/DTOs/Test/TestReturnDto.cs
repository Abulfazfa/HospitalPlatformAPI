using HospitalPlatformAPI.DTOs.Analysis;

namespace HospitalPlatformAPI.DTOs.Test;

public class TestReturnDto
{
    public string AnalisysName { get; set; }
    public string RefDoctor { get; set; }
    public double? Price { get; set; }
    //public Dictionary<string, string>? TestNameAndResult { get; set; }
    public List<string>? AnalysisImageUrl { get; set;}
    public string? TestConclusion { get; set; }
    public List<AnalysisResultDto>? TestNameAndResultEntry { get; set; }
    public DateTime? CreateDate { get; set; }
}