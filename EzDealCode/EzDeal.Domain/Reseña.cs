namespace EzDeal.Domain
{
    public class Reseña
    {
        
      public int id {get; set;}
      public string contenido {get; set;}
      public int valoracion {get; set;}
      public Anuncio anuncio {get; set;}
      public Usuario cliente {get; set;}
        
    }
}