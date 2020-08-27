using C_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace C_Presentacion.Controllers
{
    public class DcoumentoController : Controller
    {
        // GET: Dcoumento
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(Documento doc)
        {
            if (ModelState.IsValid) {
                var model = doc;
            }
            return View();
        }

    }
}