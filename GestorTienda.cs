public class GestorTienda
    {
        private ListaEnlazada<Tienda> tiendas = new ListaEnlazada<Tienda>();

        public void AgregarTienda(string nombre)
        {
            tiendas.Agregar(new Tienda(nombre));
        }

        public void EliminarTienda(string nombre)
        {
            tiendas.Eliminar(t => t.Nombre == nombre);
        }

        public void ListarTiendas()
        {
            tiendas.Listar(t => Console.WriteLine(t.Nombre));
        }

        public Tienda BuscarTienda(string nombre)
        {
            return tiendas.Buscar(t => t.Nombre == nombre);
        }
    }