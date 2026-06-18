using System.Text.Json.Serialization;

namespace VetApi.Models
{
    public class VeterinarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        
        [JsonIgnore]
        public List<ConsultaModel> Consultas { get; set; }

    }
}
