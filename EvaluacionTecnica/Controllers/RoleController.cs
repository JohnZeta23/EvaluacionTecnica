using CapaData.Models;
using CapaNegocios.CRUD;
using CapaNegocios.Interfaces;
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
        private readonly ICRUD<Role> crud = new RoleCRUD();

        [HttpGet]
        [Route("ObtenerRol/{id}")]
        public async Task<Role> ObtenerRole(int id)
        {
            return await crud.GET(id);
        }

        [HttpGet]
        [Route("ListarRoles")]
        public async Task<List<Role>> ListarRoles()
        {
            return await crud.GETALL();
        }

        [HttpPost]
        [Route("RegistrarRol")]
        public async Task<Role> RegistrarRole(Role role)
        {
            return await crud.POST(role);
        }

        [HttpPut]
        [Route("EditarRol/{id}")]
        public async Task<string> EditarRole(int id, Role role)
        {
            return await crud.PUT(id, role);
        }

        [HttpDelete]
        [Route("EliminarRol/{id}")]
        public async Task<string> EliminarRole(int id)
        {
            return await crud.DELETE(id);
        }
    }
}