using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {

        public static ML.Result GetByIdPais(int idPais) //creacion del metodo
        {
            ML.Result result = new ML.Result(); //instancia
            try{
                using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
                {
                    var query = context.EstadoGetByIdPais(idPais).ToList();
                    result.Objects = new List<object>();
                    if (query != null) //validacion
                    {
                        foreach (var row in query)
                        {
                            ML.Estado estado = new ML.Estado(); //creacion de objeto estado
                            estado.IdEstado = row.IdEstado;
                            estado.Nombre = row.Nombre;
                          
                            //tabla pais
                            estado.Pais = new ML.Pais();
                            estado.Pais.IdPais = idPais;

                            result.Objects.Add(estado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Ocurrio un error al mostrar los estados";
                    }
                }

            } catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }

    } 
}

