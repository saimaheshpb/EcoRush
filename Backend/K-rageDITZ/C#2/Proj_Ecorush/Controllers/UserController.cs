using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Proj_Ecorush.Models;
using Proj_Ecorush.Services.Interfaces;

namespace Proj_Ecorush.Controllers;

[Route("user")]
[ApiController]
[EnableCors("CorsPolicy")] // Apply the CORS policy here
public class UserController: ControllerBase
{
    private readonly IUser _user;

    public UserController(IUser user)
    {
        _user = user;
    }

    [HttpPost("register")]
    public async Task<string?> AddUser([FromBody] Userinfo userinfo)
    {
        try
        {
            await _user.AddUser(userinfo);
            return "User Registered Successfully!";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            // throw;
            return BadRequest(e.Message).ToString();
        }
    }

    [HttpGet("login")]
    public async Task<ActionResult<Userinfo?>> ValidateLogin([FromQuery] string emailId, [FromQuery] string password)
    {
        try
        { 
            Userinfo? foundUser = await _user.ValidateLogin(emailId, password);
            if (foundUser != null)
                return Ok(foundUser);
            else
                return Unauthorized();
        }
        catch (Exception e)
        {
            Console.WriteLine(e); 
            return StatusCode(500, "Internal Server Error");

        }
    }

    [HttpGet("adminLogin")]
    public async Task<ActionResult<string>> AdminLogin([FromQuery] string emailId, [FromQuery] string password)
    {
        try
        {
            string? adminLogin = await _user.AdminLogin(emailId, password);
            if (adminLogin != null)
                return Ok("ADMIN");
            return BadRequest("LOGIN FAILED");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}