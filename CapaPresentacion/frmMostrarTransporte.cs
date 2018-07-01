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
    public partial class frmMostrarTransporte : Form
    {
        public frmMostrarTransporte()
        {
            InitializeComponent();
        }
        private void ocultarColumnas()
        {

            this.dataListado.Columns[14].Visible = false;
            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[0].Width = 220;
            this.dataListado.Columns[1].Width = 100;
            this.dataListado.Columns[2].Width = 100;
            this.dataListado.Columns[3].Width = 90;
            this.dataListado.Columns[4].Width = 90;
            this.dataListado.Columns[5].Width = 90;
            this.dataListado.Columns[6].Width = 90;
            this.dataListado.Columns[7].Width = 90;
            this.dataListado.Columns[8].Width = 90;
            this.dataListado.Columns[9].Width = 90;
            this.dataListado.Columns[10].Width = 90;
            this.dataListado.Columns[11].Width = 90;
            this.dataListado.Columns[12].Width = 90;
            this.dataListado.Columns[13].Width = 90;
           

            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.DefaultCellStyle.Font = new Font("Roboto", 9);
            this.dataListado.RowsDefaultCellStyle.BackColor = Color.White;
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        private void mostrarTotales()
        {
            decimal totalGastos = 00.00m, total = 00.00m;
            for(int i = 0; i < dataListado.Rows.Count; i++)
            {
                totalGastos = totalGastos + Convert.ToDecimal(dataListado.Rows[i].Cells["TotalGastos"].Value);
                if(dataListado.Rows[i].Cells["Total"].Value.ToString() != "")
                {
                    total = total + Convert.ToDecimal(dataListado.Rows[i].Cells["Total"].Value);
                }
               
            }
            this.lblTotal.Text = total.ToString();
            this.lblTotalGastos.Text = totalGastos.ToString();
        }

        private void cargar()
        {
            dataListado.DataSource = NTransporte.Mostrar();
            if(dataListado.Rows.Count > 0)
            {
                ocultarColumnas();
                mostrarTotales();
            }
        }

        private void frmMostrarTransporte_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            cargar();
        }
    }
}
