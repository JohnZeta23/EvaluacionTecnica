using CapaData;
using CapaData.Models;
using CapaNegocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CapaNegocios.CRUD
{
    public class UsuariosCRUD : ICRUD<Usuario>
    {
        private readonly EvaluacionTecnicaDBContext _context;

        public UsuariosCRUD(EvaluacionTecnicaDBContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GET(int id)
        {
            Usuario usuario = await _context.Usuarios.FindAsync(id);

            if(usuario == null)
            {
                throw new Exception($"El usuario del ID {id} no existe en la Base de datos");
            }

            Role role = await _context.Roles.FindAsync(usuario.RoleId);
            usuario.role = role;

            return usuario;
        }

        public async Task<List<Usuario>> GETALL()
        {
            List<Usuario> Usuarios = await _context.Usuarios.ToListAsync();

            if (Usuarios == null)
            {
                throw new Exception("No hay registros en esta base de datos");
            }

            foreach (Usuario usuario in Usuarios)
            {
                Role role = await _context.Roles.FindAsync(usuario.RoleId);
                usuario.role = role;
            }

            return Usuarios;
        }

        public async Task<Usuario> POST(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new Exception("El usuario que trato de registrar no es valido. " +
                    "Revise los campos e intente de nuevo");
            }

            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
            }
            catch (DBConcurrencyException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return usuario;
        }

        public async Task<string> PUT(int id, Usuario entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    throw new Exception("El ID del USUARIO que ha introducido no es valido");
                }

                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            

            return $"El USUARIO del ID {id} ha sido editado satisfactoriamente";
        }

        public async Task<string> DELETE(int id)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FindAsync(id);

                if (usuario == null)
                {
                    throw new Exception("El ID del USUARIO que ha introducido no es valido");
                }

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
            catch (DBConcurrencyException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return $"El USUARIO del ID {id} ha sido eliminado satisfactoriamente de la base de datos";
        }
    }
}