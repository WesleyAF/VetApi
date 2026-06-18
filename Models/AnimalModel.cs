using System.Text.Json.Serialization;

namespace VetApi.Models
{
    public class AnimalModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public int Idade { get; set; }
        public DonoModel Dono { get; set; }

        [JsonIgnore]

        public List<ConsultaModel> Consultas { get; set; }
    }
}
