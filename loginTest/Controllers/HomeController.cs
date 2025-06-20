using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Business;
using Entity;

namespace loginTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult ObtenerTareas()
        {
            var tareas = new TareasListadoBusiness().ListarTareas();
            return Json(tareas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Editar(Tarea tarea)
        {
            var editada = new TareasListadoBusiness().EditarTarea(tarea);
            if(!editada)
                return Json(new { success = false, JsonRequestBehavior.AllowGet });
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Agregar(Tarea tarea)
        {
            var agregada = new TareasListadoBusiness().AgregarTarea(tarea);
            if (!agregada)
                return Json(new { success = false, JsonRequestBehavior.AllowGet });
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Eliminar(Tarea tarea)
        {
            var eliminada = new TareasListadoBusiness().EliminarTarea(tarea);
            if (!eliminada)
                return Json(new { success = false, JsonRequestBehavior.AllowGet });
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}