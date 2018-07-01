namespace CapaPresentacion
{
    partial class frmAbonoCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbonoCompra));
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDcto = new System.Windows.Forms.TextBox();
            this.btnDescuentoTotal = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblVuelto = new System.Windows.Forms.Label();
            this.txtVuelto = new System.Windows.Forms.TextBox();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button22 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblBanderaTexto = new System.Windows.Forms.Label();
            this.lblIdCompra = new System.Windows.Forms.Label();
            this.lblIdProveedor = new System.Windows.Forms.Label();
            this.cbCaja = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(288, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 34);
            this.label6.TabIndex = 266;
            this.label6.Text = "S/";
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.AutoSize = true;
            this.lblTotalPagar.Font = new System.Drawing.Font("Roboto Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagar.ForeColor = System.Drawing.Color.Navy;
            this.lblTotalPagar.Location = new System.Drawing.Point(336, 102);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(83, 34);
            this.lblTotalPagar.TabIndex = 265;
            this.lblTotalPagar.Text = "00.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 12.30769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(161, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 26);
            this.label5.TabIndex = 264;
            this.label5.Text = "TOTAL PAGO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 12.30769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(217, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 26);
            this.label2.TabIndex = 260;
            this.label2.Text = "DCTO";
            // 
            // txtDcto
            // 
            this.txtDcto.Font = new System.Drawing.Font("Roboto", 22.15385F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDcto.Location = new System.Drawing.Point(290, 275);
            this.txtDcto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDcto.Name = "txtDcto";
            this.txtDcto.ReadOnly = true;
            this.txtDcto.Size = new System.Drawing.Size(262, 55);
            this.txtDcto.TabIndex = 259;
            // 
            // btnDescuentoTotal
            // 
            this.btnDescuentoTotal.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDescuentoTotal.Font = new System.Drawing.Font("Roboto Black", 9.230769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescuentoTotal.Image = global::CapaPresentacion.Properties.Resources.vale;
            this.btnDescuentoTotal.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDescuentoTotal.Location = new System.Drawing.Point(569, 164);
            this.btnDescuentoTotal.Name = "btnDescuentoTotal";
            this.btnDescuentoTotal.Size = new System.Drawing.Size(141, 97);
            this.btnDescuentoTotal.TabIndex = 258;
            this.btnDescuentoTotal.Text = "DCTO GRAL";
            this.btnDescuentoTotal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDescuentoTotal.UseVisualStyleBackColor = false;
            this.btnDescuentoTotal.Click += new System.EventHandler(this.btnDescuentoTotal_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancelar.Font = new System.Drawing.Font("Roboto Black", 9.230769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.if_gtk_cancel_39042;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(569, 61);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(141, 99);
            this.btnCancelar.TabIndex = 254;
            this.btnCancelar.Text = "&CANCELAR";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Font = new System.Drawing.Font("Roboto Black", 9.230769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::CapaPresentacion.Properties.Resources.if_cashbox_45016;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(569, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 99);
            this.button1.TabIndex = 253;
            this.button1.Text = "COBRAR";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblVuelto
            // 
            this.lblVuelto.AutoSize = true;
            this.lblVuelto.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVuelto.Location = new System.Drawing.Point(159, 376);
            this.lblVuelto.Name = "lblVuelto";
            this.lblVuelto.Size = new System.Drawing.Size(129, 34);
            this.lblVuelto.TabIndex = 252;
            this.lblVuelto.Text = "N. SALDO";
            // 
            // txtVuelto
            // 
            this.txtVuelto.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVuelto.Location = new System.Drawing.Point(294, 348);
            this.txtVuelto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVuelto.Name = "txtVuelto";
            this.txtVuelto.ReadOnly = true;
            this.txtVuelto.Size = new System.Drawing.Size(258, 59);
            this.txtVuelto.TabIndex = 251;
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarjeta.Location = new System.Drawing.Point(352, 506);
            this.txtTarjeta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.ReadOnly = true;
            this.txtTarjeta.Size = new System.Drawing.Size(262, 59);
            this.txtTarjeta.TabIndex = 250;
            this.txtTarjeta.Visible = false;
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivo.Location = new System.Drawing.Point(290, 208);
            this.txtEfectivo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(266, 59);
            this.txtEfectivo.TabIndex = 249;
            this.txtEfectivo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtEfectivo_KeyUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CapaPresentacion.Properties.Resources.visa;
            this.pictureBox2.Location = new System.Drawing.Point(240, 493);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(106, 89);
            this.pictureBox2.TabIndex = 248;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.efec;
            this.pictureBox1.Location = new System.Drawing.Point(178, 170);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 97);
            this.pictureBox1.TabIndex = 247;
            this.pictureBox1.TabStop = false;
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button22.Font = new System.Drawing.Font("Roboto", 25.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button22.Location = new System.Drawing.Point(14, 127);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(134, 116);
            this.button22.TabIndex = 245;
            this.button22.Text = "20";
            this.button22.UseVisualStyleBackColor = false;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button21.Font = new System.Drawing.Font("Roboto", 25.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button21.Location = new System.Drawing.Point(14, 249);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(134, 116);
            this.button21.TabIndex = 244;
            this.button21.Text = "50";
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button20.Font = new System.Drawing.Font("Roboto", 25.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.Location = new System.Drawing.Point(14, 371);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(134, 116);
            this.button20.TabIndex = 243;
            this.button20.Text = "100";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button19.Font = new System.Drawing.Font("Roboto", 25.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button19.Location = new System.Drawing.Point(14, 493);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(134, 116);
            this.button19.TabIndex = 242;
            this.button19.Text = "200";
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Font = new System.Drawing.Font("Roboto", 25.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(14, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 116);
            this.button2.TabIndex = 241;
            this.button2.Text = "10";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblBanderaTexto
            // 
            this.lblBanderaTexto.AutoSize = true;
            this.lblBanderaTexto.Font = new System.Drawing.Font("Roboto", 12.30769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanderaTexto.Location = new System.Drawing.Point(352, 526);
            this.lblBanderaTexto.Name = "lblBanderaTexto";
            this.lblBanderaTexto.Size = new System.Drawing.Size(23, 26);
            this.lblBanderaTexto.TabIndex = 267;
            this.lblBanderaTexto.Text = "0";
            this.lblBanderaTexto.Visible = false;
            // 
            // lblIdCompra
            // 
            this.lblIdCompra.AutoSize = true;
            this.lblIdCompra.Font = new System.Drawing.Font("Roboto", 12.30769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdCompra.Location = new System.Drawing.Point(529, 526);
            this.lblIdCompra.Name = "lblIdCompra";
            this.lblIdCompra.Size = new System.Drawing.Size(23, 26);
            this.lblIdCompra.TabIndex = 268;
            this.lblIdCompra.Text = "0";
            this.lblIdCompra.Visible = false;
            // 
            // lblIdProveedor
            // 
            this.lblIdProveedor.AutoSize = true;
            this.lblIdProveedor.Font = new System.Drawing.Font("Roboto", 12.30769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdProveedor.Location = new System.Drawing.Point(415, 428);
            this.lblIdProveedor.Name = "lblIdProveedor";
            this.lblIdProveedor.Size = new System.Drawing.Size(23, 26);
            this.lblIdProveedor.TabIndex = 269;
            this.lblIdProveedor.Text = "0";
            this.lblIdProveedor.Visible = false;
            // 
            // cbCaja
            // 
            this.cbCaja.AutoSize = true;
            this.cbCaja.Checked = true;
            this.cbCaja.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCaja.Location = new System.Drawing.Point(290, 47);
            this.cbCaja.Name = "cbCaja";
            this.cbCaja.Size = new System.Drawing.Size(58, 24);
            this.cbCaja.TabIndex = 270;
            this.cbCaja.Text = "Caja";
            this.cbCaja.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 9.846154F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(161, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 23);
            this.label1.TabIndex = 271;
            this.label1.Text = "Origen Dinero";
            // 
            // frmAbonoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(739, 622);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCaja);
            this.Controls.Add(this.lblIdProveedor);
            this.Controls.Add(this.lblIdCompra);
            this.Controls.Add(this.lblBanderaTexto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTotalPagar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDcto);
            this.Controls.Add(this.btnDescuentoTotal);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblVuelto);
            this.Controls.Add(this.txtVuelto);
            this.Controls.Add(this.txtTarjeta);
            this.Controls.Add(this.txtEfectivo);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button2);
            this.Font = new System.Drawing.Font("Roboto", 9.230769F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbonoCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".:: ABONAR COMPRA::.";
            this.Load += new System.EventHandler(this.frmAbonoCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtDcto;
        public System.Windows.Forms.Button btnDescuentoTotal;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblVuelto;
        public System.Windows.Forms.TextBox txtVuelto;
        public System.Windows.Forms.TextBox txtTarjeta;
        public System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblBanderaTexto;
        public System.Windows.Forms.Label lblIdCompra;
        public System.Windows.Forms.Label lblIdProveedor;
        private System.Windows.Forms.CheckBox cbCaja;
        private System.Windows.Forms.Label label1;
    }
}