using System.Collections.Generic;
using System.Linq;
using EzDeal.Domain;
using EzDeal.Repository.Context;
//using Microsoft.EntityFrameworkCore;

namespace EzDeal.Repository.Implementacion
{
   public class ServicioRepository : IServicioRepository
    {

        private ApplicationDbContext context;

        public ServicioRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Servicio Get(int id)
        {
            var result = new Servicio();
            try
            {
                result = context.Servicios.Single(x => x.id == id);
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<Servicio> GetAll()
        {

            var result = new List<Servicio>();
            try
            {
                result = context.Servicios.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool Save(Servicio entity)
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

        public bool Update(Servicio entity)
        {
            try
            {
                 var servicioOrigina = context.Servicios.Single(
                     x => x.id == entity.id
                 );

                 servicioOrigina.id=entity.id;
                 servicioOrigina.nombre=entity.nombre;
                 servicioOrigina.descripcion=entity.descripcion;

                 context.Update(servicioOrigina);
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