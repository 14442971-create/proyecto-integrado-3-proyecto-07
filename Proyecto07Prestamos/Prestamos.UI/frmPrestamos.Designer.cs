namespace Prestamos.UI;

partial class frmPrestamos
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        System.Drawing.Color colorFondo = System.Drawing.Color.FromArgb(11, 17, 32);
        System.Drawing.Color colorSuperficie = System.Drawing.Color.FromArgb(30, 41, 59);
        System.Drawing.Color colorCian = System.Drawing.Color.FromArgb(6, 182, 212);
        System.Drawing.Color colorTexto = System.Drawing.Color.FromArgb(248, 250, 252);
        System.Drawing.Font fuenteUi = new System.Drawing.Font("Segoe UI", 9.5F);
        System.Drawing.Font fuenteTitulo = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
        System.Drawing.Font fuenteSubtitulo = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        System.Drawing.Font fuenteMono = new System.Drawing.Font("Consolas", 9.5F);

        this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
        this.pnlEncabezado = new System.Windows.Forms.Panel();
        this.picLogo = new System.Windows.Forms.PictureBox();
        this.lblTitulo = new System.Windows.Forms.Label();
        this.lblEquipoId = new System.Windows.Forms.Label();
        this.tabPrincipal = new System.Windows.Forms.TabControl();
        this.tabGestion = new System.Windows.Forms.TabPage();
        this.tlpGestion = new System.Windows.Forms.TableLayoutPanel();
        this.pnlFormulario = new System.Windows.Forms.Panel();
        this.lblSecRegistro = new System.Windows.Forms.Label();
        this.lblMatricula = new System.Windows.Forms.Label();
        this.txtMatricula = new System.Windows.Forms.TextBox();
        this.lblNombre = new System.Windows.Forms.Label();
        this.txtNombre = new System.Windows.Forms.TextBox();
        this.lblCategoria = new System.Windows.Forms.Label();
        this.cmbCategoria = new System.Windows.Forms.ComboBox();
        this.lblCodigo = new System.Windows.Forms.Label();
        this.txtCodigoEquipo = new System.Windows.Forms.TextBox();
        this.lblMarcaModelo = new System.Windows.Forms.Label();
        this.txtMarcaModelo = new System.Windows.Forms.TextBox();
        this.lblDetalle = new System.Windows.Forms.Label();
        this.txtDetalleExtra = new System.Windows.Forms.TextBox();
        this.lblPrioridad = new System.Windows.Forms.Label();
        this.cmbPrioridad = new System.Windows.Forms.ComboBox();
        this.lblIndice = new System.Windows.Forms.Label();
        this.nudIndice = new System.Windows.Forms.NumericUpDown();
        this.btnRegistrar = new System.Windows.Forms.Button();
        this.lblSecOperaciones = new System.Windows.Forms.Label();
        this.txtBusqueda = new System.Windows.Forms.TextBox();
        this.btnBuscar = new System.Windows.Forms.Button();
        this.btnDevolver = new System.Windows.Forms.Button();
        this.pnlCatalogo = new System.Windows.Forms.Panel();
        this.lblTituloCatalogo = new System.Windows.Forms.Label();
        this.lvPrestamos = new System.Windows.Forms.ListView();
        this.colPrioridad = new System.Windows.Forms.ColumnHeader();
        this.colMatricula = new System.Windows.Forms.ColumnHeader();
        this.colSolicitante = new System.Windows.Forms.ColumnHeader();
        this.colCategoria = new System.Windows.Forms.ColumnHeader();
        this.colCodigo = new System.Windows.Forms.ColumnHeader();
        this.colEquipo = new System.Windows.Forms.ColumnHeader();
        this.colHorario = new System.Windows.Forms.ColumnHeader();
        this.imgEquipos = new System.Windows.Forms.ImageList(this.components);
        this.tabBenchmark = new System.Windows.Forms.TabPage();
        this.tlpBenchmark = new System.Windows.Forms.TableLayoutPanel();
        this.pnlControlesBench = new System.Windows.Forms.Panel();
        this.lblRepeticiones = new System.Windows.Forms.Label();
        this.nudRepeticiones = new System.Windows.Forms.NumericUpDown();
        this.btnEjecutarBenchmark = new System.Windows.Forms.Button();
        this.lblEquivalencia = new System.Windows.Forms.Label();
        this.lvResultadosBench = new System.Windows.Forms.ListView();
        this.colVolumen = new System.Windows.Forms.ColumnHeader();
        this.colOperacion = new System.Windows.Forms.ColumnHeader();
        this.colPropiaProm = new System.Windows.Forms.ColumnHeader();
        this.colPropiaMed = new System.Windows.Forms.ColumnHeader();
        this.colNativaProm = new System.Windows.Forms.ColumnHeader();
        this.colNativaMed = new System.Windows.Forms.ColumnHeader();
        this.colFactor = new System.Windows.Forms.ColumnHeader();
        this.txtInterpretacion = new System.Windows.Forms.TextBox();
        this.statusStrip = new System.Windows.Forms.StatusStrip();
        this.lblStatusMensaje = new System.Windows.Forms.ToolStripStatusLabel();
        this.lblStatusConteo = new System.Windows.Forms.ToolStripStatusLabel();
        this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);

        this.tlpPrincipal.SuspendLayout();
        this.pnlEncabezado.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
        this.tabPrincipal.SuspendLayout();
        this.tabGestion.SuspendLayout();
        this.tlpGestion.SuspendLayout();
        this.pnlFormulario.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudIndice)).BeginInit();
        this.pnlCatalogo.SuspendLayout();
        this.tabBenchmark.SuspendLayout();
        this.tlpBenchmark.SuspendLayout();
        this.pnlControlesBench.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudRepeticiones)).BeginInit();
        this.statusStrip.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
        this.SuspendLayout();

        // tlpPrincipal
        this.tlpPrincipal.BackColor = colorFondo;
        this.tlpPrincipal.ColumnCount = 1;
        this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tlpPrincipal.Controls.Add(this.pnlEncabezado, 0, 0);
        this.tlpPrincipal.Controls.Add(this.tabPrincipal, 0, 1);
        this.tlpPrincipal.Controls.Add(this.statusStrip, 0, 2);
        this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
        this.tlpPrincipal.Name = "tlpPrincipal";
        this.tlpPrincipal.RowCount = 3;
        this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
        this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
        this.tlpPrincipal.Size = new System.Drawing.Size(1180, 760);
        this.tlpPrincipal.TabIndex = 0;

        // pnlEncabezado
        this.pnlEncabezado.BackColor = colorSuperficie;
        this.pnlEncabezado.Controls.Add(this.picLogo);
        this.pnlEncabezado.Controls.Add(this.lblTitulo);
        this.pnlEncabezado.Controls.Add(this.lblEquipoId);
        this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlEncabezado.Margin = new System.Windows.Forms.Padding(0);
        this.pnlEncabezado.Name = "pnlEncabezado";

        // picLogo
        this.picLogo.Location = new System.Drawing.Point(16, 14);
        this.picLogo.Name = "picLogo";
        this.picLogo.Size = new System.Drawing.Size(40, 40);
        this.picLogo.TabStop = false;

        // lblTitulo
        this.lblTitulo.AutoSize = true;
        this.lblTitulo.Font = fuenteTitulo;
        this.lblTitulo.ForeColor = colorTexto;
        this.lblTitulo.Location = new System.Drawing.Point(68, 21);
        this.lblTitulo.Name = "lblTitulo";
        this.lblTitulo.Text = "CONTROL DE PRÉSTAMOS DE EQUIPOS TECNOLÓGICOS";

        // lblEquipoId
        this.lblEquipoId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.lblEquipoId.BackColor = colorCian;
        this.lblEquipoId.Font = fuenteMono;
        this.lblEquipoId.ForeColor = colorFondo;
        this.lblEquipoId.Location = new System.Drawing.Point(940, 19);
        this.lblEquipoId.Name = "lblEquipoId";
        this.lblEquipoId.Size = new System.Drawing.Size(220, 30);
        this.lblEquipoId.Text = "PROYECTO 07 | LISTA SIMPLE";
        this.lblEquipoId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        // tabPrincipal
        this.tabPrincipal.Controls.Add(this.tabGestion);
        this.tabPrincipal.Controls.Add(this.tabBenchmark);
        this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabPrincipal.Font = fuenteSubtitulo;
        this.tabPrincipal.Margin = new System.Windows.Forms.Padding(10);
        this.tabPrincipal.Name = "tabPrincipal";
        this.tabPrincipal.SelectedIndex = 0;

        // tabGestion
        this.tabGestion.BackColor = colorFondo;
        this.tabGestion.Controls.Add(this.tlpGestion);
        this.tabGestion.Name = "tabGestion";
        this.tabGestion.Padding = new System.Windows.Forms.Padding(6);
        this.tabGestion.Text = "Gestión de Préstamos Activos";

        // tlpGestion
        this.tlpGestion.ColumnCount = 2;
        this.tlpGestion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 360F));
        this.tlpGestion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tlpGestion.Controls.Add(this.pnlFormulario, 0, 0);
        this.tlpGestion.Controls.Add(this.pnlCatalogo, 1, 0);
        this.tlpGestion.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tlpGestion.Name = "tlpGestion";
        this.tlpGestion.RowCount = 1;
        this.tlpGestion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

        // pnlFormulario
        this.pnlFormulario.AutoScroll = true;
        this.pnlFormulario.BackColor = colorSuperficie;
        this.pnlFormulario.Controls.Add(this.lblSecRegistro);
        this.pnlFormulario.Controls.Add(this.lblMatricula);
        this.pnlFormulario.Controls.Add(this.txtMatricula);
        this.pnlFormulario.Controls.Add(this.lblNombre);
        this.pnlFormulario.Controls.Add(this.txtNombre);
        this.pnlFormulario.Controls.Add(this.lblCategoria);
        this.pnlFormulario.Controls.Add(this.cmbCategoria);
        this.pnlFormulario.Controls.Add(this.lblCodigo);
        this.pnlFormulario.Controls.Add(this.txtCodigoEquipo);
        this.pnlFormulario.Controls.Add(this.lblMarcaModelo);
        this.pnlFormulario.Controls.Add(this.txtMarcaModelo);
        this.pnlFormulario.Controls.Add(this.lblDetalle);
        this.pnlFormulario.Controls.Add(this.txtDetalleExtra);
        this.pnlFormulario.Controls.Add(this.lblPrioridad);
        this.pnlFormulario.Controls.Add(this.cmbPrioridad);
        this.pnlFormulario.Controls.Add(this.lblIndice);
        this.pnlFormulario.Controls.Add(this.nudIndice);
        this.pnlFormulario.Controls.Add(this.btnRegistrar);
        this.pnlFormulario.Controls.Add(this.lblSecOperaciones);
        this.pnlFormulario.Controls.Add(this.txtBusqueda);
        this.pnlFormulario.Controls.Add(this.btnBuscar);
        this.pnlFormulario.Controls.Add(this.btnDevolver);
        this.pnlFormulario.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlFormulario.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
        this.pnlFormulario.Name = "pnlFormulario";

        this.lblSecRegistro.Font = fuenteSubtitulo;
        this.lblSecRegistro.ForeColor = colorCian;
        this.lblSecRegistro.Location = new System.Drawing.Point(14, 12);
        this.lblSecRegistro.Size = new System.Drawing.Size(310, 22);
        this.lblSecRegistro.Text = "NUEVO PRÉSTAMO (INSERCIÓN)";

        this.lblMatricula.Font = fuenteUi;
        this.lblMatricula.ForeColor = colorTexto;
        this.lblMatricula.Location = new System.Drawing.Point(14, 40);
        this.lblMatricula.Size = new System.Drawing.Size(300, 18);
        this.lblMatricula.Text = "Matrícula / Nómina:";

        this.txtMatricula.BackColor = colorFondo;
        this.txtMatricula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtMatricula.Font = fuenteMono;
        this.txtMatricula.ForeColor = colorTexto;
        this.txtMatricula.Location = new System.Drawing.Point(14, 60);
        this.txtMatricula.Size = new System.Drawing.Size(310, 24);

        this.lblNombre.Font = fuenteUi;
        this.lblNombre.ForeColor = colorTexto;
        this.lblNombre.Location = new System.Drawing.Point(14, 90);
        this.lblNombre.Size = new System.Drawing.Size(300, 18);
        this.lblNombre.Text = "Nombre del Solicitante:";

        this.txtNombre.BackColor = colorFondo;
        this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtNombre.Font = fuenteUi;
        this.txtNombre.ForeColor = colorTexto;
        this.txtNombre.Location = new System.Drawing.Point(14, 110);
        this.txtNombre.Size = new System.Drawing.Size(310, 24);

        this.lblCategoria.Font = fuenteUi;
        this.lblCategoria.ForeColor = colorTexto;
        this.lblCategoria.Location = new System.Drawing.Point(14, 140);
        this.lblCategoria.Size = new System.Drawing.Size(300, 18);
        this.lblCategoria.Text = "Categoría de Equipo:";

        this.cmbCategoria.BackColor = colorFondo;
        this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbCategoria.Font = fuenteUi;
        this.cmbCategoria.ForeColor = colorTexto;
        this.cmbCategoria.Items.AddRange(new object[] { "Laptop", "ProyectorMultimedia", "Tablet", "KitRobotica" });
        this.cmbCategoria.Location = new System.Drawing.Point(14, 160);
        this.cmbCategoria.SelectedIndex = 0;
        this.cmbCategoria.Size = new System.Drawing.Size(310, 24);

        this.lblCodigo.Font = fuenteUi;
        this.lblCodigo.ForeColor = colorTexto;
        this.lblCodigo.Location = new System.Drawing.Point(14, 192);
        this.lblCodigo.Size = new System.Drawing.Size(145, 18);
        this.lblCodigo.Text = "Código Equipo:";

        this.txtCodigoEquipo.BackColor = colorFondo;
        this.txtCodigoEquipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtCodigoEquipo.Font = fuenteMono;
        this.txtCodigoEquipo.ForeColor = colorTexto;
        this.txtCodigoEquipo.Location = new System.Drawing.Point(14, 212);
        this.txtCodigoEquipo.Size = new System.Drawing.Size(145, 24);

        this.lblMarcaModelo.Font = fuenteUi;
        this.lblMarcaModelo.ForeColor = colorTexto;
        this.lblMarcaModelo.Location = new System.Drawing.Point(170, 192);
        this.lblMarcaModelo.Size = new System.Drawing.Size(154, 18);
        this.lblMarcaModelo.Text = "Marca / Modelo:";

        this.txtMarcaModelo.BackColor = colorFondo;
        this.txtMarcaModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtMarcaModelo.Font = fuenteUi;
        this.txtMarcaModelo.ForeColor = colorTexto;
        this.txtMarcaModelo.Location = new System.Drawing.Point(170, 212);
        this.txtMarcaModelo.Size = new System.Drawing.Size(154, 24);

        this.lblDetalle.Font = fuenteUi;
        this.lblDetalle.ForeColor = colorTexto;
        this.lblDetalle.Location = new System.Drawing.Point(14, 242);
        this.lblDetalle.Size = new System.Drawing.Size(310, 18);
        this.lblDetalle.Text = "Especificación (CPU / Lúmenes / Plataforma):";

        this.txtDetalleExtra.BackColor = colorFondo;
        this.txtDetalleExtra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtDetalleExtra.Font = fuenteUi;
        this.txtDetalleExtra.ForeColor = colorTexto;
        this.txtDetalleExtra.Location = new System.Drawing.Point(14, 262);
        this.txtDetalleExtra.Size = new System.Drawing.Size(310, 24);

        this.lblPrioridad.Font = fuenteUi;
        this.lblPrioridad.ForeColor = colorTexto;
        this.lblPrioridad.Location = new System.Drawing.Point(14, 294);
        this.lblPrioridad.Size = new System.Drawing.Size(210, 18);
        this.lblPrioridad.Text = "Prioridad / Modo Inserción:";

        this.cmbPrioridad.BackColor = colorFondo;
        this.cmbPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbPrioridad.Font = fuenteUi;
        this.cmbPrioridad.ForeColor = colorTexto;
        this.cmbPrioridad.Items.AddRange(new object[] { "Inicio (Urgente)", "Final (Ordinario)", "Posición Intermedia" });
        this.cmbPrioridad.Location = new System.Drawing.Point(14, 314);
        this.cmbPrioridad.SelectedIndex = 1;
        this.cmbPrioridad.Size = new System.Drawing.Size(215, 24);

        this.lblIndice.Font = fuenteUi;
        this.lblIndice.ForeColor = colorTexto;
        this.lblIndice.Location = new System.Drawing.Point(240, 294);
        this.lblIndice.Size = new System.Drawing.Size(84, 18);
        this.lblIndice.Text = "Índice:";

        this.nudIndice.BackColor = colorFondo;
        this.nudIndice.Font = fuenteMono;
        this.nudIndice.ForeColor = colorTexto;
        this.nudIndice.Location = new System.Drawing.Point(240, 314);
        this.nudIndice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        this.nudIndice.Size = new System.Drawing.Size(84, 24);

        this.btnRegistrar.BackColor = colorCian;
        this.btnRegistrar.FlatAppearance.BorderSize = 0;
        this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnRegistrar.Font = fuenteSubtitulo;
        this.btnRegistrar.ForeColor = colorFondo;
        this.btnRegistrar.Location = new System.Drawing.Point(14, 350);
        this.btnRegistrar.Size = new System.Drawing.Size(310, 34);
        this.btnRegistrar.Text = "REGISTRAR EN LISTA ENLAZADA";
        this.btnRegistrar.UseVisualStyleBackColor = false;

        this.lblSecOperaciones.Font = fuenteSubtitulo;
        this.lblSecOperaciones.ForeColor = colorCian;
        this.lblSecOperaciones.Location = new System.Drawing.Point(14, 400);
        this.lblSecOperaciones.Size = new System.Drawing.Size(310, 22);
        this.lblSecOperaciones.Text = "BÚSQUEDA Y DEVOLUCIÓN";

        this.txtBusqueda.BackColor = colorFondo;
        this.txtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtBusqueda.Font = fuenteMono;
        this.txtBusqueda.ForeColor = colorTexto;
        this.txtBusqueda.Location = new System.Drawing.Point(14, 426);
        this.txtBusqueda.PlaceholderText = "Código equipo o matrícula...";
        this.txtBusqueda.Size = new System.Drawing.Size(310, 24);

        this.btnBuscar.BackColor = colorFondo;
        this.btnBuscar.FlatAppearance.BorderColor = colorCian;
        this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnBuscar.Font = fuenteSubtitulo;
        this.btnBuscar.ForeColor = colorCian;
        this.btnBuscar.Location = new System.Drawing.Point(14, 458);
        this.btnBuscar.Size = new System.Drawing.Size(150, 32);
        this.btnBuscar.Text = "Buscar Nodo";
        this.btnBuscar.UseVisualStyleBackColor = false;

        this.btnDevolver.BackColor = colorCian;
        this.btnDevolver.FlatAppearance.BorderSize = 0;
        this.btnDevolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnDevolver.Font = fuenteSubtitulo;
        this.btnDevolver.ForeColor = colorFondo;
        this.btnDevolver.Location = new System.Drawing.Point(174, 458);
        this.btnDevolver.Size = new System.Drawing.Size(150, 32);
        this.btnDevolver.Text = "Registrar Devolución";
        this.btnDevolver.UseVisualStyleBackColor = false;

        // pnlCatalogo
        this.pnlCatalogo.BackColor = colorSuperficie;
        this.pnlCatalogo.Controls.Add(this.lvPrestamos);
        this.pnlCatalogo.Controls.Add(this.lblTituloCatalogo);
        this.pnlCatalogo.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlCatalogo.Name = "pnlCatalogo";
        this.pnlCatalogo.Padding = new System.Windows.Forms.Padding(12);

        this.lblTituloCatalogo.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblTituloCatalogo.Font = fuenteSubtitulo;
        this.lblTituloCatalogo.ForeColor = colorCian;
        this.lblTituloCatalogo.Height = 28;
        this.lblTituloCatalogo.Text = "CATÁLOGO DE PRÉSTAMOS ACTIVOS (RECORRIDO SECUENCIAL DE LISTA SIMPLE)";

        this.lvPrestamos.BackColor = colorFondo;
        this.lvPrestamos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lvPrestamos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPrioridad, this.colMatricula, this.colSolicitante,
            this.colCategoria, this.colCodigo, this.colEquipo, this.colHorario
        });
        this.lvPrestamos.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvPrestamos.Font = fuenteUi;
        this.lvPrestamos.ForeColor = colorTexto;
        this.lvPrestamos.FullRowSelect = true;
        this.lvPrestamos.GridLines = true;
        this.lvPrestamos.SmallImageList = this.imgEquipos;
        this.lvPrestamos.View = System.Windows.Forms.View.Details;

        this.colPrioridad.Text = "Prioridad";
        this.colPrioridad.Width = 105;
        this.colMatricula.Text = "Matrícula";
        this.colMatricula.Width = 100;
        this.colSolicitante.Text = "Solicitante";
        this.colSolicitante.Width = 140;
        this.colCategoria.Text = "Categoría";
        this.colCategoria.Width = 135;
        this.colCodigo.Text = "Código";
        this.colCodigo.Width = 85;
        this.colEquipo.Text = "Equipo y Especificaciones";
        this.colEquipo.Width = 230;
        this.colHorario.Text = "Límite";
        this.colHorario.Width = 85;

        this.imgEquipos.ImageSize = new System.Drawing.Size(24, 24);
        this.imgEquipos.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;

        // tabBenchmark
        this.tabBenchmark.BackColor = colorFondo;
        this.tabBenchmark.Controls.Add(this.tlpBenchmark);
        this.tabBenchmark.Padding = new System.Windows.Forms.Padding(6);
        this.tabBenchmark.Text = "Benchmarking y Equivalencia (Release)";

        this.tlpBenchmark.ColumnCount = 1;
        this.tlpBenchmark.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tlpBenchmark.Controls.Add(this.pnlControlesBench, 0, 0);
        this.tlpBenchmark.Controls.Add(this.lvResultadosBench, 0, 1);
        this.tlpBenchmark.Controls.Add(this.txtInterpretacion, 0, 2);
        this.tlpBenchmark.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tlpBenchmark.RowCount = 3;
        this.tlpBenchmark.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
        this.tlpBenchmark.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68F));
        this.tlpBenchmark.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32F));

        this.pnlControlesBench.BackColor = colorSuperficie;
        this.pnlControlesBench.Controls.Add(this.lblRepeticiones);
        this.pnlControlesBench.Controls.Add(this.nudRepeticiones);
        this.pnlControlesBench.Controls.Add(this.btnEjecutarBenchmark);
        this.pnlControlesBench.Controls.Add(this.lblEquivalencia);
        this.pnlControlesBench.Dock = System.Windows.Forms.DockStyle.Fill;

        this.lblRepeticiones.AutoSize = true;
        this.lblRepeticiones.Font = fuenteUi;
        this.lblRepeticiones.ForeColor = colorTexto;
        this.lblRepeticiones.Location = new System.Drawing.Point(14, 19);
        this.lblRepeticiones.Text = "Repeticiones (mín. 30):";

        this.nudRepeticiones.BackColor = colorFondo;
        this.nudRepeticiones.Font = fuenteMono;
        this.nudRepeticiones.ForeColor = colorTexto;
        this.nudRepeticiones.Location = new System.Drawing.Point(165, 16);
        this.nudRepeticiones.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
        this.nudRepeticiones.Minimum = new decimal(new int[] { 30, 0, 0, 0 });
        this.nudRepeticiones.Size = new System.Drawing.Size(70, 24);
        this.nudRepeticiones.Value = new decimal(new int[] { 30, 0, 0, 0 });

        this.btnEjecutarBenchmark.BackColor = colorCian;
        this.btnEjecutarBenchmark.FlatAppearance.BorderSize = 0;
        this.btnEjecutarBenchmark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnEjecutarBenchmark.Font = fuenteSubtitulo;
        this.btnEjecutarBenchmark.ForeColor = colorFondo;
        this.btnEjecutarBenchmark.Location = new System.Drawing.Point(250, 12);
        this.btnEjecutarBenchmark.Size = new System.Drawing.Size(270, 34);
        this.btnEjecutarBenchmark.Text = "EJECUTAR BENCHMARK ASÍNCRONO";
        this.btnEjecutarBenchmark.UseVisualStyleBackColor = false;

        this.lblEquivalencia.AutoSize = true;
        this.lblEquivalencia.Font = fuenteUi;
        this.lblEquivalencia.ForeColor = colorCian;
        this.lblEquivalencia.Location = new System.Drawing.Point(535, 19);
        this.lblEquivalencia.Text = "Pendiente de validación de equivalencia funcional...";

        this.lvResultadosBench.BackColor = colorSuperficie;
        this.lvResultadosBench.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lvResultadosBench.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colVolumen, this.colOperacion, this.colPropiaProm,
            this.colPropiaMed, this.colNativaProm, this.colNativaMed, this.colFactor
        });
        this.lvResultadosBench.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvResultadosBench.Font = fuenteMono;
        this.lvResultadosBench.ForeColor = colorTexto;
        this.lvResultadosBench.FullRowSelect = true;
        this.lvResultadosBench.GridLines = true;
        this.lvResultadosBench.View = System.Windows.Forms.View.Details;

        this.colVolumen.Text = "Volumen (n)";
        this.colVolumen.Width = 115;
        this.colOperacion.Text = "Operación Medida";
        this.colOperacion.Width = 190;
        this.colPropiaProm.Text = "ListaSimple Prom (ms)";
        this.colPropiaProm.Width = 165;
        this.colPropiaMed.Text = "ListaSimple Med (ms)";
        this.colPropiaMed.Width = 165;
        this.colNativaProm.Text = "List<T> Prom (ms)";
        this.colNativaProm.Width = 155;
        this.colNativaMed.Text = "List<T> Med (ms)";
        this.colNativaMed.Width = 155;
        this.colFactor.Text = "Ratio (Propia/Nativa)";
        this.colFactor.Width = 155;

        this.txtInterpretacion.BackColor = colorSuperficie;
        this.txtInterpretacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtInterpretacion.Dock = System.Windows.Forms.DockStyle.Fill;
        this.txtInterpretacion.Font = fuenteUi;
        this.txtInterpretacion.ForeColor = colorTexto;
        this.txtInterpretacion.Multiline = true;
        this.txtInterpretacion.ReadOnly = true;
        this.txtInterpretacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtInterpretacion.Text = "Ejecute el benchmark en modo Release sin depurador (Ctrl+F5) para analizar complejidad O(1)/O(n) y localidad de caché.";

        // statusStrip
        this.statusStrip.BackColor = colorSuperficie;
        this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusMensaje, this.lblStatusConteo
        });
        this.statusStrip.SizingGrip = false;

        this.lblStatusMensaje.ForeColor = colorTexto;
        this.lblStatusMensaje.Spring = true;
        this.lblStatusMensaje.Text = "Listo.";
        this.lblStatusMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        this.lblStatusConteo.Font = fuenteMono;
        this.lblStatusConteo.ForeColor = colorCian;
        this.lblStatusConteo.Text = "Nodos activos: 0";

        this.errorProvider.ContainerControl = this;

        // frmPrestamos
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = colorFondo;
        this.ClientSize = new System.Drawing.Size(1180, 760);
        this.Controls.Add(this.tlpPrincipal);
        this.MinimumSize = new System.Drawing.Size(1100, 720);
        this.Name = "frmPrestamos";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Sistema de Control de Préstamos de Equipos Tecnológicos - Proyecto 07";

        this.tlpPrincipal.ResumeLayout(false);
        this.pnlEncabezado.ResumeLayout(false);
        this.pnlEncabezado.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
        this.tabPrincipal.ResumeLayout(false);
        this.tabGestion.ResumeLayout(false);
        this.tlpGestion.ResumeLayout(false);
        this.pnlFormulario.ResumeLayout(false);
        this.pnlFormulario.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudIndice)).EndInit();
        this.pnlCatalogo.ResumeLayout(false);
        this.tabBenchmark.ResumeLayout(false);
        this.tlpBenchmark.ResumeLayout(false);
        this.pnlControlesBench.ResumeLayout(false);
        this.pnlControlesBench.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudRepeticiones)).EndInit();
        this.statusStrip.ResumeLayout(false);
        this.statusStrip.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tlpPrincipal = null!;
    private System.Windows.Forms.Panel pnlEncabezado = null!;
    private System.Windows.Forms.PictureBox picLogo = null!;
    private System.Windows.Forms.Label lblTitulo = null!;
    private System.Windows.Forms.Label lblEquipoId = null!;
    private System.Windows.Forms.TabControl tabPrincipal = null!;
    private System.Windows.Forms.TabPage tabGestion = null!;
    private System.Windows.Forms.TableLayoutPanel tlpGestion = null!;
    private System.Windows.Forms.Panel pnlFormulario = null!;
    private System.Windows.Forms.Label lblSecRegistro = null!;
    private System.Windows.Forms.Label lblMatricula = null!;
    private System.Windows.Forms.TextBox txtMatricula = null!;
    private System.Windows.Forms.Label lblNombre = null!;
    private System.Windows.Forms.TextBox txtNombre = null!;
    private System.Windows.Forms.Label lblCategoria = null!;
    private System.Windows.Forms.ComboBox cmbCategoria = null!;
    private System.Windows.Forms.Label lblCodigo = null!;
    private System.Windows.Forms.TextBox txtCodigoEquipo = null!;
    private System.Windows.Forms.Label lblMarcaModelo = null!;
    private System.Windows.Forms.TextBox txtMarcaModelo = null!;
    private System.Windows.Forms.Label lblDetalle = null!;
    private System.Windows.Forms.TextBox txtDetalleExtra = null!;
    private System.Windows.Forms.Label lblPrioridad = null!;
    private System.Windows.Forms.ComboBox cmbPrioridad = null!;
    private System.Windows.Forms.Label lblIndice = null!;
    private System.Windows.Forms.NumericUpDown nudIndice = null!;
    private System.Windows.Forms.Button btnRegistrar = null!;
    private System.Windows.Forms.Label lblSecOperaciones = null!;
    private System.Windows.Forms.TextBox txtBusqueda = null!;
    private System.Windows.Forms.Button btnBuscar = null!;
    private System.Windows.Forms.Button btnDevolver = null!;
    private System.Windows.Forms.Panel pnlCatalogo = null!;
    private System.Windows.Forms.Label lblTituloCatalogo = null!;
    private System.Windows.Forms.ListView lvPrestamos = null!;
    private System.Windows.Forms.ColumnHeader colPrioridad = null!;
    private System.Windows.Forms.ColumnHeader colMatricula = null!;
    private System.Windows.Forms.ColumnHeader colSolicitante = null!;
    private System.Windows.Forms.ColumnHeader colCategoria = null!;
    private System.Windows.Forms.ColumnHeader colCodigo = null!;
    private System.Windows.Forms.ColumnHeader colEquipo = null!;
    private System.Windows.Forms.ColumnHeader colHorario = null!;
    private System.Windows.Forms.ImageList imgEquipos = null!;
    private System.Windows.Forms.TabPage tabBenchmark = null!;
    private System.Windows.Forms.TableLayoutPanel tlpBenchmark = null!;
    private System.Windows.Forms.Panel pnlControlesBench = null!;
    private System.Windows.Forms.Label lblRepeticiones = null!;
    private System.Windows.Forms.NumericUpDown nudRepeticiones = null!;
    private System.Windows.Forms.Button btnEjecutarBenchmark = null!;
    private System.Windows.Forms.Label lblEquivalencia = null!;
    private System.Windows.Forms.ListView lvResultadosBench = null!;
    private System.Windows.Forms.ColumnHeader colVolumen = null!;
    private System.Windows.Forms.ColumnHeader colOperacion = null!;
    private System.Windows.Forms.ColumnHeader colPropiaProm = null!;
    private System.Windows.Forms.ColumnHeader colPropiaMed = null!;
    private System.Windows.Forms.ColumnHeader colNativaProm = null!;
    private System.Windows.Forms.ColumnHeader colNativaMed = null!;
    private System.Windows.Forms.ColumnHeader colFactor = null!;
    private System.Windows.Forms.TextBox txtInterpretacion = null!;
    private System.Windows.Forms.StatusStrip statusStrip = null!;
    private System.Windows.Forms.ToolStripStatusLabel lblStatusMensaje = null!;
    private System.Windows.Forms.ToolStripStatusLabel lblStatusConteo = null!;
    private System.Windows.Forms.ErrorProvider errorProvider = null!;
}
