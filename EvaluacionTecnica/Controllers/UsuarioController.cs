using EvaluacionTecnica.Negocios;
using EvaluacionTecnica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace EvaluacionTecnica.Controllers
{
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ApiController
    {
        private readonly UsuariosCRUD crud = new UsuariosCRUD();

        [HttpGet]
        [Route("ObtenerUsuario/{id}")]
        public async Task<Object> ObtenerUsuario(int id)
        {
            return await crud.ObtenerUsuario(id);
        }

        [HttpGet]
        [Route("ListarUsuarios")]
        public async Task<List<Object>> ListarUsuarios()
        {
            return await crud.ListarUsuarios();
        }

        [HttpGet]
        [Route("LoginUsuario/{usuario_nombre}/{contraseña}")]
        public async Task<string> LoginUsuario(string usuario_nombre, string contraseña)
        {
            return await crud.LoginUsuario(usuario_nombre, contraseña);
        }

        [HttpPost]
        [Route("RegistrarUsuario")]
        public async Task<Usuario> RegistrarUsuario(Usuario usuario)
        {
            return await crud.RegistrarUsuario(usuario);
        }

        [HttpPut]
        [Route("EditarUsuario/{id}")]

        public async Task<string> EditarUsuario(int id, Usuario usuario)
        {
            return await crud.EditarUsuario(id, usuario);
        }

        [HttpDelete]
        [Route("EliminarUsuario/{id}")]
        public async Task<string> EliminarUsuario(int id)
        {
            return await crud.EliminarUsuario(id);
        }
    }
}