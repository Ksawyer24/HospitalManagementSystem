using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Dto.Auth
{
    public class SignInResponseDto
    {
        public string JwtToken { get; set; } = string.Empty;

    }
}
