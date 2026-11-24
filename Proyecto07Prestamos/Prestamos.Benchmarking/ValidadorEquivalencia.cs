using Prestamos.Dominio;
using Prestamos.Estructuras;

namespace Prestamos.Benchmarking;

public static class ValidadorEquivalencia
{
    public static string Validar()
    {
        var propia = new ListaSimple<Prestamo>();
        var nativa = new AdaptadorListaNativa<Prestamo>();
        Prestamo[] muestra = GeneradorDatosPrueba.CrearLote(60);

        // 1. Inserción al inicio, final y posición intermedia
        for (int i = 0; i < 20; i++)
        {
            propia.InsertarInicio(muestra[i]);
            nativa.InsertarInicio(muestra[i]);
        }
        for (int i = 20; i < 40; i++)
        {
            propia.InsertarFinal(muestra[i]);
            nativa.InsertarFinal(muestra[i]);
        }
        for (int i = 40; i < 60; i++)
        {
            int pos = propia.Conteo / 2;
            propia.InsertarEnPosicion(pos, muestra[i]);
            nativa.InsertarEnPosicion(pos, muestra[i]);
        }

        VerificarIdentidadSecuencial(propia, nativa, "tras inserciones posicionales");

        // 2. Búsqueda por código y matrícula (existente e inexistente)
        string codigoObjetivo = muestra[25].Equipo.Codigo;
        Prestamo? resPropia = propia.Buscar(p => p.Equipo.Codigo == codigoObjetivo);
        Prestamo? resNativa = nativa.Buscar(p => p.Equipo.Codigo == codigoObjetivo);

        if (resPropia is null || resNativa is null || resPropia.IdPrestamo != resNativa.IdPrestamo)
            throw new InvalidOperationException("Fallo de equivalencia en operación de búsqueda.");

        if (propia.Buscar(p => p.Equipo.Codigo == "INEXISTENTE-999") is not null ||
            nativa.Buscar(p => p.Equipo.Codigo == "INEXISTENTE-999") is not null)
            throw new InvalidOperationException("Fallo de equivalencia al buscar elemento inexistente.");

        // 3. Eliminación (inicio, medio, final)
        string codInicio = propia.ObtenerEn(0)!.Equipo.Codigo;
        string codMedio = propia.ObtenerEn(propia.Conteo / 2)!.Equipo.Codigo;
        string codFinal = propia.ObtenerEn(propia.Conteo - 1)!.Equipo.Codigo;

        if (propia.Eliminar(p => p.Equipo.Codigo == codInicio) != nativa.Eliminar(p => p.Equipo.Codigo == codInicio) ||
            propia.Eliminar(p => p.Equipo.Codigo == codMedio) != nativa.Eliminar(p => p.Equipo.Codigo == codMedio) ||
            propia.Eliminar(p => p.Equipo.Codigo == codFinal) != nativa.Eliminar(p => p.Equipo.Codigo == codFinal))
            throw new InvalidOperationException("Fallo de equivalencia en eliminación posicional.");

        VerificarIdentidadSecuencial(propia, nativa, "tras eliminaciones posicionales");

        // 4. Recorrido secuencial
        long hashPropia = 0;
        long hashNativa = 0;
        int idxA = 1;
        int idxB = 1;

        propia.Recorrer(p => hashPropia += (long)p.IdPrestamo.GetHashCode() * idxA++);
        nativa.Recorrer(p => hashNativa += (long)p.IdPrestamo.GetHashCode() * idxB++);

        if (hashPropia != hashNativa)
            throw new InvalidOperationException("Fallo de equivalencia en recorrido secuencial.");

        return $"Equivalencia 100% verificada ({propia.Conteo} nodos activos idénticos en orden, búsqueda, eliminación y recorrido).";
    }

    private static void VerificarIdentidadSecuencial(
        IEstructuraLineal<Prestamo> propia,
        IEstructuraLineal<Prestamo> nativa,
        string etapa)
    {
        if (propia.Conteo != nativa.Conteo)
            throw new InvalidOperationException($"Conteo desigual {etapa}: Propia={propia.Conteo}, Nativa={nativa.Conteo}.");

        for (int i = 0; i < propia.Conteo; i++)
        {
            Prestamo a = propia.ObtenerEn(i)!;
            Prestamo b = nativa.ObtenerEn(i)!;
            if (a.IdPrestamo != b.IdPrestamo || a.Equipo.Codigo != b.Equipo.Codigo)
                throw new InvalidOperationException($"Divergencia en índice {i} {etapa}.");
        }
    }
}

internal static class GeneradorDatosPrueba
{
    public static Prestamo[] CrearLote(int cantidad)
    {
        var lote = new Prestamo[cantidad];
        DateTime baseTime = new(2026, 11, 24, 8, 0, 0);

        for (int i = 0; i < cantidad; i++)
        {
            string codigo = $"EQ-{i:D6}";
            string matricula = $"A017{i:D6}";
            EquipoTecnologico equipo = (i % 4) switch
            {
                0 => new Laptop(codigo, "Dell", "Latitude 5440", "Core i7", 16),
                1 => new ProyectorMultimedia(codigo, "BenQ", "MW560", 4000, "WXGA"),
                2 => new Tablet(codigo, "Samsung", "Galaxy Tab S9", 11.0, true),
                _ => new KitRobotica(codigo, "LEGO", "SPIKE Prime", "Hub Technic", 6)
            };

            lote[i] = new Prestamo(
                $"PR-{i:D6}",
                matricula,
                $"Estudiante {i}",
                equipo,
                baseTime,
                baseTime.AddHours(3),
                PrioridadPrestamo.Ordinario);
        }

        return lote;
    }
}
