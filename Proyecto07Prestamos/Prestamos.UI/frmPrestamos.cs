using System.Drawing.Drawing2D;
using Prestamos.Benchmarking;
using Prestamos.Dominio;

namespace Prestamos.UI;

public partial class frmPrestamos : Form
{
    private readonly IServicioPrestamos _servicioPrestamos;
    private readonly IMotorBenchmark _motorBenchmark;
    private int _secuenciaFolio = 100;

    // Constructor con Inyección de Dependencias
    public frmPrestamos(IServicioPrestamos servicioPrestamos, IMotorBenchmark motorBenchmark)
    {
        _servicioPrestamos = servicioPrestamos ?? throw new ArgumentNullException(nameof(servicioPrestamos));
        _motorBenchmark = motorBenchmark ?? throw new ArgumentNullException(nameof(motorBenchmark));

        InitializeComponent();
        InicializarIconografia();
        EnlazarEventos();
    }

    private void InicializarIconografia()
    {
        Color cian = Color.FromArgb(6, 182, 212);
        Color fondo = Color.FromArgb(11, 17, 32);

        // Logotipo del encabezado
        var bmpLogo = new Bitmap(40, 40);
        using (Graphics g = Graphics.FromImage(bmpLogo))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(fondo);
            using var pen = new Pen(cian, 2.5f);
            g.DrawRectangle(pen, 4, 4, 31, 31);
            g.FillEllipse(new SolidBrush(cian), 11, 16, 6, 6);
            g.FillEllipse(new SolidBrush(cian), 23, 16, 6, 6);
            g.DrawLine(pen, 17, 19, 23, 19);
        }
        picLogo.Image = bmpLogo;

        // Iconos diferenciados por categoría para el ListView
        imgEquipos.Images.Add("Laptop", CrearIconoCategoria("LAP", cian, fondo));
        imgEquipos.Images.Add("ProyectorMultimedia", CrearIconoCategoria("PRY", cian, fondo));
        imgEquipos.Images.Add("Tablet", CrearIconoCategoria("TAB", cian, fondo));
        imgEquipos.Images.Add("KitRobotica", CrearIconoCategoria("ROB", cian, fondo));
    }

    private static Bitmap CrearIconoCategoria(string etiqueta, Color acento, Color fondo)
    {
        var bmp = new Bitmap(24, 24);
        using Graphics g = Graphics.FromImage(bmp);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Clear(fondo);
        using var pen = new Pen(acento, 1.5f);
        g.DrawRectangle(pen, 1, 1, 21, 21);
        using var font = new Font("Consolas", 6.5f, FontStyle.Bold);
        using var brush = new SolidBrush(acento);
        g.DrawString(etiqueta, font, brush, 2, 6);
        return bmp;
    }

    private void EnlazarEventos()
    {
        Load += FrmPrestamos_Load;
        cmbPrioridad.SelectedIndexChanged += (_, _) => nudIndice.Enabled = cmbPrioridad.SelectedIndex == 2;
        btnRegistrar.Click += BtnRegistrar_Click;
        btnBuscar.Click += BtnBuscar_Click;
        btnDevolver.Click += BtnDevolver_Click;
        btnEjecutarBenchmark.Click += BtnEjecutarBenchmark_Click;
    }

    private void FrmPrestamos_Load(object? sender, EventArgs e)
    {
        try
        {
            nudIndice.Enabled = false;
            _servicioPrestamos.CargarDatosDemostracion();
            RefrescarCatalogoVisual();
            ActualizarEstado("Sistema iniciado. Catálogo cargado mediante recorrido secuencial de ListaSimple<Prestamo>.");
        }
        catch (Exception ex)
        {
            ActualizarEstado($"Error al inicializar: {ex.Message}");
        }
    }

    private void BtnRegistrar_Click(object? sender, EventArgs e)
    {
        errorProvider.Clear();
        if (!ValidarCamposRegistro())
        {
            ActualizarEstado("Corrija los campos marcados antes de registrar el préstamo.");
            return;
        }

        try
        {
            EquipoTecnologico equipo = ConstruirEquipoPolimorfico();
            PrioridadPrestamo prioridad = cmbPrioridad.SelectedIndex switch
            {
                0 => PrioridadPrestamo.Urgente,
                2 => PrioridadPrestamo.Programado,
                _ => PrioridadPrestamo.Ordinario
            };

            string folio = $"PR-{++_secuenciaFolio}";
            var prestamo = new Prestamo(
                folio,
                txtMatricula.Text,
                txtNombre.Text,
                equipo,
                DateTime.Now,
                DateTime.Now.AddHours(3),
                prioridad);

            if (cmbPrioridad.SelectedIndex == 0)
                _servicioPrestamos.RegistrarPrestamoUrgente(prestamo);
            else if (cmbPrioridad.SelectedIndex == 1)
                _servicioPrestamos.RegistrarPrestamoOrdinario(prestamo);
            else
                _servicioPrestamos.RegistrarPrestamoEnPosicion((int)nudIndice.Value, prestamo);

            RefrescarCatalogoVisual();
            LimpiarEntradas();
            ActualizarEstado($"Préstamo {folio} ({equipo.Codigo}) registrado correctamente.");
        }
        catch (Exception ex)
        {
            ActualizarEstado($"Operación rechazada: {ex.Message}");
            MessageBox.Show(ex.Message, "Validación de Dominio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnBuscar_Click(object? sender, EventArgs e)
    {
        errorProvider.Clear();
        if (string.IsNullOrWhiteSpace(txtBusqueda.Text))
        {
            errorProvider.SetError(txtBusqueda, "Ingrese un código de equipo o matrícula.");
            return;
        }

        try
        {
            Prestamo? encontrado = _servicioPrestamos.BuscarPorCodigoOMatricula(txtBusqueda.Text);
            if (encontrado is null)
            {
                ActualizarEstado($"Sin coincidencias para '{txtBusqueda.Text.Trim()}'.");
                return;
            }

            foreach (ListViewItem item in lvPrestamos.Items)
            {
                bool coincide = item.SubItems[4].Text == encontrado.Equipo.Codigo;
                item.Selected = coincide;
                if (coincide) item.EnsureVisible();
            }

            ActualizarEstado($"Localizado: {encontrado.Equipo.Codigo} asignado a {encontrado.NombreUsuario} ({encontrado.MatriculaUsuario}).");
        }
        catch (Exception ex)
        {
            ActualizarEstado($"Error en búsqueda: {ex.Message}");
        }
    }

    private void BtnDevolver_Click(object? sender, EventArgs e)
    {
        try
        {
            string criterio = txtBusqueda.Text.Trim();
            if (string.IsNullOrEmpty(criterio) && lvPrestamos.SelectedItems.Count > 0)
                criterio = lvPrestamos.SelectedItems[0].SubItems[4].Text;

            if (string.IsNullOrEmpty(criterio))
            {
                errorProvider.SetError(txtBusqueda, "Seleccione una fila o escriba el código/matrícula.");
                return;
            }

            bool eliminado = _servicioPrestamos.RegistrarDevolucion(criterio);
            if (!eliminado)
            {
                ActualizarEstado($"No se encontró préstamo activo para '{criterio}'.");
                return;
            }

            txtBusqueda.Clear();
            RefrescarCatalogoVisual();
            ActualizarEstado($"Devolución registrada y nodo eliminado para '{criterio.ToUpperInvariant()}'.");
        }
        catch (Exception ex)
        {
            ActualizarEstado($"Error al registrar devolución: {ex.Message}");
        }
    }

    private async void BtnEjecutarBenchmark_Click(object? sender, EventArgs e)
    {
        btnEjecutarBenchmark.Enabled = false;
        lvResultadosBench.Items.Clear();
        int repeticiones = (int)nudRepeticiones.Value;

        var progreso = new Progress<string>(mensaje => ActualizarEstado(mensaje));

        try
        {
            ReporteBenchmarkCompleto reporte = await Task.Run(() =>
                _motorBenchmark.EjecutarSuiteCompleta(repeticiones, progreso));

            lblEquivalencia.Text = reporte.MensajeEquivalencia;
            txtInterpretacion.Text = reporte.InterpretacionTeorica;

            lvResultadosBench.BeginUpdate();
            foreach (var r in reporte.Resultados)
            {
                var fila = new ListViewItem(r.VolumenN.ToString("N0"));
                fila.SubItems.Add(r.Operacion);
                fila.SubItems.Add(r.PromedioPropiaMs.ToString("F4"));
                fila.SubItems.Add(r.MedianaPropiaMs.ToString("F4"));
                fila.SubItems.Add(r.PromedioNativaMs.ToString("F4"));
                fila.SubItems.Add(r.MedianaNativaMs.ToString("F4"));
                fila.SubItems.Add($"{r.FactorPropiaSobreNativa:F2}x");
                lvResultadosBench.Items.Add(fila);
            }
            lvResultadosBench.EndUpdate();
        }
        catch (Exception ex)
        {
            ActualizarEstado($"Error en benchmark: {ex.Message}");
            MessageBox.Show(ex.Message, "Error de Benchmarking", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnEjecutarBenchmark.Enabled = true;
        }
    }

    private bool ValidarCamposRegistro()
    {
        bool valido = true;

        if (string.IsNullOrWhiteSpace(txtMatricula.Text) || txtMatricula.Text.Trim().Length < 5)
        {
            errorProvider.SetError(txtMatricula, "Ingrese una matrícula válida (mín. 5 caracteres).");
            valido = false;
        }

        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            errorProvider.SetError(txtNombre, "El nombre del solicitante es obligatorio.");
            valido = false;
        }

        if (string.IsNullOrWhiteSpace(txtCodigoEquipo.Text) || txtCodigoEquipo.Text.Trim().Length < 3)
        {
            errorProvider.SetError(txtCodigoEquipo, "Ingrese un código de equipo válido (ej. LAP-205).");
            valido = false;
        }

        if (string.IsNullOrWhiteSpace(txtMarcaModelo.Text))
        {
            errorProvider.SetError(txtMarcaModelo, "Indique marca y modelo.");
            valido = false;
        }

        if (cmbPrioridad.SelectedIndex == 2 && nudIndice.Value > _servicioPrestamos.CantidadActivos)
        {
            errorProvider.SetError(nudIndice, $"El índice máximo permitido es {_servicioPrestamos.CantidadActivos}.");
            valido = false;
        }

        return valido;
    }

    private EquipoTecnologico ConstruirEquipoPolimorfico()
    {
        string codigo = txtCodigoEquipo.Text.Trim();
        string[] partes = txtMarcaModelo.Text.Trim().Split(' ', 2);
        string marca = partes[0];
        string modelo = partes.Length > 1 ? partes[1] : "Estándar";
        string extra = string.IsNullOrWhiteSpace(txtDetalleExtra.Text) ? "Configuración Base" : txtDetalleExtra.Text.Trim();

        return cmbCategoria.SelectedItem?.ToString() switch
        {
            "ProyectorMultimedia" => new ProyectorMultimedia(codigo, marca, modelo, 3500, extra),
            "Tablet" => new Tablet(codigo, marca, modelo, 11.0, true),
            "KitRobotica" => new KitRobotica(codigo, marca, modelo, extra, 6),
            _ => new Laptop(codigo, marca, modelo, extra, 16)
        };
    }

    private void RefrescarCatalogoVisual()
    {
        lvPrestamos.BeginUpdate();
        lvPrestamos.Items.Clear();

        _servicioPrestamos.RecorrerPrestamosActivos(p =>
        {
            var item = new ListViewItem(p.Prioridad.ToString(), p.Equipo.Categoria);
            item.SubItems.Add(p.MatriculaUsuario);
            item.SubItems.Add(p.NombreUsuario);
            item.SubItems.Add(p.Equipo.Categoria);
            item.SubItems.Add(p.Equipo.Codigo);
            item.SubItems.Add(p.Equipo.ObtenerDescripcionCompleta());
            item.SubItems.Add(p.FechaHoraLimite.ToString("HH:mm"));
            lvPrestamos.Items.Add(item);
        });

        lvPrestamos.EndUpdate();
        nudIndice.Maximum = _servicioPrestamos.CantidadActivos;
        lblStatusConteo.Text = $"Nodos activos: {_servicioPrestamos.CantidadActivos}";
    }

    private void LimpiarEntradas()
    {
        txtMatricula.Clear();
        txtNombre.Clear();
        txtCodigoEquipo.Clear();
        txtMarcaModelo.Clear();
        txtDetalleExtra.Clear();
    }

    private void ActualizarEstado(string mensaje)
    {
        lblStatusMensaje.Text = mensaje;
    }
}
