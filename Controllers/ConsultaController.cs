using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetApi.Dto.Consulta;
using VetApi.Dto.Dono;
using VetApi.Interfaces.Services;
using VetApi.Models;
using VetApi.Responses;
using VetApi.Services;

namespace VetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaInterface _consultaInterface;
        public ConsultaController(IConsultaInterface consultaInterface)
        {
            _consultaInterface = consultaInterface;
        }

        [HttpGet("ListarConsultas")]
        public async Task<ActionResult<ApiResponse<List<ConsultaModel>>>> ListarConsultas()
        {
            var response = await _consultaInterface.ListarConsultas();
            return Ok(response);
        }

        [HttpGet("BuscarConsultaPorId/{Id}")]
        public async Task<ActionResult<ApiResponse<ConsultaModel>>> BuscarConsultaPorId(int Id)
        {
            var response = await _consultaInterface.BuscarConsultaPorId(Id);
            return Ok(response);
        }

        [HttpPost("CriarConsulta")]
        public async Task<ActionResult<List<ApiResponse<ConsultaDto>>>> CriarDono(CreateConsultaDto createConsultaDto)
        {
            var response = await _consultaInterface.CriarConsulta(createConsultaDto);
            return Ok(response);
        }


        [HttpPut("AtualizarConsulta/{Id}")]
        public async Task<ActionResult<List<ApiResponse<ConsultaDto>>>> AtualizarConsulta(int Id, UpdateConsultaDto updateConsultaDto)
        {
            var response = await _consultaInterface.AtualizarConsulta(Id, updateConsultaDto);
            return Ok(response);
        }

        [HttpDelete("DeletarConsulta/{Id}")]
        public async Task<ActionResult<List<ApiResponse<DonoModel>>>> DeletarDono(int Id)
        {
            var response = await _consultaInterface.DeletarConsulta(Id);
            return Ok(response);
        }

    }
}
