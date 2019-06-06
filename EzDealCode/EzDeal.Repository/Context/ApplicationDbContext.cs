using EzDeal.Domain;
using Microsoft.EntityFrameworkCore;

namespace EzDeal.Repository.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Usuario> UsuarioDb {get; set;}
        public DbSet<Anuncio> AnuncioDb {get; set;}
        public DbSet<Servicio> ServicioDb {get; set;}
        public DbSet<Solicitud> SolicitudDb{get; set;}
        public DbSet<Reseña> ReseñaDb {get; set;}
        public DbSet<HorarioAtencion> HorarioAtencionDb {get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){
            
        }
    }
}