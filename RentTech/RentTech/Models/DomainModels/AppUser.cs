using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RentTech.Models.DomainModels
{
    public class AppUser : IdentityUser
    {
        public string UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int ReputationScore { get; set; } = 50; //colored text, trustworthy or not
        public string ProfilePicture { get; set; }
        public List<Review> Reviews { get; set; } //list number of reviews + 'new lender' if 0
        public List<TechItem> Items { get; set; }
    }
}
