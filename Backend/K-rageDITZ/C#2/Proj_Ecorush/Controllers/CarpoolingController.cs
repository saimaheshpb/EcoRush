using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proj_Ecorush.Models;
using Proj_Ecorush.Services.Interfaces;

namespace Proj_Ecorush.Controllers
{
    [Route("carpooling")]
    [ApiController]
    [EnableCors("CorsPolicy")] // Apply the CORS policy here

    public class CarpoolingController : ControllerBase
    {
        private readonly ICarpooling? _carpooling;

        public CarpoolingController(ICarpooling? icarpooling)
        {
            _carpooling = icarpooling;
        }

        [HttpGet("getByEmail")]
        public async Task<ActionResult<List<Carpooling>>> GetCarPoolingByEmail(string email)
        {
            try
            {
                var carpool = await _carpooling.GetCarpoolingByEmail(email);
                return Ok(carpool);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("getByStatus")]
        public async Task<ActionResult<List<Carpooling>>> GetCarpoolingByStatus([FromQuery] string status)
        {
            //Console.WriteLine("in controller ", status);
            try
            {
                var carpool = await _carpooling.GetCarpoolingByStatus(status);
                return Ok(carpool);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("addCarpool")]
        public async Task<ActionResult<string>> AddCarpooling(Carpooling carpooling)
        {
            var students = await _carpooling.AddCarpool(carpooling);

            return "added successfully";
        }

        [HttpPut("updateCarpool")]
        public async Task<ActionResult<string>> UpdateCarpooling(int activityId, string statusApproved)
        {
            try
            {
                var upTravel = await _carpooling.UpdateCarpooling(activityId, statusApproved);
                return Ok(upTravel);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}