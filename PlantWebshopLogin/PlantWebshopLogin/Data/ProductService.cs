using PlantWebshopLogin.Models;

namespace PlantWebshopLogin.Data;

public class ProductService
{

    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Product> GetProducts()
    {
        return _context.Products.ToList();
    }

	public Product GetProduct(int id)
	{
		return _context.Products.First(p => p.Id == id); 
	}

}
