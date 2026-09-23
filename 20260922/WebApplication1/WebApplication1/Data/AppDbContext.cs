using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Produto> Produtos => Set<Produto>();
        public DbSet<Pedido> Pedidos => Set<Pedido>();
        public DbSet<ItemPedido> ItensPedido => Set<ItemPedido>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(produto =>
            {
                produto.Property(item => item.Preco).HasPrecision(18, 2);
                produto.Property(item => item.Nome).IsRequired();
            });

            modelBuilder.Entity<Pedido>(pedido =>
            {
                pedido.ToTable("Pedidos");
                pedido.Property(item => item.Cliente).IsRequired();
                pedido.Property(item => item.Total).HasPrecision(18, 2);

                pedido.HasMany(item => item.Itens)
                    .WithOne(item => item.Pedido)
                    .HasForeignKey(item => item.PedidoId);
            });

            modelBuilder.Entity<ItemPedido>(item =>
            {
                item.ToTable("ItensPedido");
                item.Property(linha => linha.Produto).IsRequired();
                item.Property(linha => linha.ValorUnitario).HasPrecision(18, 2);
            });
        }
    }
}
