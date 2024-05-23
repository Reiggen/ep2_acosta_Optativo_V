using Microsoft.EntityFrameworkCore;
using Repository.Data;

namespace Repository.Context
{
    public class ContextoAplicacionDB : DbContext
    {
        //

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<FacturaModel> Facturas { get; set; }
        public ContextoAplicacionDB(DbContextOptions<ContextoAplicacionDB> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<ClienteModel>().ToTable("cliente");

            modelBuilder.Entity<FacturaModel>().ToTable("factura");

        }
    }

}
