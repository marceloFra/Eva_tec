using C_Datos;
using C_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Negocios
{
    public class N_Provincia
    {
        D_Provincia pro = new D_Provincia();

        public List<Provincias> ListarProvincia(int idProvincia)
        {
            return pro.ListarProvincia(idProvincia);
        }
    }
}
