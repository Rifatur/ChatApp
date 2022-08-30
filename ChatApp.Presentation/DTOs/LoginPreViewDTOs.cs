using System.ComponentModel.DataAnnotations;

namespace ChatApp.Presentation.DTOs
{
    public class LoginPreViewDTOs
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
