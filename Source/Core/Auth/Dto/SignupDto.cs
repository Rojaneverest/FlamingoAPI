using System;
using System.ComponentModel.DataAnnotations;

namespace ecommerce.Core.Auth.Dto
{
    public class SignupDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;


        [Required]
        public string LastName { get; set; } = string.Empty;


        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;


        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public long provinceId { get; set; }
    }
}

