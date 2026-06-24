using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetApi.Dto.Animal;
using VetApi.Interfaces.Services;
using VetApi.Models;

namespace VetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalInterface _animalInterface;
        public AnimalController(IAnimalInterface animalInterface)
        {
            _animalInterface = animalInterface;
        }

        [HttpGet("ListarAnimais")]
        public async Task<ActionResult<List<AnimaisDto>>> ListarAnimais()
        {
            var animais = await _animalInterface.ListarAnimais();
            return Ok(animais);
        }
        [HttpGet("BuscarAnimalPorId/{Id}")]
        public async Task<ActionResult<AnimaisDto>> BuscarAnimalPorId(int Id)
        {
            var animais = await _animalInterface.BuscarAnimalPorId(Id);
            return Ok(animais);
        }

        [HttpPost("CriarAnimal")]
        public async Task<ActionResult<AnimaisDto>> CriarAnimal(CreateAnimalDto createAnimalDto)
        {
            var animais = await _animalInterface.CriarAnimal(createAnimalDto);
            return Ok(animais);
        }

        [HttpPut("AtualizarAnimal/{Id}")]
        public async Task<ActionResult<AnimaisDto>> AtualizarAnimal(int Id, UpdateAnimalDto updateAnimalDto)
        {
            var animais = await _animalInterface.AtualizarAnimal(Id, updateAnimalDto);
            return Ok(animais);
        }
        [HttpDelete("DeletarAnimal/{Id}")]
        public async Task<ActionResult<AnimaisDto>> DeletarAnimal(int Id)
        {
            var animais = await _animalInterface.DeletarAnimal(Id);
            return Ok(animais);
        }

        [HttpGet("{Id}/Consultas")]
        public async Task<ActionResult<AnimalModel>> ListarConsultasPorAnimal(int Id)
        {
            var animais = await _animalInterface.ListarConsultasPorAnimal(Id);
            return Ok(animais);
        }



    }
}
