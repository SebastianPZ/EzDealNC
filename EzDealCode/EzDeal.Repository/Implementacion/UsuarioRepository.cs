using System.Collections.Generic;
using System.Linq;
using EzDeal.Domain;
using EzDeal.Repository.Context;
//using Microsoft.EntityFrameworkCore;

namespace EzDeal.Repository.Implementacion
{
   public class UsuarioRepository : IUsuarioRepository
    {

        private ApplicationDbContext context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Usuario Get(int id)
        {
            var result = new Usuario();
            try
            {
                result = context.Usuarios.Single(x => x.id == id);
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<Usuario> GetAll()
        {

            var result = new List<Usuario>();
            try
            {
                result = context.Usuarios.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool Save(Usuario entity)
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

        public bool Update(Usuario entity)
        {
            try
            {
                 var usuarioOrigina = context.Usuarios.Single(
                     x => x.id == entity.id
                 );

                 usuarioOrigina.id=entity.id;
                 usuarioOrigina.contraseña= entity.contraseña;
                 usuarioOrigina.email = entity.email;
                 usuarioOrigina.nombre=entity.nombre;
                 usuarioOrigina.apellido=entity.apellido;
                 usuarioOrigina.url_contacto = entity.url_contacto;
                 usuarioOrigina.telefono=entity.telefono;
                 usuarioOrigina.distrito = entity.distrito;

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