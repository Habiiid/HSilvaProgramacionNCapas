using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // ************** CRUD ****************

        // GET: Usuario

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario(); //instancia
            ML.Result result = BL.Usuario.GetAllEF(usuario); //mandamos a llamar el metodo con EF
                     

            if (result.Correct) //validacion 
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
            }

            return View(usuario);
        }

        [HttpGet] //muestra las vistas
        public ActionResult Form(int? IdUsuario)
        {

            ML.Usuario usuario = new ML.Usuario(); //instancia de la clase usuario
            usuario.Rol = new ML.Rol(); //Objeto de la instancia

            //Objeto  //Instancias de Tabla Direccion
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();//Instancias de las rutas
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();//Instancias de las rutas

            //instancias
            ML.Result resultRol = BL.Rol.GetAll();
            ML.Result resultPaises = BL.Pais.GetAll();//metodo GetAll de rol


            if (IdUsuario == null) //validacion de la informacion
            {
                usuario.Rol.Roles = resultRol.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;

                return View(usuario); //regresa a la vista
            }
            else
            {
                //GetById
                ML.Result result = BL.Usuario.GetByIdEF(IdUsuario.Value);

                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;

                    usuario.Rol.Roles = resultRol.Objects;

                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;                     

                    ML.Result resultEstados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;

                    ML.Result resultMunicipios = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                    usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;

                    ML.Result resultColonias = BL.Colonia.GetbyIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                    usuario.Direccion.Colonia.Colonias = resultColonias.Objects;
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error";
                }
                return View(usuario);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

           // HttpPostedFileBase file = Request.Files["ImagenData"]; //busca el archivo

            //if (file.ContentLength > 0) //validacion
            //{
            //    usuario.Imagen = ConvertToBytes(file); //convierte la imagen en un arreglo de bytes
            //}
                
            if (usuario.IdUsuario == 0)
            {
                //ADD
                result = BL.Usuario.AddEF(usuario);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Error" + result.Message;
                }
            }
            else
            {
                //Update
                result = BL.Usuario.UpdateEF(usuario);

                if (result.Correct)
                {
                    ViewBag.Massage = "Se actualizo correctamente el usuario. " + result.Message;
                }
                else
                {
                    ViewBag.Massage = "Error: " + result.Message;
                }
            }

            return PartialView("Modal");
        }

        //[HttpDelete]
        public ActionResult Delete(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.DeleteEF(usuario);

            if (usuario != null)
            {
                if (result.Correct)
                {
                    ViewBag.Massage = result.Message;
                }
                else
                {
                    ViewBag.Massage = "Error: " + result.Message;
                }
            }
            else
            {
                return Redirect("/Usuario/GetAll");
            }
            return PartialView("Modal");
        }

        //metodo para agregar Imagen
        //public Byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        //{
            
        //        byte[] data = null; //inicializamos el arreglo en null
        //        System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream); //libreria
        //        data = reader.ReadBytes((int)Imagen.ContentLength); //igualamos el arreglo a la lista de bytes

        //        return data;
              
        //}

        //metodo para mostrar la imagen


        //JSON  DROP DOWN LIST EN CASCADA 

        public JsonResult GetEstado(int IdPais)
        {
            var result= BL.Estado.GetByIdPais(IdPais);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMunicipio(int IdEstado)
        {
            var result = BL.Municipio.GetByIdEstado(IdEstado);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetColonia(int IdMunicipio)
        {
            var result = BL.Colonia.GetbyIdMunicipio(IdMunicipio);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
  
    }
}

