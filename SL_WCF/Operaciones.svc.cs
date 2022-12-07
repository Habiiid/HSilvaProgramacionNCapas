using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Operaciones" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Operaciones.svc or Operaciones.svc.cs at the Solution Explorer and start debugging.
    public class Operaciones : IOperaciones
    {
        public int Sumar(int numeroUno, int numeroDos)
        {
            return numeroUno + numeroDos;
        }

        public int Restar(int numeroUno, int numeroDos)
        {
            return numeroUno - numeroDos;
        }

        public int Multiplicacion(int numeroUno, int numeroDos)
        {
            return numeroUno * numeroDos;
        }

        public int Division(int numeroUno, int numeroDos)
        {
            return numeroUno / numeroDos;
        }

        public string Saludar(string nombre)
        {
            return "Hola: " + nombre + " ten un buen dia.";
        }
  
    }
}
