using System.ComponentModel.DataAnnotations;

namespace RentTech.Models.ViewModels
{
    public class TechItemVM
    {
        public int ItemId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Thumbnail { get; set; } = "No Image";
        public string Condition { get; set; }
        public string Type { get; set; }

        public IFormFile File { get; set; }

        public string Nonce { get; set; }
    }
}
