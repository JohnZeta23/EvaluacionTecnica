using EvaluacionTecnica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EvaluacionTecnica.Data
{
    public class RoleCRUD
    {
        private readonly EvaluacionTecnicaDBContext _context = new EvaluacionTecnicaDBContext();

        public async Task<Role> ObtenerRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);

            return role;
        }

        public async Task<List<Role>> ListarRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> RegistrarRole(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<string> EditarRole(int id, Role role)
        {
            if (id != role.Id)
            {
                return "El ID del ROL que ha introducido no es valido";
            }

            _context.Entry(role).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return $"El ROL con el ID{id} ha sido editado satisfactoriamente";
        }

        public async Task<string> EliminarRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
            {
                return "El ID del ROL que ha introducido no es valido";
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return $"El ROL del ID {id} ha sido eliminado satisfactoriamente de la base de datos";
        }
    }
}