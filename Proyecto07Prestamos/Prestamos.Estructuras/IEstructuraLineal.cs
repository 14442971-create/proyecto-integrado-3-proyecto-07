namespace Prestamos.Estructuras;

public interface IEstructuraLineal<T>
{
    string NombreEstructura { get; }
    int Conteo { get; }
    bool EstaVacia { get; }
    void InsertarInicio(T elemento);
    void InsertarFinal(T elemento);
    void InsertarEnPosicion(int indice, T elemento);
    T? Buscar(Predicate<T> criterio);
    bool Eliminar(Predicate<T> criterio);
    T? ObtenerEn(int indice);
    void Recorrer(Action<T> accion);
    void Limpiar();
}
