using VetApi.Dto.Animal;
using VetApi.Models;

namespace VetApi.Mappers
{
    public class AnimalMapper
    {
      
        public static AnimaisDto ToDto(AnimalModel animal)
        {
            return new AnimaisDto
            {
                Id = animal.Id,
                Nome = animal.Nome,
                Especie = animal.Especie,
                Idade = animal.Idade,
            };
        }

     
        public static AnimalModel ToModel(CreateAnimalDto dto, DonoModel dono)
        {
            return new AnimalModel
            {
                Nome = dto.Nome,
                Especie = dto.Especie,
                Idade = dto.Idade,
                Dono = dono
            };
        }
    }
}
