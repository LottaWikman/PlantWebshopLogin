using PlantWebshopLogin.Models;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace PlantWebshopLogin.Data;

//ShoppingCart-funktionen behöver vara en service för
//att kunna användas på olika platser i projektet.

public interface IShoppingCartService
{
    //interface där vi definierar vad som ska finnas
    //i en shoppingCartService:

    //metod som hämtar en lista med Products
    Task<List<Product>> GetShoppingCart();

    //metod som tar emot en Product
    Task AddToCart(Product product);

    //metod som tömmer kundvagnen
    Task EmptyCart();
}

public class ShoppingCartService : IShoppingCartService
{
    //injicerar localStorage:
    private readonly ILocalStorageService _localStorage;


    public ShoppingCartService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    //Här skapar vi en faktisk service som implementerar
    //IShoppingCartService.
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
