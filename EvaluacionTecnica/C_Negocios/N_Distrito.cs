using C_Datos;
using C_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Negocios
{
    public class N_Distrito
    {
        D_Distrito dis = new D_Distrito();
        public List<Distritos> ListarDistrito(int idProvincia)
        {
            return dis.ListarDistrito(  idProvincia);
        }
    }
}
