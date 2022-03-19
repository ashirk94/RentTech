using System.ComponentModel.DataAnnotations;

namespace RentTech.Models.DomainModels
{
    public class TechItem
    {
        [Key]
        public int TechItemId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Title { get; set; }

        [StringLength(100, MinimumLength = 4)]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Condition { get; set; }
        [Required]
        public string Type { get; set; }
        public List<Tag> Tags { get; set; } //free, low-price, item specifics

        public List<Review> Reviews { get; set; }
        public DateTime? RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string OwnerId { get; set; }
        public AppUser Owner { get; set; }
        public string Thumbnail { get; set; } = "No Image";

        public bool IsRented { get; set; } = false;
    }
}
