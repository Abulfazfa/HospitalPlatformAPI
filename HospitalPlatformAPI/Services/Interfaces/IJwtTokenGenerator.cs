using HospitalPlatformAPI.Models;

namespace HospitalPlatformAPI.Services.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(AppUser applicationUser, IEnumerable<string> roles);
    }
}
