using Microsoft.AspNetCore.Identity;

namespace RentTech.Models.DomainModels
{
    public class AppUser : IdentityUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ReputationScore { get; set; } = 50; //colored text, trustworthy or not
        public List<CreditCard> CreditCards { get; }
        public List<Review> Reviews { get; } //list number of reviews + 'new lender' if 0
        public List<TechItem> OwnedItems { get; }
        public List<TechItem> RentedItems { get; }
    }
}
