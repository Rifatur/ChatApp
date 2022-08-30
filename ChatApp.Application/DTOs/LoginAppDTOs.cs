using System.ComponentModel.DataAnnotations;

namespace ChatApp.Application.DTOs
{
    public class LoginAppDTOs
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
