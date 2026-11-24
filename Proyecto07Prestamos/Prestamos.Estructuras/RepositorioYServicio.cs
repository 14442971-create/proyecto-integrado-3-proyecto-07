using Prestamos.Dominio;

namespace Prestamos.Estructuras;

public sealed class RepositorioPrestamos : IRepositorioPrestamos<Prestamo>
{
    private readonly IEstructuraLineal<Prestamo> _estructura;

    public RepositorioPrestamos(IEstructuraLineal<Prestamo> estructura)
    {
        _estructura = estructura ?? throw new ArgumentNullException(nameof(estructura));
    }

    public int TotalRegistros => _estructura.Conteo;

    public void AgregarAlInicio(Prestamo entidad) => _estructura.InsertarInicio(entidad);
    public void AgregarAlFinal(Prestamo entidad) => _estructura.InsertarFinal(entidad);
    public void AgregarEnPosicion(int indice, Prestamo entidad) => _estructura.InsertarEnPosicion(indice, entidad);
    public Prestamo? Buscar(Predicate<Prestamo> criterio) => _estructura.Buscar(criterio);
    public bool Eliminar(Predicate<Prestamo> criterio) => _estructura.Eliminar(criterio);
    public Prestamo? ObtenerPorIndice(int indice) => _estructura.ObtenerEn(indice);
    public void Recorrer(Action<Prestamo> accion) => _estructura.Recorrer(accion);
    public void Limpiar() => _estructura.Limpiar();

    public Prestamo? BuscarPorCodigoEquipo(string codigoEquipo)
    {
        if (string.IsNullOrWhiteSpace(codigoEquipo)) return null;
        string buscado = codigoEquipo.Trim().ToUpperInvariant();
        return _estructura.Buscar(p => p.Equipo.Codigo == buscado);
    }

    public Prestamo? BuscarPorMatricula(string matricula)
    {
        if (string.IsNullOrWhiteSpace(matricula)) return null;
        string buscado = matricula.Trim().ToUpperInvariant();
        return _estructura.Buscar(p => p.MatriculaUsuario == buscado);
    }
}

public sealed class ServicioPrestamos : IServicioPrestamos
{
    private readonly IRepositorioPrestamos<Prestamo> _repositorio;

    public ServicioPrestamos(IRepositorioPrestamos<Prestamo> repositorio)
    {
        _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
    }

    public int CantidadActivos => _repositorio.TotalRegistros;

    public void RegistrarPrestamoUrgente(Prestamo prestamo)
    {
        ValidarDisponibilidadEquipo(prestamo);
        _repositorio.AgregarAlInicio(prestamo);
    }

    public void RegistrarPrestamoOrdinario(Prestamo prestamo)
    {
        ValidarDisponibilidadEquipo(prestamo);
        _repositorio.AgregarAlFinal(prestamo);
    }

    public void RegistrarPrestamoEnPosicion(int indice, Prestamo prestamo)
    {
        ValidarDisponibilidadEquipo(prestamo);
        _repositorio.AgregarEnPosicion(indice, prestamo);
    }

    public Prestamo? BuscarPorCodigoOMatricula(string criterio)
    {
        if (string.IsNullOrWhiteSpace(criterio))
            throw new ArgumentException("Ingrese un código de equipo o una matrícula para buscar.");

        Prestamo? porEquipo = _repositorio.BuscarPorCodigoEquipo(criterio);
        return porEquipo ?? _repositorio.BuscarPorMatricula(criterio);
    }

    public bool RegistrarDevolucion(string codigoOMatricula)
    {
        if (string.IsNullOrWhiteSpace(codigoOMatricula))
            throw new ArgumentException("Especifique el código de equipo o matrícula a devolver.");

        string clave = codigoOMatricula.Trim().ToUpperInvariant();
        Prestamo? existente = BuscarPorCodigoOMatricula(clave);
        if (existente is null)
            return false;

        existente.MarcarDevuelto();
        return _repositorio.Eliminar(p => p.IdPrestamo == existente.IdPrestamo);
    }

    public void RecorrerPrestamosActivos(Action<Prestamo> accion)
    {
        _repositorio.Recorrer(accion);
    }

    public void CargarDatosDemostracion()
    {
        if (_repositorio.TotalRegistros > 0) return;

        DateTime ahora = DateTime.Now;
        RegistrarPrestamoOrdinario(new Prestamo(
            "PR-001", "A01704512", "Valeria Mendoza",
            new Laptop("LAP-101", "Lenovo", "ThinkPad T14", "Ryzen 7 Pro", 16),
            ahora.AddHours(-2), ahora.AddHours(2), PrioridadPrestamo.Ordinario));

        RegistrarPrestamoUrgente(new Prestamo(
            "PR-002", "PROF-8821", "Dr. Carlos Herrera",
            new ProyectorMultimedia("PRY-204", "Epson", "PowerLite X49", 3600, "XGA 1024x768"),
            ahora.AddMinutes(-45), ahora.AddHours(3), PrioridadPrestamo.Urgente));

        RegistrarPrestamoOrdinario(new Prestamo(
            "PR-003", "A01709931", "Diego Salazar",
            new Tablet("TAB-305", "Apple", "iPad Air M2", 11.0, true),
            ahora.AddHours(-1), ahora.AddHours(4), PrioridadPrestamo.Ordinario));

        RegistrarPrestamoEnPosicion(1, new Prestamo(
            "PR-004", "A01703319", "Fernanda Ríos",
            new KitRobotica("ROB-402", "Arduino", "Engineering Kit R2", "Nano 33 IoT", 8),
            ahora.AddMinutes(-20), ahora.AddHours(5), PrioridadPrestamo.Programado));
    }

    private void ValidarDisponibilidadEquipo(Prestamo prestamo)
    {
        ArgumentNullException.ThrowIfNull(prestamo);
        Prestamo? ocupado = _repositorio.BuscarPorCodigoEquipo(prestamo.Equipo.Codigo);
        if (ocupado is not null)
            throw new InvalidOperationException($"El equipo {prestamo.Equipo.Codigo} ya se encuentra en préstamo activo ({ocupado.MatriculaUsuario}).");
    }
}
