using VetApi.Dto.Consulta;
using VetApi.Models;
using VetApi.Responses;

namespace VetApi.Interfaces.Services
{
    public interface IConsultaInterface
    {
        Task<ApiResponse<List<ConsultaModel>>> ListarConsultas();
        Task<ApiResponse<ConsultaModel>> BuscarConsultaPorId(int id);
        Task<ApiResponse<ConsultaDto>> CriarConsulta(CreateConsultaDto createConsultaDto);
        Task<ApiResponse<ConsultaDto>> AtualizarConsulta(int Id, UpdateConsultaDto updateConsultaDto);
        Task<ApiResponse<ConsultaDto>> DeletarConsulta(int id);
    }
}
