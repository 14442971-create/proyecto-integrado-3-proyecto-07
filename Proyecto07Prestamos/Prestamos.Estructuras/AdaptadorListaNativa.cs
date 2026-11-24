using System.Collections.Generic;

namespace Prestamos.Estructuras;

/// <summary>
/// Única clase autorizada para encapsular System.Collections.Generic.List<T>
/// con fines de validación funcional y contraste experimental.
/// </summary>
public sealed class AdaptadorListaNativa<T> : IEstructuraLineal<T>
{
    private readonly List<T> _coleccionNativa = new();

    public string NombreEstructura => "List<T> (.NET Nativa)";
    public int Conteo => _coleccionNativa.Count;
    public bool EstaVacia => _coleccionNativa.Count == 0;

    public void InsertarInicio(T elemento)
    {
        _coleccionNativa.Insert(0, elemento);
    }

    public void InsertarFinal(T elemento)
    {
        _coleccionNativa.Add(elemento);
    }

    public void InsertarEnPosicion(int indice, T elemento)
    {
        if (indice < 0 || indice > _coleccionNativa.Count)
            throw new ArgumentOutOfRangeException(nameof(indice));

        _coleccionNativa.Insert(indice, elemento);
    }

    public T? Buscar(Predicate<T> criterio)
    {
        ArgumentNullException.ThrowIfNull(criterio);
        return _coleccionNativa.Find(criterio);
    }

    public bool Eliminar(Predicate<T> criterio)
    {
        ArgumentNullException.ThrowIfNull(criterio);
        int idx = _coleccionNativa.FindIndex(criterio);
        if (idx < 0)
            return false;

        _coleccionNativa.RemoveAt(idx);
        return true;
    }

    public T? ObtenerEn(int indice)
    {
        return _coleccionNativa[indice];
    }

    public void Recorrer(Action<T> accion)
    {
        ArgumentNullException.ThrowIfNull(accion);
        for (int i = 0; i < _coleccionNativa.Count; i++)
        {
            accion(_coleccionNativa[i]);
        }
    }

    public void Limpiar()
    {
        _coleccionNativa.Clear();
    }
}
