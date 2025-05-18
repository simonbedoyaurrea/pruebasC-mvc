using streamingParadigmas.Clases;

namespace mvcPruebas.Services
{
    public class ProveedorService
    {
        private Proveedor _proveedor;
        public List<Cuenta> l_cuentas;

        public ProveedorService(Proveedor proveedor)
        {
            _proveedor = proveedor;
            l_cuentas = new List<Cuenta>();

        }

        public Cuenta BuscarCuenta(string nombreUsuario) {
           return  l_cuentas.Find(c => c.Usuario.Nombre == nombreUsuario);

        }

        public Juego BuscarJuego(string nombreJuego) {

            return _proveedor.L_catalogoJuegos.Find(j => j.Nombre == nombreJuego);
        }


        public List<Cuenta> MostrarCuentas() {
            return l_cuentas;
        }

        public void AgregarCuenta(string nombre) {
            //_proveedor.AgregarCuenta(nombre);
            Usuario usu = new Usuario(nombre);
            Cuenta cu = new Cuenta(usu);
            l_cuentas.Add(cu);
        }

        public Cuenta IniciarSesion(string nombre) {

            try
            {
                Cuenta cuentaBuscada=l_cuentas.Find(c => c.Usuario.Nombre == nombre);
                return cuentaBuscada;
            }
            catch {
                throw new Exception("cuenta no encontrada");
            }

        }
    }
}
