using System.Diagnostics;
using Prestamos.Dominio;
using Prestamos.Estructuras;

namespace Prestamos.Benchmarking;

public sealed class MotorBenchmark : IMotorBenchmark
{
    private static readonly int[] Volumenes = { 100, 1_000, 10_000, 100_000 };

    public ReporteBenchmarkCompleto EjecutarSuiteCompleta(int repeticiones = 30, IProgress<string>? progreso = null)
    {
        if (repeticiones < 30)
            repeticiones = 30;

        // 1. Validación obligatoria de equivalencia funcional antes de medir
        progreso?.Report("Validando equivalencia funcional entre ListaSimple<Prestamo> y List<Prestamo>...");
        string mensajeEquivalencia = ValidadorEquivalencia.Validar();

        // 2. Fase de calentamiento (Warm-up JIT)
        progreso?.Report("Ejecutando fase de calentamiento (Warm-up JIT)...");
        EjecutarWarmUp();

        // 3. Medición experimental para n = 100, 1,000, 10,000 y 100,000
        var resultados = new ResultadoOperacionBenchmark[Volumenes.Length * 6];
        int cursor = 0;

        for (int v = 0; v < Volumenes.Length; v++)
        {
            int n = Volumenes[v];
            progreso?.Report($"Midiendo volumen n = {n:N0} ({repeticiones} repeticiones por operación)...");

            Prestamo[] dataset = GeneradorDatosPrueba.CrearLote(n);
            int operacionesPosicionales = Math.Min(n, 2_000);
            Prestamo[] extras = GeneradorDatosPrueba.CrearLote(operacionesPosicionales);

            // Claves idénticas de búsqueda y eliminación distribuidas en inicio, medio y final
            string[] clavesBusqueda = ConstruirClavesObjetivo(dataset, operacionesPosicionales);

            resultados[cursor++] = MedirInsercionInicio(n, repeticiones, dataset);
            resultados[cursor++] = MedirInsercionMedio(n, repeticiones, dataset, extras);
            resultados[cursor++] = MedirInsercionFinal(n, repeticiones, dataset);
            resultados[cursor++] = MedirBusqueda(n, repeticiones, dataset, clavesBusqueda);
            resultados[cursor++] = MedirEliminacion(n, repeticiones, dataset, clavesBusqueda);
            resultados[cursor++] = MedirRecorrido(n, repeticiones, dataset);
        }

        progreso?.Report("Benchmark completado correctamente.");

        return new ReporteBenchmarkCompleto
        {
            EquivalenciaVerificada = true,
            MensajeEquivalencia = mensajeEquivalencia,
            Resultados = resultados,
            InterpretacionTeorica = GenerarInterpretacionTeorica()
        };
    }

    private static void EjecutarWarmUp()
    {
        Prestamo[] lote = GeneradorDatosPrueba.CrearLote(250);
        var propia = new ListaSimple<Prestamo>();
        var nativa = new AdaptadorListaNativa<Prestamo>();

        for (int i = 0; i < lote.Length; i++)
        {
            propia.InsertarInicio(lote[i]);
            nativa.InsertarInicio(lote[i]);
        }
        propia.Recorrer(_ => { });
        nativa.Recorrer(_ => { });
        _ = propia.Buscar(p => p.Equipo.Codigo == lote[125].Equipo.Codigo);
        _ = nativa.Buscar(p => p.Equipo.Codigo == lote[125].Equipo.Codigo);
        _ = propia.Eliminar(p => p.Equipo.Codigo == lote[125].Equipo.Codigo);
        _ = nativa.Eliminar(p => p.Equipo.Codigo == lote[125].Equipo.Codigo);
    }

    private static ResultadoOperacionBenchmark MedirInsercionInicio(int n, int rep, Prestamo[] dataset)
    {
        double[] tPropia = new double[rep];
        double[] tNativa = new double[rep];
        var sw = new Stopwatch();

        for (int r = 0; r < rep; r++)
        {
            var propia = new ListaSimple<Prestamo>();
            sw.Restart();
            for (int i = 0; i < n; i++) propia.InsertarInicio(dataset[i]);
            sw.Stop();
            tPropia[r] = sw.Elapsed.TotalMilliseconds;

            var nativa = new AdaptadorListaNativa<Prestamo>();
            sw.Restart();
            for (int i = 0; i < n; i++) nativa.InsertarInicio(dataset[i]);
            sw.Stop();
            tNativa[r] = sw.Elapsed.TotalMilliseconds;
        }

        return CrearResultado(n, "1. Inserción Inicio", rep, tPropia, tNativa);
    }

    private static ResultadoOperacionBenchmark MedirInsercionMedio(int n, int rep, Prestamo[] dataset, Prestamo[] extras)
    {
        double[] tPropia = new double[rep];
        double[] tNativa = new double[rep];
        var sw = new Stopwatch();

        for (int r = 0; r < rep; r++)
        {
            var propia = PoblarEstructura(new ListaSimple<Prestamo>(), dataset);
            sw.Restart();
            for (int i = 0; i < extras.Length; i++)
                propia.InsertarEnPosicion(propia.Conteo / 2, extras[i]);
            sw.Stop();
            tPropia[r] = sw.Elapsed.TotalMilliseconds;

            var nativa = PoblarEstructura(new AdaptadorListaNativa<Prestamo>(), dataset);
            sw.Restart();
            for (int i = 0; i < extras.Length; i++)
                nativa.InsertarEnPosicion(nativa.Conteo / 2, extras[i]);
            sw.Stop();
            tNativa[r] = sw.Elapsed.TotalMilliseconds;
        }

        return CrearResultado(n, "2. Inserción Medio", rep, tPropia, tNativa);
    }

    private static ResultadoOperacionBenchmark MedirInsercionFinal(int n, int rep, Prestamo[] dataset)
    {
        double[] tPropia = new double[rep];
        double[] tNativa = new double[rep];
        var sw = new Stopwatch();

        for (int r = 0; r < rep; r++)
        {
            var propia = new ListaSimple<Prestamo>();
            sw.Restart();
            for (int i = 0; i < n; i++) propia.InsertarFinal(dataset[i]);
            sw.Stop();
            tPropia[r] = sw.Elapsed.TotalMilliseconds;

            var nativa = new AdaptadorListaNativa<Prestamo>();
            sw.Restart();
            for (int i = 0; i < n; i++) nativa.InsertarFinal(dataset[i]);
            sw.Stop();
            tNativa[r] = sw.Elapsed.TotalMilliseconds;
        }

        return CrearResultado(n, "3. Inserción Final", rep, tPropia, tNativa);
    }

    private static ResultadoOperacionBenchmark MedirBusqueda(int n, int rep, Prestamo[] dataset, string[] claves)
    {
        double[] tPropia = new double[rep];
        double[] tNativa = new double[rep];
        var sw = new Stopwatch();

        var propia = PoblarEstructura(new ListaSimple<Prestamo>(), dataset);
        var nativa = PoblarEstructura(new AdaptadorListaNativa<Prestamo>(), dataset);

        for (int r = 0; r < rep; r++)
        {
            sw.Restart();
            for (int i = 0; i < claves.Length; i++)
            {
                string c = claves[i];
                _ = propia.Buscar(p => p.Equipo.Codigo == c);
            }
            sw.Stop();
            tPropia[r] = sw.Elapsed.TotalMilliseconds;

            sw.Restart();
            for (int i = 0; i < claves.Length; i++)
            {
                string c = claves[i];
                _ = nativa.Buscar(p => p.Equipo.Codigo == c);
            }
            sw.Stop();
            tNativa[r] = sw.Elapsed.TotalMilliseconds;
        }

        return CrearResultado(n, "4. Búsqueda", rep, tPropia, tNativa);
    }

    private static ResultadoOperacionBenchmark MedirEliminacion(int n, int rep, Prestamo[] dataset, string[] claves)
    {
        double[] tPropia = new double[rep];
        double[] tNativa = new double[rep];
        var sw = new Stopwatch();

        for (int r = 0; r < rep; r++)
        {
            var propia = PoblarEstructura(new ListaSimple<Prestamo>(), dataset);
            sw.Restart();
            for (int i = 0; i < claves.Length; i++)
            {
                string c = claves[i];
                _ = propia.Eliminar(p => p.Equipo.Codigo == c);
            }
            sw.Stop();
            tPropia[r] = sw.Elapsed.TotalMilliseconds;

            var nativa = PoblarEstructura(new AdaptadorListaNativa<Prestamo>(), dataset);
            sw.Restart();
            for (int i = 0; i < claves.Length; i++)
            {
                string c = claves[i];
                _ = nativa.Eliminar(p => p.Equipo.Codigo == c);
            }
            sw.Stop();
            tNativa[r] = sw.Elapsed.TotalMilliseconds;
        }

        return CrearResultado(n, "5. Eliminación", rep, tPropia, tNativa);
    }

    private static ResultadoOperacionBenchmark MedirRecorrido(int n, int rep, Prestamo[] dataset)
    {
        double[] tPropia = new double[rep];
        double[] tNativa = new double[rep];
        var sw = new Stopwatch();

        var propia = PoblarEstructura(new ListaSimple<Prestamo>(), dataset);
        var nativa = PoblarEstructura(new AdaptadorListaNativa<Prestamo>(), dataset);

        for (int r = 0; r < rep; r++)
        {
            int acumuladorA = 0;
            sw.Restart();
            propia.Recorrer(p => acumuladorA += p.IdPrestamo.Length);
            sw.Stop();
            tPropia[r] = sw.Elapsed.TotalMilliseconds;

            int acumuladorB = 0;
            sw.Restart();
            nativa.Recorrer(p => acumuladorB += p.IdPrestamo.Length);
            sw.Stop();
            tNativa[r] = sw.Elapsed.TotalMilliseconds;

            if (acumuladorA != acumuladorB)
                throw new InvalidOperationException("Inconsistencia detectada durante el recorrido.");
        }

        return CrearResultado(n, "6. Recorrido", rep, tPropia, tNativa);
    }

    private static IEstructuraLineal<Prestamo> PoblarEstructura(IEstructuraLineal<Prestamo> estructura, Prestamo[] dataset)
    {
        for (int i = 0; i < dataset.Length; i++)
            estructura.InsertarFinal(dataset[i]);
        return estructura;
    }

    private static string[] ConstruirClavesObjetivo(Prestamo[] dataset, int cantidad)
    {
        var claves = new string[cantidad];
        int n = dataset.Length;
        for (int i = 0; i < cantidad; i++)
        {
            int idx = (int)((long)i * n / cantidad);
            claves[i] = dataset[idx].Equipo.Codigo;
        }
        return claves;
    }

    private static ResultadoOperacionBenchmark CrearResultado(
        int n, string operacion, int rep, double[] muestrasPropia, double[] muestrasNativa)
    {
        return new ResultadoOperacionBenchmark
        {
            VolumenN = n,
            Operacion = operacion,
            Repeticiones = rep,
            PromedioPropiaMs = CalcularPromedio(muestrasPropia),
            MedianaPropiaMs = CalcularMediana(muestrasPropia),
            PromedioNativaMs = CalcularPromedio(muestrasNativa),
            MedianaNativaMs = CalcularMediana(muestrasNativa)
        };
    }

    private static double CalcularPromedio(double[] valores)
    {
        double suma = 0;
        for (int i = 0; i < valores.Length; i++)
            suma += valores[i];
        return suma / valores.Length;
    }

    private static double CalcularMediana(double[] valores)
    {
        // Ordenamiento por inserción sobre arreglo primitivo sin usar List<T>
        var copia = new double[valores.Length];
        Array.Copy(valores, copia, valores.Length);

        for (int i = 1; i < copia.Length; i++)
        {
            double clave = copia[i];
            int j = i - 1;
            while (j >= 0 && copia[j] > clave)
            {
                copia[j + 1] = copia[j];
                j--;
            }
            copia[j + 1] = clave;
        }

        int mitad = copia.Length / 2;
        return copia.Length % 2 == 0
            ? (copia[mitad - 1] + copia[mitad]) / 2.0
            : copia[mitad];
    }

    private static string GenerarInterpretacionTeorica()
    {
        return
            "INTERPRETACIÓN DE COMPLEJIDAD TEÓRICA Y LOCALIDAD DE CACHÉ CPU:\r\n" +
            "1. Inserción al Inicio: ListaSimple<T> opera en O(1) estricto reasignando _cabeza, mientras List<T>.Insert(0) cuesta O(n) por desplazar todo el arreglo interno (Array.Copy).\r\n" +
            "2. Inserción en Medio, Búsqueda y Eliminación: Ambas estructuras tienen complejidad O(n), pero List<T> es significativamente más rápida gracias a la localidad espacial: sus referencias viven contiguas en memoria y aprovechan las líneas de caché L1/L2/L3 del procesador, mientras ListaSimple<T> sufre fallos de caché (cache misses) al saltar entre nodos dispersos en el heap.\r\n" +
            "3. Inserción al Final: Ambas alcanzan O(1) amortizado/directo (mediante puntero _cola en ListaSimple<T> y capacidad preasignada en List<T>).\r\n" +
            "4. Recorrido Secuencial: Aunque ambos son O(n), el acceso secuencial contiguo de List<T> permite prefetching por hardware, superando la persecución de punteros (pointer chasing) de Nodo<T>.";
    }
}
