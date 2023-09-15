using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proj_Ecorush.Models;
using Proj_Ecorush.Services.Interfaces;

namespace Proj_Ecorush.Controllers
{
    [Route("evTravel")]
    [ApiController]
    [EnableCors("CorsPolicy")] // Apply the CORS policy here
    public class EvTravelController : ControllerBase
    {
        private readonly IEVTravel? _eVTravel;

        public EvTravelController(IEVTravel? eVTravel)
        {
            _eVTravel = eVTravel;
        }

        [HttpGet("getByEmail")]
        public async Task<ActionResult<List<EvTravel>>> GetEvTravelByEmail(string email)
        {
            try
            {
                var evTravel = await _eVTravel.GetEVTravelByEmail(email);
                return Ok(evTravel);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("getEVByStatus")]
        public async Task<ActionResult<List<EvTravel>>> GetEvTravelByStatus([FromQuery] string status)
        {
            Console.WriteLine("in controller ", status);
            try
            {
                var evtravel = await _eVTravel.GetEVTravelByStatus(status);
                return Ok(evtravel);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("addEvTravel")]
        public async Task<ActionResult<string>> AddEvTravel(EvTravel evTravel)
        {
            var students = await _eVTravel.AddEVTravel(evTravel);

            return "added successfully";
        }

        [HttpPut("updateEvTravel")]
        public async Task<ActionResult<string>> UpdateEvTravel(int activityId, string statusApproved)
        {
            try
            {
                var updateEvTravel = await _eVTravel.UpdateEVTravel(activityId, statusApproved);
                return Ok(updateEvTravel);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}