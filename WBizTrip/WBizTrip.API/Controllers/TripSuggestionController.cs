using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Model;
using WBizTrip.Services.Abstractions;

namespace WBizTrip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripSuggestionController : ControllerBase
    {
        private readonly ITripSuggestionService _tripSuggestionService;

        public TripSuggestionController(ITripSuggestionService tripSuggestionService)
        {
            _tripSuggestionService = tripSuggestionService;
        }

        [HttpGet("{tripId}")]
        public ActionResult<IEnumerable<TripSuggestionDto>> GetTripSuggestionsByTripId(int tripId)
        {
            try
            {
                var tripSuggestionsDto = _tripSuggestionService.GetTripSuggestionsByTripId(tripId);
                return Ok(tripSuggestionsDto);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{tripId}/{tripSuggestionId}")]
        public ActionResult<TripSuggestion> GetTripSuggestionByTripId(int tripId,int tripSuggestionId)
        {
            try
            {
                var trips = _tripSuggestionService.GetTripSuggestionByTripId(tripId, tripSuggestionId);
                return Ok(trips);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("create")]
        public IActionResult CreateTripSuggestion([FromBody] TripSuggestionDto tripSuggestionDto)
        {
            try
            {
                _tripSuggestionService.CreateTripSuggestion(tripSuggestionDto);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPatch("update/{id}")]
        public IActionResult PatchTripSuggestion(int id, [FromBody] JsonPatchDocument<TripSuggestionDto> tripSuggestionDoc)
        {
            try
            {
                _tripSuggestionService.UpdatePatchTripSuggestion(id, tripSuggestionDoc);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
