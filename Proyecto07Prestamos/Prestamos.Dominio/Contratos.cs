namespace Prestamos.Dominio;

public interface IRepositorio<T>
{
    int TotalRegistros { get; }
    void AgregarAlInicio(T entidad);
    void AgregarAlFinal(T entidad);
    void AgregarEnPosicion(int indice, T entidad);
    T? Buscar(Predicate<T> criterio);
    bool Eliminar(Predicate<T> criterio);
    T? ObtenerPorIndice(int indice);
    void Recorrer(Action<T> accion);
    void Limpiar();
}

public interface IRepositorioPrestamos<T> : IRepositorio<T>
{
    T? BuscarPorCodigoEquipo(string codigoEquipo);
    T? BuscarPorMatricula(string matricula);
}

public interface IServicioPrestamos
{
    int CantidadActivos { get; }
    void RegistrarPrestamoUrgente(Prestamo prestamo);
    void RegistrarPrestamoOrdinario(Prestamo prestamo);
    void RegistrarPrestamoEnPosicion(int indice, Prestamo prestamo);
    Prestamo? BuscarPorCodigoOMatricula(string criterio);
    bool RegistrarDevolucion(string codigoOMatricula);
    void RecorrerPrestamosActivos(Action<Prestamo> accion);
    void CargarDatosDemostracion();
}