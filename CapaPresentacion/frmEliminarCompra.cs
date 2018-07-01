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
    public partial class frmEliminarCompra : Form
    {
        public frmEliminarCompra()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rpta = "";
            DataTable dt = NCompra.mostrarDetalleIngreso(Convert.ToInt32(lblIdCompra.Text));
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rpta = NCompra.EditarStcok(Convert.ToInt32(dt.Rows[i][0].ToString()),
                        Convert.ToDecimal(dt.Rows[i][9].ToString()), Convert.ToDecimal(dt.Rows[i][7].ToString()));
                }
            }
            if (rpta == "OK")
            {
                rpta = NCompra.Eliminar(Convert.ToInt32(lblIdCompra.Text));
                if (rpta == "OK")
                {
                    if (cbOrigen.Checked)
                    {
                        decimal monto = 00.00m;
                        if (lblFormaPago.Text == "CREDITO")
                        {
                            monto = Convert.ToDecimal(lblAdelanto.Text);
                        }
                        else if (lblFormaPago.Text == "EFECTIVO")
                        {
                            monto = Convert.ToDecimal(lblTotal.Text);
                        }
                        rpta = NCaja.Insertar(Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "1", "INGRESO", monto, "COMPRA ELIMINADA", "EFECTIVO");
                        if (rpta == "OK")
                        {
                            this.Close();
                            frmMostrarCompras.f1.Mostrar();
                        }
                    }
                    else
                    {
                        this.Close();
                        frmMostrarCompras.f1.Mostrar();
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEliminarCompra_Load(object sender, EventArgs e)
        {

        }
    }
}
