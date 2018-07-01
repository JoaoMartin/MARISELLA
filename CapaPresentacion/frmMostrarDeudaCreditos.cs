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
    public partial class frmMostrarDeudaCreditos : Form
    {
        public frmMostrarDeudaCreditos()
        {
            InitializeComponent();
        }
        public void mostrarAbonos()
        {
            if (lblBandera.Text == "0")
            {
                dataListado.Rows.Clear();
                dataListado.Columns.Add("cliente", "Cliente");
                dataListado.Columns.Add("saldo", "Saldo");
                dataListado.Columns[0].Width = 300;
                dataListado.Columns[1].Width = 150;
            }

            if (rbAperturaCaja.Checked)
            {
                DataTable dtPersona = NCliente.Mostrar();
                if (dtPersona.Rows.Count > 0)
                {

                    dataListado.Rows.Clear();
                    for (int i = 0; i < dtPersona.Rows.Count; i++)
                    {
                        DataTable dtCreditos = NVenta.mostrarTotalCreditoAbono(Convert.ToInt32(dtPersona.Rows[i][0].ToString()));

                        if (dtCreditos.Rows.Count > 0)
                        {

                            dataListado.Rows.Add(dtCreditos.Rows[0][0].ToString(), dtCreditos.Rows[0][1].ToString());
                        }

                    }
                    decimal totalAbonado = 00.00m;
                    for (int k = 0; k < dataListado.Rows.Count; k++)
                    {
                        totalAbonado = totalAbonado + Convert.ToDecimal(dataListado.Rows[k].Cells[1].Value);
                    }
                    this.lblTotalAbonado.Text = totalAbonado.ToString();
                    this.dataListado.RowTemplate.Height = 28;
                    this.dataListado.ClearSelection();
                    this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                    this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
                    this.dataListado.Font = new Font("Roboto", 9);
                    this.dataListado.GridColor = SystemColors.ActiveBorder;
                    this.lblTotalCreditos.Text = Convert.ToString(Convert.ToDecimal(lblTotalAbonado.Text) + Convert.ToDecimal(lblTotalSinAbonar.Text));

                }

            }
            else if (rbElegir.Checked)
            {

                DataTable dtCreditos = NVenta.mostrarTotalCreditoAbono(Convert.ToInt32(cbProducto.SelectedValue));

                if (dtCreditos.Rows.Count > 0)
                {
                    dataListado.Rows.Clear();
                    dataListado.Rows.Add(dtCreditos.Rows[0][0].ToString(), dtCreditos.Rows[0][1].ToString());
                    dataListado.Visible = true;
                    decimal totalAbonado = 00.00m;
                    for (int k = 0; k < dataListado.Rows.Count; k++)
                    {
                        totalAbonado = totalAbonado + Convert.ToDecimal(dataListado.Rows[k].Cells[1].Value);
                    }
                    this.lblTotalAbonado.Text = totalAbonado.ToString();
                    this.dataListado.RowTemplate.Height = 28;
                    this.dataListado.ClearSelection();
                    this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                    this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
                    this.dataListado.Font = new Font("Roboto", 9);
                    this.dataListado.GridColor = SystemColors.ActiveBorder;
                    this.lblTotalCreditos.Text = Convert.ToString(Convert.ToDecimal(lblTotalAbonado.Text) + Convert.ToDecimal(lblTotalSinAbonar.Text));

                }

            }

        }
        public void mostrarSinAbonos()
        {
            if (rbAperturaCaja.Checked)
            {

                DataTable dtSinAbono = new DataTable();
                dtSinAbono = NVenta.mostrarTotalCreditoVenta();
                if (dtSinAbono.Rows.Count > 0)
                {
                    dataListadoSinAbonr.DataSource = null;
                    dataListadoSinAbonr.Refresh();
                    dataListadoSinAbonr.DataSource = dtSinAbono;

                    decimal totalSinAbonado = 00.00m;
                    for (int k = 0; k < dataListadoSinAbonr.Rows.Count; k++)
                    {
                        totalSinAbonado = totalSinAbonado + Convert.ToDecimal(dataListadoSinAbonr.Rows[k].Cells[1].Value);
                    }
                    this.lblTotalSinAbonar.Text = totalSinAbonado.ToString();


                    dataListadoSinAbonr.Columns[0].Width = 300;
                    dataListadoSinAbonr.Columns[1].Width = 150;
                    this.dataListadoSinAbonr.ClearSelection();
                    this.dataListadoSinAbonr.ColumnHeadersDefaultCellStyle.Font = new Font(dataListadoSinAbonr.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                    this.dataListadoSinAbonr.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
                    this.dataListadoSinAbonr.Font = new Font("Roboto", 9);
                    this.dataListadoSinAbonr.GridColor = SystemColors.ActiveBorder;
                    this.lblTotalCreditos.Text = Convert.ToString(Convert.ToDecimal(lblTotalAbonado.Text) + Convert.ToDecimal(lblTotalSinAbonar.Text));

                }

            }
            else if (rbElegir.Checked)
            {

                DataTable dtSinAbono = new DataTable();
                dtSinAbono = NVenta.mostrarTotalCreditoVentaCliente(Convert.ToInt32(cbProducto.SelectedValue));
                if (dtSinAbono.Rows.Count > 0)
                {
                    dataListadoSinAbonr.Visible = true;
                    dataListadoSinAbonr.DataSource = null;
                    dataListadoSinAbonr.Refresh();
                    dataListadoSinAbonr.DataSource = dtSinAbono;

                    decimal totalSinAbonado = 00.00m;
                    for (int k = 0; k < dataListadoSinAbonr.Rows.Count; k++)
                    {
                        totalSinAbonado = totalSinAbonado + Convert.ToDecimal(dataListadoSinAbonr.Rows[k].Cells[1].Value);
                    }
                    this.lblTotalSinAbonar.Text = totalSinAbonado.ToString();


                    dataListadoSinAbonr.Columns[0].Width = 300;
                    dataListadoSinAbonr.Columns[1].Width = 150;
                    this.dataListadoSinAbonr.ClearSelection();
                    this.dataListadoSinAbonr.ColumnHeadersDefaultCellStyle.Font = new Font(dataListadoSinAbonr.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                    this.dataListadoSinAbonr.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
                    this.dataListadoSinAbonr.Font = new Font("Roboto", 9);
                    this.dataListadoSinAbonr.GridColor = SystemColors.ActiveBorder;
                    this.lblTotalCreditos.Text = Convert.ToString(Convert.ToDecimal(lblTotalAbonado.Text) + Convert.ToDecimal(lblTotalSinAbonar.Text));

                }

            }


        }
        private void cargarCliente()
        {
            cbProducto.DataSource = NCliente.Mostrar();
            cbProducto.ValueMember = "Codigo";
            cbProducto.DisplayMember = "Cliente";
            cbProducto.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }

        private void frmMostrarDeudaCreditos_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            mostrarAbonos();
            mostrarSinAbonos();
            cargarCliente();
            lblBandera.Text = "1";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalAbonado_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalSinAbonar_Click(object sender, EventArgs e)
        {

        }

        private void rbAperturaCaja_CheckedChanged(object sender, EventArgs e)
        {
            gbCliente.Visible = false;
            dataListado.Visible = true;
            dataListadoSinAbonr.Visible = true;
            mostrarAbonos();
            mostrarSinAbonos();
            
        }

        private void rbElegir_CheckedChanged(object sender, EventArgs e)
        {
            gbCliente.Visible = true;
            dataListadoSinAbonr.Visible = false;
            dataListado.Visible = false;
         
            this.lblTotalAbonado.Text = "00.00";
            this.lblTotalCreditos.Text = "00.00";
            this.lblTotalSinAbonar.Text = "00.00";
            cbProducto.SelectedIndex = -1;
        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mostrarAbonos();
            mostrarSinAbonos();
        }
    }
}
