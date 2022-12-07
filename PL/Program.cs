using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ent; //entidad
            int opc; //opcion

            Console.Write("****** BIENVENIDO ****** \n\n" +
                              "1) Usuario \n" +
                              "2) Departamento \n\n" +
                              "Selecciones una entidad: ");
            ent = int.Parse(Console.ReadLine());

            switch (ent)
            {
                case 1:
                                     
                        Console.Write("\n" + 
                                      "************ USUARIO *************\n\n" +
                                      "1) Mostrar Usuarios \n" +
                                      "2) Mostrar Usuario por ID \n" +
                                      "3) Insertar \n" +
                                      "4) Actualizar \n" +
                                      "5) Eliminar \n\n " +
                                      "**********************************\n" +
                                      "Selecciones una opcion: ");
                    opc = int.Parse(Console.ReadLine());

                    switch (opc)
                    {

                        case 1:
                            //Usuario.GetAll();
                           // Usuario.GetAllEF();
                            //Usuario.GetAllLINQ();
                            break;

                        case 2:
                            //Usuario.GetById();
                            Usuario.GetByIdEF();
                            //Usuario.GetByIdLINQ();
                            break;

                        case 3:
                            // Usuario.Add();                           
                            // Usuario.AddSP();
                             Usuario.AddEF();
                            // Usuario.AddLINQ();
                            break;

                        case 4:
                            // Usuario.Update();
                            // Usuario.UpdateSP();
                             Usuario.UpdateEF();
                            // Usuario.UpdateLINQ();
                            break;

                        case 5:
                            // Usuario.Deleted();
                            // Usuario.DeleteSP();
                               Usuario.DeleteEF();
                            // Usuario.DeleteLINQ();
                            break;

                        default:
                            Console.WriteLine("Opcion Invalida.");
                            break;
                    }

                            break;

                case 2:
                    Console.Write("\n"+
                                      "********** DEPARTAMENTO ********** \n\n" +
                                      "1) Mostrar Departamentos \n" +
                                      "2) Mostrar Departamento por ID \n" +
                                      "3) Insertar \n" +
                                      "4) Actualizar \n" +
                                      "5) Eliminar\n\n " +
                                      "********************************** \n"+
                                      "Selecciones una opcion: ");
                    opc = int.Parse(Console.ReadLine());

                    switch (opc) 
                    { 
                      case 1:
                         //Departamento.GetAll();
                         //Departamento.GetAllEF();
                           Departamento.GetAllLINQ();
                           break;

                      case 2:
                         //Departamento.GetById();
                         //Departamento.GetByIdEF();
                           Departamento.GetByIdLINQ();
                           break;

                      case 3:
                         //Departamento.AddSP();
                         //Departamento.AddEF();
                           Departamento.AddLINQ();
                           break;

                      case 4:
                         //Departamento.UpdateSP();
                         //Departamento.UpdateEF();        
                           Departamento.UpdateLINQ();        
                           break;

                      case 5:
                         //Departamento.DeleteSP();
                         //Departamento.DeleteEF();
                           Departamento.DeleteLINQ();
                          break;

                      default:
                          Console.Write("Opcion Invalida.");
                          break;
            }

            break;

                default:
                    Console.WriteLine("Por favor seleccione una entidad valida. ");
                    break;
            }
        }
    }
}
