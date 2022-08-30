using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ChatApp.DataAccess.Entities
{
    public class AppUser : IdentityUser
    {
        [Required, MinLength(2)]
        public string? FirstName { get; set; }
        [Required, MinLength(2)]
        public string? LastName { get; set; }
        public DateTime? Created { get; set; }

    }
}
