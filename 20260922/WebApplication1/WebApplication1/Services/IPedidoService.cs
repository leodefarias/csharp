using WebApplication1.Dtos;

namespace WebApplication1.Services
{
    public interface IPedidoService
    {
        Task<OperacaoResultado<PedidoResponse>> CriarAsync(CriarPedidoRequest request);
        Task<IReadOnlyList<PedidoResponse>> ListarAsync();
        Task<PedidoResponse?> ObterAsync(int id);
        Task<OperacaoResultado<PedidoResponse>> AtualizarAsync(int id, AtualizarPedidoRequest request);
        Task<OperacaoResultado> DesativarAsync(int id);
        Task<OperacaoResultado<PedidoResponse>> FecharAsync(int id);
        Task<OperacaoResultado<ImportacaoResponse>> ImportarAsync(IReadOnlyList<CriarPedidoRequest>? pedidos);
        Task<IReadOnlyList<ResumoStatusResponse>> ObterResumoAsync();
    }
}
