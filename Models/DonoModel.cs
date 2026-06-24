using System.Text.Json.Serialization;

namespace VetApi.Models
{
    public class DonoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
     
        public List<AnimalModel> Animais { get; set; }

    }
}
