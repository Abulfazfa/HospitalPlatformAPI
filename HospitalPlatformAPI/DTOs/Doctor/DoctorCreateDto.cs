namespace HospitalPlatformAPI.DTOs.Doctor
{
    public class DoctorCreateDto
    {
        public string Fullname { get; set; }
        public List<string>? About { get; set; }
        public string Branch { get; set; }
        public List<string> WorkingTimes { get; set; }
        public string PhoneNumber { get; set; }
        public string WorkingOffice { get; set; }
        public double ConsultingFee { get; set; }
    }
}
