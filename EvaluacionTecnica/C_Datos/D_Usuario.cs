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
    public class D_Usuario
    {

        public  Usuarios  Login(Login login)
        {
             Usuarios usu = new  Usuarios();
           
            try
            {
                using (SqlConnection connection = new SqlConnection(Conexion.Cn))
                {
                    using (SqlCommand command = new SqlCommand("sp_loginUsuario", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@usu", login.usu);
                        command.Parameters.AddWithValue("@contrasena", login.contrasena);
                         
                          SqlDataReader reader = command.ExecuteReader();

                            while (reader.Read())
                            {

                                usu.id_Usuario = (int)reader["id_Usuario"];
                                usu.nombre = (string)reader["nombre"];
                                usu.apellido_Paterno = (string)reader["apellido_Paterno"];
                                usu.apellido_Materno = (string)reader["apellido_Materno"];
                                usu.id_Documento = (int)reader["id_Documento"];
                                usu.nro_documento = (string)reader["nro_documento"];
                                usu.usuario = (string)reader["usu"];
                                usu.contrasena = (string)reader["contrasena"];
                                usu.id_Depa = (int)reader["id_Depa"];
                                usu.id_Provincia = (int)reader["id_Provincia"];
                                usu.id_Distrito = (int)reader["id_Distrito"]; 
                            } 
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
            return usu;
        }

        public Usuarios Login(Func<Usuarios> login1, object login2)
        {
            throw new NotImplementedException();
        }

        public List<Usuarios> ListarUsuario() 
        {
            List<Usuarios> list = new List<Usuarios>();
             try
             {
                using (SqlConnection connection = new SqlConnection(Conexion.Cn)) 
                {
                    using (SqlCommand command = new SqlCommand("sp_listUsuario", connection)) 
                    {
                        command.CommandType = CommandType.StoredProcedure;

                    
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                Usuarios usu = new Usuarios();
                                usu.id_Usuario = (int)reader["id_Usuario"];
                                usu.nombre = (string)reader["nombre"];
                                usu.apellido_Paterno = (string)reader["apellido_Paterno"];
                                usu.apellido_Materno = (string)reader["apellido_Materno"];
                                usu.id_Documento = (int)reader["id_Documento"];
                                usu.nro_documento = (string)reader["nro_documento"];
                                usu.usuario = (string)reader["usu"];
                                usu.contrasena = (string)reader["contrasena"];
                                usu.id_Depa = (int)reader["id_Depa"];
                                usu.id_Provincia = (int)reader["id_Provincia"];
                                usu.id_Distrito = (int)reader["id_Distrito"];

                                list.Add(usu);
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

        public int Crear(Usuarios usuario)
        {
            int rpta = 1;
            try
            {
                using (SqlConnection connection = new SqlConnection(Conexion.Cn))
                {
                    using (SqlCommand command = new SqlCommand("sp_createUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@nombre", usuario.nombre));
                        command.Parameters.Add(new SqlParameter("@apellido_Paterno", usuario.apellido_Paterno));
                        command.Parameters.Add(new SqlParameter("@apellido_Materno", usuario.apellido_Materno));
                        command.Parameters.Add(new SqlParameter("@id_Documento", usuario.id_Documento));
                        command.Parameters.Add(new SqlParameter("@nro_documento", usuario.nro_documento));
                        command.Parameters.Add(new SqlParameter("@usu", usuario.usuario));
                        command.Parameters.Add(new SqlParameter("@contrasena", usuario.contrasena));
                        command.Parameters.Add(new SqlParameter("@id_Depa", usuario.id_Depa));
                        command.Parameters.Add(new SqlParameter("@id_Provincia", usuario.id_Provincia));
                        command.Parameters.Add(new SqlParameter("@id_Distrito", usuario.id_Distrito));


                        connection.Open();
                        rpta = command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception e)
            {

                var rptas = "Excepción encontrada: " + e.Message;
            }
            finally
            {

            }
            return rpta;



        }

        public int Editar(Usuarios usuario)
        {
            int rpta = 1;
            try
            {
                using (SqlConnection connection = new SqlConnection(Conexion.Cn))
                {
                    using (SqlCommand command = new SqlCommand("sp_updateUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@id_Usuario", usuario.id_Usuario)); 
                        command.Parameters.Add(new SqlParameter("@nombre", usuario.nombre));
                        command.Parameters.Add(new SqlParameter("@apellido_Paterno", usuario.apellido_Paterno));
                        command.Parameters.Add(new SqlParameter("@apellido_Materno", usuario.apellido_Materno));
                        command.Parameters.Add(new SqlParameter("@id_Documento", usuario.id_Documento));
                        command.Parameters.Add(new SqlParameter("@nro_documento", usuario.nro_documento));
                        command.Parameters.Add(new SqlParameter("@usu", usuario.usuario));
                        command.Parameters.Add(new SqlParameter("@contrasena", usuario.contrasena));
                        command.Parameters.Add(new SqlParameter("@id_Depa", usuario.id_Depa));
                        command.Parameters.Add(new SqlParameter("@id_Provincia", usuario.id_Provincia));
                        command.Parameters.Add(new SqlParameter("@id_Distrito", usuario.id_Distrito));


                        connection.Open();
                        rpta = command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception e)
            {

                var rptas = "Excepción encontrada: " + e.Message;
            }
            finally
            {

            }
            return rpta; 
        }


        public int Eliminar(int id_Usuario)
        {
            int rpta = 1;
            try
            {
                using (SqlConnection connection = new SqlConnection(Conexion.Cn))
                {
                    using (SqlCommand command = new SqlCommand("sp_deleteUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@id_Usuario", id_Usuario));
                       
                        connection.Open();
                        rpta = command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception e)
            {

                var rptas = "Excepción encontrada: " + e.Message;
            }
            finally
            {

            }
            return rpta;
        }



    }

}
