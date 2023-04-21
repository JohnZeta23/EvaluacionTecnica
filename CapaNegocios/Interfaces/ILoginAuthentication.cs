using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios.Interfaces
{
    public interface ILoginAuthentication
    {
        Task<string> LoginUsuario(string usuario_nombre, string contrasena);
    }
}
