using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentTech.Models.DomainModels
{
    public class AppUser : IdentityUser
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ReputationScore { get; set; } = 50; //colored text, trustworthy or not
        public string ProfilePicture { get; set; }
        public List<Review> Reviews { get; set; } //list number of reviews + 'new lender' if 0
        public List<TechItem> Items { get; set; }
        [NotMapped]
        public ICollection<string> RoleNames { get; set; }
    }
}
