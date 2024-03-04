using PlantWebshopLogin.Models;
using Blazored.LocalStorage;

namespace PlantWebshopLogin.Data;

public class ShoppingCartService
{
    //injicerar localStorage:
    private readonly ILocalStorageService _localStorage;


    public ShoppingCartService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    private List<Product> shoppingCart = new List<Product>();

    public async Task<List<Product>> GetShoppingCart()
    {
        return await _localStorage.GetItemAsync<List<Product>>("ShoppingCart") ?? new List<Product>();
    }

    public async Task AddToCart(Product product)
    {
        shoppingCart = await GetShoppingCart();
        shoppingCart.Add(product);
        await _localStorage.SetItemAsync("ShoppingCart", shoppingCart);
    }

    public async Task EmptyCart()
    {
        shoppingCart.Clear();
        await _localStorage.RemoveItemAsync("ShoppingCart");
    }
}
