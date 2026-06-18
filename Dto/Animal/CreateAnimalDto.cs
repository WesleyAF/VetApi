using VetApi.Models;

namespace VetApi.Dto.Animal
{
    public class CreateAnimalDto
    {
        public string Nome { get; set; }
        public string Especie { get; set; }
        public int Idade { get; set; }
        public int Dono { get; set; }
    }
}
