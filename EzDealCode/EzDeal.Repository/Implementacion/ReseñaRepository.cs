using System.Collections.Generic;
using System.Linq;
using EzDeal.Domain;
using EzDeal.Repository.Context;
//using Microsoft.EntityFrameworkCore;

namespace EzDeal.Repository.Implementacion
{
   public class ReseñaRepository : IReseñaRepository
    {

        private ApplicationDbContext context;

        public ReseñaRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Reseña Get(int id)
        {
            var result = new Reseña();
            try
            {
                result = context.Reseñas.Single(x => x.id == id);
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<Reseña> GetAll()
        {

            var result = new List<Reseña>();
            try
            {
                result = context.Reseñas.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool Save(Reseña entity)
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

        public bool Update(Reseña entity)
        {
            try
            {
                 var usuarioOrigina = context.Reseñas.Single(
                     x => x.id == entity.id
                 );

                 usuarioOrigina.id=entity.id;
                 usuarioOrigina.contenido = entity.contenido;
                 usuarioOrigina.valoracion = entity.valoracion;
                 usuarioOrigina.anuncio = entity.anuncio;
                 usuarioOrigina.cliente = entity.cliente;
                 
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