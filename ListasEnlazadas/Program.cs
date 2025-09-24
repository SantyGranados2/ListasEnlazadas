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

            opcion = PedirEntero("Seleccione una opción: ");

            switch (opcion)
            {
                case 1:
                    string nombreTienda = PedirDatoObligatorio("Nombre de la tienda: ");
                    string nit = PedirDatoObligatorio("NIT de la tienda: ");
                    string direccion = PedirDatoObligatorio("Dirección de la tienda: ");
                    string celular = PedirDatoObligatorio("Celular de la tienda: ");

                    gestor.AgregarTienda(nombreTienda, nit, direccion, celular);
                    Console.WriteLine($"Tienda '{nombreTienda}' creada exitosamente.");
                    break;

                case 2:
                    gestor.ListarTiendas();
                    break;

                case 3:
                    string eliminarTienda = PedirDatoObligatorio("Nombre de la tienda a eliminar: ");
                    Tienda tiendaAEliminar = gestor.BuscarTienda(eliminarTienda);

                    if (tiendaAEliminar != null)
                    {
                        gestor.EliminarTienda(eliminarTienda);
                        Console.WriteLine($"Tienda '{eliminarTienda}' eliminada con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("No existe una tienda con ese nombre.");
                    }
                    break;

                case 4:
                    string nombreSelec = PedirDatoObligatorio("Nombre de la tienda a seleccionar: ");
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
                            subopcion = PedirEntero("Seleccione una opción: ");

                            switch (subopcion)
                            {
                                case 1:
                                    string prod = PedirDatoObligatorio("Nombre del producto: ");
                                    float precio = PedirFloat("Precio del producto: ");

                                    tiendaSeleccionada.Productos.Agregar(new Producto { Nombre = prod, Precio = precio });
                                    Console.WriteLine($"Producto '{prod}' agregado exitosamente.");
                                    break;

                                case 2:
                                    tiendaSeleccionada.Productos.Listar(p => Console.WriteLine(p));
                                    break;

                                case 3:
                                    string prodEliminar = PedirDatoObligatorio("Nombre del producto a eliminar: ");
                                    Producto prodBuscado = tiendaSeleccionada.Productos.Buscar(p => p.Nombre == prodEliminar);

                                    if (prodBuscado != null)
                                    {
                                        tiendaSeleccionada.Productos.Eliminar(p => p.Nombre == prodEliminar);
                                        Console.WriteLine($"Producto '{prodEliminar}' eliminado con éxito.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("No existe un producto con ese nombre.");
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Opción no válida, intente de nuevo");
                                    break;
                            }
                        } while (subopcion != 0);
                    }
                    else
                    {
                        Console.WriteLine("Tienda no encontrada.");
                    }
                    break;

                default:
                    Console.WriteLine("Opción no válida, intente de nuevo");
                    break;
            }
        } while (opcion != 0);

        Console.WriteLine("Saliendo del sistema");
    }

    static string PedirDatoObligatorio(string mensaje)
    {
        string dato;
        do
        {
            Console.Write(mensaje);
            dato = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(dato))
            {
                Console.WriteLine("Este campo es obligatorio. Por favor, ingrese un valor.");
            }
        } while (string.IsNullOrWhiteSpace(dato));
        return dato;
    }

    static int PedirEntero(string mensaje)
    {
        int numero;
        string input;
        do
        {
            Console.Write(mensaje);
            input = Console.ReadLine();
            if (!int.TryParse(input, out numero))
            {
                Console.WriteLine("⚠ Debe ingresar solo números enteros. Intente de nuevo.");
            }
        } while (!int.TryParse(input, out numero));
        return numero;
    }

    static float PedirFloat(string mensaje)
    {
        float numero;
        string input;
        do
        {
            Console.Write(mensaje);
            input = Console.ReadLine();
            if (!float.TryParse(input, out numero) || numero < 0)
            {
                Console.WriteLine("⚠ Ingrese un número válido para el precio (ej: 1500.50).");
            }
        } while (!float.TryParse(input, out numero) || numero < 0);
        return numero;
    }  
}