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
    public  class D_Departamentos
    {

        public List<Departamentos> ListarDepartamentos()
        {
            List<Departamentos> list = new List<Departamentos>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Conexion.Cn))
                {
                    using (SqlCommand command = new SqlCommand("sp_List_Deparatamento", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Departamentos dis = new Departamentos();
                            dis.id_Depa = (int)reader["id_Depa"];
                            dis.departamento = (string)reader["departamento"];  
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
