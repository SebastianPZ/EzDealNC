using System;
using System.Collections.Generic;

namespace EzDeal.Domain
{
    public class Servicio
    {
        public int id {get; set;}
        public string nombre {get; set;}
        public string descripcion {get; set;}

        public List<Anuncio> Anuncios {get;set;}

    }
}