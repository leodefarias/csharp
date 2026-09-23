using WebApplication1.Models;

namespace WebApplication1.Dtos
{
    public sealed class ItemPedidoResponse
    {
        public int Id { get; set; }
        public string Produto { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
    }

    public sealed class PedidoResponse
    {
        public int Id { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public StatusPedido Status { get; set; }
        public decimal Total { get; set; }
        public List<ItemPedidoResponse> Itens { get; set; } = [];
    }
}
