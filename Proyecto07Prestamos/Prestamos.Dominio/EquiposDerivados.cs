
namespace Prestamos.Dominio;

public sealed class Laptop : EquipoTecnologico
{
    private string _procesador = string.Empty;
    private int _memoriaRamGb;

    public Laptop(string codigo, string marca, string modelo, string procesador, int memoriaRamGb)
        : base(codigo, marca, modelo)
    {
        Procesador = procesador;
        MemoriaRamGb = memoriaRamGb;
    }

    public string Procesador
    {
        get => _procesador;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El procesador de la laptop es obligatorio.");
            _procesador = value.Trim();
        }
    }

    public int MemoriaRamGb
    {
        get => _memoriaRamGb;
        set
        {
            if (value < 4 || value > 256)
                throw new ArgumentOutOfRangeException(nameof(MemoriaRamGb), "La RAM debe estar entre 4 GB y 256 GB.");
            _memoriaRamGb = value;
        }
    }

    public override string Categoria => "Laptop";
    public override decimal TarifaPenalizacionHora => 50.00m;
    public override string ObtenerEspecificacionTecnica() => $"CPU {Procesador}, {MemoriaRamGb} GB RAM";
}

public sealed class ProyectorMultimedia : EquipoTecnologico
{
    private int _lumenes;
    private string _resolucion = string.Empty;

    public ProyectorMultimedia(string codigo, string marca, string modelo, int lumenes, string resolucion)
        : base(codigo, marca, modelo)
    {
        Lumenes = lumenes;
        Resolucion = resolucion;
    }

    public int Lumenes
    {
        get => _lumenes;
        set
        {
            if (value < 500 || value > 30000)
                throw new ArgumentOutOfRangeException(nameof(Lumenes), "Los lúmenes deben estar entre 500 y 30,000.");
            _lumenes = value;
        }
    }

    public string Resolucion
    {
        get => _resolucion;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("La resolución del proyector es obligatoria.");
            _resolucion = value.Trim().ToUpperInvariant();
        }
    }

    public override string Categoria => "ProyectorMultimedia";
    public override decimal TarifaPenalizacionHora => 45.00m;
    public override string ObtenerEspecificacionTecnica() => $"{Lumenes} lm, Res. {Resolucion}";
}

public sealed class Tablet : EquipoTecnologico
{
    private double _pulgadasPantalla;
    private bool _incluyeStylus;

    public Tablet(string codigo, string marca, string modelo, double pulgadasPantalla, bool incluyeStylus)
        : base(codigo, marca, modelo)
    {
        PulgadasPantalla = pulgadasPantalla;
        IncluyeStylus = incluyeStylus;
    }

    public double PulgadasPantalla
    {
        get => _pulgadasPantalla;
        set
        {
            if (value < 7.0 || value > 16.0)
                throw new ArgumentOutOfRangeException(nameof(PulgadasPantalla), "La pantalla debe medir entre 7 y 16 pulgadas.");
            _pulgadasPantalla = value;
        }
    }

    public bool IncluyeStylus
    {
        get => _incluyeStylus;
        set => _incluyeStylus = value;
    }

    public override string Categoria => "Tablet";
    public override decimal TarifaPenalizacionHora => 30.00m;
    public override string ObtenerEspecificacionTecnica() => $"{PulgadasPantalla:0.0}\" {(IncluyeStylus ? "+ Stylus" : "Sin Stylus")}";
}

public sealed class KitRobotica : EquipoTecnologico
{
    private string _plataforma = string.Empty;
    private int _numeroSensores;

    public KitRobotica(string codigo, string marca, string modelo, string plataforma, int numeroSensores)
        : base(codigo, marca, modelo)
    {
        Plataforma = plataforma;
        NumeroSensores = numeroSensores;
    }

    public string Plataforma
    {
        get => _plataforma;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("La plataforma del kit de robótica es obligatoria.");
            _plataforma = value.Trim();
        }
    }

    public int NumeroSensores
    {
        get => _numeroSensores;
        set
        {
            if (value < 1 || value > 50)
                throw new ArgumentOutOfRangeException(nameof(NumeroSensores), "El número de sensores debe estar entre 1 y 50.");
            _numeroSensores = value;
        }
    }

    public override string Categoria => "KitRobotica";
    public override decimal TarifaPenalizacionHora => 60.00m;
    public override string ObtenerEspecificacionTecnica() => $"{Plataforma} ({NumeroSensores} sensores)";
}