using VetApi.Models;

namespace VetApi.Dto.Consulta
{
    public class CreateConsultaDto
    {
        public DateTime Data { get; set; }
        public string Diagnostico { get; set; }
        public int Animal { get; set; }
        public int Veterinario { get; set; }
    }
}
