﻿using Blazored.SessionStorage;
using Microsoft.EntityFrameworkCore;
namespace PlantWebshopLogin.Data;

public class UserService
{
    private readonly ApplicationDbContext _context;
    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task UpdateUser(ApplicationUser user)
    {
        _context.Update(user);
        _context.SaveChanges();
    }

    //public async Task<ApplicationUser> GetUserProductsInfo(ApplicationUser user)
    //{
    //    return _context.Users.Include(u => u.UserProducts).First(u => user.Id == user.Id);
    //}

    public async Task<ApplicationUser> GetUser(ApplicationUser user)
    {
        //Hitta en användare på databasne med rätt Id
        return _context.Users.First(u => u.Id == user.Id);
    }
}
