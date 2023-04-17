using EvaluacionTecnica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EvaluacionTecnica.Data
{
    public class UsuariosCRUD
    {
        private readonly EvaluacionTecnicaDBContext _context = new EvaluacionTecnicaDBContext();

        public async Task<Object> ObtenerUsuario(int id)
        {
            var query = from user in _context.Usuarios
                        where user.Id == id
                        join role in _context.Roles on user.RoleId equals role.Id into roleGroup
                        from rol in roleGroup
                        select new
                        {
                            user.Id,
                            Rol = rol.Nombre,
                            user.Nombre,
                            user.Apellido,
                            user.Cedula,
                            user.Usuario_Nombre,
                            user.Contraseña,
                            user.Fecha_Nacimiento,
                            user.Usuario_Transaccion,
                            user.Fecha_Transaccion
                        };
            if(query.Count() != 0)
            {
                return await query.FirstAsync();
            }

            return null;
        }

        public async Task<List<Object>> ListarUsuarios()
        {
            var query = from user in _context.Usuarios
                        join role in _context.Roles on user.RoleId equals role.Id into roleGroup
                        from rol in roleGroup
                        select new
                        {
                            user.Id,
                            Rol = rol.Nombre,
                            user.Nombre,
                            user.Apellido,
                            user.Cedula,
                            user.Usuario_Nombre,
                            user.Contraseña,
                            user.Fecha_Nacimiento,
                            user.Usuario_Transaccion,
                            user.Fecha_Transaccion
                        };

            return await query.ToListAsync<Object>();
        }

        public async Task<string> LoginUsuario(string usuario_nombre, string contraseña)
        {
            var query = from user in _context.Usuarios
                        where user.Usuario_Nombre == usuario_nombre && user.Contraseña == contraseña
                        select user;

            if (await query.CountAsync() <= 0)
            {
                return "No se pudo loguear de manera exitosa, revise sus credenciales e intente de nuevo";
            }
            return "Se logueo de manera exitosa";
        }

        public async Task<Usuario> RegistrarUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<string> EditarUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return "El ID del USUARIO que ha introducido no es valido";
            }

            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return $"El USUARIO del ID {id} ha sido editado satisfactoriamente";
        }

        public async Task<string> EliminarUsuario(int id)
        {
            Usuario usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return "El ID del USUARIO que ha introducido no es valido";
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return $"El USUARIO del ID {id} ha sido eliminado satisfactoriamente de la base de datos";
        }
    }
}