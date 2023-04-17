using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
namespace EvaluacionTecnica.Negocios
{
    public class LogUsuario_Transaccion
    {
        public string Current_UserGet()
        {
            StreamReader reader = new StreamReader("User-log.txt");
            return reader.ReadToEnd();
        }
        
        public void Current_UserCreate(string Current_User)
        {
            File.WriteAllText("User-log.txt", Current_User);
        }
    }
}