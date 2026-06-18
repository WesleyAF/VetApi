using VetApi.Dto.Dono;
using VetApi.Interfaces.Repositories;
using VetApi.Interfaces.Services;
using VetApi.Models;
using VetApi.Responses;

namespace VetApi.Services
{
    public class DonoService : IDonoInterface
    {
        private readonly IDonoRepository _repository;

        public DonoService(IDonoRepository repository)
        {
            _repository = repository;
        }
        public async Task<ApiResponse<List<DonoModel>>> AtualizarDono(int Id, UpdateDonoDto updateDonoDto)
        {
            ApiResponse<List<DonoModel>> resposta = new ApiResponse<List<DonoModel>>();
            try
            {
                var dono = await _repository.GetById(Id);
                if (dono == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Dono não encontrado.";
                    return resposta;
                }
                dono.Nome = updateDonoDto.Nome;
                dono.Telefone = updateDonoDto.Telefone;

                _repository.Update(dono);

                await _repository.Save();



                resposta.Dados = await _repository.GetAll();
                resposta.Mensagem = "Dono atualizado com sucesso.";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ApiResponse<DonoModel>> BuscarDonoPorId(int id)
        {
            ApiResponse<DonoModel> resposta = new ApiResponse<DonoModel>();
            try
            {
                var dono = await _repository.GetById(id);
                if (dono == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Dono não encontrado.";
                    return resposta;
                }

                resposta.Dados = dono;
                resposta.Mensagem = "Dono localizado.";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ApiResponse<List<DonoModel>>> CriarDono(CreateDonoDto createDonoDto)
        {
            ApiResponse<List<DonoModel>> resposta = new ApiResponse<List<DonoModel>>();
            try
            {
                var dono = new DonoModel
                {
                    Nome = createDonoDto.Nome,
                    Telefone = createDonoDto.Telefone,
                };

                await _repository.Add(dono);
                await _repository.Save();

                resposta.Dados = await _repository.GetAll();
                resposta.Mensagem = "Dono salvo com sucesso";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ApiResponse<List<DonoModel>>> DeletarDono(int id)
        {
            ApiResponse<List<DonoModel>> resposta = new ApiResponse<List<DonoModel>>();
            try
            {
                var dono = await _repository.GetById(id);
                if (dono == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Dono não encontrado.";
                    return resposta;
                }

                _repository.Delete(dono);
                await _repository.Save();


                resposta.Dados = await _repository.GetAll();
                resposta.Mensagem = "Dono removido com sucesso.";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ApiResponse<DonoModel>> ListarAnimaisPorDono(int donoId)
        {
            ApiResponse<DonoModel> resposta = new ApiResponse<DonoModel>();
            try
            {
                var dono = await _repository.ListAnimalsByOwner(donoId);

                resposta.Dados = dono;
                resposta.Mensagem = "Donos listados com sucesso.";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ApiResponse<List<DonoModel>>> ListarDonos()
        {
            ApiResponse<List<DonoModel>> resposta = new ApiResponse<List<DonoModel>>();
            try
            {
                var donos = await _repository.GetAll();

                resposta.Dados = donos;
                resposta.Mensagem = "Donos listados com sucesso.";
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
