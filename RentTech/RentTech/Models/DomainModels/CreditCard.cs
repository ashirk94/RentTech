using System.ComponentModel.DataAnnotations;

namespace RentTech.Models.DomainModels
{
    public class CreditCard
    {
        [Key]
        public int CardId { get; set; }
        public int CardNumber { get; set; }
        public int CVC { get; set; }
        public DateTime Expiration { get; set; }
        public int UserId { get; set; }
    }
}
