namespace VetApi.Dto.Consulta
{
    public class UpdateConsultaDto
    {
        public DateTime Data { get; set; }
        public string Diagnostico { get; set; }
        public int Animal { get; set; }
        public int Veterinario { get; set; }
    }
}
