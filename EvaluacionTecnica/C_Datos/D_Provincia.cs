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
    public class D_Provincia
    {
        public List<Provincias> ListarProvincia(int id_Depa)
        {
            List<Provincias> list = new List<Provincias>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Conexion.Cn))
                {
                    using (SqlCommand command = new SqlCommand("sp_List_Provincia", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id_Depa", id_Depa);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Provincias dis = new Provincias();
                            dis.id_Provincia = (int)reader["id_Provincia"];
                            dis.provincia = (string)reader["provincia"];
                            dis.id_Depa = (int)reader["id_Depa"];
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
