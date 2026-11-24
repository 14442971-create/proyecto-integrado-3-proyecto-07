namespace Prestamos.Estructuras;

public sealed class Nodo<T>
{
    private T _valor;
    private Nodo<T>? _siguiente;

    public Nodo(T valor)
    {
        _valor = valor;
        _siguiente = null;
    }

    public T Valor
    {
        get => _valor;
        set => _valor = value;
    }

    public Nodo<T>? Siguiente
    {
        get => _siguiente;
        set => _siguiente = value;
    }
}
