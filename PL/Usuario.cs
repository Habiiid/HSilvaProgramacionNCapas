using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    //Tabla Usuario
    public class Usuario
    {
        public static void GetAllEF(ML.Usuario usuario)  //Mostrar Todo

        {   //ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetAllEF(usuario); 

            if (result.Correct)
            {
                foreach (ML.Usuario usuario1 in result.Objects)
                {
                    Console.WriteLine("El id del usuario es:" + usuario.IdUsuario);
                    Console.WriteLine("El nombre del usuario es:" + usuario.Nombre);
                    Console.WriteLine("El apellido paterno del usuario es:" + usuario.ApellidoPaterno);
                    Console.WriteLine("El apellido materno del usuario es:" + usuario.ApellidoMaterno);
                    Console.WriteLine("La fecha de nacimiento del usuario es:" + usuario.FechaNacimiento);
                    Console.WriteLine("El genero del usuario es:" + usuario.Genero);
                    Console.WriteLine("El username del usuario es:" + usuario.UserName);
                    Console.WriteLine("El email del usuario es:" + usuario.Email);
                    Console.WriteLine("El password del usuario es:" + usuario.Password);
                    Console.WriteLine("El telefono del usuario es:" + usuario.Telefono);
                    Console.WriteLine("El celular del usuario es:" + usuario.Celular);
                    Console.WriteLine("El curp del usuario es:" + usuario.CURP);
                    Console.WriteLine("El rol del usuario es:" + usuario.Rol.IdRol);
                    Console.WriteLine("----------------------------------------------------------");
                }
            }
            Console.ReadLine();
        }
    
        public static void GetByIdEF()  //Mostrar por Id
        {
            ML.Usuario usuario = new ML.Usuario(); //Instancia

            Console.WriteLine("Por favor ingrese el Id del usuario: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());
          
            //ML.Result result = BL.Usuario.GetById(usuario.IdUsuario);
          
              ML.Result result = BL.Usuario.GetByIdEF(usuario.IdUsuario);
           
            //ML.Result result = BL.Usuario.GetByIdLINQ(usuario.IdUsuario);

            if (result.Correct)
            {
                usuario = (ML.Usuario)result.Object; // unboxing 

                Console.WriteLine("El Id del usuario es: " + usuario.IdUsuario);
                Console.WriteLine("El nombre del usuario es: " + usuario.Nombre);
                Console.WriteLine("El apellido paterno del usuario es: " + usuario.ApellidoPaterno);
                Console.WriteLine("El apellido materno del usuario es: " + usuario.ApellidoMaterno);
                Console.WriteLine("La fecha de nacimiento del usuario es: " + usuario.FechaNacimiento);
                Console.WriteLine("El genero del usuario es: " + usuario.Genero);
                Console.WriteLine("El username del usuario es: " + usuario.UserName);
                Console.WriteLine("El email del usuario es: " + usuario.Email);
                Console.WriteLine("El password del usuario es: " + usuario.Password);
                Console.WriteLine("El telefono del usuario es: " + usuario.Telefono);
                Console.WriteLine("El celular del usuario es: " + usuario.Celular);
                Console.WriteLine("El curp del usuario es: " + usuario.CURP);
                Console.WriteLine("El rol del usuario es: " + usuario.Rol.IdRol);
                Console.WriteLine("----------------------------------------------------------");
            }

            Console.ReadKey();
        }

        public static void AddEF()    //Insertar 
        {
            ML.Usuario usuario = new ML.Usuario(); //Instancia

            Console.WriteLine("Por favor ingrese los datos del Usuario");
            Console.WriteLine("Nombre: ");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Apellido Paterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Apellido Materno: ");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Fecha Nacimiento (dd--mm-yyy): ");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Genero (M-F):  ");
            usuario.Genero = Console.ReadLine();

            Console.WriteLine("UserName:  ");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Email:  ");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Password:  ");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Telefono:  ");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Celular:  ");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("CURP:  ");
            usuario.CURP = Console.ReadLine();

            Console.Write("Ingrese el rol del usuario:  ");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            //llenamos el objeto de informacion 

          //  ML.Result result = BL.Usuario.Add(usuario);   //query 
          //  ML.Result result = BL.Usuario.AddSP(usuario); //SP
              ML.Result result = BL.Usuario.AddEF(usuario); //EF
          //  ML.Result result = BL.Usuario.AddLINQ(usuario); //LINQ

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
                Console.ReadKey();
            }

        }

        public static void UpdateEF() //Actualizar
        {
            ML.Usuario usuario = new ML.Usuario(); //Instancia
            Console.WriteLine("Por favor ingrese el ID del Usuario");
            usuario.IdUsuario = byte.Parse(Console.ReadLine());

            Console.WriteLine("Por favor ingrese los nuevos datos del Usuario");
            Console.WriteLine("Nombre: ");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Apellido Paterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Apellido Materno: ");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Fecha Nacimiento (dd-mm-yyyyy): ");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Genero (M-F):  ");
            usuario.Genero = Console.ReadLine();

            Console.WriteLine("UserName:  ");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Email:  ");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Password:  ");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Telefono:  ");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Celular:  ");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("CURP:  ");
            usuario.CURP = Console.ReadLine();

            Console.Write("Ingrese el rol del usuario:  ");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            // ML.Result result = BL.Usuario.Update(usuario);  //query
            // ML.Result result = BL.Usuario.UpdateSP(usuario); //SP
               ML.Result result = BL.Usuario.UpdateEF(usuario); //EF
            // ML.Result result = BL.Usuario.UpdateLINQ(usuario); //LINQ

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
            }
            Console.ReadKey();
        }
       
        public static void DeleteEF()  //Eliminar
        {
            ML.Usuario usuario = new ML.Usuario(); //Instancia

            Console.WriteLine("Por favor ingrese el ID del Usuario");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

         // ML.Result result = BL.Usuario.Deleted(usuario);  //query
         // ML.Result result = BL.Usuario.DeleteSP(usuario); //SP
            ML.Result result = BL.Usuario.DeleteEF(usuario); //EF
         // ML.Result result = BL.Usuario.DeleteLINQ(usuario); //LINQ

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
            }
            Console.ReadKey();
        }
     
    }

}