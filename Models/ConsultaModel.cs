using Microsoft.Identity.Client;
using System.Text.Json.Serialization;

namespace VetApi.Models
{
    public class ConsultaModel
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Diagnostico { get; set; }
        [JsonIgnore]
        public AnimalModel Animal { get; set; }
        public VeterinarioModel Veterinario { get; set; }

      

    }
}
