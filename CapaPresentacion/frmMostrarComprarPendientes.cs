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
    public partial class frmMostrarComprarPendientes : Form
    {
        public static frmMostrarComprarPendientes f1;
        public frmMostrarComprarPendientes()
        {
            InitializeComponent();
            frmMostrarComprarPendientes.f1 = this;
        }

        private void cargarProveedor()
        {
            cbProducto.DataSource = NProveedor.Mostrar();
            cbProducto.ValueMember = "Codigo";
            cbProducto.DisplayMember = "Razon_Social";
            cbProducto.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }

        private void frmMostrarComprarPendientes_Load(object sender, EventArgs e)
        {
            this.Left = 0;
            this.Top = 0;

            this.txtBuscar.Select();
            this.btnAbonar.Enabled = false;
            cargarProveedor();
        }

        private void ocultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;

            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[0].Width = 60;
            this.dataListado.Columns[1].Width = 210;
            this.dataListado.Columns[2].Width = 150;
            this.dataListado.Columns[3].Width = 150;
            this.dataListado.Columns[4].Width = 150;
            this.dataListado.Columns[5].Width = 150;
            //this.dataListado.Columns[7].Width = 190;

            this.dataListado.RowTemplate.Height = 38;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.Font = new Font("Roboto", 10);
            this.dataListado.GridColor = SystemColors.ActiveBorder;
            decimal totalSaldo = 00.00m;
            for (int i = 0; i < dataListado.Rows.Count; i++)
            {
                totalSaldo = totalSaldo + Convert.ToDecimal(dataListado.Rows[i].Cells[5].Value);
            }
            lblTotal.Text = totalSaldo.ToString();

        }

        public void Mostrar()
        {
            this.dataListado.DataSource = NPagoCredito.Mostrar(Convert.ToInt32(cbProducto.SelectedValue));
           // lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
              

                //ocultarColumnas();
            }
            else
            {
                this.dataListado.Visible = true;
                
                ocultarColumnas();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbProducto.SelectedIndex != -1)
            {
                Mostrar();
            }
        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            if(dataListado.Rows.Count > 0)
            {
                btnAbonar.Enabled = true;
                this.lblIdCompra.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idIngreso"].Value);
                this.lblSaldo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Saldo"].Value);
              
            }
        }

        private void btnAbonar_Click(object sender, EventArgs e)
        {
            frmAbonoCompra frm = new frmAbonoCompra();
            frm.lblIdCompra.Text = this.lblIdCompra.Text;
            frm.lblTotalPagar.Text = this.lblSaldo.Text;
            frm.lblIdProveedor.Text = this.lblIdProveedor.Text;
            frm.ShowDialog();
        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblIdProveedor.Text = Convert.ToString(cbProducto.SelectedValue);
        }
    }
}
