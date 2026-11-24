namespace Prestamos.Dominio;

public abstract class EquipoTecnologico
{
    private string _codigo = string.Empty;
    private string _marca = string.Empty;
    private string _modelo = string.Empty;

    protected EquipoTecnologico(string codigo, string marca, string modelo)
    {
        Codigo = codigo;
        Marca = marca;
        Modelo = modelo;
    }

    public string Codigo
    {
        get => _codigo;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Trim().Length < 3)
                throw new ArgumentException("El código del equipo debe tener al menos 3 caracteres.");
            _codigo = value.Trim().ToUpperInvariant();
        }
    }

    public string Marca
    {
        get => _marca;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("La marca del equipo es obligatoria.");
            _marca = value.Trim();
        }
    }

    public string Modelo
    {
        get => _modelo;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El modelo del equipo es obligatorio.");
            _modelo = value.Trim();
        }
    }

    public abstract string Categoria { get; }
    public abstract decimal TarifaPenalizacionHora { get; }
    public abstract string ObtenerEspecificacionTecnica();

    public virtual string ObtenerDescripcionCompleta()
    {
        return $"{Marca} {Modelo} | {ObtenerEspecificacionTecnica()}";
    }
}