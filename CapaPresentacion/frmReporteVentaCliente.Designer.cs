﻿namespace CapaPresentacion
{
    partial class frmReporteVentaCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteVentaCliente));
            this.cbProducto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rbAperturaCaja = new System.Windows.Forms.RadioButton();
            this.rbElegir = new System.Windows.Forms.RadioButton();
            this.lblBandera = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbltot = new System.Windows.Forms.Label();
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
            this.cbProducto.Location = new System.Drawing.Point(626, 130);
            this.cbProducto.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cbProducto.Name = "cbProducto";
            this.cbProducto.Size = new System.Drawing.Size(312, 31);
            this.cbProducto.TabIndex = 59;
            this.cbProducto.SelectedIndexChanged += new System.EventHandler(this.cbProducto_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(627, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 18);
            this.label3.TabIndex = 58;
            this.label3.Text = "Seleccione Cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(547, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(343, 28);
            this.label4.TabIndex = 57;
            this.label4.Text = "REPORTE DE VENTAS POR CLIENTE";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotal.Location = new System.Drawing.Point(1197, 177);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(114, 20);
            this.lblTotal.TabIndex = 56;
            this.lblTotal.Text = "Total Registros:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 18);
            this.label2.TabIndex = 53;
            this.label2.Text = "Fecha Fin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 52;
            this.label1.Text = "Fecha Inicio";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(94, 66);
            this.dtpFechaFin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(198, 26);
            this.dtpFechaFin.TabIndex = 51;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(94, 21);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(198, 26);
            this.dtpFechaInicio.TabIndex = 50;
            // 
            // dataListado
            // 
            this.dataListado.AllowUserToAddRows = false;
            this.dataListado.AllowUserToDeleteRows = false;
            this.dataListado.AllowUserToOrderColumns = true;
            this.dataListado.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListado.Location = new System.Drawing.Point(26, 201);
            this.dataListado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.RowTemplate.Height = 28;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(1388, 373);
            this.dataListado.TabIndex = 49;
            this.dataListado.DoubleClick += new System.EventHandler(this.dataListado_DoubleClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::CapaPresentacion.Properties.Resources.if_Generate_tables_85519;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button1.Location = new System.Drawing.Point(943, 88);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 74);
            this.button1.TabIndex = 55;
            this.button1.Text = "Generar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnImprimir.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnImprimir.Image = global::CapaPresentacion.Properties.Resources.print4;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImprimir.Location = new System.Drawing.Point(1294, 78);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(93, 74);
            this.btnImprimir.TabIndex = 54;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpFechaInicio);
            this.groupBox1.Controls.Add(this.dtpFechaFin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(257, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 107);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto Black", 9.846154F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 23);
            this.label5.TabIndex = 54;
            this.label5.Text = "Fecha Inicio";
            // 
            // rbAperturaCaja
            // 
            this.rbAperturaCaja.AutoSize = true;
            this.rbAperturaCaja.Checked = true;
            this.rbAperturaCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.230769F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAperturaCaja.Location = new System.Drawing.Point(35, 98);
            this.rbAperturaCaja.Name = "rbAperturaCaja";
            this.rbAperturaCaja.Size = new System.Drawing.Size(115, 22);
            this.rbAperturaCaja.TabIndex = 61;
            this.rbAperturaCaja.TabStop = true;
            this.rbAperturaCaja.Text = "Apertura Caja";
            this.rbAperturaCaja.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbAperturaCaja.UseVisualStyleBackColor = true;
            this.rbAperturaCaja.CheckedChanged += new System.EventHandler(this.rbAperturaCaja_CheckedChanged);
            // 
            // rbElegir
            // 
            this.rbElegir.AutoSize = true;
            this.rbElegir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.230769F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbElegir.Location = new System.Drawing.Point(35, 127);
            this.rbElegir.Name = "rbElegir";
            this.rbElegir.Size = new System.Drawing.Size(108, 22);
            this.rbElegir.TabIndex = 62;
            this.rbElegir.Text = "Elegir Fecha";
            this.rbElegir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbElegir.UseVisualStyleBackColor = true;
            this.rbElegir.CheckedChanged += new System.EventHandler(this.rbElegir_CheckedChanged);
            // 
            // lblBandera
            // 
            this.lblBandera.AutoSize = true;
            this.lblBandera.Location = new System.Drawing.Point(679, 55);
            this.lblBandera.Name = "lblBandera";
            this.lblBandera.Size = new System.Drawing.Size(15, 18);
            this.lblBandera.TabIndex = 63;
            this.lblBandera.Text = "0";
            this.lblBandera.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(862, 598);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 20);
            this.label6.TabIndex = 64;
            this.label6.Text = "Total:";
            // 
            // lbltot
            // 
            this.lbltot.AutoSize = true;
            this.lbltot.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltot.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbltot.Location = new System.Drawing.Point(1073, 598);
            this.lbltot.Name = "lbltot";
            this.lbltot.Size = new System.Drawing.Size(49, 20);
            this.lbltot.TabIndex = 65;
            this.lbltot.Text = "00.00";
            // 
            // frmReporteVentaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1418, 627);
            this.Controls.Add(this.lbltot);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblBandera);
            this.Controls.Add(this.rbElegir);
            this.Controls.Add(this.rbAperturaCaja);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbProducto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.dataListado);
            this.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReporteVentaCliente";
            this.Text = ".:: REPORTE DE VENTAS POR CLIENTE ::.";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReporteVentaCliente_FormClosed);
            this.Load += new System.EventHandler(this.frmReporteVentaCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataListado;
        public System.Windows.Forms.DateTimePicker dtpFechaFin;
        public System.Windows.Forms.DateTimePicker dtpFechaInicio;
        public System.Windows.Forms.ComboBox cbProducto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbAperturaCaja;
        private System.Windows.Forms.RadioButton rbElegir;
        public System.Windows.Forms.Label lblBandera;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbltot;
    }
}