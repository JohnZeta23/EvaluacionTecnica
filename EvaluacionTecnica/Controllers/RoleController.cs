using EvaluacionTecnica.Negocios;
using EvaluacionTecnica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace EvaluacionTecnica.Controllers
{
    [RoutePrefix("api/Role")]
    public class RoleController : ApiController
    {
        private readonly RoleCRUD crud = new RoleCRUD();

        [HttpGet]
        [Route("ObtenerRol/{id}")]
        public async Task<Role> ObtenerRole(int id)
        {
            return await crud.ObtenerRole(id);
        }

        [HttpGet]
        [Route("ListarRoles")]
        public async Task<List<Role>> ListarRoles()
        {
            return await crud.ListarRoles();
        }

        [HttpPost]
        [Route("RegistrarRol")]
        public async Task<Role> RegistrarRole(Role role)
        {
            return await crud.RegistrarRole(role);
        }

        [HttpPut]
        [Route("EditarRol/{id}")]
        public async Task<string> EditarRole(int id, Role role)
        {
            return await crud.EditarRole(id, role);
        }

        [HttpDelete]
        [Route("EliminarRol/{id}")]
        public async Task<string> EliminarRole(int id)
        {
            return await crud.EliminarRole(id);
        }
    }
}