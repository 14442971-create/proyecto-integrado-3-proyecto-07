using Prestamos.Benchmarking;

Console.WriteLine("====================================================================================");
Console.WriteLine(" PROYECTO 07 - VALIDACIÓN DE EQUIVALENCIA Y BENCHMARKING (MODO RELEASE)");
Console.WriteLine("====================================================================================\n");

IMotorBenchmark motor = new MotorBenchmark();
var progreso = new Progress<string>(msg => Console.WriteLine($"[INFO] {msg}"));

ReporteBenchmarkCompleto reporte = motor.EjecutarSuiteCompleta(30, progreso);

Console.WriteLine($"\n[EQUIVALENCIA] {reporte.MensajeEquivalencia}\n");
Console.WriteLine($"{"n",9} | {"Operación",-20} | {"Propia Prom",11} | {"Propia Med",10} | {"Nativa Prom",11} | {"Nativa Med",10}");
Console.WriteLine(new string('-', 86));

foreach (var r in reporte.Resultados)
{
    Console.WriteLine(
        $"{r.VolumenN,9:N0} | {r.Operacion,-20} | {r.PromedioPropiaMs,9:F4} ms | {r.MedianaPropiaMs,8:F4} ms | {r.PromedioNativaMs,9:F4} ms | {r.MedianaNativaMs,8:F4} ms");
}

Console.WriteLine("\n" + reporte.InterpretacionTeorica);
