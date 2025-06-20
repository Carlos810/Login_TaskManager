
using System.Web.Mvc;
using Data;
using Entity;

namespace loginTest.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public JsonResult Login(LoginUsuarios credentials)
        {
            bool accesoPermitido = false;
            if (credentials == null)
                return Json(new { success = false, message = "Credenciales vacias" });

            if(credentials != null)
            {
                accesoPermitido = new LoginData().ValidandoAccesoUsuario(credentials);
                if (accesoPermitido)
                    return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
            }
            return Json(new { success = false, message = "Credenciales incorrectas" });
        }

    }
}