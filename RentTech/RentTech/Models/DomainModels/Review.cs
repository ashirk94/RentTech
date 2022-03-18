using System.ComponentModel.DataAnnotations;

namespace RentTech.Models.DomainModels
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string ReviewerId { get; set; }
        public AppUser Reviewer { get; set; }
        public int TechItemId { get; set; }
        public TechItem Item { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Text { get; set; }
        [Range(0, 5)]
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.UtcNow;
    }
}
