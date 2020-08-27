using C_Datos;
using C_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Negocios
{
    public class N_Documento
    {
        D_Documento dis = new D_Documento();

        public List<Documento> ListarDepartamentos()
        {
            return dis.ListarDepartamentos();
        }
    }
}
