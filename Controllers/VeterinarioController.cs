using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetApi.Dto.Animal;
using VetApi.Dto.Veterinario;
using VetApi.Interfaces.Services;
using VetApi.Models;

namespace VetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinarioController : ControllerBase
    {
        private readonly IVeterinarioInterface _veterinarioInterface;
        public VeterinarioController(IVeterinarioInterface veterinarioInterface)
        {
            _veterinarioInterface = veterinarioInterface;
        }


        [HttpGet("ListarVeterinarios")]
        public async Task<ActionResult<List<VeterinarioModel>>> ListarVeterinarios()
        {
            var veterinarios = await _veterinarioInterface.ListarVeterinarios();
            return Ok(veterinarios);
        }
        [HttpGet("BuscarVeterinarioPorId/{Id}")]
        public async Task<ActionResult<VeterinarioModel>> BuscarVeterinarioPorId(int Id)
        {
            var veterinario = await _veterinarioInterface.BuscarVeterinarioPorId(Id);
            return Ok(veterinario);
        }

        [HttpPost("CriarVeterinario")]
        public async Task<ActionResult<VeterinarioModel>> CriarVeterinario(CreateVeterinarioDto createVeterinarioDto)
        {
            var veterinario = await _veterinarioInterface.CriarVeterinario(createVeterinarioDto);
            return Ok(veterinario);
        }

        [HttpPut("AtualizarVeterinario/{Id}")]
        public async Task<ActionResult<VeterinarioModel>> AtualizarVeterianrio(int Id, UpdateVeterinarioDto updateVeterinarioDto)
        {
            var veterinario = await _veterinarioInterface.AtualizarVeterinario(Id, updateVeterinarioDto);
            return Ok(veterinario);
        }
        [HttpDelete("DeletarVeterinario/{Id}")]
        public async Task<ActionResult<VeterinarioModel>> DeletarVeterinario(int Id)
        {
            var veterinario = await _veterinarioInterface.DeletarVeterinario(Id);
            return Ok(veterinario);
        }

        [HttpGet("{Id}/Consultas")]
        public async Task<ActionResult<VeterinarioConsultasDto>> ListarConsultasPorVeterinario(int Id)
        {
            var veterinario = await _veterinarioInterface.ListarConsultasPorVeterinario(Id);
            return Ok(veterinario);
        }

    }
}
