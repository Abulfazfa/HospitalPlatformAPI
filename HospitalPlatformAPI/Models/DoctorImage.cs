namespace HospitalPlatformAPI.Models;

public class DoctorImage
{
    public int Id { get; set; }
    public string ImgUrl { get; set; }
    public bool IsMain { get; set; }
    public int DoctorId { get; set; }
    public bool IsDeleted { get; set; }
    public DoctorImage()
    {
        IsMain = false;
        IsDeleted = false;
    }
}