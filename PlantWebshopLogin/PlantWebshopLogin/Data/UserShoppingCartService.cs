using Blazored.LocalStorage;
using PlantWebshopLogin.Models;

namespace PlantWebshopLogin.Data;

public class UserShoppingCartService
{
    private readonly ILocalStorageService _localStorage;

    public UserShoppingCartService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    ApplicationUser user;

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

}
