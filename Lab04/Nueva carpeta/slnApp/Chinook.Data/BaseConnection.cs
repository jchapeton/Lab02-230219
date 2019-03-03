using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Data
{
    public class BaseConnection
    {
        public string GetConnection()
        {
            string cadenaConexion = "Server=S000-00;DataBase=ChinookSabado;User=sa;pwd=sql";
            return cadenaConexion;
        }
    }
}
