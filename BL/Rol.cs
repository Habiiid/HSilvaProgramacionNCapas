using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
       //creamos el metodo
       public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result(); //inicializamos 
            try
            {
                using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
                {
                    var query = context.RolGetAll();
                    if (query != null)
                    {
                        result.Objects = new List<object>(); //inicializamos la lista
                  
                        foreach (var row in query) //se pasa la lista al objeto row
                        {
                            ML.Rol rol = new ML.Rol(); //instanciamos

                            rol.IdRol = row.IdRol;
                            rol.Nombre = row.Nombre;

                            result.Objects.Add(rol); 
                        } 
                    }
                }

                result.Correct = true;  
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al consultar la tabla de rol" + result.Ex;
                throw;
            }
            return result; //regresa el valor del metodo
        } 
          
    }
}
