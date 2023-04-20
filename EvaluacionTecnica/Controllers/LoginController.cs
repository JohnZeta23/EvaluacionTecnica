using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using CapaNegocios.Tools;

namespace EvaluacionTecnica.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        private readonly LoginAuthenticationcs login = new LoginAuthenticationcs();

        [HttpGet]
        [Route("LoginUsuario/{usuario_nombre}/{contrasena}")]
        public async Task<string> LoginUsuario(string usuario_nombre, string contrasena)
        {
            return await login.LoginUsuario(usuario_nombre, contrasena);
        }
    }
}