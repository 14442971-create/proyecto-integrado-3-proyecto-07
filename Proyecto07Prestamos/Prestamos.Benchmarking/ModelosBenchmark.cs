namespace Prestamos.Benchmarking;

public sealed class ResultadoOperacionBenchmark
{
    public int VolumenN { get; init; }
    public string Operacion { get; init; } = string.Empty;
    public int Repeticiones { get; init; }
    public double PromedioPropiaMs { get; init; }
    public double MedianaPropiaMs { get; init; }
    public double PromedioNativaMs { get; init; }
    public double MedianaNativaMs { get; init; }
    public double FactorPropiaSobreNativa =>
        PromedioNativaMs > 0.00001 ? PromedioPropiaMs / PromedioNativaMs : 1.0;
}

public sealed class ReporteBenchmarkCompleto
{
    public bool EquivalenciaVerificada { get; init; }
    public string MensajeEquivalencia { get; init; } = string.Empty;
    public ResultadoOperacionBenchmark[] Resultados { get; init; } = Array.Empty<ResultadoOperacionBenchmark>();
    public string InterpretacionTeorica { get; init; } = string.Empty;
}

public interface IMotorBenchmark
{
    ReporteBenchmarkCompleto EjecutarSuiteCompleta(int repeticiones = 30, IProgress<string>? progreso = null);
}
