using Proj_Ecorush.Models;
using Proj_Ecorush.Services.Interfaces;

namespace Proj_Ecorush.Services.ServiceClasses;

public class UserService : IUser
{
    private readonly EcoRushDbContext? _ecoRushDbContext;

    public UserService(EcoRushDbContext ecoRushDbContext)
    {
        _ecoRushDbContext = ecoRushDbContext;
    }

    public async Task<string> AddUser(Userinfo userinfo)
    {
        userinfo.URole = userinfo.URole.ToUpper();
        userinfo.Password = BCrypt.Net.BCrypt.HashPassword(userinfo.Password);
        _ecoRushDbContext.Userinfos.Add(userinfo);
        await _ecoRushDbContext.SaveChangesAsync();

        return "Saved User! :D";
    }

    public async Task<Userinfo?> ValidateLogin(string emailId, string givenPassword)
    {
        Userinfo foundUser = await _ecoRushDbContext.Userinfos.FindAsync(emailId);

        if (foundUser != null)
        {
            if (BCrypt.Net.BCrypt.Verify(givenPassword, foundUser.Password))
                return foundUser;
        }

        return null;
    }

    public async Task<string?> AdminLogin(string emailId, string givenPassword)
    {
        Userinfo foundUser = await _ecoRushDbContext.Userinfos.FindAsync(emailId);

        if (foundUser != null && foundUser.URole.Equals("ADMIN"))
        {
            if (BCrypt.Net.BCrypt.Verify(givenPassword, foundUser.Password))
                return "ADMIN";
        }

        return null;
    }
}