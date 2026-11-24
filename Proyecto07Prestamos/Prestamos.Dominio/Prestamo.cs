namespace Prestamos.Dominio;

public sealed class Prestamo
{
    private string _idPrestamo = string.Empty;
    private string _matriculaUsuario = string.Empty;
    private string _nombreUsuario = string.Empty;
    private EquipoTecnologico _equipo = null!;
    private DateTime _fechaHoraInicio;
    private DateTime _fechaHoraLimite;
    private PrioridadPrestamo _prioridad;
    private EstadoPrestamo _estado;

    public Prestamo(
        string idPrestamo,
        string matriculaUsuario,
        string nombreUsuario,
        EquipoTecnologico equipo,
        DateTime fechaHoraInicio,
        DateTime fechaHoraLimite,
        PrioridadPrestamo prioridad)
    {
        IdPrestamo = idPrestamo;
        MatriculaUsuario = matriculaUsuario;
        NombreUsuario = nombreUsuario;
        Equipo = equipo;
        FechaHoraInicio = fechaHoraInicio;
        FechaHoraLimite = fechaHoraLimite;
        Prioridad = prioridad;
        _estado = EstadoPrestamo.Activo;
    }

    public string IdPrestamo
    {
        get => _idPrestamo;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El identificador de préstamo es obligatorio.");
            _idPrestamo = value.Trim().ToUpperInvariant();
        }
    }

    public string MatriculaUsuario
    {
        get => _matriculaUsuario;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Trim().Length < 5 || value.Trim().Length > 15)
                throw new ArgumentException("La matrícula debe contener entre 5 y 15 caracteres válidos.");
            _matriculaUsuario = value.Trim().ToUpperInvariant();
        }
    }

    public string NombreUsuario
    {
        get => _nombreUsuario;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Trim().Length < 3)
                throw new ArgumentException("El nombre del solicitante debe tener al menos 3 caracteres.");
            _nombreUsuario = value.Trim();
        }
    }

    public EquipoTecnologico Equipo
    {
        get => _equipo;
        set => _equipo = value ?? throw new ArgumentNullException(nameof(Equipo), "Debe asociar un equipo tecnológico.");
    }

    public DateTime FechaHoraInicio
    {
        get => _fechaHoraInicio;
        set => _fechaHoraInicio = value;
    }

    public DateTime FechaHoraLimite
    {
        get => _fechaHoraLimite;
        set
        {
            if (value <= _fechaHoraInicio)
                throw new ArgumentException("La fecha límite debe ser posterior al inicio del préstamo.");
            _fechaHoraLimite = value;
        }
    }

    public PrioridadPrestamo Prioridad
    {
        get => _prioridad;
        set => _prioridad = value;
    }

    public EstadoPrestamo Estado => _estado;

    public void MarcarDevuelto()
    {
        _estado = EstadoPrestamo.Devuelto;
    }
}
