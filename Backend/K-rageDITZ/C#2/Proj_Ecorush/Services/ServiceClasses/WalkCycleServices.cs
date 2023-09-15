using Microsoft.EntityFrameworkCore;
using Proj_Ecorush.Models;
using Proj_Ecorush.Services.Interfaces;

namespace Proj_Ecorush.Services.ServiceClasses
{
    public class WalkCycleServices : IWalkingCycle
    {
        private readonly EcoRushDbContext? _context;

        public WalkCycleServices(EcoRushDbContext? context)
        {
            _context = context;
        }

        public async Task<string> AddNewActivityWC(WalkCycle walkCycle)
        {
            walkCycle.Status = "PENDING";
            _context.WalkCycles.Add(walkCycle);
            await _context.SaveChangesAsync();

            return "Activity successfully saved";
        }

        public async Task<List<WalkCycle>> GetWCbyStatus(string status)
        {
            List<WalkCycle> walkCycles = await _context.WalkCycles.ToListAsync();
            walkCycles = walkCycles.Where(wc => wc.Status == status.ToUpper()).ToList();

            if (walkCycles == null)
            {
                throw new Exception();
            }

            return walkCycles;
        }

        public async Task<List<WalkCycle>> GetAllActivitiesWC()
        {
            List<WalkCycle> walkCycles = await _context.WalkCycles.ToListAsync();
            return walkCycles;
        }

        public async Task<List<WalkCycle>> GetWCbyEmail(string email)
        {
            List<WalkCycle> walkCycles = await _context.WalkCycles.ToListAsync();
            walkCycles = walkCycles.Where(wc => wc.EmailId == email).ToList();

            if (walkCycles == null)
            {
                throw new Exception();
            }

            return walkCycles;
        }

        public async Task<string> UpdateActivityWC(int activityId, string statusApproved)
        {
            var walkCycles = await _context.WalkCycles.FindAsync(activityId);


            if (walkCycles == null)
            {
                throw new Exception();
            }

            walkCycles.Status = statusApproved.ToUpper();

            if (walkCycles.Status.ToUpper() == "APPROVED")
            {
                Userinfo? foundUser = await _context.Userinfos.FindAsync(walkCycles.EmailId);
                if (foundUser != null)
                {
                    foundUser.CcPoints += walkCycles.Ccawarded;
                }
            }

            await _context.SaveChangesAsync();

            return "update successful";
        }
    }
}