using HospitalPlatformAPI.Models;

namespace HospitalPlatformAPI.DTOs.Test;

public class TestCreateDto
{
    public string AnalysisName { get; set; }
    public string? RefDoctor { get; set; }
    public string User { get; set; }
}