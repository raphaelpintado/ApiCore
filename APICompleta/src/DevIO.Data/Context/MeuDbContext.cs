using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace DevIO.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endereco>()
                .Property(x => x.Complemento)
                .IsRequired(false);

            var entityTypes = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string)));

            //Caso alguma propriedade da entidade não tenha sido definida nos mappings
            //obs: não sobrescreve as que foram definidas
            foreach (IMutableProperty property in entityTypes)
                property.Relational().ColumnType = "varchar(100)"; //EF Core 1 e 2
                                                                   //property.SetColumnType("varchar(100)"); //EF Core 3 

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            var collection = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(x => x.GetForeignKeys());

            //Evitar delete cascade no banco
            foreach (var relationship in collection)
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
