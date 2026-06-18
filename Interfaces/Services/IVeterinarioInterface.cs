using VetApi.Dto.Veterinario;
using VetApi.Models;
using VetApi.Responses;

namespace VetApi.Interfaces.Services
{
    public interface IVeterinarioInterface
    {
        Task<ApiResponse<List<VeterinarioModel>>> ListarVeterinarios();
        Task<ApiResponse<VeterinarioModel>> BuscarVeterinarioPorId(int id);
        Task<ApiResponse<List<VeterinarioModel>>> CriarVeterinario(CreateVeterinarioDto createVeterinarioDto);
        Task<ApiResponse<List<VeterinarioModel>>> AtualizarVeterinario(int Id, UpdateVeterinarioDto updateVeterinarioDto);
        Task<ApiResponse<List<VeterinarioModel>>> DeletarVeterinario(int id);
        Task<ApiResponse<List<ConsultaModel>>> ListarConsultasPorVeterinario(int veterinarioId);
       
    }
}
