using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Model;
using WBizTrip.Services.Abstractions;

namespace WBizTrip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ITripService _tripService;

        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Trip>> GetTrips()
        {
            try
            {
                var trips = _tripService.GetTrips();
                return Ok(trips);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Trip> GetTripById(int id)
        {
            try
            {
                var trips = _tripService.GetTripById(id);
                return Ok(trips);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("add-trip")]
        public IActionResult CreateTrip([FromBody] TripDto tripDto)
        {
            try
            {
                _tripService.CreateTrip(tripDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        [HttpPatch("update/{id}")]
        public async Task<IActionResult> PatchTrip([FromRoute] int id, [FromBody] JsonPatchDocument<TripDto> tripDocument)
        {
            var updatedTrip = await _tripService.UpdateTripPatchAsync(id, tripDocument);
            if (updatedTrip == null)
            {
                return NotFound();
            }
            return Ok(updatedTrip);
        }
    }
}
