using Prestamos.Benchmarking;
using Prestamos.Dominio;
using Prestamos.Estructuras;

namespace Prestamos.UI;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        // Composición e Inyección de Dependencias (cero lógica de nodos en el formulario)
        IEstructuraLineal<Prestamo> estructuraPrincipal = new ListaSimple<Prestamo>();
        IRepositorioPrestamos<Prestamo> repositorio = new RepositorioPrestamos(estructuraPrincipal);
        IServicioPrestamos servicioPrestamos = new ServicioPrestamos(repositorio);
        IMotorBenchmark motorBenchmark = new MotorBenchmark();

        Application.Run(new frmPrestamos(servicioPrestamos, motorBenchmark));
    }
}
