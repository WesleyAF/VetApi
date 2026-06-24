using VetApi.Dto.Dono;
using VetApi.Models;
using VetApi.Responses;

namespace VetApi.Interfaces.Services
{
    public interface IDonoInterface
    {
        Task<ApiResponse<List<DonoModel>>> ListarDonos();
        Task<ApiResponse<DonoModel>> BuscarDonoPorId(int id);
        Task<ApiResponse<List<DonoModel>>> CriarDono(CreateDonoDto createDonoDto);
        Task<ApiResponse<List<DonoModel>>> AtualizarDono(int Id, UpdateDonoDto updateDonoDto);
        Task<ApiResponse<List<DonoModel>>> DeletarDono(int id);
        Task<ApiResponse<DonoAnimaisDto>> ListarAnimaisPorDono(int donoId);

    }
}
