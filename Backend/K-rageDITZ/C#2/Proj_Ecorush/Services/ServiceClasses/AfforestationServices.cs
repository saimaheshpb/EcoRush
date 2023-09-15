using Microsoft.EntityFrameworkCore;
using Proj_Ecorush.Models;
using Proj_Ecorush.Services.Interfaces;

namespace Proj_Ecorush.Services.ServiceClasses
{
    public class AfforestationServices : IAfforestation
    {
        private readonly EcoRushDbContext? _context;

        public AfforestationServices(EcoRushDbContext? context)
        {
            _context = context;
        }

        public async Task<string> AddNewActivityAf(Afforestation afforestation)
        {
            afforestation.Status = "PENDING";
            _context.Afforestations.Add(afforestation);
            await _context.SaveChangesAsync();

            return "Activity successfully saved";
        }

        public async Task<List<Afforestation>> GetAFbyStatus(string status)
        {
            List<Afforestation> afforestation = await _context.Afforestations.ToListAsync();
            afforestation = afforestation.Where(wc => wc.Status == status.ToUpper()).ToList();

            if (afforestation == null)
            {
                throw new Exception();
            }

            return afforestation;
        }

        public async Task<List<Afforestation>> GetAllActivitiesAf()
        {
            List<Afforestation> afforestations = await _context.Afforestations.ToListAsync();
            return afforestations;
        }

        public async Task<List<Afforestation>> GetAFbyEmail(string email)
        {
            List<Afforestation> afforestations = await _context.Afforestations.ToListAsync();
            afforestations = afforestations.Where(wc => wc.EmailId == email).ToList();

            if (afforestations == null)
            {
                throw new Exception();
            }

            return afforestations;
        }

        public async Task<string> UpdateActivityAf(int activityId, string statusApproved)
        {
            var afforestation1 = await _context.Afforestations.FindAsync(activityId);

            if (afforestation1 == null)
            {
                throw new Exception();
            }

            afforestation1.Status = statusApproved.ToUpper();


            if (afforestation1.Status.ToUpper() == "APPROVED")
            {
                Userinfo? foundUser = await _context.Userinfos.FindAsync(afforestation1.EmailId);
                if (foundUser != null)
                {
                    foundUser.CcPoints += afforestation1.Ccawarded;
                }
            }

            await _context.SaveChangesAsync();
            return "update successful";
        }
    }
}