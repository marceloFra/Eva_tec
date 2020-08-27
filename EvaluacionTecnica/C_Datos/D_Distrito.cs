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
    public class D_Distrito
    {
        public List<Distritos> ListarDistrito(int idProvincia)
        {
            List<Distritos> list = new List<Distritos>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Conexion.Cn))
                {
                    using (SqlCommand command = new SqlCommand("sp_List_Distrito", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id_Provincia", idProvincia);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Distritos dis = new Distritos();
                            dis.id_Distrito = (int)reader["id_Distrito"];
                            dis.distrito  = (string)reader["distrito"];
                            dis.id_Provincia = (int)reader["id_Provincia"]; 

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
