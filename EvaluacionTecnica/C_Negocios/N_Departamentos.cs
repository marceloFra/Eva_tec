using C_Datos;
using C_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Negocios
{
    public class N_Departamentos
    {
        D_Departamentos depa = new D_Departamentos();

        public List<Departamentos> ListarDepartamentos()
        {
            return depa.ListarDepartamentos();
        }
    }
}
