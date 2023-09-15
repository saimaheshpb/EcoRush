using Proj_Ecorush.Models;

namespace Proj_Ecorush.Services.Interfaces
{
    public interface IAfforestation
    {
        Task<List<Afforestation>> GetAllActivitiesAf();
        Task<List<Afforestation>> GetAFbyEmail(string email);
        Task<string> AddNewActivityAf(Afforestation afforestation);
        Task<string> UpdateActivityAf(int activityId, string statusApproved);
        Task<List<Afforestation>> GetAFbyStatus(string status);
    }
}