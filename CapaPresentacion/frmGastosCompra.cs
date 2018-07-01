using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmGastosCompra : Form
    {
        public frmGastosCompra()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            decimal flete = 00.00m, gastosCarga = 00.00m, lavadoJaba = 00.00m, comisiones = 00.00m;
            if(txtFlete.Text.Trim().Length == 0)
            {
                flete = 00.00m;
            }else
            {
                flete = Convert.ToDecimal(txtFlete.Text.Trim());
            }

            if(txtGastosCarga.Text.Trim().Length == 0)
            {
                gastosCarga = 00.00m;
            }else
            {
                gastosCarga = Convert.ToDecimal(txtGastosCarga.Text.Trim());
            }

            if(txtLavadoJaba.Text.Trim().Length == 0)
            {
                lavadoJaba = 00.00m;
            }else
            {
                lavadoJaba = Convert.ToDecimal(txtLavadoJaba.Text.Trim());
            }

            if(txtComisiones.Text.Trim().Length == 0)
            {
                comisiones = 00.00m;
            }else
            {
                comisiones = Convert.ToDecimal(txtComisiones.Text.Trim());
            }

            frmCompra.f1.lblFlete.Text = flete.ToString();
            frmCompra.f1.lblComisiones.Text = comisiones.ToString();
            frmCompra.f1.lblLavadoJaba.Text = lavadoJaba.ToString();
            frmCompra.f1.lblGastosCarga.Text = gastosCarga.ToString();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGastosCompra_Load(object sender, EventArgs e)
        {

        }
    }
}
