using VetApi.Dto.Veterinario;
using VetApi.Models;
using VetApi.Responses;

namespace VetApi.Interfaces.Services
{
    public interface IVeterinarioInterface
    {
        Task<ApiResponse<List<VeterinarioModel>>> ListarVeterinarios();
        Task<ApiResponse<VeterinarioModel>> BuscarVeterinarioPorId(int id);
        Task<ApiResponse<VeterinarioModel>> CriarVeterinario(CreateVeterinarioDto createVeterinarioDto);
        Task<ApiResponse<VeterinarioModel>> AtualizarVeterinario(int Id, UpdateVeterinarioDto updateVeterinarioDto);
        Task<ApiResponse<VeterinarioModel>> DeletarVeterinario(int id);
        Task<ApiResponse<VeterinarioConsultasDto>> ListarConsultasPorVeterinario(int veterinarioId);
       
    }
}
