namespace VetApi.Responses
{
    public class ApiResponse<T>
    {
        public T? Dados;
        public string? Mensagem;
        public bool Status = true;
    }
}
