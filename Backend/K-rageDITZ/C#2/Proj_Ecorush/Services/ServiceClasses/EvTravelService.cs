using Microsoft.EntityFrameworkCore;
using Proj_Ecorush.Models;
using Proj_Ecorush.Services.Interfaces;
using System.Collections.Generic;

namespace Proj_Ecorush.Services.ServiceClasses
{
    public class EvTravelService : IEVTravel
    {
        private EcoRushDbContext? _context;

        public EvTravelService(EcoRushDbContext? context)
        {
            _context = context;
        }

        public async Task<string> AddEVTravel(EvTravel evTravel)
        {
            evTravel.Status = "PENDING";
            _context.EvTravels.Add(evTravel);
            await _context.SaveChangesAsync();

            return "Travel saved Travel";
        }

        public async Task<List<EvTravel>> GetEVTravelByStatus(string status)
        {
            List<EvTravel> evTravels = await _context.EvTravels.ToListAsync();
            //Console.WriteLine(evTravels.ElementAt(0).Status);
            evTravels = evTravels.Where(travel => travel.Status == status.ToUpper()).ToList();
            if (evTravels == null)
            {
                throw new Exception();
            }

            return evTravels;
        }

        public async Task<List<EvTravel>> GetEVTravelByEmail(string email)
        {
            List<EvTravel> evTravels = await _context.EvTravels.ToListAsync();
            evTravels = evTravels.Where(travel => travel.EmailId == email).ToList();
            if (evTravels == null)
            {
                throw new Exception();
            }

            return evTravels;
        }

        public async Task<string> UpdateEVTravel(int activityID, string statusApproved)
        {
            var evTravel = await _context.EvTravels.FindAsync(activityID);

            if (evTravel == null)
            {
                throw new Exception();
            }

            evTravel.Status = statusApproved.ToUpper();

            if (evTravel.Status.ToUpper() == "APPROVED")
            {
                Userinfo? foundUser = await _context.Userinfos.FindAsync(evTravel.EmailId);
                if (foundUser != null)
                {
                    foundUser.CcPoints += evTravel.Ccawarded;
                }
            }

            await _context.SaveChangesAsync();

            return "update successfull";
        }
    }
}