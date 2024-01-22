namespace HospitalPlatformAPI.DTOs.Appointment;

public class CreateAppointmentDto
{
    public string PatientFullname { get; set; }
    public string PhoneNumber { get; set; }
    public string Message { get; set; }
    public string Time { get; set; }
    public string ConsultingDate { get; set; }
}