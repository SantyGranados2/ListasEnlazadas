public class GestorTienda
    {
        private ListaEnlazada<Tienda> tiendas = new ListaEnlazada<Tienda>();

        public void AgregarTienda(string nombre, string nit, string direccion, string celular)
        {
            tiendas.Agregar(new Tienda(nombre, nit, direccion, celular));
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