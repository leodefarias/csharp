using WebApplication1.Models;

namespace WebApplication1.Dtos
{
    public sealed class ResumoStatusResponse
    {
        public StatusPedido Status { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
