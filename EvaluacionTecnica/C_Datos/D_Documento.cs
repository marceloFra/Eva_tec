using C_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Datos
{
    public class D_Documento
    {

        public List<Documento> ListarDepartamentos()
        {
            List<Documento> list = new List<Documento>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Conexion.Cn))
                {
                    using (SqlCommand command = new SqlCommand("sp_listDocu", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Documento dis = new Documento();
                            dis.id_Documento = (int)reader["id_Documento"];
                            dis.tipo_Documento = (string)reader["tipo_Documento"];
                            list.Add(dis);
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception e)
            {

                var rpta = "Excepción encontrada: " + e.Message;
            }
            finally
            {

            }
            return list;
        }
    }
}
