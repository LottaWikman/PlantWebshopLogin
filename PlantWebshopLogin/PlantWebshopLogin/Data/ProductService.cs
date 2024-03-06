using PlantWebshopLogin.Client.Models;
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

    public UserProduct ConvertToUserProduct(Product product, ApplicationUser user)
    {
        return new UserProduct
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
            User = user
        };
    }

    public void DecreaseQuantity(List<UserProduct> userShoppingCart)
    {
        foreach (UserProduct userProduct in userShoppingCart)
        {
            Product product = _context.Products.First(p => p.Id == userProduct.Id);
            product.Quantity = product.Quantity - 1;
            _context.SaveChanges();
        }
    }

    public ClientProduct ConvertToClientProduct(UserProduct userShoppingCart)
    {
        return new ClientProduct
        {
            Id = userShoppingCart.Id,
            Name = userShoppingCart.Name,
            Price = userShoppingCart.Price,
        };
    }

}
