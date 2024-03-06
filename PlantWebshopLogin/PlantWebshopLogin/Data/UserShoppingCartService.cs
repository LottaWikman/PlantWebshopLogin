using Blazored.LocalStorage;
using PlantWebshopLogin.Client.Models;
using PlantWebshopLogin.Models;

namespace PlantWebshopLogin.Data;

public class UserShoppingCartService
{
    private readonly ILocalStorageService _localStorage;
    private readonly ApplicationDbContext _context;

    public UserShoppingCartService(ILocalStorageService localStorage, ApplicationDbContext context)
    {
        _localStorage = localStorage;
        _context = context;
    }


    ApplicationUser? user;

    private List<UserProduct> userShoppingCart = new List<UserProduct>();


    public async Task<List<UserProduct>> GetShoppingCart(ApplicationUser user)
    {
        return await _localStorage.GetItemAsync<List<UserProduct>>(user.Id) ?? new List<UserProduct>();
    }

    public async Task AddToCart(Product product, ApplicationUser user)
    {
        userShoppingCart = await GetShoppingCart(user);
        UserProduct userProduct = ConvertToUserProduct(product, user);
        userShoppingCart.Add(userProduct);
        await _localStorage.SetItemAsync(user.Id, userShoppingCart);
    }

    public async Task EmptyCart(ApplicationUser user)
    {
        userShoppingCart.Clear();
        await _localStorage.RemoveItemAsync(user.Id);
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
