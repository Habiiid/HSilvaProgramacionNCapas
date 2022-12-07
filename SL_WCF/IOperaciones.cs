using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOperaciones" in both code and config file together.
    [ServiceContract]
    public interface IOperaciones
    {
        [OperationContract]
        int Sumar(int numeroUno, int numeroDos);

        [OperationContract]
        int Restar(int numeroUno, int numeroDos);

        [OperationContract]
        int Multiplicacion(int numeroUno, int numeroDos);
        [OperationContract]
        int Division(int numeroUno, int numeroDos);
        [OperationContract]
        string Saludar(string nombre);
        
    }
}
