using VetApi.Dto.Animal;
using VetApi.Dto.Consulta;
using VetApi.Models;

namespace VetApi.Mappers
{
    public class ConsultaMapper
    {
        public static ConsultaDto ToDto(ConsultaModel consulta)
        {
            return new ConsultaDto
            {
                Id = consulta.Id,
                Data = consulta.Data,
                Diagnostico = consulta.Diagnostico,
                AnimalId = consulta.Animal?.Id,
                VeterinarioId = consulta.Veterinario?.Id
            };
        }


        public static ConsultaModel ToModel(CreateConsultaDto dto, AnimalModel animal, VeterinarioModel veterinario)
        {
            return new ConsultaModel
            {
                Data = dto.Data,
                Diagnostico = dto.Diagnostico,
                Animal = animal,
                Veterinario = veterinario
            };
        }
    }
}
