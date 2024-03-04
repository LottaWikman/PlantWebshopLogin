using Microsoft.AspNetCore.Identity;
using PlantWebshopLogin.Models;

namespace PlantWebshopLogin.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public List<UserProduct> UserShoppingCart { get; set; } = new List<UserProduct>();
    }

}
