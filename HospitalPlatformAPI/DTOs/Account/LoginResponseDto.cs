namespace HospitalPlatformAPI.DTOs.Account
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
