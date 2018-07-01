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
    public partial class frmMostrarRegistroTrabajador : Form
    {
        public frmMostrarRegistroTrabajador()
        {
            InitializeComponent();
        }

        private void Mostrar()
        {


            this.dataListado.DataSource = NRegistroTrabajador.Mostrar();
            if (dataListado.Rows.Count > 0)
            {
                this.dataListado.ClearSelection();
                ocultarColumnas();
                dataListado.ClearSelection();
            }

        }

        private void ocultarColumnas()
        {


            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[0].Width = 220;
            this.dataListado.Columns[1].Width = 370;
            this.dataListado.Columns[2].Width = 100;


            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.DefaultCellStyle.Font = new Font("Roboto", 9);
            this.dataListado.RowsDefaultCellStyle.BackColor = Color.White;
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }


        private void frmMostrarRegistroTrabajador_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            Mostrar();
        }
    }
}
