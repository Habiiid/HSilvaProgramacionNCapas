using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    //tabla Usuario
    public class Usuario
    {
        //Metodos Completos query
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "INSERT INTO[Usuario]([Nombre],[ApellidoPaterno],[ApellidoMaterno],[FechaNacimiento],[Genero])VALUES(@Nombre, @ApellidoPaterno, @ApellidoMaterno, @FechaNacimiento, @Genero)";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = query; //query

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.Date);
                        collection[3].Value = usuario.FechaNacimiento;

                        collection[4] = new SqlParameter("Genero", SqlDbType.Char);
                        collection[4].Value = usuario.Genero;

                        collection[5] = new SqlParameter("UserName", SqlDbType.Char);
                        collection[5].Value = usuario.UserName;

                        collection[6] = new SqlParameter("Email", SqlDbType.Char);
                        collection[6].Value = usuario.Email;

                        collection[7] = new SqlParameter("Password", SqlDbType.Char);
                        collection[7].Value = usuario.Password;

                        collection[8] = new SqlParameter("Telefono", SqlDbType.Char);
                        collection[8].Value = usuario.Telefono;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = ("Se agrego al usuario correctamente");
                            Console.ReadLine();
                        }
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "No se pudo agregar al usuario" + result.Ex;
                Console.ReadLine();

                throw;
            }//manejo de excepciones 
            return result;

        }

        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "UPDATE [Usuario]SET [Nombre]=@Nombre,[ApellidoPaterno]=@ApellidoPaterno,[ApellidoMaterno]=@ApellidoMaterno,[FechaNacimiento]=@FechaNacimiento,[Genero]=@Genero WHERE IdUsuario=@IdUsuario";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = query; //query

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[6];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.TinyInt);
                        collection[0].Value = usuario.IdUsuario;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        collection[4] = new SqlParameter("FechaNacimiento", SqlDbType.Date);
                        collection[4].Value = usuario.FechaNacimiento;

                        collection[5] = new SqlParameter("Genero", SqlDbType.Char);
                        collection[5].Value = usuario.Genero;


                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se actualizo el usuario correctamente";
                            Console.ReadLine();
                        }
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "No se pudo actualizar al usuario" + result.Ex;
                Console.ReadLine();

                throw;
            }//manejo de excepciones 
            return result;
        }

        public static ML.Result Deleted(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "DELETE FROM [dbo].[Usuario] WHERE IdUsuario=@IdUsuario";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = query; //query

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.VarChar);
                        collection[0].Value = usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);
                        int rowsAffected = cmd.ExecuteNonQuery();

                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "No se pudo eliminar al usuario" + result.Ex;
                Console.ReadLine();

                throw;
            }//manejo de excepciones 
            return result;
        }

        //Procedimiento Almacenados

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySP = "UsuarioGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = querySP; //query
                        cmd.CommandType = CommandType.StoredProcedure;//SP

                        context.Open();

                        DataTable usuarioTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(usuarioTable);

                        if (usuarioTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in usuarioTable.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();

                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.Nombre = row[1].ToString();
                                usuario.ApellidoPaterno = row[2].ToString();
                                usuario.ApellidoMaterno = row[3].ToString();
                                usuario.FechaNacimiento = row[4].ToString();
                                usuario.Genero = row[5].ToString();
                                usuario.UserName = row[6].ToString();
                                usuario.Email = row[7].ToString();
                                usuario.Password = row[8].ToString();
                                usuario.Telefono = row[9].ToString();
                                usuario.Celular = row[10].ToString();
                                usuario.CURP = row[11].ToString();
                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = int.Parse(row[12].ToString());
                                result.Objects.Add(usuario); //boxing y unboxing

                            }

                        }

                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "No se pudo mostrar la informacion. " + result.Ex;

                throw;
            }//manejo de excepciones 

            return result;

        }

        public static ML.Result GetById(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySP = "UsuarioGetById";


                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = querySP; //query
                        cmd.CommandType = CommandType.StoredProcedure;//SP

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = idUsuario;

                        cmd.Parameters.AddRange(collection);

                        DataTable usuarioTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(usuarioTable);

                        if (usuarioTable.Rows.Count > 0)
                        {
                            //result.Objects = new List<object>();
                            DataRow row = usuarioTable.Rows[0];

                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.FechaNacimiento = row[4].ToString();
                            usuario.Genero = row[5].ToString();

                            result.Object = usuario;//boxing y unboxing



                        }

                    }

                }
                result.Correct = true;


            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el usuario" + result.Ex;

                throw;
            }//manejo de excepciones 

            return result;
        }

        public static ML.Result AddSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "UsuarioAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[12];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        collection[3].Value = usuario.FechaNacimiento;

                        collection[4] = new SqlParameter("Genero", SqlDbType.VarChar);
                        collection[4].Value = usuario.Genero;

                        collection[5] = new SqlParameter("UserName", SqlDbType.VarChar);
                        collection[5].Value = usuario.UserName;

                        collection[6] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[6].Value = usuario.Email;

                        collection[7] = new SqlParameter("Password", SqlDbType.VarChar);
                        collection[7].Value = usuario.Password;

                        collection[8] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[8].Value = usuario.Telefono;

                        collection[9] = new SqlParameter("Celular", SqlDbType.VarChar);
                        collection[9].Value = usuario.Celular;

                        collection[10] = new SqlParameter("CURP", SqlDbType.VarChar);
                        collection[10].Value = usuario.CURP;

                        collection[11] = new SqlParameter("IdRol", SqlDbType.Int);
                        collection[11].Value = usuario.Rol.IdRol;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se agrego el usuario correctamente";
                        }
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el usuario" + result.Ex;

                throw;
            }//manejo de excepciones 
            return result;

        }

        public static ML.Result UpdateSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "UsuarioUpdate";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[7];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.TinyInt);
                        collection[0].Value = usuario.IdUsuario;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        collection[4] = new SqlParameter("FechaNacimiento", SqlDbType.Date);
                        collection[4].Value = usuario.FechaNacimiento;

                        collection[5] = new SqlParameter("Genero", SqlDbType.Char);
                        collection[5].Value = usuario.Genero;
                        
                        collection[6] = new SqlParameter("IdRol", SqlDbType.Int);
                        collection[6].Value = usuario.Rol.IdRol;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se actualizo el usuario correctamente";
                            Console.ReadLine();
                        }
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "No se pudo actualizar al usuario" + result.Ex;
                Console.ReadLine();

                throw;
            }//manejo de excepciones 
            return result;
        }

        public static ML.Result DeleteSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "UsuarioDelete";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;//SP

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.VarChar);
                        collection[0].Value = usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);
                        int rowsAffected = cmd.ExecuteNonQuery();

                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "No se pudo eliminar al usuario" + result.Ex;
                Console.ReadLine();

                throw;
            }//manejo de excepciones 
            return result;
        }

        //Entity Framework

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
                {

                    var query = context.UsuarioGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var row in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = row.IdUsuario;
                            usuario.Nombre = row.Nombre;
                            usuario.ApellidoPaterno = row.ApellidoPaterno;
                            usuario.ApellidoMaterno = row.ApellidoMaterno;
                            usuario.FechaNacimiento = row.FechaNacimiento.ToString("dd-MM-yyyy");
                            usuario.Genero = row.Genero;
                            usuario.UserName = row.UserName;
                            usuario.Email = row.Email;
                            usuario.Password = row.Password;
                            usuario.Telefono = row.Telefono;
                            usuario.Celular = row.Celular;
                            usuario.CURP = row.CURP;
                         // usuario.Imagen = row.Imagen;

                            //tabla rol
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = row.IdRol.Value;
                            usuario.Rol.Nombre = row.NombreRol;
                            
                            //direccion
                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.IdDireccion = row.IdDireccion;
                            usuario.Direccion.Calle = row.Calle;
                            usuario.Direccion.NumeroExterior = row.NumeroExterior;
                            usuario.Direccion.NumeroInterior = row.NumeroIxterior;

                            //colonia
                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.IdColonia = row.IdColonia.Value;
                            usuario.Direccion.Colonia.Nombre = row.NombreColonia;
                            usuario.Direccion.Colonia.CodigoPostal = row.CodigoPostal;

                            //municipio
                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.IdMunicipio = row.IdMunicipio.Value;
                            usuario.Direccion.Colonia.Municipio.Nombre = row.NombreMunicipio;

                            //estado
                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.IdEstado = row.IdEstado.Value;
                            usuario.Direccion.Colonia.Municipio.Estado.Nombre = row.NumbreEstado;

                            //pais
                            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = row.IdPais.Value;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = row.PaisNombre;

                            result.Objects.Add(usuario); //boxing 

                        }
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el usuario" + result.Ex;

                throw;
            }//manejo de excepciones 

            return result;
        }

        public static ML.Result GetByIdEF(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
                {

                    //var query = context.UsuarioGetById(idUsuario).First();
                    //var query = context.UsuarioGetById(idUsuario).FirstOrDefault();
                    //var query = context.UsuarioGetById(idUsuario).Single();
                     var query = context.UsuarioGetById(idUsuario).SingleOrDefault(); 

                    if (query != null)
                    {

                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.FechaNacimiento = query.FechaNacimiento.ToString("dd-MM-yyyy");
                        usuario.Genero = query.Genero;
                        usuario.UserName = query.UserName;
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.Telefono = query.Telefono;
                        usuario.Celular = query.Celular;
                        usuario.CURP = query.CURP;
                       // usuario.Imagen = query.Imagen;

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = query.IdRol.Value;

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = query.IdDireccion;
                        usuario.Direccion.Calle = query.Calle;
                        usuario.Direccion.NumeroExterior = query.NumeroExterior;
                        usuario.Direccion.NumeroInterior = query.NumeroIxterior;

                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = query.IdColonia.Value;
                        usuario.Direccion.Colonia.Nombre = query.NombreColonia;

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = query.IdMunicipio.Value;
                        usuario.Direccion.Colonia.Municipio.Nombre = query.NombreMunicipio;

                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = query.IdEstado.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = query.NumbreEstado;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = query.IdPais.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = query.PaisNombre;

                        result.Object = usuario; //boxing y unboxing
                    }

                }
                result.Correct = true;

            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "No se pudo mostar al usuario selecionado. " + result.Ex;

                throw;
            }//manejo de excepciones 

            return result;
        }
       
        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
                {
                    int query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.FechaNacimiento, usuario.Genero, usuario.UserName,usuario.Email, usuario.Password, usuario.Telefono, usuario.Celular, usuario.CURP,  usuario.Rol.IdRol, usuario.Imagen, usuario.Direccion.Calle, usuario.Direccion.NumeroExterior, usuario.Direccion.NumeroInterior, usuario.Direccion.Colonia.IdColonia);

                    if (query > 0)
                    {
                        result.Message = "Se agrago el Usuario Correctamente.";
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "No se pudo agregar al usuario." + result.Ex;

                throw;
            }//manejo de excepciones 
            return result;

        }

        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
                {
                    int query = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.FechaNacimiento, usuario.Genero, usuario.UserName, usuario.Email, usuario.Password, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Rol.IdRol, usuario.Imagen, usuario.Direccion.Calle, usuario.Direccion.NumeroExterior, usuario.Direccion.NumeroInterior, usuario.Direccion.Colonia.IdColonia); ; ;

                    if (query > 0)
                    {
                        result.Message = "Se actualizo al usuario correctamente.";
                    }

                }
                result.Correct = true;
                
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "No se pudo actualizar al usuario." + result.Ex;

                throw;
            }//manejo de excepciones 
            return result;

        }

        public static ML.Result DeleteEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
                {
                    int query = context.UsuarioDelete(usuario.IdUsuario);

                    if (query > 0)
                    {
                        result.Message = "Se elimino al Usuario Correctamente.";
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "No se pudo eliminar al usuario." + result.Ex;

                throw;
            }//manejo de excepciones 
            return result;
        }

        //LINQ

        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
                {
                    var query = (from usuarioDL in context.Usuarios

                                 select new
                                 {
                                     IdUsuario = usuarioDL.IdUsuario,
                                     Nombre =usuarioDL.Nombre,
                                     ApellidoPaterno = usuarioDL.ApellidoPaterno,
                                     ApellidoMaterno = usuarioDL.ApellidoMaterno,
                                     FechaNacimiento = usuarioDL.FechaNacimiento,
                                     Genero = usuarioDL.Genero,
                                     UserName = usuarioDL.UserName,
                                     Email = usuarioDL.Email,
                                     Password = usuarioDL.Password,
                                     Telefono = usuarioDL.Telefono,
                                     Celular = usuarioDL.Celular,
                                     CURP = usuarioDL.CURP, 
                                     IdRol = usuarioDL.IdRol
                                 });

                    result.Objects = new List<Object>();
                    if(query != null && query.ToList().Count > 0)
                    {
                        foreach (var row in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = row.IdUsuario;
                            usuario.Nombre = row.Nombre;
                            usuario.ApellidoPaterno = row.ApellidoPaterno;
                            usuario.ApellidoMaterno = row.ApellidoMaterno;
                            usuario.FechaNacimiento = row.FechaNacimiento.ToString("dd-mm-yyyy");
                            usuario.Genero = row.Genero;
                            usuario.UserName = row.UserName;
                            usuario.Email = row.Email;
                            usuario.Password = row.Password;
                            usuario.Telefono = row.Telefono;
                            usuario.Celular = row.Celular;
                            usuario.CURP = row.CURP;
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = row.IdRol.Value;

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct=false;
                        result.Message = "No se pudo mostrar el usuario.";
                    }
                }

            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static ML.Result GetByIdLINQ(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
                {
                    var query = (from usuarioDL in context.Usuarios
                                 where usuarioDL.IdUsuario == idUsuario
                                 select new
                                 {
                                     IdUsuario = usuarioDL.IdUsuario,
                                     Nombre = usuarioDL.Nombre,
                                     ApellidoPaterno = usuarioDL.ApellidoPaterno,
                                     ApellidoMaterno = usuarioDL.ApellidoMaterno,
                                     FechaNacimiento = usuarioDL.FechaNacimiento,
                                     Genero = usuarioDL.Genero,
                                     UserName = usuarioDL.UserName,
                                     Email = usuarioDL.Email,
                                     Password = usuarioDL.Password,
                                     Telefono = usuarioDL.Telefono,
                                     Celular = usuarioDL.Celular,
                                     CURP = usuarioDL.CURP,
                                     IdRol = usuarioDL.IdRol
                                 }); //GETBYID 

                    result.Objects = new List<Object>();
                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var row in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = row.IdUsuario;
                            usuario.Nombre = row.Nombre;
                            usuario.ApellidoPaterno = row.ApellidoPaterno;
                            usuario.ApellidoMaterno = row.ApellidoMaterno;
                            usuario.FechaNacimiento = row.FechaNacimiento.ToString("dd-mm-yyyy");
                            usuario.UserName = row.UserName;
                            usuario.Email = row.Email;
                            usuario.Password = row.Password;
                            usuario.Telefono = row.Telefono;
                            usuario.Celular = row.Celular;
                            usuario.CURP = row.CURP;
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = row.IdRol.Value;

                            result.Objects.Add(usuario);
                            result.Object = usuario;
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pudo mostrar el usuario.";
                    }
                }
            }catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
            }
        
        public static ML.Result AddLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuarioDL = new DL_EF.Usuario();

                    usuarioDL.IdUsuario = usuario.IdUsuario;
                    usuarioDL.Nombre = usuario.Nombre;
                    usuarioDL.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioDL.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioDL.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                    usuarioDL.Genero = usuario.Genero;
                    usuarioDL.UserName = usuario.UserName;
                    usuarioDL.Password = usuario.Password;
                    usuarioDL.Email = usuario.Email;
                    usuarioDL.Telefono = usuario.Telefono;
                    usuarioDL.Celular = usuario.Celular;
                    usuarioDL.CURP = usuario.CURP;
                    //tabla rol
                    usuarioDL.IdRol = usuario.Rol.IdRol;

                    context.Usuarios.Add(usuarioDL);
                    context.SaveChanges();

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "No se pudo agregar al usuario. " + result.Ex;

                throw;
            }
            return result;
        } 
    
        public static ML.Result UpdateLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
                {
                    var query = (from usuarioDL in context.Usuarios
                                 where usuarioDL.IdUsuario == usuario.IdUsuario
                                 select usuarioDL).SingleOrDefault();
                    if (query != null)
                    {
                        query.Nombre = usuario.Nombre;
                        query.ApellidoPaterno = usuario.ApellidoPaterno;
                        query.ApellidoMaterno = usuario.ApellidoMaterno;
                        query.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                        query.Genero = usuario.Genero;
                        query.UserName = usuario.UserName;
                        query.Email = usuario.Email;
                        query.Password = usuario.Password;
                        query.Telefono = usuario.Telefono;
                        query.Celular = usuario.Celular;
                        query.CURP = usuario.CURP;
                        query.IdRol = usuario.Rol.IdRol;

                        context.SaveChanges();
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct= false;
                   
                    }
                }
                 
            }catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "No se pudo actualizar al usuario." + result.Ex;

                throw;
            }
            return result;
        }  
    
        public static ML.Result DeleteLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
                {
                    var query = (from usuarioDL in context.Usuarios
                                 where usuarioDL.IdUsuario == usuario.IdUsuario
                                 select usuarioDL).First();

                    context.Usuarios.Remove(query);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message =  ex.Message;
            }
            return result;
        }   
    
    }
   
}


       
