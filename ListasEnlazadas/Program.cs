class Program
{
    static void Main(string[] args)
    {
        GestorTienda gestor = new GestorTienda();
        int opcion;

        do
        {
            Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
            Console.WriteLine("1. Crear Tienda");
            Console.WriteLine("2. Listar Tienda");
            Console.WriteLine("3. Borrar Tiendas");
            Console.WriteLine("4. Escoger Tienda");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Nombre de la tienda: ");
                    string nombreTienda = Console.ReadLine();
                    
                    Console.Write("NIT de la tienda: ");
                    string nit = Console.ReadLine();

                    Console.Write("Dirección de la tienda: ");
                    string direccion = Console.ReadLine();

                    Console.Write("Celular de la tienda: ");
                    string celular = Console.ReadLine();

                    gestor.AgregarTienda(nombreTienda, nit, direccion, celular);
                    break;
                case 2:
                    gestor.ListarTiendas();
                    break;
                case 3:
                    Console.Write("Nombre de la tienda a eliminar: ");
                    string eliminarTienda = Console.ReadLine();
                    gestor.EliminarTienda(eliminarTienda);
                    break;
                case 4:
                    Console.Write("Nombre de la tienda a seleccionar: ");
                    string nombreSelec = Console.ReadLine();
                    Tienda tiendaSeleccionada = gestor.BuscarTienda(nombreSelec);
                    if (tiendaSeleccionada != null)
                    {
                        int subopcion;
                        do
                        {
                            Console.WriteLine($"\n--- MENÚ TIENDA: {tiendaSeleccionada.Nombre} ---");
                            Console.WriteLine("1. Agregar Producto");
                            Console.WriteLine("2. Listar Productos");
                            Console.WriteLine("3. Borrar Producto");
                            Console.WriteLine("0. Volver al menú principal");
                            Console.Write("Seleccione una opción: ");
                            subopcion = int.Parse(Console.ReadLine());

                            switch (subopcion)
                            {
                                case 1:
                                    Console.Write("Nombre del producto: ");
                                    string prod = Console.ReadLine();
                                    Console.Write("Precio: ");
                                    float precio = float.Parse(Console.ReadLine());
                                    tiendaSeleccionada.Productos.Agregar(new Producto { Nombre = prod, Precio = precio });
                                    break;
                                case 2:
                                    tiendaSeleccionada.Productos.Listar(p => Console.WriteLine(p));
                                    break;
                                case 3:
                                    Console.Write("Nombre del producto a eliminar: ");
                                    string prodEliminar = Console.ReadLine();
                                    tiendaSeleccionada.Productos.Eliminar(p => p.Nombre == prodEliminar);
                                    break;
                            }
                        } while (subopcion != 0);
                    }
                    else
                    {
                        Console.WriteLine("Tienda no encontrada.");
                    }
                    break;
            }
        } while (opcion != 0);

        Console.WriteLine("Saliendo del sistema...");
    }
}