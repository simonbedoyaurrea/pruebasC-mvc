using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvcPruebas.Services;
using streamingParadigmas.Clases;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace mvcPruebas.Controllers
{
    public class ProveedorController : Controller
    {

        private ProveedorService _pService;

        public ProveedorController(ProveedorService pService)
        {
            _pService = pService;
        }


        public IActionResult Index()
        {
            List<Cuenta> cuentas = _pService.MostrarCuentas();
            return View(cuentas);
        }

        public IActionResult Login()
        {
            
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Registro(string username)
        {
            _pService.AgregarCuenta(username);
            HttpContext.Session.SetString("cuentaActiva",username);
            return RedirectToAction("Index");
        }

        public IActionResult Login(string username)
        {
           var cuenta= _pService.IniciarSesion(username);
            if (cuenta != null)
            {
                HttpContext.Session.SetString("cuentaActiva", cuenta.Usuario.Nombre);
            }

            return View();
        }



    }
}
