using Proj_Ecorush.Models;

namespace Proj_Ecorush.Services.Interfaces;

public interface IUser
{
    Task<string> AddUser(Userinfo userinfo);
    Task<Userinfo?> ValidateLogin(string emailId, string password);
    Task<string?> AdminLogin(string emailId, string password);
}