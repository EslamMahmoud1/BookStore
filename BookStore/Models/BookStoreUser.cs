using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class BookStoreUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImage { get; set; } = string.Empty;
        [NotMapped]
        [ValidateNever]
        public IFormFile File { get; set; }
    }
}
