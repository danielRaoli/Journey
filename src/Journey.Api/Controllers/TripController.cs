using Journey.Application.UseCases.Trips.Activities.DeleteActivity;
using Journey.Application.UseCases.Trips.Activities.RegisterActivity;
using Journey.Application.UseCases.Trips.Activities.UpdateActivity;
using Journey.Application.UseCases.Trips.Delete;
using Journey.Application.UseCases.Trips.GetAll;
using Journey.Application.UseCases.Trips.GetById;
using Journey.Application.UseCases.Trips.Register;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Journey.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseTripJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] RequestRegisterTripJson request)
        {

            var useCase = new RegisterTripUseCase();

            var response = await useCase.Execute(request);

            return Created("", response);

        }


        [HttpGet]
        [ProducesResponseType(typeof(ResponseTripJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var useCase = new GetAllTripsUseCase();

            var response = await useCase.Execute();

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseTripJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var useCase = new GetByIdUseCase();
            var response = await useCase.Execute(id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseTripJson), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var useCase = new DeleteTripUseCase();
            await useCase.Execute(id);

            return NoContent();
        }

        [HttpPost("{tripId}/activity")]
        [ProducesResponseType(typeof(ResponseTripJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddActivity([FromRoute] Guid tripId, [FromBody] RequestRegisterActivityJson request)
        {
            var useCase = new RegisterActivityUseCase();
            var response = await useCase.Execute(tripId, request);

            return Created("", response);
        }

        [HttpPut("{tripId}/activity/{activityId}")]
        [ProducesResponseType(typeof(ResponseTripJson), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateActivityStatus([FromRoute] Guid tripId, [FromRoute] Guid activityId)
        {
            var useCase = new UpdateActivityStatusUseCase();
            await useCase.Execute(tripId, activityId);

            return NoContent();
        }

        [HttpDelete("{tripId}/activity/{activityId}")]
        [ProducesResponseType(typeof(ResponseTripJson), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteActivity([FromRoute] Guid tripId, [FromRoute] Guid activityId)
        {
            var useCase = new DeleteActivityUseCase();
            await useCase.Execute(tripId, activityId);

            return NoContent();
        }

    }
}
