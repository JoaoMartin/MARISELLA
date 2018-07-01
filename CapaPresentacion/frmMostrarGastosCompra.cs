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
    public partial class frmMostrarGastosCompra : Form
    {
        public frmMostrarGastosCompra()
        {
            InitializeComponent();
        }

        public void mostrar()
        {
            dataListado.DataSource = NCompra.mostrarGastoCompra(Convert.ToInt32(lblIdCompra.Text));
        }

       
        private void frmMostrarGastosCompra_Load(object sender, EventArgs e)
        {
            mostrar();
            this.dataListado.ClearSelection();
        }
    }
}
