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
    public class RoleCRUD : ICRUD<Role>
    {
        private readonly EvaluacionTecnicaDBContext _context;

        public RoleCRUD(EvaluacionTecnicaDBContext context)
        {
            _context = context;
        }

        public async Task<Role> GET(int id)
        {
            Role role = await _context.Roles.FindAsync(id);

            if (role == null)
            {
                throw new Exception($"El rol del ID {id} no existe en la Base de datos");
            }

            return role;
        }

        public async Task<List<Role>> GETALL()
        {
            List<Role> roles = await _context.Roles.ToListAsync();

            if(roles == null)
            {
                throw new Exception("No hay registros en esta base de datos");
            }

            return roles;
        }

        public async Task<Role> POST(Role role)
        {
            try 
            { 
            _context.Roles.Add(role);
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
            return role;
        }

        public async Task<string>PUT(int id, Role role)
        {
            if (id != role.Id)
            {
                throw new Exception("El ID del ROL que ha introducido no es valido");
            }
            try 
            { 
            _context.Entry(role).State = EntityState.Modified;
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

            return $"El ROL con el ID {id} ha sido editado satisfactoriamente";
        }

        public async Task<string> DELETE(int id)
        {
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
            {
                throw new Exception("El ID del ROL que ha introducido no es valido");
            }
            try
            {
                _context.Roles.Remove(role);
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

            return $"El ROL del ID {id} ha sido eliminado satisfactoriamente de la base de datos";
        }
    }
}