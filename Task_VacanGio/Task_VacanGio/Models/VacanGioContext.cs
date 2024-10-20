using Microsoft.EntityFrameworkCore;

namespace Task_VacanGio.Models
{
    public class VacanGioContext : DbContext
    {
        public VacanGioContext(DbContextOptions<VacanGioContext> options) : base(options)
        {
        }

        public DbSet<Utente> Utenti { get; set; }
        public DbSet<Destinazione> Destinazioni { get; set; }
        public DbSet<Pacchetto> Pacchetti { get; set; }
        public DbSet<Recensione> Recensioni { get; set; }
        public DbSet<Tratta> Tratte { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tratta>()
                .HasOne(t => t.Destinazione)
                .WithMany()
                .HasForeignKey(t => t.DestinazioneRif);

            modelBuilder.Entity<Tratta>()
                .HasOne(t => t.Pacchetto)
                .WithMany()
                .HasForeignKey(t => t.PacchettoRif);
        }




    }
}
