using System.ComponentModel.DataAnnotations;

namespace RentTech.Models.DomainModels
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        public int TechItemId { get; set; }
        public TechItem Item { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Text { get; set; }
    }
}
