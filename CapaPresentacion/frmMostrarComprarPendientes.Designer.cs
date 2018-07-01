namespace CapaPresentacion
{
    partial class frmMostrarComprarPendientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMostrarComprarPendientes));
            this.cbProducto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbNombre = new System.Windows.Forms.RadioButton();
            this.rbCodigo = new System.Windows.Forms.RadioButton();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.lblTipoComprobante = new System.Windows.Forms.Label();
            this.lblCorrelativo = new System.Windows.Forms.Label();
            this.lblIdComprobante = new System.Windows.Forms.Label();
            this.lblDctoGral = new System.Windows.Forms.Label();
            this.lblClase = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.lblIdUsuario = new System.Windows.Forms.Label();
            this.lblFechaCompr = new System.Windows.Forms.Label();
            this.lblBanderaAnulacion = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblIdProveedor = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAbonar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.btnAnular = new System.Windows.Forms.Button();
            this.btnRecoger = new System.Windows.Forms.Button();
            this.lblIdCompra = new System.Windows.Forms.Label();
            this.lblTotalPago = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbProducto
            // 
            this.cbProducto.BackColor = System.Drawing.Color.White;
            this.cbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProducto.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProducto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbProducto.FormattingEnabled = true;
            this.cbProducto.Location = new System.Drawing.Point(16, 111);
            this.cbProducto.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cbProducto.Name = "cbProducto";
            this.cbProducto.Size = new System.Drawing.Size(459, 31);
            this.cbProducto.TabIndex = 130;
            this.cbProducto.SelectedIndexChanged += new System.EventHandler(this.cbProducto_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 20);
            this.label3.TabIndex = 129;
            this.label3.Text = "Seleccione Proveedor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(355, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 39);
            this.label1.TabIndex = 108;
            this.label1.Text = "COMPRAS PENDIENTES";
            // 
            // dataListado
            // 
            this.dataListado.AllowUserToAddRows = false;
            this.dataListado.AllowUserToDeleteRows = false;
            this.dataListado.AllowUserToOrderColumns = true;
            this.dataListado.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListado.Location = new System.Drawing.Point(15, 165);
            this.dataListado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.RowTemplate.Height = 24;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(893, 413);
            this.dataListado.TabIndex = 107;
            this.dataListado.Click += new System.EventHandler(this.dataListado_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbNombre);
            this.groupBox1.Controls.Add(this.rbCodigo);
            this.groupBox1.Controls.Add(this.txtBuscar);
            this.groupBox1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(294, 302);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(105, 69);
            this.groupBox1.TabIndex = 114;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterio de Búsqueda";
            // 
            // rbNombre
            // 
            this.rbNombre.AutoSize = true;
            this.rbNombre.Checked = true;
            this.rbNombre.Location = new System.Drawing.Point(31, 41);
            this.rbNombre.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbNombre.Name = "rbNombre";
            this.rbNombre.Size = new System.Drawing.Size(74, 24);
            this.rbNombre.TabIndex = 8;
            this.rbNombre.TabStop = true;
            this.rbNombre.Text = "Cliente";
            this.rbNombre.UseVisualStyleBackColor = true;
            // 
            // rbCodigo
            // 
            this.rbCodigo.AutoSize = true;
            this.rbCodigo.Location = new System.Drawing.Point(215, 41);
            this.rbCodigo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbCodigo.Name = "rbCodigo";
            this.rbCodigo.Size = new System.Drawing.Size(73, 24);
            this.rbCodigo.TabIndex = 9;
            this.rbCodigo.Text = "Código";
            this.rbCodigo.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(31, 74);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(1072, 37);
            this.txtBuscar.TabIndex = 20;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(694, 410);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(17, 20);
            this.lblCliente.TabIndex = 127;
            this.lblCliente.Text = "0";
            this.lblCliente.Visible = false;
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Location = new System.Drawing.Point(777, 414);
            this.lblEfectivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(17, 20);
            this.lblEfectivo.TabIndex = 123;
            this.lblEfectivo.Text = "0";
            this.lblEfectivo.Visible = false;
            // 
            // lblTipoComprobante
            // 
            this.lblTipoComprobante.AutoSize = true;
            this.lblTipoComprobante.Location = new System.Drawing.Point(662, 381);
            this.lblTipoComprobante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.Size = new System.Drawing.Size(17, 20);
            this.lblTipoComprobante.TabIndex = 121;
            this.lblTipoComprobante.Text = "0";
            this.lblTipoComprobante.Visible = false;
            // 
            // lblCorrelativo
            // 
            this.lblCorrelativo.AutoSize = true;
            this.lblCorrelativo.Location = new System.Drawing.Point(863, 407);
            this.lblCorrelativo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCorrelativo.Name = "lblCorrelativo";
            this.lblCorrelativo.Size = new System.Drawing.Size(17, 20);
            this.lblCorrelativo.TabIndex = 120;
            this.lblCorrelativo.Text = "0";
            this.lblCorrelativo.Visible = false;
            // 
            // lblIdComprobante
            // 
            this.lblIdComprobante.AutoSize = true;
            this.lblIdComprobante.Location = new System.Drawing.Point(887, 353);
            this.lblIdComprobante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdComprobante.Name = "lblIdComprobante";
            this.lblIdComprobante.Size = new System.Drawing.Size(17, 20);
            this.lblIdComprobante.TabIndex = 119;
            this.lblIdComprobante.Text = "0";
            this.lblIdComprobante.Visible = false;
            // 
            // lblDctoGral
            // 
            this.lblDctoGral.AutoSize = true;
            this.lblDctoGral.Location = new System.Drawing.Point(732, 365);
            this.lblDctoGral.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDctoGral.Name = "lblDctoGral";
            this.lblDctoGral.Size = new System.Drawing.Size(17, 20);
            this.lblDctoGral.TabIndex = 117;
            this.lblDctoGral.Text = "0";
            this.lblDctoGral.Visible = false;
            // 
            // lblClase
            // 
            this.lblClase.AutoSize = true;
            this.lblClase.Location = new System.Drawing.Point(810, 368);
            this.lblClase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClase.Name = "lblClase";
            this.lblClase.Size = new System.Drawing.Size(17, 20);
            this.lblClase.TabIndex = 116;
            this.lblClase.Text = "0";
            this.lblClase.Visible = false;
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Location = new System.Drawing.Point(732, 414);
            this.lblSaldo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(17, 20);
            this.lblSaldo.TabIndex = 115;
            this.lblSaldo.Text = "0";
            this.lblSaldo.Visible = false;
            // 
            // lblIdUsuario
            // 
            this.lblIdUsuario.AutoSize = true;
            this.lblIdUsuario.Location = new System.Drawing.Point(694, 332);
            this.lblIdUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdUsuario.Name = "lblIdUsuario";
            this.lblIdUsuario.Size = new System.Drawing.Size(17, 20);
            this.lblIdUsuario.TabIndex = 109;
            this.lblIdUsuario.Text = "0";
            this.lblIdUsuario.Visible = false;
            // 
            // lblFechaCompr
            // 
            this.lblFechaCompr.AutoSize = true;
            this.lblFechaCompr.Location = new System.Drawing.Point(851, 201);
            this.lblFechaCompr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaCompr.Name = "lblFechaCompr";
            this.lblFechaCompr.Size = new System.Drawing.Size(17, 20);
            this.lblFechaCompr.TabIndex = 122;
            this.lblFechaCompr.Text = "0";
            this.lblFechaCompr.Visible = false;
            // 
            // lblBanderaAnulacion
            // 
            this.lblBanderaAnulacion.AutoSize = true;
            this.lblBanderaAnulacion.Location = new System.Drawing.Point(887, 459);
            this.lblBanderaAnulacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBanderaAnulacion.Name = "lblBanderaAnulacion";
            this.lblBanderaAnulacion.Size = new System.Drawing.Size(17, 20);
            this.lblBanderaAnulacion.TabIndex = 118;
            this.lblBanderaAnulacion.Text = "0";
            this.lblBanderaAnulacion.Visible = false;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(887, 221);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(17, 20);
            this.lblEstado.TabIndex = 111;
            this.lblEstado.Text = "0";
            this.lblEstado.Visible = false;
            // 
            // lblIdProveedor
            // 
            this.lblIdProveedor.AutoSize = true;
            this.lblIdProveedor.Location = new System.Drawing.Point(837, 9);
            this.lblIdProveedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdProveedor.Name = "lblIdProveedor";
            this.lblIdProveedor.Size = new System.Drawing.Size(17, 20);
            this.lblIdProveedor.TabIndex = 132;
            this.lblIdProveedor.Text = "0";
            this.lblIdProveedor.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::CapaPresentacion.Properties.Resources.print4;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button2.Location = new System.Drawing.Point(762, 68);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 74);
            this.button2.TabIndex = 131;
            this.button2.Text = "Imprimir";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::CapaPresentacion.Properties.Resources.if_Generate_tables_85519;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button1.Location = new System.Drawing.Point(480, 68);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 74);
            this.button1.TabIndex = 128;
            this.button1.Text = "Generar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAbonar
            // 
            this.btnAbonar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAbonar.Enabled = false;
            this.btnAbonar.Font = new System.Drawing.Font("Roboto", 9.230769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbonar.Image = global::CapaPresentacion.Properties.Resources.if_Finance_loan_money_1889199;
            this.btnAbonar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAbonar.Location = new System.Drawing.Point(912, 165);
            this.btnAbonar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAbonar.Name = "btnAbonar";
            this.btnAbonar.Size = new System.Drawing.Size(97, 90);
            this.btnAbonar.TabIndex = 125;
            this.btnAbonar.Text = "Abonar";
            this.btnAbonar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAbonar.UseVisualStyleBackColor = false;
            this.btnAbonar.Click += new System.EventHandler(this.btnAbonar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEditar.Font = new System.Drawing.Font("Roboto", 9.230769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Image = global::CapaPresentacion.Properties.Resources.edit4;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditar.Location = new System.Drawing.Point(807, 366);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(97, 80);
            this.btnEditar.TabIndex = 124;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Visible = false;
            // 
            // btnCobrar
            // 
            this.btnCobrar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCobrar.Font = new System.Drawing.Font("Roboto", 9.230769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobrar.Image = global::CapaPresentacion.Properties.Resources.if_cashbox_45016;
            this.btnCobrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCobrar.Location = new System.Drawing.Point(807, 284);
            this.btnCobrar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(97, 90);
            this.btnCobrar.TabIndex = 112;
            this.btnCobrar.Text = "Confirmar";
            this.btnCobrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Visible = false;
            // 
            // btnAnular
            // 
            this.btnAnular.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAnular.Font = new System.Drawing.Font("Roboto", 9.230769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnular.Image = global::CapaPresentacion.Properties.Resources.if_Cut_728989;
            this.btnAnular.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAnular.Location = new System.Drawing.Point(697, 365);
            this.btnAnular.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(97, 90);
            this.btnAnular.TabIndex = 113;
            this.btnAnular.Text = "Anular";
            this.btnAnular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAnular.UseVisualStyleBackColor = false;
            this.btnAnular.Visible = false;
            // 
            // btnRecoger
            // 
            this.btnRecoger.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRecoger.Font = new System.Drawing.Font("Roboto", 9.230769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecoger.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRecoger.Image = global::CapaPresentacion.Properties.Resources.save2;
            this.btnRecoger.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRecoger.Location = new System.Drawing.Point(771, 334);
            this.btnRecoger.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRecoger.Name = "btnRecoger";
            this.btnRecoger.Size = new System.Drawing.Size(97, 79);
            this.btnRecoger.TabIndex = 110;
            this.btnRecoger.Text = "Atender";
            this.btnRecoger.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecoger.UseVisualStyleBackColor = false;
            this.btnRecoger.Visible = false;
            // 
            // lblIdCompra
            // 
            this.lblIdCompra.AutoSize = true;
            this.lblIdCompra.Location = new System.Drawing.Point(962, 39);
            this.lblIdCompra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdCompra.Name = "lblIdCompra";
            this.lblIdCompra.Size = new System.Drawing.Size(17, 20);
            this.lblIdCompra.TabIndex = 133;
            this.lblIdCompra.Text = "0";
            this.lblIdCompra.Visible = false;
            // 
            // lblTotalPago
            // 
            this.lblTotalPago.AutoSize = true;
            this.lblTotalPago.Location = new System.Drawing.Point(777, 23);
            this.lblTotalPago.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalPago.Name = "lblTotalPago";
            this.lblTotalPago.Size = new System.Drawing.Size(17, 20);
            this.lblTotalPago.TabIndex = 134;
            this.lblTotalPago.Text = "0";
            this.lblTotalPago.Visible = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Roboto", 9.230769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(732, 597);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(49, 20);
            this.lblTotal.TabIndex = 138;
            this.lblTotal.Text = "00.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 9.230769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(546, 597);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 137;
            this.label2.Text = "TOTAL";
            // 
            // frmMostrarComprarPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1018, 626);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalPago);
            this.Controls.Add(this.lblIdCompra);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbProducto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAbonar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataListado);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lblEfectivo);
            this.Controls.Add(this.lblTipoComprobante);
            this.Controls.Add(this.lblCorrelativo);
            this.Controls.Add(this.lblIdComprobante);
            this.Controls.Add(this.lblDctoGral);
            this.Controls.Add(this.lblClase);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.btnCobrar);
            this.Controls.Add(this.lblIdUsuario);
            this.Controls.Add(this.lblFechaCompr);
            this.Controls.Add(this.lblBanderaAnulacion);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnRecoger);
            this.Controls.Add(this.lblIdProveedor);
            this.Font = new System.Drawing.Font("Roboto", 9.230769F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMostrarComprarPendientes";
            this.Text = ".:: COMPRAS PENDIENTES ::";
            this.Load += new System.EventHandler(this.frmMostrarComprarPendientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.ComboBox cbProducto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button btnAbonar;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbNombre;
        private System.Windows.Forms.RadioButton rbCodigo;
        private System.Windows.Forms.TextBox txtBuscar;
        public System.Windows.Forms.Label lblCliente;
        public System.Windows.Forms.Button btnEditar;
        public System.Windows.Forms.Label lblEfectivo;
        public System.Windows.Forms.Label lblTipoComprobante;
        public System.Windows.Forms.Label lblCorrelativo;
        public System.Windows.Forms.Label lblIdComprobante;
        public System.Windows.Forms.Label lblDctoGral;
        public System.Windows.Forms.Label lblClase;
        public System.Windows.Forms.Label lblSaldo;
        public System.Windows.Forms.Button btnCobrar;
        public System.Windows.Forms.Label lblIdUsuario;
        public System.Windows.Forms.Label lblFechaCompr;
        public System.Windows.Forms.Label lblBanderaAnulacion;
        public System.Windows.Forms.Button btnAnular;
        public System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnRecoger;
        public System.Windows.Forms.Label lblIdProveedor;
        public System.Windows.Forms.Label lblIdCompra;
        public System.Windows.Forms.Label lblTotalPago;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Label label2;
    }
}