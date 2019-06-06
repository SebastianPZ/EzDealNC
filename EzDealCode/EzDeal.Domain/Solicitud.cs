namespace EzDeal.Domain
{
    public class Solicitud
    {
        public int id {get; set;}
        public Anuncio anuncio {get; set;}
        public Usuario cliente {get; set;}
        public string mensaje {get; set;}
        public string estado {get; set;}
        public string aprobacion {get; set;}
    }
}