using System;

namespace EzDeal.Domain
{
    public class Anuncio
    {
        public int id { get; set; }
        public int anunciante_id { get; set; }
        public string titulo {get; set;}
        public string descripcion {get; set;}
        public int costo_servicio {get; set;}
        public Servicio servicio {get; set;}
        public int esta_habilitado {get; set;}
        public float valoracion {get; set;}

    }
}