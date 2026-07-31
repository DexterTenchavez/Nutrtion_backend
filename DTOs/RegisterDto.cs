using System.ComponentModel.DataAnnotations;

namespace Nutrition_backend.DTOs
{
    public class RegisterDto
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;

        public string? Role { get; set; } = "staff";

        public string? Barangay { get; set; }
    }
}