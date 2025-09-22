public class Producto
    {
        public string Nombre { get; set; }
        public string Id { get; set; }
        public float Precio { get; set; }

        public override string ToString()
        {
            return $"{Nombre} - ${Precio}";
        }
    }