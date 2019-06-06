using EzDeal.Domain;
using EzDeal.Repository;
using System.Collections.Generic;

namespace EzDeal.Service.Implementacion
{
    public class AnuncioService : IAnuncioService
    {
        public bool  Save(Anuncio entity){
             return true;
        }
        public bool  Update(Anuncio entity){
             return true;
        }

        public bool  Delete(int id){
             return true;
        }


        public IEnumerable<Anuncio> GetAll(){
             return null;
        }

        public Anuncio Get(int id){
          return null;
        }
    }
}