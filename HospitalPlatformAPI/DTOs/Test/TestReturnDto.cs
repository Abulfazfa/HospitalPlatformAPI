namespace HospitalPlatformAPI.DTOs.Test;

public class TestReturnDto
{
    public string Name { get; set; }
    public string RefDoctor { get; set; }
    public double? Price { get; set; }
    public Dictionary<string, string>? TestNameAndResult { get; set; }
    public string? TestImageUrl { get; set;}
    public string? TestConclusion { get; set; }
    public DateTime? CreateDate { get; set; }
}