using System.ComponentModel.DataAnnotations;

namespace RentTech.Models.ViewModels
{
    public class ReviewVM
    {
        public int ItemId { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string ReviewText { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10")]
        public int ReviewScore { get; set; }
    }
}
