using System.ComponentModel.DataAnnotations;

namespace RentTech.Models.ViewModels
{
    public class TechItemVM
    {
        public int ItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Thumbnail { get; set; }

        public string Nonce { get; set; }
    }
}
