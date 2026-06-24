using VetApi.Data;
using VetApi.Dto.Veterinario;
using VetApi.Interfaces.Repositories;
using VetApi.Interfaces.Services;
using VetApi.Models;
using VetApi.Responses;

namespace VetApi.Services
{
    public class VeterinarioService : IVeterinarioInterface
    {
        private readonly IVeterinarioRepository _repository;

        public VeterinarioService(IVeterinarioRepository repository)
        {
            _repository = repository;
        }
        public async Task<ApiResponse<VeterinarioModel>> AtualizarVeterinario(int Id, UpdateVeterinarioDto updateVeterinarioDto)
        {
            ApiResponse<VeterinarioModel> resposta = new ApiResponse<VeterinarioModel>();
            try
            {
                var veterinario = await _repository.GetById(Id);
                if (veterinario == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Veterinario não encontrado.";
                    return resposta;
                }
                veterinario.Nome = updateVeterinarioDto.Nome;
                veterinario.Sobrenome = updateVeterinarioDto.Sobrenome;

                _repository.Update(veterinario);
                await _repository.Save();

                resposta.Dados = veterinario;
                resposta.Mensagem = "Veterinario atualizado com sucesso.";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ApiResponse<VeterinarioModel>> BuscarVeterinarioPorId(int id)
        {
            ApiResponse<VeterinarioModel> resposta = new ApiResponse<VeterinarioModel>();
            try
            {
                var veterinario = await _repository.GetById(id);
                if (veterinario == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Veterinario não encontrado.";
                    return resposta;
                }

                resposta.Dados = veterinario;
                resposta.Mensagem = "Veterinario localizado com sucesso.";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ApiResponse<VeterinarioModel>> CriarVeterinario(CreateVeterinarioDto createVeterinarioDto)
        {
            ApiResponse<VeterinarioModel> resposta = new ApiResponse<VeterinarioModel>();
            try
            {
                var veterinarioNovo = new VeterinarioModel
                {
                    Nome = createVeterinarioDto.Nome,
                    Sobrenome = createVeterinarioDto.Sobrenome,
                };
                await _repository.Add(veterinarioNovo);
                await _repository.Save();

                resposta.Dados = veterinarioNovo;
                resposta.Mensagem = "Veterinario salvo com sucesso.";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ApiResponse<VeterinarioModel>> DeletarVeterinario(int id)
        {
            ApiResponse<VeterinarioModel> resposta = new ApiResponse<VeterinarioModel>();
            try
            {
                var veterinario = await _repository.GetById(id);
                if (veterinario == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Veterinario não encontrado.";
                    return resposta;
                }
                _repository.Delete(veterinario);
                await _repository.Save();

                resposta.Dados = veterinario;
                resposta.Mensagem = "Veterinario deletado com sucesso.";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ApiResponse<VeterinarioConsultasDto>> ListarConsultasPorVeterinario(int veterinarioId)
        {
            ApiResponse<VeterinarioConsultasDto> resposta = new ApiResponse<VeterinarioConsultasDto>();
            try
            {
                var veterinario = await _repository.GetVeterinariosWithConsultas(veterinarioId);
                if (veterinario == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Veterinario não encontrado.";
                    return resposta;
                }
                var veterinarioDto = new VeterinarioConsultasDto
                {
                    Id = veterinario.Id,
                    Nome = veterinario.Nome,
                    Sobrenome = veterinario.Sobrenome,
                    Consultas = veterinario.Consultas,
                };

                resposta.Dados = veterinarioDto;
                resposta.Mensagem = "consultas listadas com sucesso.";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ApiResponse<List<VeterinarioModel>>> ListarVeterinarios()
        {
            ApiResponse<List<VeterinarioModel>> resposta = new ApiResponse<List<VeterinarioModel>>();
            try
            {
                var veterinarios = await _repository.GetAll();

                resposta.Dados = veterinarios;
                resposta.Mensagem = "Veterinarios listados com sucesso.";
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
