using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Dto.Auth
{
    public class SignInRequestDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public  string Password { get; set; } = string.Empty;

    }
}
