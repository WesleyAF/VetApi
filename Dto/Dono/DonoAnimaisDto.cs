using VetApi.Dto.Animal;
using VetApi.Models;

namespace VetApi.Dto.Dono
{
    public class DonoAnimaisDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public List<AnimaisDto> Animais { get; set; }
    }
}
