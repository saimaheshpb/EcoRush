using Microsoft.EntityFrameworkCore;
using Proj_Ecorush.Models;
using Proj_Ecorush.Services.Interfaces;

namespace Proj_Ecorush.Services.ServiceClasses;

public class CarpoolingService : ICarpooling
{
    private readonly EcoRushDbContext? _ecoRushDbContext;

    public async Task<string> AddCarpool(Carpooling carpooling)
    {
        if (carpooling == null)
        {
            // Handle the case where carpooling is null
            return "Carpooling object is null.";
        }
        
        Console.WriteLine(carpooling.ToString());
        carpooling.Status = "PENDING";
        _ecoRushDbContext.Carpoolings.Add(carpooling);
        await _ecoRushDbContext.SaveChangesAsync();

        return "Carpooling saved";
    }

    public async Task<List<Carpooling>> GetCarpoolingByEmail(string email)
    {
        List<Carpooling> cars = await _ecoRushDbContext.Carpoolings.ToListAsync();
        cars = cars.Where(car => car.EmailId == email).ToList();
        if (cars == null)
        {
            throw new Exception();
        }

        return cars;
    }

    public async Task<List<Carpooling>> GetCarpoolingByStatus(string status)
    {
        List<Carpooling> carpoolingList = await _ecoRushDbContext.Carpoolings.ToListAsync();
        //Console.WriteLine(evTravels.ElementAt(0).Status);
        carpoolingList = carpoolingList.Where(car => car.Status == status.ToUpper()).ToList();
        if (carpoolingList == null)
        {
            throw new Exception();
        }

        return carpoolingList;
    }

    public async Task<string> UpdateCarpooling(int activityID, string statusApproved)
    {
        var carpooling = await _ecoRushDbContext.Carpoolings.FindAsync(activityID);

        if (carpooling == null)
        {
            throw new Exception();
        }

        carpooling.Status = statusApproved.ToUpper();

        if (carpooling.Status == "APPROVED")
        {
            Userinfo? foundUser = await _ecoRushDbContext.Userinfos.FindAsync(carpooling.EmailId);
            if (foundUser != null)
            {
                foundUser.CcPoints += carpooling.Ccawarded;
            }
        }

        await _ecoRushDbContext.SaveChangesAsync();

        return "Update Successful";
    }
}