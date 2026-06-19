namespace VetApi.Responses
{
    public class ApiResponse<T>
    {
        public T? Dados { get; set; }
        public string? Mensagem { get; set; }
        public bool Status { get; set; } = true;
    }
}
