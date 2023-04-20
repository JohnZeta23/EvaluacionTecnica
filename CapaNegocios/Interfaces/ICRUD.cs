using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios.Interfaces
{
    public interface ICRUD<T>
    {
        Task<T> GET(int id) ;
        Task<List<T>> GETALL();
        Task<T> POST(T entity);
        Task<string> PUT(int id, T entity);
        Task<string> DELETE(int id);
    }
}
