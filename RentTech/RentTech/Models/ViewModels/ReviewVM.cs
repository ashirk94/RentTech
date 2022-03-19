using System.ComponentModel.DataAnnotations;

namespace RentTech.Models.ViewModels
{
    public class ReviewVM
    {
        public int ItemId { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string ReviewText { get; set; }

        public int ReviewScore { get; set; }
    }
}
