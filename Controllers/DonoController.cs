
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VetApi.Interfaces.Services;
using VetApi.Models;
using VetApi.Responses;

namespace VetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonoController : ControllerBase
    {
        private readonly IDonoInterface _donoService;
        public DonoController(IDonoInterface donoService)
        {
            _donoService = donoService;
        }
        [HttpGet("ListarDonos")]
        public async Task<ActionResult<ApiResponse<List<DonoModel>>>> ListarDonos()
        {
            var response = await _donoService.ListarDonos();
            return Ok(response);
        }

    }
}
