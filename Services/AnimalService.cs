using VetApi.Dto.Animal;
using VetApi.Interfaces.Repositories;
using VetApi.Interfaces.Services;
using VetApi.Mappers;
using VetApi.Models;
using VetApi.Responses;

namespace VetApi.Services
{
    public class AnimalService : IAnimalInterface
    {
        private readonly IAnimalRepository _repository;
        private readonly IDonoRepository _donoRepository;
        public AnimalService(IAnimalRepository repository, IDonoRepository donoRepository)
        {
            _repository = repository;
            _donoRepository = donoRepository;
        }
        public async Task<ApiResponse<AnimaisDto>> AtualizarAnimal(int Id, UpdateAnimalDto updateAnimalDto)
        {
            ApiResponse<AnimaisDto> resposta = new ApiResponse<AnimaisDto>();
            try
            {
                var animal = await _repository.GetById(Id);
                if (animal == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Animal não encontrado.";
                    return resposta;
                }
                if (updateAnimalDto.Dono.HasValue)
                {
                    var dono = await _donoRepository.GetById(updateAnimalDto.Dono.Value);

                    if (dono == null)
                    {
                        resposta.Status = false;
                        resposta.Mensagem = "Dono não encontrado.";
                        return resposta;
                    }

                    animal.Dono = dono;

                }

                animal.Nome = updateAnimalDto.Nome;
                animal.Especie = updateAnimalDto.Especie;
                animal.Idade = updateAnimalDto.Idade;


                _repository.Update(animal);
                await _repository.Save();



                var animaisDto = AnimalMapper.ToDto(animal);

                resposta.Dados = animaisDto;
                resposta.Mensagem = "Animal atualizado com sucesso.";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }

        }

        public async Task<ApiResponse<AnimaisDto>> BuscarAnimalPorId(int id)
        {
            ApiResponse<AnimaisDto> resposta = new ApiResponse<AnimaisDto>();
            try
            {
                var animal = await _repository.GetById(id);
                if (animal == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Animal não encontrado.";
                    return resposta;
                }


                var animaisDto = AnimalMapper.ToDto(animal);


                resposta.Dados = animaisDto;
                resposta.Mensagem = "Animal encontrado com sucesso.";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ApiResponse<AnimaisDto>> CriarAnimal(CreateAnimalDto createAnimalDto)
        {
            ApiResponse<AnimaisDto> resposta = new ApiResponse<AnimaisDto>();
            try
            {
                var dono = await _donoRepository.GetById(createAnimalDto.Dono);
                if (dono == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Dono não encontrado.";
                    return resposta;
                }
                var NovoAnimal = AnimalMapper.ToModel(createAnimalDto, dono);
                await _repository.Add(NovoAnimal);
                await _repository.Save();

                resposta.Dados = AnimalMapper.ToDto(NovoAnimal);
                resposta.Mensagem = "Animal salvo com sucesso.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ApiResponse<AnimaisDto>> DeletarAnimal(int id)
        {
            ApiResponse<AnimaisDto> resposta = new ApiResponse<AnimaisDto>();
            try
            {
                var animal = await _repository.GetById(id);
                if (animal == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Animal não encontrado.";
                    return resposta;
                }
                _repository.Delete(animal);
                await _repository.Save();

                var animaisDto = AnimalMapper.ToDto(animal);

                resposta.Dados = animaisDto;
                resposta.Mensagem = "Animal deletado com sucesso.";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ApiResponse<List<AnimaisDto>>> ListarAnimais()
        {
            ApiResponse<List<AnimaisDto>> resposta = new ApiResponse<List<AnimaisDto>>();
            try
            {
                var animais = await _repository.GetAll();

                var Dto = animais.Select(AnimalMapper.ToDto).ToList();

                resposta.Dados = Dto;
                resposta.Mensagem = "Animais listados com sucesso.";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ApiResponse<AnimalModel>> ListarConsultasPorAnimal(int animalId)
        {
            ApiResponse<AnimalModel> resposta = new ApiResponse<AnimalModel>();
            try
            {
                var animal = await _repository.ListConsultasByAnimal(animalId);
                if (animal == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Animal não encontrado.";
                    return resposta;
                }



                resposta.Dados = animal;
                resposta.Mensagem = "Consultas listadas com sucesso.";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }
    }
}
