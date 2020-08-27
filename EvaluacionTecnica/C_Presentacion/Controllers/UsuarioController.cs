using C_Entidades;
using C_Presentacion.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace C_Presentacion.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        C_Negocios.N_Usuario Usu = new C_Negocios.N_Usuario();
        C_Negocios.N_Departamentos Depa = new C_Negocios.N_Departamentos();
        C_Negocios.N_Provincia prov = new C_Negocios.N_Provincia();
        C_Negocios.N_Distrito dis = new C_Negocios.N_Distrito();
        C_Negocios.N_Documento doc = new C_Negocios.N_Documento();





        public ActionResult Index()
        {
            if (Session["nombres"] == null && Session["usuario"] == null)
            {
                return View("Login", new Login());

            }
            else
            {
                var list = Usu.ListarUsuario();
            return View(list);
            }
        }
        public ActionResult Create()
        {

            if (Session["nombres"] == null && Session["usuario"] == null)
            {
                return View("Login", new Login());

            }
            else
            {
                ViewBag.Documento = doc.ListarDepartamentos();
                ViewBag.Departamento = Depa.ListarDepartamentos();

                return View("Create", new Usuarios());
            }

           
            /* try
             {
                 if (Request.IsAjaxRequest())
                 {
                     return View("Create");
                 }
               //  return Json("No es una peticion ajax", JsonRequestBehavior.AllowGet);
             }
             catch (Exception e)
             {

               //  return Json("Sucedio un error al momento de obtener informacion", JsonRequestBehavior.AllowGet);
             } */
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuarios usu)
        {
            if (ModelState.IsValid) {
                 Usu.Crear(usu);
            }

            return RedirectToAction("Index");
        }

        ///Edit
         [HttpGet]
        public ActionResult Edit(int id)
        {
            Usuarios usu;
            List<Usuarios> dto = Usu.ListarUsuario();
            usu = dto.FirstOrDefault(x => x.id_Usuario == id);

            ViewBag.Documento = doc.ListarDepartamentos();

            ViewBag.Departamento = Depa.ListarDepartamentos();
            ViewBag.Depa  = (int)usu.id_Depa;

            ViewBag.Provincia = (int)usu.id_Provincia ;
            //Console.WriteLine("LA PROVINCIA ES "); 
            
            ViewBag.Distrito = dis.ListarDistrito((int)usu.id_Distrito);


            return View("Edit", usu);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {

            Usuarios usu;
            List<Usuarios> dto = Usu.ListarUsuario();
            usu = dto.FirstOrDefault(x => x.id_Usuario == id);
            return View("Details", usu);
        }
        [HttpPost]
        public ActionResult Edit(Usuarios usua)
        {
            if (ModelState.IsValid)
            {
                //     producto.id_Producto = id_prod;
                Usu.Editar(usua);
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Delete(int id)
        {
            Usu.Eliminar(id);
            return RedirectToAction("Index");
              
        }




        public JsonResult JSONListaDocumento()
        {
            var lstListaDocumento = (List<Documento>)doc.ListarDepartamentos();
            return Json(lstListaDocumento, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JSONListaProvincia(String id)
        {
            var lstListaProvincia = (List<Provincias>)prov.ListarProvincia(int.Parse(id));
            return Json(lstListaProvincia, JsonRequestBehavior.AllowGet);
        }
        public JsonResult JSONListaDepartamento()
        {
            var lstListaDepartamenmto = (List<Departamentos>)Depa.ListarDepartamentos();
            return Json(lstListaDepartamenmto, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JSONListaDistrito(String id)
        {
            var lstListaDistrito = (List<Distritos>)dis.ListarDistrito((int.Parse(id)));
            return Json(lstListaDistrito, JsonRequestBehavior.AllowGet);
        }


        //////////////////LOGIN////////////////////

        public ActionResult Login() {

            if (Session["usuario"] == null) {
                return View("Login", new  Login());
            }

            return RedirectToAction("Index", "Usuario");
        }


        [HttpPost]
        public ActionResult Login(Login login)
        {

            if (ModelState.IsValid)
            {
                Usuarios usuario = new Usuarios();
                  usuario = Usu.Login(login);

                if (usuario.nombre == null && usuario.usuario == null)
                {
                    return View("Login", new Login());
                     
                }
                else {
                    Session["nombres"] = usuario.nombre;
                    Session["usuario"] = usuario.usuario;
                    return RedirectToAction("Index", "Usuario");
                }
               
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("nombres");
            Session.Remove("usuario");

            return Redirect("/Usuario/Login");
        }


    }
}