using EzDeal.Domain;
using EzDeal.Repository;
using System.Collections.Generic;

namespace EzDeal.Service.Implementacion
{
    public class AnuncioService : IAnuncioService
    {

       private IAnuncioRepository anuncioRepository;
   
     public AnuncioService(IAnuncioRepository anuncioRepository){
        this.anuncioRepository = anuncioRepository;
     }
        public bool Save(Anuncio entity){
              anuncioRepository.Save(entity);
              return true;
        }
        public bool  Update(Anuncio entity){
             return true;
        }

        public bool  Delete(int id){
             return true;
        }


        public IEnumerable<Anuncio> GetAll(){
             return anuncioRepository.FindAll();
        }

        public Anuncio Get(int id){
          return null;
        }
    }
}