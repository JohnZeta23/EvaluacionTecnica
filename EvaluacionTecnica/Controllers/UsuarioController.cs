using CapaData.Models;
using CapaNegocios.CRUD;
using CapaNegocios.Interfaces;
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
        readonly ICRUD<Usuario> _crud;

        public UsuarioController(ICRUD<Usuario> crud)
        {
            _crud = crud;
        }

        [HttpGet]
        [Route("ObtenerUsuario/{id}")]
        public async Task<Usuario> ObtenerUsuario(int id)
        {
            return await _crud.GET(id);
        }

        [HttpGet]
        [Route("ListarUsuarios")]
        public async Task<List<Usuario>> ListarUsuarios()
        {
            return await _crud.GETALL();
        }

        [HttpPost]
        [Route("RegistrarUsuario")]
        public async Task<Usuario> RegistrarUsuario(Usuario usuario)
        {
            return await _crud.POST(usuario);
        }

        [HttpPut]
        [Route("EditarUsuario/{id}")]

        public async Task<string> EditarUsuario(int id, Usuario usuario)
        {
            return await _crud.PUT(id, usuario);
        }

        [HttpDelete]
        [Route("EliminarUsuario/{id}")]
        public async Task<string> EliminarUsuario(int id)
        {
            return await _crud.DELETE(id);
        }
    }
}