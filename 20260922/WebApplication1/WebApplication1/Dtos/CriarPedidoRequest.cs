namespace WebApplication1.Dtos
{
    public sealed class CriarItemPedidoRequest
    {
        public string Produto { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
    }

    public sealed class CriarPedidoRequest
    {
        public string Cliente { get; set; } = string.Empty;
        public List<CriarItemPedidoRequest> Itens { get; set; } = [];
    }
}
