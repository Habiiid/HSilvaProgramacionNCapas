using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    //Tabla Departamento
    public class Departamento
    {
        public static void GetAllLINQ()  //Mostrar Todo

        {
            //ML.Result result = BL.Departamento.GetAllEF(); 

            ML.Result result = BL.Departamento.GetAllLINQ();

            if (result.Correct)
            {
                foreach (ML.Departamento departamento in result.Objects)
                {
                    Console.WriteLine("El Id del departamento es: " + departamento.IdDepartamento);
                    Console.WriteLine("El nombre del departamento es: " + departamento.Nombre);
                    Console.WriteLine("El area del departamento es: " + departamento.Area.IdArea);
                    Console.WriteLine("----------------------------------------------------------");
                }
            }
            Console.ReadLine();
        }

        public static void GetByIdLINQ()  //Mostrar por Id
        {
            ML.Departamento departamento = new ML.Departamento(); //Instancia

            Console.WriteLine("Por favor ingrese el id del departamento: ");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());


            //ML.Result result = BL.Departamento.GetById(departamento.IdDepartamento);

            //ML.Result result = BL.Departamento.GetByIdEF(departamento.IdDepartamento);

            ML.Result result = BL.Departamento.GetByIdLINQ(departamento.IdDepartamento);

            if (result.Correct)
            {
                departamento = (ML.Departamento)result.Object; // unboxing 

                Console.WriteLine("El id del departamento es: " + departamento.IdDepartamento);
                Console.WriteLine("El nombre del departamento es: " + departamento.Nombre);
                Console.WriteLine("El area del departamento es: " + departamento.Area.IdArea);
                Console.WriteLine("----------------------------------------------------------");
            }

            Console.ReadKey();
        }

        public static void AddLINQ()  //Insertar
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Por favor ingrese el nombre del departamento. ");
            Console.Write("Nombre: ");
            departamento.Nombre = Console.ReadLine();

            Console.Write("Ingrese el area:  ");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Departamento.AddSP(departamento);//SP
            //ML.Result result = BL.Departamento.AddEF(departamento);//EF
            ML.Result result = BL.Departamento.AddLINQ(departamento);//LINQ

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
            }
        }

        public static void UpdateLINQ() //Actualizar
        {
            ML.Departamento departamento = new ML.Departamento(); //Instancia
            Console.WriteLine("Por favor ingrese el ID del Departamento: ");
            departamento.IdDepartamento = byte.Parse(Console.ReadLine());

            Console.WriteLine("Por favor ingrese los nuevos datos del Departamento");
            Console.WriteLine("Nombre: ");
            departamento.Nombre = Console.ReadLine();

            Console.Write("Ingrese el area del departamento: ");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());


            //ML.Result result = BL.Usuario.UpdateSP(usuario); //SP

            //ML.Result result = BL.Departamento.UpdateEF(departamento); //EF

            ML.Result result = BL.Departamento.UpdateLINQ(departamento); //LINQ

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
            }
            Console.ReadKey();
        }

        public static void DeleteLINQ()  //Eliminar
        {
            ML.Departamento departamento = new ML.Departamento(); //Instancia

            Console.WriteLine("Por favor ingrese el ID del departamento");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            // ML.Result result = BL.Departamento.DeleteSP(departamento); //SP

            // ML.Result result = BL.Departamento.DeleteEF(departamento); //EF

            ML.Result result = BL.Departamento.DeleteLINQ(departamento); //LINQ

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
            }
            Console.ReadKey();
        }

    }
}
