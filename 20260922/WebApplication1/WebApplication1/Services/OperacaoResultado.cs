namespace WebApplication1.Services
{
    public class OperacaoResultado
    {
        public bool Sucesso { get; init; }
        public int Status { get; init; }
        public string? Mensagem { get; init; }

        public static OperacaoResultado Ok(int status = StatusCodes.Status200OK) =>
            new() { Sucesso = true, Status = status };

        public static OperacaoResultado Falha(int status, string mensagem) =>
            new() { Sucesso = false, Status = status, Mensagem = mensagem };
    }

    public sealed class OperacaoResultado<T> : OperacaoResultado
    {
        public T? Dados { get; init; }

        public static OperacaoResultado<T> Ok(T dados, int status = StatusCodes.Status200OK) =>
            new() { Sucesso = true, Status = status, Dados = dados };

        public new static OperacaoResultado<T> Falha(int status, string mensagem) =>
            new() { Sucesso = false, Status = status, Mensagem = mensagem };
    }
}
