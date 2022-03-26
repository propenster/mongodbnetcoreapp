using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDbNetcoreApp.Dtos;
using MongoDbNetcoreApp.Helpers;
using MongoDbNetcoreApp.Interfaces;
using MongoDbNetcoreApp.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace MongoDbNetcoreApp.Controllers.v1
{
    [ApiController]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/feedbacks")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse<string>))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(GenericResponse<string>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse<string>))]
    public class FeedbackController : ControllerBase
    {

        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }


        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<Feedback>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse<string>))]
        [SwaggerOperation(Summary = "To create a new feedback")]
        public async Task<IActionResult> OnBoardBusiness([FromBody] FeedbackDto feedback)
        {
            var result = await _feedbackService.InsertFeedback(feedback);

            return StatusCode((int)result.StatusCode, result);
        }

    }
}
