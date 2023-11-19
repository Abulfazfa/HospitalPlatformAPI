namespace HospitalPlatformAPI.DTOs.Analysis;

public class AnalysisCreateDto
{
    public string Name { get; set; }
    public double? Price { get; set; }
    public List<string>? Key { get; set; }
}