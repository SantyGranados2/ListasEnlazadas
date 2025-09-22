public class ListaEnlazada<T>
    {
        private Nodo<T> cabeza;

        public void Agregar(T dato)
        {
            Nodo<T> nuevo = new Nodo<T>(dato);
            if (cabeza == null)
                cabeza = nuevo;
            else
            {
                Nodo<T> temp = cabeza;
                while (temp.Siguiente != null)
                    temp = temp.Siguiente;
                temp.Siguiente = nuevo;
            }
        }

        public void Eliminar(Func<T, bool> criterio)
        {
            if (cabeza == null) return;

            if (criterio(cabeza.Dato))
            {
                cabeza = cabeza.Siguiente;
                return;
            }

            Nodo<T> actual = cabeza;
            while (actual.Siguiente != null)
            {
                if (criterio(actual.Siguiente.Dato))
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    return;
                }
                actual = actual.Siguiente;
            }
        }

        public void Listar(Action<T> accion)
        {
            Nodo<T> temp = cabeza;
            while (temp != null)
            {
                accion(temp.Dato);
                temp = temp.Siguiente;
            }
        }

        public T Buscar(Func<T, bool> criterio)
        {
            Nodo<T> temp = cabeza;
            while (temp != null)
            {
                if (criterio(temp.Dato))
                    return temp.Dato;
                temp = temp.Siguiente;
            }
            return default(T);
        }
    }