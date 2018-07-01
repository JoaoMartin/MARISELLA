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
    public partial class frmDetalleCompra : Form
    {
        public frmDetalleCompra()
        {
            InitializeComponent();
        }

        private void Formato()
        {
            this.dataListado.Columns[0].Visible = false;

            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[2].DefaultCellStyle.Format = "N2";
            this.dataListado.Columns[10].DefaultCellStyle.Format = "N2";
            this.dataListado.Columns[11].DefaultCellStyle.Format = "N2";
            this.dataListado.Columns[1].Width = 200;
            this.dataListado.Columns[2].Width = 85;
            this.dataListado.Columns[4].Width = 85;
            this.dataListado.Columns[5].Width = 85;
            this.dataListado.Columns[6].Width = 85;
            this.dataListado.Columns[7].Width = 85;
            this.dataListado.Columns[8].Width = 85;
            this.dataListado.Columns[9].Width = 85;
            this.dataListado.Columns[10].Width = 85;
            this.dataListado.Columns[11].Width = 85;

            this.dataListado.RowTemplate.Height = 34;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.Font = new Font("Roboto", 9);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NCompra.mostrarDetalleIngreso(Convert.ToInt32(this.lblIdVenta.Text));
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {

                this.dataListado.Visible = true;
                Formato();
                decimal nroTotalJabas = 00.00m, nroTotalPollos = 00.00m, kgs = 00.00m, nroUnidades = 00.00m, pesoTara = 00.00m, pesoNeto = 00.00m, importe = 00.00m;
                for(int i = 0; i < dataListado.Rows.Count; i++)
                {
                    nroTotalJabas = nroTotalJabas + Convert.ToDecimal(dataListado.Rows[i].Cells[5].Value);
                    nroTotalPollos = nroTotalPollos + Convert.ToDecimal(dataListado.Rows[i].Cells[7].Value);
                    kgs = kgs + Convert.ToDecimal(dataListado.Rows[i].Cells[3].Value);
                    nroUnidades = nroUnidades + Convert.ToDecimal(dataListado.Rows[i].Cells[4].Value);
                    pesoTara = pesoTara + Convert.ToDecimal(dataListado.Rows[i].Cells[8].Value);
                    pesoNeto = pesoNeto + Convert.ToDecimal(dataListado.Rows[i].Cells[9].Value);
                    importe = importe + Convert.ToDecimal(dataListado.Rows[i].Cells[11].Value);
                }
                lblNroTotalJaba.Text = nroTotalJabas.ToString();
                lblNroTotalPollos.Text = nroTotalPollos.ToString();
                lblKgs.Text = kgs.ToString();
                lblNroUnidades.Text = nroUnidades.ToString();
                lblPesoTara.Text = pesoTara.ToString();
                lblPesoNeto.Text = pesoNeto.ToString();
                lblTotalImporte.Text = importe.ToString("#0.00#");
            }
        }
        private void frmDetalleCompra_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.dataListado.ClearSelection();
        }
    }
}
