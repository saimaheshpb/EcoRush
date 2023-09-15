using Proj_Ecorush.Models;

namespace Proj_Ecorush.Services.Interfaces;

public interface ICarpooling
{
    Task<String> AddCarpool(Carpooling carpooling);
    Task<List<Carpooling>> GetCarpoolingByStatus(string status);
    Task<List<Carpooling>> GetCarpoolingByEmail(string email);
    Task<string> UpdateCarpooling(int activityId, string statusApproved);
}