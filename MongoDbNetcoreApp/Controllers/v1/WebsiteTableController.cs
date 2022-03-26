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
    [Route("api/v{version:apiVersion}/websitetables")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse<string>))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(GenericResponse<string>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse<string>))]
    public class WebsiteTableController : ControllerBase
    {
        private readonly IWebsiteTableService _websiteTableService;

        public WebsiteTableController(IWebsiteTableService websiteTableService)
        {
            _websiteTableService = websiteTableService;
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<WebsiteTable>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse<string>))]
        [SwaggerOperation(Summary = "To create a new website table")]
        public async Task<IActionResult> OnBoardBusiness([FromBody] WebsiteTableDto websiteTable)
        {
            var result = await _websiteTableService.InsertWebsiteTable(websiteTable);

            return StatusCode((int)result.StatusCode, result);
        }
    }
}
