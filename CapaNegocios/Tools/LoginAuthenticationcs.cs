using CapaData;
using CapaNegocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios.Tools
{
    public class LoginAuthenticationcs : ILoginAuthentication
    {
        private readonly EvaluacionTecnicaDBContext _context;

        public LoginAuthenticationcs(EvaluacionTecnicaDBContext context)
        {
            _context = context;
        }

        public async Task<string> LoginUsuario(string usuario_nombre, string contrasena)
        {
            try
            {
                var query = await (from user in _context.Usuarios
                                   where user.Usuario_Nombre == usuario_nombre && user.Contrasena == contrasena
                                   select user).CountAsync();

                if (query == 0)
                {
                    throw new Exception("No se pudo loguear de manera exitosa, revise sus credenciales e intente de nuevo");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return "Se logueo de manera exitosa";
        }
    }
}
