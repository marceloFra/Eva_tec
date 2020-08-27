using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace C_Datos
{
    class Conexion
    {
        public static string Cn
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["conexion"].ToString();
            } 
        }


    }
}
