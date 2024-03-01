using Microsoft.AspNetCore.Identity;
using PlantWebshopLogin.Models;

namespace PlantWebshopLogin.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<UserProduct> UserProducts { get; set; } = new List<UserProduct>();
    }

}
