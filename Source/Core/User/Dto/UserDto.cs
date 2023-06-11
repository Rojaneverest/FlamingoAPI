using System;
using System.ComponentModel.DataAnnotations;

namespace ecommerce.Core.User.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string[]? Roles { get; set; }
    }
}

