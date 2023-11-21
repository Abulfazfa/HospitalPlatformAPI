namespace HospitalPlatformAPI.DTOs.Doctor
{
    public class DoctorReturnDto
    {
        public string FullName { get; set; }
        public List<string> About { get; set; }
        public int GroupId { get; set; }
        public List<string> WorkingTimes { get; set; }
        public string PhoneNumber { get; set; }
        public int WorkingOfficeId { get; set; }
        public string WorkingOfficeName { get; set; }
        public double ConsultingFee { get; set; }

        public DoctorReturnDto()
        {
            About = new List<string>();
            WorkingTimes = new List<string>();
        }
    }
}
