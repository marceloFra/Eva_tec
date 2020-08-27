using C_Datos;
using C_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Negocios
{
    public class N_Usuario
    {
        D_Usuario usu = new D_Usuario();

        public List<Usuarios> ListarUsuario()
        {
            return usu.ListarUsuario();
        }

        public int Crear(Usuarios usuario)
        {
            return usu.Crear(usuario);
        }

        public int Editar(Usuarios usuario)
        {
            return usu.Editar(usuario);
        }

        public int Eliminar(int id_Usuario) 
        {
            return usu.Eliminar(id_Usuario);
        }
        public Usuarios Login(Login login)
        {
            return usu.Login(login); 
        }
    }
}
