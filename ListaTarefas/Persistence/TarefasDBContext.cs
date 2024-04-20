using ListaTarefas.Entities;
using Microsoft.EntityFrameworkCore;

namespace ListaTarefas.Persistence
{
    public class TarefasDBContext : DbContext
    {
        public TarefasDBContext(DbContextOptions<TarefasDBContext> options) : base(options)
        {
            
        }

        public DbSet<TarefaEvento> TarefaEventos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TarefaEvento>(e =>
            {
                e.Property(te => te.Titulo)
                    .HasMaxLength(30)
                    .HasColumnType("varchar(30)")
                    .IsRequired();
                e.Property(te => te.Descricao)
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)");
                e.Property(te => te.StatusTarefa)
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)");

            });
        }


    }
}
