using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlantWebshopLogin.Models;

namespace PlantWebshopLogin.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<UserProduct> Purchases {  get; set; }
    public DbSet<Product> Products { get; set;}
}
