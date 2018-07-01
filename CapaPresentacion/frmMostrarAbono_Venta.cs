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
    public partial class frmMostrarAbono_Venta : Form
    {
        public frmMostrarAbono_Venta()
        {
            InitializeComponent();
        }

        private void ocultarColumnas()
        {

            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[0].Width = 170;
            this.dataListado.Columns[1].Width = 92;
            this.dataListado.Columns[2].Width = 92;
            this.dataListado.Columns[3].Width = 92;
        }

        private void mostrarAbono()
        {
            DataTable dtAbono = NAbono.MostrarAbono_Venta(Convert.ToInt32(lblIdVenta.Text));
            dataListado.DataSource = dtAbono;
            if(dataListado.Rows.Count > 0)
            {
                ocultarColumnas();
                dataListado.ClearSelection();
            }
        }

        private void frmMostrarAbono_Venta_Load(object sender, EventArgs e)
        {
            mostrarAbono();
        }

        private void frmMostrarAbono_Venta_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmCreditosPendientes.f1.dataListado.ClearSelection();
            frmCreditosPendientes.f1.btnAbonar.Enabled = false;
            frmCreditosPendientes.f1.btnVerAbono.Enabled = false;
        }
    }
}
