using AWS.PUC.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AWS.PUC.Repositorio
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
            }

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Torneio> Torneios { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Partida> Partidas { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }
        public DbSet<TorneioPartida> TorneiosPartidas { get; set; }
    }
}
