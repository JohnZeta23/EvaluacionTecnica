using CapaData;
using CapaData.Models;
using CapaNegocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CapaNegocios.CRUD
{
    public class UsuariosCRUD : ICRUD<Usuario>
    {
        private readonly EvaluacionTecnicaDBContext _context = new EvaluacionTecnicaDBContext();

        public async Task<Usuario> GET(int id)
        {
            Usuario usuario = await _context.Usuarios.FindAsync(id);

            return usuario;
        }

        public async Task<List<Usuario>> GETALL()
        {
            List<Usuario> users = await _context.Usuarios.ToListAsync();

            return users;
        }

        public async Task<Usuario> POST(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<string> PUT(int id, Usuario entity)
        {
            if (id != entity.Id)
            {
                return "El ID del USUARIO que ha introducido no es valido";
            }

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return $"El USUARIO del ID {id} ha sido editado satisfactoriamente";
        }

        public async Task<string> DELETE(int id)
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