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
    public partial class frmMostrarGastoTransporte : Form
    {
        public frmMostrarGastoTransporte()
        {
            InitializeComponent();
        }
        public void mostrar()
        {
            dataListado.DataSource = NCompra.mostrarTransporteGasto(Convert.ToInt32(lblIdCompra.Text));
        }


        private void frmMostrarGastoTransporte_Load(object sender, EventArgs e)
        {
            mostrar();
            this.dataListado.ClearSelection();
        }
    }
}
