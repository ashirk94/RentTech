using System.ComponentModel.DataAnnotations;

namespace RentTech.Models.ViewModels
{
    public class TagVM
    {
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Tag { get; set; }
        public int ItemId { get; set; }
    }
}
