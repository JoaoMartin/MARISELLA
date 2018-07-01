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
    public partial class frmReporteAbono : Form
    {
        public static frmReporteAbono f1;
        public frmReporteAbono()
        {
            InitializeComponent();
            frmReporteAbono.f1 = this;
        }
        private void cargarCliente()
        {
            cbProducto.DataSource = NCliente.Mostrar();
            cbProducto.ValueMember = "Codigo";
            cbProducto.DisplayMember = "Cliente";
            cbProducto.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }

        private void Mostrar()
        {
           
                string fechaInicio = "";
                string fechaFin = "";
                decimal totalCan = 00.00m;
                if (rbAperturaCaja.Checked == true)
                {
                    //fecIn = Convert.ToDateTime(frmPrincipal.f1.lblFechaApertura.Text);
                    //fechaInicio = fecIn.ToString("yyyy-MM-dd hh:mm:ss");
                    fechaInicio = frmPrincipal.f1.lblFechaApertura.Text;
                    // fechaFin = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    fechaFin = DateTime.Now.ToString();
                }
                else if (rbElegir.Checked == true)
                {
                    fechaInicio = dtpFechaInicio.Value.ToString("yyyy-MM-dd" + " 00:00:00");
                    fechaFin = dtpFechaFin.Value.ToString("yyyy-MM-dd" + " 23:59:59");
                }

               
                this.dataListado.DataSource = NAbono.reporteAbonos(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin));
            /*decimal total = 00.00m, totalUnid = 00.00m;
            for (int i = 0; i < dataListado.Rows.Count; i++)
            {
                totalCan = totalCan + Convert.ToDecimal(dataListado.Rows[i].Cells[4].Value.ToString());
                total = total + Convert.ToDecimal(dataListado.Rows[i].Cells[12].Value.ToString());
                totalUnid = totalUnid + Convert.ToDecimal(dataListado.Rows[i].Cells[5].Value.ToString());
            }*/

            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

                if (this.dataListado.Rows.Count == 0)
                {
                    //this.dataListado.Visible = false;
                   
                    btnImprimir.Enabled = false;
                    //ocultarColumnas();
                }
                else
                {

                    this.dataListado.Visible = true;
                    btnImprimir.Enabled = true;
                    ocultarColumnas();
                }
           
        }

        private void ocultarColumnas()
        {

            //this.dataListado.Columns[4].Visible = false;
            //DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[0].Width = 340;
            this.dataListado.Columns[1].Width = 190;
            this.dataListado.Columns[2].Width = 150;
            this.dataListado.Columns[3].Width = 190;
            this.dataListado.RowTemplate.Height = 28;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.Font = new Font("Roboto", 9);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }


        private void frmReporteAbono_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            cargarCliente();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmRAbono frm = new frmRAbono();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void rbElegir_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAperturaCaja.Checked == true)
            {
                groupBox1.Enabled = false;
                lblBandera.Text = "0";

            }
            else if (rbElegir.Checked == true)
            {
                groupBox1.Enabled = true;
                lblBandera.Text = "1";

            }
        }

        private void rbAperturaCaja_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAperturaCaja.Checked == true)
            {
                groupBox1.Enabled = false;
                lblBandera.Text = "0";
                
            }
            else if (rbElegir.Checked == true)
            {
                groupBox1.Enabled = true;
                lblBandera.Text = "1";

            }
        }
    }
}
