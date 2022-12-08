using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Area { 
    public static ML.Result GetAllEF()
    {
        ML.Result result = new ML.Result(); //inicializamos 
        try
        {
            using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
            {

                var query = context.AreaGetAll().ToList();

                if (query != null)
                {
                    result.Objects = new List<object>();

                    foreach (var row in query)
                    {
                        ML.Area area = new ML.Area();

                        area.IdArea = row.IdArea;
                        area.Nombre = row.Nombre;


                        result.Objects.Add(area); //boxing y unboxing

                    }
                }

            }
            result.Correct = true;
        }//codigo que puede causar una excepcion 
        catch (Exception ex)
        {
            result.Correct = false;
            result.Ex = ex;
            result.Message = "Ocurrio un error al mostrar las areas" + result.Ex;

            throw;
        }//manejo de excepciones 

        return result;
    }
}
}