namespace HospitalPlatformAPI.DTOs.Analysis;

public class AnalysisCreateDto
{
    public string Name { get; set; }
    public string About { get; set; }
    public string Preparation { get; set; }
    public double? Price { get; set; }
    public List<AnalysisNameAndResultEntryDto> KeyEntries { get; set; }
}
public class AnalysisNameAndResultEntryDto
{
    public string Key { get; set; }
    public string Value { get; set; }
    //public string Desc { get; set; }
}
