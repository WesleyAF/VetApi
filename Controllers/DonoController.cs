
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VetApi.Dto.Dono;
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

        [HttpGet("BuscarDonoPorId/{IdDono}")]
        public async Task<ActionResult<ApiResponse<DonoModel>>> BuscarDonoPorId(int IdDono)
        {
            var response = await _donoService.BuscarDonoPorId(IdDono);
            return Ok(response);
        }

        [HttpPost("CriarDono")]
        public async Task<ActionResult<List<ApiResponse<DonoModel>>>> CriarDono(CreateDonoDto createDonoDto)
        {
            var response = await _donoService.CriarDono(createDonoDto);
            return Ok(response);
        }


        [HttpPut("AtualizarDono/{IdDono}")]
        public async Task<ActionResult<List<ApiResponse<DonoModel>>>> AtualizarDono(int IdDono, UpdateDonoDto updateDonoDto)
        {
            var response = await _donoService.AtualizarDono(IdDono, updateDonoDto);
            return Ok(response);
        }

        [HttpDelete("DeletarDono/{IdDono}")]
        public async Task<ActionResult<List<ApiResponse<DonoModel>>>> DeletarDono(int IdDono)
        {
            var response = await _donoService.DeletarDono(IdDono);
            return Ok(response);
        }

        [HttpGet("{IdDono}/animais")]
        public async Task<ActionResult<ApiResponse<DonoModel>>> ListarAnimaisPorDono(int IdDono)
        {
            var response = await _donoService.ListarAnimaisPorDono(IdDono);
            return Ok(response);
        }



        }
    }
