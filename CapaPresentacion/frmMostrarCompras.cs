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
    public partial class frmMostrarCompras : Form
    {
        public static frmMostrarCompras f1;
        public frmMostrarCompras()
        {
            InitializeComponent();
            frmMostrarCompras.f1 = this;

        }


        public void Mostrar()
        {
            string fechaInicio = dtpFechaInicio.Value.ToString("yyyy-MM-dd");
            string fechaFin = dtpFechaFin.Value.ToString("yyyy-MM-dd");

            this.dataListado.DataSource = NCompra.Mostrar(Convert.ToDateTime(fechaInicio + " 00:00:00"), Convert.ToDateTime(fechaFin + " 23:59:59"));
            this.lblTotal.Text = "Total de Registros: " + this.dataListado.Rows.Count;
            this.dataListado.ClearSelection();
        }

        private void ocultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[10].Visible = false;
            this.dataListado.Columns[11].Visible = false;
            this.dataListado.Columns[12].Visible = false;
            this.dataListado.Columns[13].Visible = false;
            this.dataListado.Columns[14].Visible = false;
            // DataGridView1.Columns(1).Width = 150

            this.dataListado.Columns[1].Width = 250;
            this.dataListado.Columns[2].Width = 100;
            this.dataListado.Columns[3].Width = 100;
            this.dataListado.Columns[4].Width = 80;
            this.dataListado.Columns[5].Width = 100;
            this.dataListado.Columns[6].Width = 140;
            this.dataListado.Columns[7].Width = 140;
            this.dataListado.Columns[8].Width = 140;
            this.dataListado.Columns[9].Width = 160;
            this.dataListado.RowTemplate.Height = 28;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.Font = new Font("Roboto", 9);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mostrar();
            ocultarColumnas();
            btnImprimir.Enabled = true;
        }

        private void frmMostrarCompras_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmDetalleCompra form = new frmDetalleCompra();
            form.lblIdVenta.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            form.dataListado.ClearSelection();
            form.ShowDialog();
            form.dataListado.ClearSelection();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmRMostrarCompras frm = new frmRMostrarCompras();

            frm.ShowDialog();
        }

        private void frmMostrarCompras_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            btnGastos.Enabled = true;
            btnTransporte.Enabled = true;
            btnImprimirCompra.Enabled = true;
            if (dataListado.Rows.Count > 0)
            {
                btnEliminar.Enabled = true;
                this.lblIdCompra.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
                this.lblFormaPago.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["formaPago"].Value);
                this.lblAdelanto.Text =  Convert.ToString(this.dataListado.CurrentRow.Cells["Adelanto"].Value);
                this.lblTotalCompra.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Total"].Value);
            }
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            frmMostrarGastosCompra frm = new frmMostrarGastosCompra();
            frm.lblIdCompra.Text = this.lblIdCompra.Text;
            frm.Show();
            frm.dataListado.ClearSelection();
        }

        private void btnTransporte_Click(object sender, EventArgs e)
        {
            frmMostrarGastoTransporte frm = new frmMostrarGastoTransporte();
            frm.lblIdCompra.Text = this.lblIdCompra.Text;
            frm.ShowDialog();
            frm.dataListado.ClearSelection();
        }

        private void btnImprimirCompra_Click(object sender, EventArgs e)
        {
            frmRImprimirDetalleCompra frm = new frmRImprimirDetalleCompra();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Está seguro de anular la compra?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {

                    frmEliminarCompra frm = new frmEliminarCompra();
                    frm.lblIdCompra.Text = this.lblIdCompra.Text;
                    frm.lblFormaPago.Text = this.lblFormaPago.Text;
                    frm.lblAdelanto.Text = this.lblAdelanto.Text;
                    frm.lblTotal.Text = this.lblTotalCompra.Text;
                    frm.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
