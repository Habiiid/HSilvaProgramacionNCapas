﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static ML.Result GetbyIdMunicipio(int idMunicipio)
        {
            ML.Result result = new ML.Result(); //instancia
            try
            {
                using (DL_EF.HSilvaProgramacionNCapasEntities context = new DL_EF.HSilvaProgramacionNCapasEntities())
                {
                    var query = context.ColoniaGetByIdMunicipio(idMunicipio).ToList();
                    result.Objects = new List<object>();
                    
                    if (query != null) //validacion
                    {
                        foreach (var row in query)
                        {
                            ML.Colonia colonia = new ML.Colonia(); //creacion de objeto estado
                            colonia.IdColonia = row.IdColonia;
                            colonia.Nombre = row.Nombre;
                            colonia.CodigoPostal = row.CodigoPostal;

                            //tabla estado
                            colonia.Municipio = new ML.Municipio();
                            colonia.Municipio.IdMunicipio = idMunicipio;

                            result.Objects.Add(colonia); //boxing
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
