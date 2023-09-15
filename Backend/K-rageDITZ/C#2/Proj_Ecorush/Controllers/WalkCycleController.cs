using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Proj_Ecorush.Models;
using Proj_Ecorush.Services.Interfaces;

namespace Proj_Ecorush.Controllers
{
    [Route("walk-cycle")]
    [ApiController]
    [EnableCors("CorsPolicy")] // Apply the CORS policy here
    public class WalkCycleController : ControllerBase
    {
        private readonly IWalkingCycle? _walkingCycles;

        public WalkCycleController(IWalkingCycle? walkingCycles)
        {
            _walkingCycles = walkingCycles;
        }

        [HttpGet("getAllActivities")]
        public async Task<ActionResult<List<WalkCycle>>> GetAllActivitiesWc()
        {
            var activities = await _walkingCycles.GetAllActivitiesWC();

            if (activities == null)
            {
                return NotFound("Activity list Empty");
            }

            return Ok(activities);
        }

        [HttpGet("getByEmail")]
        public async Task<ActionResult<List<WalkCycle>>> GetWCbyEmail(string email)
        {
            var activities = await _walkingCycles.GetWCbyEmail(email);

            if (activities == null)
            {
                return NotFound("Activity list empty");
            }

            return Ok(activities);
        }

        [HttpGet("getByStatus")]
        public async Task<ActionResult<List<WalkCycle>>> GetWCbyStatus(string status)
        {
            var activities = await _walkingCycles.GetWCbyStatus(status);

            if (activities == null)
            {
                return NotFound("Activity list empty");
            }

            return Ok(activities);
        }

        [HttpPost("addWalkCycle")]
        public async Task<ActionResult<string>> AddNewActivityWc(WalkCycle walkCycle)
        {
            return await _walkingCycles.AddNewActivityWC(walkCycle);
        }

        [HttpPut("updateWalkCycle")]
        public async Task<ActionResult<string>> UpdateActivityWc(int activityId, string statusApproved)
        {
            try
            {
                var activity = await _walkingCycles.UpdateActivityWC(activityId, statusApproved);
                return Ok("Updated Successfully");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}