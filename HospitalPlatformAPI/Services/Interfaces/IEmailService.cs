namespace HospitalPlatformAPI.Services.Interfaces;

public interface IEmailService
{
    public void Send(string to, string subject, string body);
}