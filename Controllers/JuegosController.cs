using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using streamingParadigmas.Clases;

namespace mvcPruebas.Controllers
{
    public class JuegosController : Controller
    {
        private readonly Proveedor _proveedor;

        public JuegosController(Proveedor proveedor)
        {
            _proveedor = proveedor;
        }

        public IActionResult Index()
        {
            var juegos = _proveedor.L_catalogoJuegos;
            return View(juegos);
        }
    }

}
