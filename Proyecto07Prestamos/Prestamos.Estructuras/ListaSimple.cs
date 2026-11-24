namespace Prestamos.Estructuras;

public sealed class ListaSimple<T> : IEstructuraLineal<T>
{
    private Nodo<T>? _cabeza;
    private Nodo<T>? _cola;
    private int _conteo;

    public string NombreEstructura => "ListaSimple<T> (Propia)";
    public int Conteo => _conteo;
    public bool EstaVacia => _conteo == 0;

    public void InsertarInicio(T elemento)
    {
        var nuevo = new Nodo<T>(elemento);
        if (_cabeza is null)
        {
            _cabeza = nuevo;
            _cola = nuevo;
        }
        else
        {
            nuevo.Siguiente = _cabeza;
            _cabeza = nuevo;
        }
        _conteo++;
    }

    public void InsertarFinal(T elemento)
    {
        var nuevo = new Nodo<T>(elemento);
        if (_cabeza is null)
        {
            _cabeza = nuevo;
            _cola = nuevo;
        }
        else
        {
            _cola!.Siguiente = nuevo;
            _cola = nuevo;
        }
        _conteo++;
    }

    public void InsertarEnPosicion(int indice, T elemento)
    {
        if (indice < 0 || indice > _conteo)
            throw new ArgumentOutOfRangeException(nameof(indice), $"Índice fuera de rango (0 a {_conteo}).");

        if (indice == 0)
        {
            InsertarInicio(elemento);
            return;
        }

        if (indice == _conteo)
        {
            InsertarFinal(elemento);
            return;
        }

        var nuevo = new Nodo<T>(elemento);
        Nodo<T> actual = _cabeza!;
        for (int i = 0; i < indice - 1; i++)
        {
            actual = actual.Siguiente!;
        }

        nuevo.Siguiente = actual.Siguiente;
        actual.Siguiente = nuevo;
        _conteo++;
    }

    public T? Buscar(Predicate<T> criterio)
    {
        ArgumentNullException.ThrowIfNull(criterio);

        Nodo<T>? actual = _cabeza;
        while (actual is not null)
        {
            if (criterio(actual.Valor))
                return actual.Valor;
            actual = actual.Siguiente;
        }
        return default;
    }

    public bool Eliminar(Predicate<T> criterio)
    {
        ArgumentNullException.ThrowIfNull(criterio);

        if (_cabeza is null)
            return false;

        if (criterio(_cabeza.Valor))
        {
            _cabeza = _cabeza.Siguiente;
            if (_cabeza is null)
                _cola = null;
            _conteo--;
            return true;
        }

        Nodo<T> anterior = _cabeza;
        Nodo<T>? actual = _cabeza.Siguiente;

        while (actual is not null)
        {
            if (criterio(actual.Valor))
            {
                anterior.Siguiente = actual.Siguiente;
                if (actual.Siguiente is null)
                    _cola = anterior;
                _conteo--;
                return true;
            }
            anterior = actual;
            actual = actual.Siguiente;
        }

        return false;
    }

    public T? ObtenerEn(int indice)
    {
        if (indice < 0 || indice >= _conteo)
            throw new ArgumentOutOfRangeException(nameof(indice));

        Nodo<T> actual = _cabeza!;
        for (int i = 0; i < indice; i++)
        {
            actual = actual.Siguiente!;
        }
        return actual.Valor;
    }

    public void Recorrer(Action<T> accion)
    {
        ArgumentNullException.ThrowIfNull(accion);

        Nodo<T>? actual = _cabeza;
        while (actual is not null)
        {
            accion(actual.Valor);
            actual = actual.Siguiente;
        }
    }

    public void Limpiar()
    {
        _cabeza = null;
        _cola = null;
        _conteo = 0;
    }
}
