using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Proj_Ecorush.Models;
using Proj_Ecorush.Services.Interfaces;

namespace Proj_Ecorush.Controllers
{
    [Route("afforestation")]
    [ApiController]
    [EnableCors("CorsPolicy")] // Apply the CORS policy here
    public class AfforestationController : ControllerBase
    {
        private readonly IAfforestation? _afforestation;

        public AfforestationController(IAfforestation? afforestations)
        {
            _afforestation = afforestations;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<Afforestation>>> GetAllActivitiesAf()
        {
            var activities = await _afforestation.GetAllActivitiesAf();

            if (activities != null)
            {
                return Ok(activities);
            }

            return NotFound("Activity list Empty");
        }

        [HttpGet("getAFByEmail")]
        public async Task<ActionResult<List<Afforestation>>> GetAFbyEmail(string email)
        {
            var activities = await _afforestation.GetAFbyEmail(email);

            if (activities == null)
            {
                return NotFound("Activity list empty");
            }

            return Ok(activities);
        }

        [HttpGet("getAFByStatus")]
        public async Task<ActionResult<List<Afforestation>>> GetAFbyStatus(string status)
        {
            var activities = await _afforestation.GetAFbyStatus(status);

            if (activities == null)
            {
                return NotFound("Activity list empty");
            }

            return Ok(activities);
        }

        [HttpPost("addAfforestation")]
        public async Task<ActionResult<string>> AddNewActivityAf(Afforestation afforestation)
        {
            return await _afforestation.AddNewActivityAf(afforestation);
        }

        [HttpPut("updateAfforestation")]
        public async Task<ActionResult<string>> UpdateActivityAf(int activityId, string statusApproved)
        {
            try
            {
                var activity = await _afforestation.UpdateActivityAf(activityId, statusApproved);
                return Ok("Updated Successfully");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}