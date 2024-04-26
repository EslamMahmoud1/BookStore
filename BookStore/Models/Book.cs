using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Book
    {
        public int Id{ get; set; }
        [MinLength(3)]
        public string Title { get; set; }
        public string Author { get; set; }
        public string? Genre{ get; set; }
        public string? Description { get; set; }
        public Decimal Price { get; set; }
        public string? ISBN { get; set; }
        public string? Rating{ get; set; }
        public string? Image { get; set; }
        [NotMapped]
        [ValidateNever]
        public IFormFile ImageFile { get; set; }
    }
}
