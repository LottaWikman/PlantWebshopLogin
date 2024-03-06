using Blazored.LocalStorage;
using PlantWebshopLogin.Client.Models;
using PlantWebshopLogin.Models;

namespace PlantWebshopLogin.Data;

public class UserShoppingCartService
{
    private readonly ILocalStorageService _localStorage;
    private readonly ApplicationDbContext _context;
    ProductService _productService;

    public UserShoppingCartService(ILocalStorageService localStorage, ApplicationDbContext context, ProductService productService)
    {
        _localStorage = localStorage;
        _context = context;
        _productService = productService;
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
        UserProduct userProduct = _productService.ConvertToUserProduct(product, user);
        userShoppingCart.Add(userProduct);
        await _localStorage.SetItemAsync(user.Id, userShoppingCart);
    }

    public async Task EmptyCart(ApplicationUser user)
    {
        userShoppingCart.Clear();
        await _localStorage.RemoveItemAsync(user.Id);
    }
}
