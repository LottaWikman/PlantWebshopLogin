using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlantWebshopLogin.Models;

namespace PlantWebshopLogin.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    DbSet<UserProduct> UserProducts {  get; set; }
    public DbSet<Product> Products { get; set;}
}
