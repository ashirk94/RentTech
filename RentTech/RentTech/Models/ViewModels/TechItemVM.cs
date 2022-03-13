namespace RentTech.Models.ViewModels
{
    public class TechItemVM
    {
        public int ItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; } = 0;
        public int YearsOwned { get; set; } = 0;
        public string Type { get; set; } = "Misc";
        public List<string> Tags { get; } //free, low-price, item specifics
        public DateTime LendDate { get; set; } = DateTime.Now;
        public DateTime ReturnDate { get; set; } = DateTime.Now.AddDays(7);
        public int? RenterId { get; set; }
        public int OwnerId { get; set; }

        public string Thumbnail { get; set; }
    }
}
