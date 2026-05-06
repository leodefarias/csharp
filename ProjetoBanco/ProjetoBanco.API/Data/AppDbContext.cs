using Microsoft.EntityFrameworkCore;
using ProjetoBanco.API.Models;

namespace ProjetoBanco.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Contratacao> Contratacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasDiscriminator<string>("TipoCliente")
                .HasValue<PessoaFisica>("PF")
                .HasValue<PessoaJuridica>("PJ");

            modelBuilder.Entity<Produto>()
                .HasDiscriminator<string>("TipoProduto")
                .HasValue<Emprestimo>("Emprestimo");
        }
    }
}
