using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace C_Presentacion.Models
{
    public class MUsuario
    {
        public int? id_Usuario { get; set; }
        public string nombre { get; set; }
        public string apellido_Paterno { get; set; }
        public string apellido_Materno { get; set; }
        public int  id_Documento { get; set; }
        public string nro_documento { get; set; } 
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public int  id_Depa { get; set; }
        public int  id_Provincia { get; set; }
        public int  id_Distrito { get; set; }  
    }
}