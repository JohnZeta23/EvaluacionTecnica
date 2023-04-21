using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using CapaNegocios.Interfaces;

namespace EvaluacionTecnica.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        private readonly ILoginAuthentication _login;

        public LoginController(ILoginAuthentication login)
        {
            _login = login;   
        }

        [HttpGet]
        [Route("LoginUsuario/{usuario_nombre}/{contrasena}")]
        public async Task<string> LoginUsuario(string usuario_nombre, string contrasena)
        {
            return await _login.LoginUsuario(usuario_nombre, contrasena);
        }
    }
}