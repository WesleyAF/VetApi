using System.Text.Json.Serialization;
using VetApi.Models;

namespace VetApi.Dto.Veterinario
{
    public class VeterinarioConsultasDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public List<ConsultaModel> Consultas { get; set; }
    }
}
