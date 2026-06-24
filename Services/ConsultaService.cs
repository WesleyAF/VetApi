using VetApi.Dto.Consulta;
using VetApi.Interfaces.Repositories;
using VetApi.Interfaces.Services;
using VetApi.Mappers;
using VetApi.Models;
using VetApi.Repositories;
using VetApi.Responses;

namespace VetApi.Services
{
    public class ConsultaService : IConsultaInterface
    {
        private readonly IConsultaRepository _repository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IVeterinarioRepository _veterinarioRepository;
        public ConsultaService(IConsultaRepository repository, IAnimalRepository animalRepository, IVeterinarioRepository veterinarioRepository)
        {
            _repository = repository;
            _animalRepository = animalRepository;
            _veterinarioRepository = veterinarioRepository;
        }

        public async Task<ApiResponse<ConsultaDto>> AtualizarConsulta(int Id, UpdateConsultaDto updateConsultaDto)
        {
            ApiResponse<ConsultaDto> resposta = new ApiResponse<ConsultaDto>();
            try
            {
                var consulta = await _repository.GetById(Id);
                if (consulta == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Consulta não encontrada.";
                    return resposta;
                }
                if (updateConsultaDto.Animal.HasValue)
                {
                    var animal = await _animalRepository.GetById(updateConsultaDto.Animal.Value);
                    if (animal == null)
                    {
                        resposta.Status = false;
                        resposta.Mensagem = "Animal não encontrado.";
                        return resposta;
                    }
                    consulta.Animal = animal;
                }
                if(updateConsultaDto.Veterinario.HasValue)
                {
                    var veterinario = await _veterinarioRepository.GetById(updateConsultaDto.Veterinario.Value);
                    if (veterinario == null)
                    {
                        resposta.Status = false;
                        resposta.Mensagem = "Veterinário não encontrado.";
                        return resposta;
                    }
                    consulta.Veterinario = veterinario;
                }
                if (updateConsultaDto.Data.HasValue)
                {
                    consulta.Data = updateConsultaDto.Data.Value;
                }
                consulta.Diagnostico = updateConsultaDto.Diagnostico;
                _repository.Update(consulta);
                await _repository.Save();

                var consultaDto = ConsultaMapper.ToDto(consulta);



                resposta.Dados = consultaDto;
                resposta.Mensagem = "Consulta atualizada com sucesso.";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ApiResponse<ConsultaModel>> BuscarConsultaPorId(int id)
        {
            ApiResponse<ConsultaModel> resposta = new ApiResponse<ConsultaModel>();
            try
            {
                var consulta = await _repository.BuscarConsultaDonoVeterinario(id);
                if (consulta == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Consulta não encontrada.";
                    return resposta;
                }

                resposta.Dados = consulta;
                resposta.Mensagem = "Consulta encontrada com sucesso.";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ApiResponse<ConsultaDto>> CriarConsulta(CreateConsultaDto createConsultaDto)
        {
            ApiResponse<ConsultaDto> resposta = new ApiResponse<ConsultaDto>();
            try
            {
                var animal = await _animalRepository.GetById(createConsultaDto.Animal);
                if (animal == null)
                    {
                    resposta.Status = false;
                    resposta.Mensagem = "Animal não encontrado.";
                    return resposta;
                }
                var veterinario = await _veterinarioRepository.GetById(createConsultaDto.Veterinario);
                if (veterinario == null)
                    {
                    resposta.Status = false;
                    resposta.Mensagem = "Veterinário não encontrado.";
                    return resposta;
                }

                var consultaNova = ConsultaMapper.ToModel(createConsultaDto, animal, veterinario);
                await _repository.Add(consultaNova);
                await _repository.Save();

                var consultaDto = ConsultaMapper.ToDto(consultaNova);



                resposta.Dados = consultaDto;
                resposta.Mensagem = "Consulta criada com sucesso.";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ApiResponse<ConsultaDto>> DeletarConsulta(int id)
        {

            ApiResponse<ConsultaDto> resposta = new ApiResponse<ConsultaDto>();
            try
            {
                var consulta = await _repository.GetById(id);
                if (consulta == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Consulta não encontrada.";
                    return resposta;
                }
                 _repository.Delete(consulta);
                await _repository.Save();

                var consultaDto = ConsultaMapper.ToDto(consulta);

                resposta.Dados = consultaDto;
                resposta.Mensagem = "Consulta deletada com sucesso.";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ApiResponse<List<ConsultaModel>>> ListarConsultas()
        {
            ApiResponse<List<ConsultaModel>> resposta = new ApiResponse<List<ConsultaModel>>();
            try
            {
                var consultas = await _repository.GetAll();

                resposta.Dados = consultas;
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
