namespace CapaPresentacion
{
    partial class frmEliminarCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEliminarCompra));
            this.cbOrigen = new System.Windows.Forms.CheckBox();
            this.lblAdelanto = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.lblIdCompra = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblMonto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbOrigen
            // 
            this.cbOrigen.AutoSize = true;
            this.cbOrigen.Checked = true;
            this.cbOrigen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOrigen.Location = new System.Drawing.Point(75, 21);
            this.cbOrigen.Name = "cbOrigen";
            this.cbOrigen.Size = new System.Drawing.Size(107, 24);
            this.cbOrigen.TabIndex = 21;
            this.cbOrigen.Text = "Origen Caja";
            this.cbOrigen.UseVisualStyleBackColor = true;
            // 
            // lblAdelanto
            // 
            this.lblAdelanto.AutoSize = true;
            this.lblAdelanto.Location = new System.Drawing.Point(187, 82);
            this.lblAdelanto.Name = "lblAdelanto";
            this.lblAdelanto.Size = new System.Drawing.Size(17, 20);
            this.lblAdelanto.TabIndex = 20;
            this.lblAdelanto.Text = "0";
            this.lblAdelanto.Visible = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(71, 203);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(17, 20);
            this.lblTotal.TabIndex = 18;
            this.lblTotal.Text = "0";
            this.lblTotal.Visible = false;
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Location = new System.Drawing.Point(22, 218);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(17, 20);
            this.lblFormaPago.TabIndex = 17;
            this.lblFormaPago.Text = "0";
            this.lblFormaPago.Visible = false;
            // 
            // lblIdCompra
            // 
            this.lblIdCompra.AutoSize = true;
            this.lblIdCompra.Location = new System.Drawing.Point(22, 144);
            this.lblIdCompra.Name = "lblIdCompra";
            this.lblIdCompra.Size = new System.Drawing.Size(17, 20);
            this.lblIdCompra.TabIndex = 16;
            this.lblIdCompra.Text = "0";
            this.lblIdCompra.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(238, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 52);
            this.button2.TabIndex = 15;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(75, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 52);
            this.button1.TabIndex = 14;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(33, 177);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(17, 20);
            this.lblMonto.TabIndex = 22;
            this.lblMonto.Text = "0";
            this.lblMonto.Visible = false;
            // 
            // frmEliminarCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(396, 126);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.cbOrigen);
            this.Controls.Add(this.lblAdelanto);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblFormaPago);
            this.Controls.Add(this.lblIdCompra);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Roboto", 9.230769F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEliminarCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".::ELIMINAR COMPRA::.";
            this.Load += new System.EventHandler(this.frmEliminarCompra_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbOrigen;
        public System.Windows.Forms.Label lblAdelanto;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Label lblFormaPago;
        public System.Windows.Forms.Label lblIdCompra;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label lblMonto;
    }
}