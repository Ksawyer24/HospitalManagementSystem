﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HospitalManagementSystem.Dto.Auth
{
    public class SignUpRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "This must be a valid email")]
        public  string Email { get; set; } = string.Empty;


        [Required]
       
        public  string FirstName { get; set; } = string.Empty;

        [Required]
     
        public string LastName { get; set; } = string.Empty;


        [Required]
        public  string UserName { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required]
        public required string[] Roles { get; set; }

    }
}
