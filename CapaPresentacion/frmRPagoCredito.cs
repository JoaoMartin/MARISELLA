using CrystalDecisions.CrystalReports.Engine;
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
    public partial class frmRPagoCredito : Form
    {
        public frmRPagoCredito()
        {
            InitializeComponent();
        }

        public Tables CrTables { get; private set; }

        private void frmRPagoCredito_Load(object sender, EventArgs e)
        {
            try
            {
                cvVentas.Refresh();
            }

            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
            }
        }
    }
}
