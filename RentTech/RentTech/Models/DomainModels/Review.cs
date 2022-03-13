using System.ComponentModel.DataAnnotations;

namespace RentTech.Models.DomainModels
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set;}
        public int UserId { get; set; }
        [Required]
        public string ReviewerName { get; set; }
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Text { get; set; }
        [Range(0,5)]
        public int Rating { get; set; }
    }
}
