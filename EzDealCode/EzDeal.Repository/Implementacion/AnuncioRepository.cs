using System.Collections.Generic;
using System.Linq;
using EzDeal.Domain;
using EzDeal.Repository.Context;
//using Microsoft.EntityFrameworkCore;

namespace EzDeal.Repository.Implementacion
{
   public class AnuncioRepository : IAnuncioRepository
    {

        private ApplicationDbContext context;

        public AnuncioRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Anuncio Get(int id)
        {
            var result = new Anuncio();
            try
            {
                result = context.Anuncios.Single(x => x.id == id);
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<Anuncio> GetAll()
        {

            var result = new List<Anuncio>();
            try
            {
                result = context.Anuncios.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool Save(Anuncio entity)
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

        public bool Update(Anuncio entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

    }
}