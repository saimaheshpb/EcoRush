using Proj_Ecorush.Models;

namespace Proj_Ecorush.Services.Interfaces;

public interface IEVTravel
{
    Task<String> AddEVTravel(EvTravel evTravel);
    Task<List<EvTravel>> GetEVTravelByStatus(string status);
    Task<List<EvTravel>> GetEVTravelByEmail(string email);
    Task<string> UpdateEVTravel(int activityID, string statusApproved);
}