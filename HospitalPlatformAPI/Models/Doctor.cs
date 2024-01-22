namespace HospitalPlatformAPI.Models;

public class Doctor : BaseEntity
{
    public string Fullname { get; set; }
    public List<string>? About { get; set; }
    public Group Branch { get; set; }
    public int? GroupId { get; set; }
    public List<string> WorkingTimes { get; set;}
    public string PhoneNumber { get; set; }
    public Office WorkingOffice { get; set; }
    public int? OfficeId { get; set; }
    public double ConsultingFee { get; set; }
    public List<Appointment> Appointments { get; set; }

    public Doctor()
    {
        WorkingTimes = new List<string>();
        About = new List<string>();
        Appointments = new List<Appointment>();  
    }
}