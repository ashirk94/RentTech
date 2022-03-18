using Microsoft.AspNetCore.Identity;
using RentTech.Models.DomainModels;

namespace RentTech.Models.ViewModels
{
    public class AdminVM
    {
        public IEnumerable<AppUser> Users { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
