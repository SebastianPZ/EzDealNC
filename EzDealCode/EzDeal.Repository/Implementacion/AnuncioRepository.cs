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

         public AnuncioRepository(ApplicationDbContext context){
           this.context = context;
         }
         public void Save(Anuncio entity){
           context.AnuncioDb.Add(entity);
           context.SaveChanges();
         }
         public void Update(Anuncio entity){

         }
         public void Delete(Anuncio entity){

         }
         public IEnumerable<Anuncio> FindAll(){
            var result = new List<Anuncio>();
            try
            {
                result = context.AnuncioDb.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
         }
         public Anuncio FindById(int id){
           return null;
         }
    }
}