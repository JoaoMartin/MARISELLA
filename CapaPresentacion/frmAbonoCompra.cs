using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class frmAbonoCompra : Form
    {
        public static frmAbonoCompra f1;
        public frmAbonoCompra()
        {
            InitializeComponent();
            frmAbonoCompra.f1 = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text = "10";

                mostrarTotales();
                this.txtEfectivo.Focus();

            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text = "20";

                mostrarTotales();
                this.txtEfectivo.Focus();

            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text = "50";

                mostrarTotales();
                this.txtEfectivo.Focus();

            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text = "100";

                mostrarTotales();
                this.txtEfectivo.Focus();

            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text = "200";

                mostrarTotales();
                this.txtEfectivo.Focus();

            }
        }

        public void mostrarTotales()
        {

            decimal total = Convert.ToDecimal(this.lblTotalPagar.Text);
            decimal dcto = 00.00m;
            decimal efectivo = 0;
            if (txtDcto.Text.Trim().Length == 0)
            {
                dcto = 00.00m;
            }
            else
            {
                dcto = Convert.ToDecimal(txtDcto.Text.Trim());
            }
            if (this.txtEfectivo.Text.Trim().Length > 0)
            {
                efectivo = Convert.ToDecimal(this.txtEfectivo.Text);
                decimal vuelto = total - efectivo - dcto;
                this.txtVuelto.Text = vuelto.ToString();
            }
            else
            {
                this.txtVuelto.Text = string.Empty;
            }


        }

        private void frmAbonoCompra_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDescuentoTotal_Click(object sender, EventArgs e)
        {
            frmDescuentoTotal frm = new frmDescuentoTotal();
            frm.lblIdBandera.Text = "4";
            frm.Show();
        }

        private void txtEfectivo_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotales();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rpta = "";
            decimal efectivo = 00.00m, dcto = 00.00m;
            
            if(txtEfectivo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese el monto a abonar");
                return;
            }else
            {
                if(txtDcto.Text.Trim().Length == 0)
                {
                    dcto = 00.00m;
                }else
                {
                    dcto = Convert.ToDecimal(txtDcto.Text.Trim());
                }
                efectivo = Convert.ToDecimal(txtEfectivo.Text.Trim());
                rpta = NPagoCredito.Insertar(Convert.ToInt32(lblIdProveedor.Text), DateTime.Now, efectivo, dcto, Convert.ToDecimal(txtVuelto.Text), "SI",
                    Convert.ToInt32(lblIdCompra.Text));
                if(rpta == "OK")
                {
                    if (cbCaja.Checked)
                    {
                        rpta = NCaja.Insertar(Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "1", "EGRESO", Convert.ToDecimal(txtEfectivo.Text), "PAGO COMPRA", "EFECTIVO");
                        if(rpta == "OK")
                        {
                            this.Close();
                            frmMostrarComprarPendientes.f1.btnAbonar.Enabled = false;
                            frmMostrarComprarPendientes.f1.Mostrar();
                        }
                    }
                    else
                    {
                        this.Close();
                        frmMostrarComprarPendientes.f1.Mostrar();
                    }
                  
                  
                }
            }

        }
    }
}
