using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Departamento
    {
        //Procedimientos almacenados

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySP = "DepartamentoGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = querySP; //query
                        cmd.CommandType = CommandType.StoredProcedure;//SP

                        context.Open();

                        DataTable departamentoTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(departamentoTable);

                        if (departamentoTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in departamentoTable.Rows)
                            {
                                ML.Departamento departamento = new ML.Departamento();

                                departamento.IdDepartamento = int.Parse(row[0].ToString());
                                departamento.Nombre = row[1].ToString();
                                departamento.Area = new ML.Area();
                                departamento.Area.IdArea = int.Parse(row[2].ToString());

                                result.Objects.Add(departamento); //boxing y unboxing

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

        public static ML.Result GetById(int idDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySP = "DepartamentoGetById";


                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = querySP; //query
                        cmd.CommandType = CommandType.StoredProcedure;//SP

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[0].Value = idDepartamento;

                        cmd.Parameters.AddRange(collection);

                        DataTable departamentoTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(departamentoTable);

                        if (departamentoTable.Rows.Count > 0)
                        {
                            //result.Objects = new List<object>();
                            DataRow row = departamentoTable.Rows[0];

                            ML.Departamento departamento = new ML.Departamento();

                            departamento.IdDepartamento = int.Parse(row[0].ToString());
                            departamento.Nombre = row[1].ToString();
                            //tabla rol
                            departamento.Area = new ML.Area();
                            departamento.Area.IdArea = int.Parse(row[2].ToString());

                            result.Object = departamento;//boxing y unboxing

                        }

                    }

                }
                result.Correct = true;


            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar el departamento." + result.Ex;

                throw;
            }//manejo de excepciones 

            return result;
        }

        public static ML.Result AddSP(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "DepartamentoAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure; //SP

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = departamento.Nombre;

                        collection[1] = new SqlParameter("IdArea", SqlDbType.Int);
                        collection[1].Value = departamento.Area.IdArea;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se agrego el departamento correctamente";
                        }
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "No se pudo agregar el departamento" + result.Ex;

                throw;
            }//manejo de excepciones 
            return result;
        }

        public static ML.Result UpdateSP(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "DepartamentoUpdate";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("IdDepartamento", SqlDbType.TinyInt);
                        collection[0].Value = departamento.IdDepartamento;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = departamento.Nombre;

                        collection[2] = new SqlParameter("IdArea", SqlDbType.Int);
                        collection[2].Value = departamento.Area.IdArea;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se actualizo el departamento correctamente";
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
                result.Message = "No se pudo actualizar el departamento" + result.Ex;
                Console.ReadLine();

                throw;
            }//manejo de excepciones 
            return result;
        }

        public static ML.Result DeleteSP(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "DepartamentoDelete";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;//SP

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdDepartamento", SqlDbType.VarChar);
                        collection[0].Value = departamento.IdDepartamento;

                        cmd.Parameters.AddRange(collection);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se elimino el departamento correctamente";
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
                result.Message = "No se pudo eliminar el departamento. " + result.Ex;
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

                    var query = context.DepartamentoGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var row in query)
                        {
                            ML.Departamento departamento = new ML.Departamento();

                            departamento.IdDepartamento = row.IdDepartamento;
                            departamento.Nombre = row.Nombre;

                            //tabla rol
                            departamento.Area = new ML.Area();
                            departamento.Area.IdArea = row.IdArea.Value;

                            result.Objects.Add(departamento); //boxing y unboxing

                        }
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar los usuarios" + result.Ex;

                throw;
            }//manejo de excepciones 

            return result;
        }

        public static ML.Result GetByIdEF(int idDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
                {

                    //var query = context.UsuarioGetById(idUsuario).First();
                    //var query = context.UsuarioGetById(idUsuario).FirstOrDefault();
                    //var query = context.UsuarioGetById(idUsuario).Single();
                    var query = context.DepartamentoGetById(idDepartamento).SingleOrDefault();

                    if (query != null)
                    {

                        ML.Departamento departamento = new ML.Departamento();

                        departamento.IdDepartamento = query.IdDepartamento;
                        departamento.Nombre = query.Nombre;
                        //tabla area
                        departamento.Area = new ML.Area();
                        departamento.Area.IdArea = query.IdArea.Value;

                        result.Object = departamento; //boxing y unboxing
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

        public static ML.Result AddEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
                {
                    int query = context.DepartamentoAdd(departamento.Nombre, departamento.Area.IdArea);

                    if (query > 0)
                    {
                        result.Message = "Se agrago el departamento correctamente.";
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "No se pudo agregar el departamento." + result.Ex;

                throw;
            }//manejo de excepciones 
            return result;

        }

        public static ML.Result UpdateEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
                {
                    int query = context.DepartamentoUpdate(departamento.IdDepartamento, departamento.Nombre, departamento.Area.IdArea);

                    if (query > 0)
                    {
                        result.Message = "Se actualizo el departamento correctamente.";
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "No se pudo actualizar el departamento." + result.Ex;

                throw;
            }//manejo de excepciones 
            return result;

        }

        public static ML.Result DeleteEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
                {
                    int query = context.DepartamentoDelete(departamento.IdDepartamento);

                    if (query > 0)
                    {
                        result.Message = "Se elimino el departamento correctamente.";
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "No se pudo eliminar el departamento." + result.Ex;

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
                    var query = (from departamentoDL in context.Departamentoes

                                 select new
                                 {
                                     IdDepartamento = departamentoDL.IdDepartamento,
                                     Nombre = departamentoDL.Nombre,
                                     IdArea = departamentoDL.IdArea
                                 });

                    result.Objects = new List<Object>();
                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var row in query)
                        {
                            ML.Departamento departamento = new ML.Departamento();
                            departamento.IdDepartamento = row.IdDepartamento;
                            departamento.Nombre = row.Nombre;
                            //Tabla area
                            departamento.Area = new ML.Area();
                            departamento.Area.IdArea = row.IdArea.Value;

                            result.Objects.Add(departamento);
                            result.Object = departamento;

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pudo mostrar los departamentos. ";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static ML.Result GetByIdLINQ(int idDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
                {
                    var query = (from departamentoDL in context.Departamentoes
                                 where departamentoDL.IdDepartamento == idDepartamento
                                 select new
                                 {
                                     IdDepartamento = departamentoDL.IdDepartamento,
                                     Nombre = departamentoDL.Nombre,
                                     IdArea = departamentoDL.IdArea
                                 }); //GETBYID 
                    result.Objects = new List<Object>();
                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var row in query)
                        {
                            ML.Departamento departamento = new ML.Departamento();
                            departamento.IdDepartamento = row.IdDepartamento;
                            departamento.Nombre = row.Nombre;
                            departamento.Area = new ML.Area();
                            departamento.Area.IdArea = row.IdArea.Value;

                            result.Objects.Add(departamento);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pudo mostrar el usuario.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static ML.Result AddLINQ(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
                {
                    DL_EF.Departamento departamentoDL = new DL_EF.Departamento();

                    departamentoDL.IdDepartamento = departamento.IdDepartamento;
                    departamentoDL.Nombre = departamento.Nombre;

                    //tabla rol
                    departamentoDL.IdArea = departamento.Area.IdArea;

                    context.Departamentoes.Add(departamentoDL);
                    context.SaveChanges();

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "No se pudo agregar el departamento. " + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result UpdateLINQ(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
                {
                    var query = (from departamentoDL in context.Departamentoes
                                 where departamentoDL.IdDepartamento == departamento.IdDepartamento
                                 select departamentoDL).SingleOrDefault();
                    if (query != null)
                    {
                        query.Nombre = departamento.Nombre;
                        query.IdArea = departamento.Area.IdArea;

                        context.SaveChanges();
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;

                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "No se pudo actualizar al departamento." + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result DeleteLINQ(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
                {
                    var query = (from departamentoDL in context.Departamentoes
                                 where departamentoDL.IdDepartamento == departamento.IdDepartamento
                                 select departamentoDL).First();

                    context.Departamentoes.Remove(query);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }

    }
}
