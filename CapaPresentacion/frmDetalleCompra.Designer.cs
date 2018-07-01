namespace CapaPresentacion
{
    partial class frmDetalleCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleCompra));
            this.lblIdVenta = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNroTotalJaba = new System.Windows.Forms.Label();
            this.lblNroTotalPollos = new System.Windows.Forms.Label();
            this.lblKgs = new System.Windows.Forms.Label();
            this.lblNroUnidades = new System.Windows.Forms.Label();
            this.lblPesoTara = new System.Windows.Forms.Label();
            this.lblPesoNeto = new System.Windows.Forms.Label();
            this.lblTotalImporte = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIdVenta
            // 
            this.lblIdVenta.AutoSize = true;
            this.lblIdVenta.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdVenta.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblIdVenta.Location = new System.Drawing.Point(322, -1);
            this.lblIdVenta.Name = "lblIdVenta";
            this.lblIdVenta.Size = new System.Drawing.Size(50, 20);
            this.lblIdVenta.TabIndex = 41;
            this.lblIdVenta.Text = "label3";
            this.lblIdVenta.Visible = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTotal.Location = new System.Drawing.Point(948, 18);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(50, 20);
            this.lblTotal.TabIndex = 40;
            this.lblTotal.Text = "label3";
            // 
            // dataListado
            // 
            this.dataListado.AllowUserToAddRows = false;
            this.dataListado.AllowUserToDeleteRows = false;
            this.dataListado.AllowUserToOrderColumns = true;
            this.dataListado.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListado.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataListado.Location = new System.Drawing.Point(14, 46);
            this.dataListado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.RowTemplate.Height = 28;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(1123, 333);
            this.dataListado.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Black", 9.230769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(207, 386);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "TOTAL";
            // 
            // lblNroTotalJaba
            // 
            this.lblNroTotalJaba.AutoSize = true;
            this.lblNroTotalJaba.Font = new System.Drawing.Font("Roboto", 11.07692F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroTotalJaba.Location = new System.Drawing.Point(526, 383);
            this.lblNroTotalJaba.Name = "lblNroTotalJaba";
            this.lblNroTotalJaba.Size = new System.Drawing.Size(55, 24);
            this.lblNroTotalJaba.TabIndex = 43;
            this.lblNroTotalJaba.Text = "00.00";
            // 
            // lblNroTotalPollos
            // 
            this.lblNroTotalPollos.AutoSize = true;
            this.lblNroTotalPollos.Font = new System.Drawing.Font("Roboto", 11.07692F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroTotalPollos.Location = new System.Drawing.Point(709, 383);
            this.lblNroTotalPollos.Name = "lblNroTotalPollos";
            this.lblNroTotalPollos.Size = new System.Drawing.Size(55, 24);
            this.lblNroTotalPollos.TabIndex = 44;
            this.lblNroTotalPollos.Text = "00.00";
            // 
            // lblKgs
            // 
            this.lblKgs.AutoSize = true;
            this.lblKgs.Font = new System.Drawing.Font("Roboto", 11.07692F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKgs.Location = new System.Drawing.Point(336, 383);
            this.lblKgs.Name = "lblKgs";
            this.lblKgs.Size = new System.Drawing.Size(55, 24);
            this.lblKgs.TabIndex = 45;
            this.lblKgs.Text = "00.00";
            // 
            // lblNroUnidades
            // 
            this.lblNroUnidades.AutoSize = true;
            this.lblNroUnidades.Font = new System.Drawing.Font("Roboto", 11.07692F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroUnidades.Location = new System.Drawing.Point(426, 383);
            this.lblNroUnidades.Name = "lblNroUnidades";
            this.lblNroUnidades.Size = new System.Drawing.Size(55, 24);
            this.lblNroUnidades.TabIndex = 46;
            this.lblNroUnidades.Text = "00.00";
            // 
            // lblPesoTara
            // 
            this.lblPesoTara.AutoSize = true;
            this.lblPesoTara.Font = new System.Drawing.Font("Roboto", 11.07692F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesoTara.Location = new System.Drawing.Point(797, 383);
            this.lblPesoTara.Name = "lblPesoTara";
            this.lblPesoTara.Size = new System.Drawing.Size(55, 24);
            this.lblPesoTara.TabIndex = 47;
            this.lblPesoTara.Text = "00.00";
            // 
            // lblPesoNeto
            // 
            this.lblPesoNeto.AutoSize = true;
            this.lblPesoNeto.Font = new System.Drawing.Font("Roboto", 11.07692F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesoNeto.Location = new System.Drawing.Point(877, 382);
            this.lblPesoNeto.Name = "lblPesoNeto";
            this.lblPesoNeto.Size = new System.Drawing.Size(55, 24);
            this.lblPesoNeto.TabIndex = 48;
            this.lblPesoNeto.Text = "00.00";
            // 
            // lblTotalImporte
            // 
            this.lblTotalImporte.AutoSize = true;
            this.lblTotalImporte.Font = new System.Drawing.Font("Roboto", 11.07692F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalImporte.Location = new System.Drawing.Point(1034, 382);
            this.lblTotalImporte.Name = "lblTotalImporte";
            this.lblTotalImporte.Size = new System.Drawing.Size(55, 24);
            this.lblTotalImporte.TabIndex = 49;
            this.lblTotalImporte.Text = "00.00";
            // 
            // frmDetalleCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1142, 425);
            this.Controls.Add(this.lblTotalImporte);
            this.Controls.Add(this.lblPesoNeto);
            this.Controls.Add(this.lblPesoTara);
            this.Controls.Add(this.lblNroUnidades);
            this.Controls.Add(this.lblKgs);
            this.Controls.Add(this.lblNroTotalPollos);
            this.Controls.Add(this.lblNroTotalJaba);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblIdVenta);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dataListado);
            this.Font = new System.Drawing.Font("Roboto", 9.230769F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDetalleCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".:: DETALLE COMPRA ::.";
            this.Load += new System.EventHandler(this.frmDetalleCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblIdVenta;
        private System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNroTotalJaba;
        private System.Windows.Forms.Label lblNroTotalPollos;
        private System.Windows.Forms.Label lblKgs;
        private System.Windows.Forms.Label lblNroUnidades;
        private System.Windows.Forms.Label lblPesoTara;
        private System.Windows.Forms.Label lblPesoNeto;
        private System.Windows.Forms.Label lblTotalImporte;
    }
}