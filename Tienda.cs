public class Tienda
    {
        public string Nombre { get; set; }
        public string Nit { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public ListaEnlazada<Producto> Productos { get; set; }

        public Tienda(string _nombre, string _NIT, string _direccion, string _celular)
        {
            Nombre = _nombre;
            Nit = _NIT;
            Direccion = _direccion;
            Celular = _celular;
            Productos = new ListaEnlazada<Producto>();
        }

        public override string ToString()
        {
            return $"Tienda: {Nombre}";
        }
    }