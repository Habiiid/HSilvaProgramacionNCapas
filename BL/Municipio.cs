using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public static ML.Result GetByIdEstado(int idEstado)
        {
            ML.Result result = new ML.Result(); //instancia
            try
            {
                using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
                {
                    var query = context.MunicipioGetByIdEstado(idEstado).ToList();
                    result.Objects = new List<object>();
                    if (query != null) //validacion
                    {
                        foreach (var row in query)
                        {
                            ML.Municipio municipio = new ML.Municipio(); //creacion de objeto municipio
                            municipio.IdMunicipio = row.IdMunicipio;
                            municipio.Nombre = row.Nombre;
                          
                            //tabla estado
                            municipio.Estado = new ML.Estado();
                            municipio.Estado.IdEstado = idEstado;

                            result.Objects.Add(municipio); //boxing
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Ocurrio un error al mostrar los estados";
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
    }
}
