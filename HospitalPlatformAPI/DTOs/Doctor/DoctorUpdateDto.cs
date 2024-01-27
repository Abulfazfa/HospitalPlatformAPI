namespace HospitalPlatformAPI.DTOs.Doctor;

public class DoctorUpdateDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public List<string> About { get; set; }
    public string Branch { get; set; }
    public List<string> WorkingTimes { get; set; }
    public string PhoneNumber { get; set; }
    public string WorkingOfficeName { get; set; }
    public double ConsultingFee { get; set; }
}