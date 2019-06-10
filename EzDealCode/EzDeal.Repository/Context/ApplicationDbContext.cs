using EzDeal.Domain;
using Microsoft.EntityFrameworkCore;

namespace EzDeal.Repository.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios {get; set;}
        public DbSet<Anuncio> Anuncios {get; set;}
        public DbSet<Servicio> Servicios {get; set;}
        public DbSet<Solicitud> Solicitudes{get; set;}
        public DbSet<Reseña> Reseñas {get; set;}
        //public DbSet<HorarioAtencion> HorarioAtencion {get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servicio>()
                    .Property(p => p.nombre)
                    .HasColumnName("Nombres")
                    .HasMaxLength(50)
                    .IsRequired();

             modelBuilder.Entity<Anuncio>()
                .HasOne(p => p.servicio)
                .WithMany(b => b.Anuncios)
                .HasForeignKey(p => p.servicio_id);       
                    
        }
    }
}