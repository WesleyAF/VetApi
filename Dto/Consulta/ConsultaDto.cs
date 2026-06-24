namespace VetApi.Dto.Consulta
{
    public class ConsultaDto
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Diagnostico { get; set; }
        public int? AnimalId { get; set; } = null!;
        public int? VeterinarioId { get; set; } = null!;
    }
}
