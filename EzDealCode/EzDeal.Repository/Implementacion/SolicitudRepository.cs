using System.Collections.Generic;
using System.Linq;
using EzDeal.Domain;
using EzDeal.Repository.Context;
//using Microsoft.EntityFrameworkCore;

namespace EzDeal.Repository.Implementacion
{
   public class SolicitudRepository : ISolicitudRepository
    {

        private ApplicationDbContext context;

        public SolicitudRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Solicitud Get(int id)
        {
            var result = new Solicitud();
            try
            {
                result = context.Solicitudes.Single(x => x.id == id);
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<Solicitud> GetAll()
        {

            var result = new List<Solicitud>();
            try
            {
                result = context.Solicitudes.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool Save(Solicitud entity)
        {
            try
            {
                context.Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }

        public bool Update(Solicitud entity)
        {
            try
            {
                 var usuarioOrigina = context.Solicitudes.Single(
                     x => x.id == entity.id
                 );

                 usuarioOrigina.id=entity.id;
                 usuarioOrigina.anuncio = entity.anuncio;
                 usuarioOrigina.cliente = entity.cliente;
                 usuarioOrigina.mensaje = entity.mensaje;
                 usuarioOrigina.estado = entity.estado;
                 usuarioOrigina.aprobacion = entity.aprobacion;

                 context.Update(usuarioOrigina);
                 context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

    }
}