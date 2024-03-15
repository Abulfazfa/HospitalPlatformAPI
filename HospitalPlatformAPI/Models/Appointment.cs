namespace HospitalPlatformAPI.Models;


public class Appointment : BaseEntity
{
    public string PatientFullname { get; set; }
    public string PhoneNumber { get; set; }
    public string Message { get; set; }
    public string Time { get; set; }
    public string ConsultingDate { get; set; }
    public int DoctorId { get; set; }
}