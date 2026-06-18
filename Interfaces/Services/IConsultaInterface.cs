using VetApi.Dto.Consulta;
using VetApi.Models;
using VetApi.Responses;

namespace VetApi.Interfaces.Services
{
    public interface IConsultaInterface
    {
        Task<ApiResponse<List<ConsultaModel>>> ListarConsultas();
        Task<ApiResponse<ConsultaModel>> BuscarConsultaPorId(int id);
        Task<ApiResponse<List<ConsultaModel>>> CriarConsulta(CreateConsultaDto createConsultaDto);
        Task<ApiResponse<List<ConsultaModel>>> AtualizarConsulta(int Id, UpdateConsultaDto updateConsultaDto);
        Task<ApiResponse<List<ConsultaModel>>> DeletarConsulta(int id);
    }
}
