using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentTech.Models.DomainModels;

namespace RentTech.Data
{
    public static class SeedData
    {
        // password hidden
        private const string USERNAME = "admin";
        private const string ROLE_NAME = "Admin";
        private const string EMAIL = "ashirk94@gmail.com";
        private const string ID1 = "A";
        private const string ID2 = "B";
        private const string ID3 = "C";

        public async static Task Initialize(IServiceProvider serviceProvider, string password)
        {
            //dbcontext
            ApplicationDbContext context =
                serviceProvider.GetRequiredService<ApplicationDbContext>();
            //managers from serviceprovider
            UserManager<AppUser> userManager =
                serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // if role doesn't exist, create it
            var adminRole = await roleManager.FindByNameAsync(ROLE_NAME);
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new IdentityRole(ROLE_NAME));
            }

            if (await userManager.FindByNameAsync(USERNAME) == null)
            {
                var user = new AppUser
                {
                    FirstName = "Alan",
                    LastName = "Shirk",
                    Email = EMAIL,
                    UserName = USERNAME,
                };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, ROLE_NAME);

                }

            }
            await context.SaveChangesAsync();
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            // seed users
            var user1 = new AppUser()
            {
                Id = ID1,
                UserName = "ashirk99",
                FirstName = "Alan",
                LastName = "Shirk"
            };
            var user2 = new AppUser()
            {
                Id = ID2,
                UserName = "PraisetheSun",
                FirstName = "Solaire",
                LastName = "ofAstora"
            };
            var user3 = new AppUser()
            {
                Id = ID3,
                UserName = "ShotelMan",
                FirstName = "Lautrec",
                LastName = "ofCarim"
            };

            modelBuilder.Entity<AppUser>().HasData(
                user1, user2, user3
            );

            // seed posts
            modelBuilder.Entity<TechItem>().HasData(
                new
                {
                    TechItemId = 1,
                    OwnerId = ID1,
                    Title = "ASUS Laptop",
                    Price = 75.99,
                    Condition = "Good",
                    Type = "Laptop Computer",
                    IsRented = false,
                    Thumbnail = "../../images/asus.png"
                },
                new
                {
                    TechItemId = 2,
                    OwnerId = ID2,
                    Title = "IPad",
                    Price = 50.00,
                    Condition = "Fair",
                    Type = "Tablet",
                    IsRented = false,
                    Thumbnail = "../../images/ipad.png"
                },
                new
                {
                    TechItemId = 3,
                    OwnerId = ID3,
                    Title = "PlayStation 5",
                    Price = 100.00,
                    Condition = "Like-New",
                    Type = "Game Console",
                    IsRented = false,
                    Thumbnail = "../../images/ps5.png"
                }
            );
        }
    }
}
