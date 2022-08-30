using System.ComponentModel.DataAnnotations;

namespace ChatApp.Presentation.DTOs
{
    public class RegisterPreViewDTOs
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [StringLength(20)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string? LastName { get; set; }
    }
}
