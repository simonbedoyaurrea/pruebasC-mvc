using Microsoft.AspNetCore.Mvc;
using mvcPruebas.Services;
using streamingParadigmas.Clases;

namespace mvcPruebas.Controllers
{
    public class CuentaController : Controller
    {

        private ProveedorService _pService;

        public CuentaController(ProveedorService pService)
        {
            _pService = pService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult JugarJuego(string nombreJuego)
        {
            var cuentaIniciada = HttpContext.Session.GetString("cuentaActiva");

            if (string.IsNullOrEmpty(cuentaIniciada))
            {
                return RedirectToAction("Login", "Cuenta"); 
            }

            var cuentaEncontrada = _pService.BuscarCuenta(cuentaIniciada);
            if (cuentaEncontrada == null)
            {
                return NotFound("Cuenta no encontrada");
            }

            var juegoJugado = _pService.BuscarJuego(nombreJuego);
            if (juegoJugado == null)
            {
                return NotFound("Juego no encontrado");
            }

            cuentaEncontrada.JugarJuego(juegoJugado);

            return RedirectToAction("Index", "Proveedor");
        }

    }
}
