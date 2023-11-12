namespace HospitalPlatformAPI.Models;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsDeleted { get; set; }

    public BaseEntity()
    {
        CreateDate = DateTime.Now;
        IsDeleted = false;
    }

}