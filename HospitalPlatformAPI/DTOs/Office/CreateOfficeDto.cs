namespace HospitalPlatformAPI.DTOs.Office
{
    public class CreateOfficeDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Tel { get; set; }
        public List<string> WorkingTimes { get; set; }
    }
}
