using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
    public partial class frmCreditosPendientes : Form
    {
        public static frmCreditosPendientes f1;
        public int nroDetalles = 0;
        public frmCreditosPendientes()
        {
            InitializeComponent();
            frmCreditosPendientes.f1 = this;
        }

        private void Buscar()
        {
            this.dataListado.DataSource = NVenta.BuscarCreditoPendiente(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarCliente()
        {
            this.dataListado.DataSource = NVenta.BuscarCreditoPendienteCliente(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void AñadirSaldo()
        {
            decimal cargo = 00.00m;

            for (int i = 0; i < dataListado.Rows.Count; i++)
            {
                DataTable dtNroDetalle = NVenta.mostrarNroDetalle(Convert.ToInt32(dataListado.Rows[i].Cells[0].Value));
                for (int k = 0; k < dtNroDetalle.Rows.Count; k++)
                {
                    if (k == 0)
                    {
                        nroDetalles = nroDetalles + 1;
                    }
                    else if (k != 0)
                    {
                        if (dtNroDetalle.Rows[k][0].ToString() == dtNroDetalle.Rows[k][0].ToString())
                        {
                            nroDetalles = nroDetalles + 1;
                        }
                    }
                }



                if (i == 0)
                {
                    decimal adelanto = Convert.ToDecimal(this.dataListado[13, i].Value);
                    this.dataListado[7, i].Value = adelanto / nroDetalles;
                    this.dataListado[9, i].Value = Convert.ToDecimal(Convert.ToDecimal(this.dataListado[6, i].Value) - Convert.ToDecimal(this.dataListado[7, i].Value)
                                                    - Convert.ToDecimal(this.dataListado[8, i].Value));

                    this.dataListado[11, i].Value = lblUltimoSaldo.Text;
                    nroDetalles = 0;

                }
                else
                {
                    decimal adelanto = Convert.ToDecimal(this.dataListado[13, i].Value);
                    this.dataListado[7, i].Value = adelanto / nroDetalles;
                    this.dataListado[9, i].Value = Convert.ToDecimal(this.dataListado[9, i - 1].Value) + Convert.ToDecimal(this.dataListado[6, i].Value) - 
                        Convert.ToDecimal(this.dataListado[7, i].Value) - Convert.ToDecimal(this.dataListado[8,i].Value);



                    this.dataListado[11, i].Value = lblUltimoSaldo.Text;
                    nroDetalles = 0;
                }

            }

        }

        private void ocultarColumnas()
        {
            this.dataListado.Columns[10].Visible = false;
            this.dataListado.Columns[12].Visible = false;
            this.dataListado.Columns[13].Visible = false;
            this.dataListado.Columns[14].Visible = false;
            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[0].Width = 60;
            this.dataListado.Columns[1].Width = 150;
            this.dataListado.Columns[2].Width = 270;
            this.dataListado.Columns[3].Width = 100;
            this.dataListado.Columns[4].Width = 120;
            this.dataListado.Columns[5].Width = 120;
            this.dataListado.Columns[6].Width = 120;
            //this.dataListado.Columns[7].Width = 190;

            this.dataListado.RowTemplate.Height = 27;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.Font = new Font("Roboto", 9);
            this.dataListado.GridColor = SystemColors.ActiveBorder;
            this.dataListado.Refresh();

        }
        private void ocultarColumnas1()
        {
           
            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Width = 180;
            this.dataListado.Columns[2].Width = 300;

            //this.dataListado.Columns[7].Width = 190;

            this.dataListado.RowTemplate.Height = 27;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.Font = new Font("Roboto", 9);
            this.dataListado.GridColor = SystemColors.ActiveBorder;
            this.dataListado.Refresh();
            this.lblDeudaTotal.Text = dataListado.Rows[0].Cells[2].Value.ToString();

        }

        public void Mostrar()
        {
            this.dataListado.DataSource = NVenta.MostrarCreditosPendientes(Convert.ToInt32(cbCliente.SelectedValue));
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
                this.btnAbonar.Enabled = false;
                this.btnVerAbono.Enabled = true;
                DataTable dtSaldo = NAbono.MostrarSaldoCliente(Convert.ToInt32(cbCliente.SelectedValue));
                decimal saldo = Convert.ToDecimal(dtSaldo.Rows[0][2]);
                if(saldo <= 0)
                {
                    MessageBox.Show("No hay saldos para este cliente");
                    return;
                }else
                {
                    this.dataListado.DataSource = dtSaldo;
                    this.dataListado.Visible = true;
                    this.lblBanderaAbono.Text = "1";
                    this.ocultarColumnas1();
                    btnUltimoSaldo.Enabled = false;
                }
                //ocultarColumnas();
            }
            else
            {
                this.lblBanderaAbono.Text = "0";
                this.dataListado.Visible = true;
               // this.btnAbonar.Enabled = true;
                this.btnVerAbono.Enabled = true;
                ocultarColumnas();
                DataTable dtSaldo = NAbono.MostrarUltimoSaldo(Convert.ToInt32(cbCliente.SelectedValue));

                if (dtSaldo.Rows.Count > 0)
                {
                    lblUltimoSaldo.Text = dtSaldo.Rows[0][0].ToString();
                    AñadirSaldo();
                }
                else
                {
                    lblUltimoSaldo.Text = "00.00";
                    AñadirSaldo();
                }
                int nroFilas = dataListado.Rows.Count;
                decimal ultimoSaldo = Convert.ToDecimal(dataListado.Rows[nroFilas-1].Cells[11].Value);
                decimal ultimoCargo = Convert.ToDecimal(dataListado.Rows[nroFilas-1].Cells[9].Value);
                decimal total = ultimoCargo + ultimoSaldo;
                lblDeudaTotal.Text = total.ToString();
                btnUltimoSaldo.Enabled = true;

            }
        }

        private void cargarCliente()
        {
            cbCliente.DataSource = NCliente.MostrarCredPendiente();
            cbCliente.ValueMember = "Codigo";
            cbCliente.DisplayMember = "Cliente";
            cbCliente.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }

        private void frmCreditosPendientes_Load(object sender, EventArgs e)
        {
            this.Left = 0;
            this.Top = 0;

            this.txtBuscar.Select();
            this.btnRecoger.Enabled = false;
            this.btnCobrar.Enabled = false;
            this.btnAnular.Enabled = false;
            this.btnEditar.Enabled = false;
            cargarCliente();

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            if (txtBuscar.Text.Trim().Length == 0)
            {
                Mostrar();
            }

            if (rbCodigo.Checked == true)
            {
                this.Mostrar();
                this.Buscar();
            }
            else
            {
                this.Mostrar();
                this.BuscarCliente();
            }
        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            /*
            this.lblEstado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Estado"].Value);
            this.lblIdVenta.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            this.lblTotal.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Total"].Value);
            this.lblClase.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipoCliente"].Value);
            this.lblDctoGral.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Dcto"].Value);
            this.lblSaldo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Saldo"].Value);
            this.lblCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cliente"].Value);
            DataTable dtConsulta = NComprobante.consultaComprobanteCredito(Convert.ToInt32(lblIdVenta.Text));
            if (dtConsulta.Rows.Count <= 0)
            {
                btnAnular.Enabled = true;
                lblBanderaAnulacion.Text = "0";
            }
            else if (dtConsulta.Rows[0][2].ToString() == "BOLETA")
            {
                btnAnular.Enabled = false;
            }
            else if (dtConsulta.Rows[0][2].ToString() == "FACTURA")
            {
                btnAnular.Enabled = true;
                lblBanderaAnulacion.Text = "1";
                lblIdComprobante.Text = dtConsulta.Rows[0][0].ToString();
                lblCorrelativo.Text = dtConsulta.Rows[0][1].ToString();
                lblTipoComprobante.Text = dtConsulta.Rows[0][2].ToString();
                lblFechaCompr.Text = dtConsulta.Rows[0][5].ToString();
                lblEfectivo.Text = dtConsulta.Rows[0][6].ToString();
            }
            btnRecoger.Enabled = true;
            btnCobrar.Enabled = true;
            btnEditar.Enabled = true;
            btnAbonar.Enabled = true;
            btnVerAbono.Enabled = true;*/
            if(lblBanderaAbono.Text == "0")
            {
                
                if (dataListado.SelectedRows.Count == 1)
                {
                    lblIdDetalle.Text = this.dataListado.CurrentRow.Cells["idDetalleVenta"].Value.ToString();
                }
            }
            btnAbonar.Enabled = true;
            btnCancelar.Enabled = true;


        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            frmConfirmarCredito frm = new frmConfirmarCredito();
            frm.lblEstado.Text = this.lblEstado.Text;
            frm.lblIdVenta.Text = this.lblIdVenta.Text;
            frm.lblMonto.Text = this.lblTotal.Text;
            frm.lblClase.Text = this.lblClase.Text;
            frm.lblDctoGral.Text = this.lblDctoGral.Text;
            frm.Show();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            frmAnularComprobante frm = new frmAnularComprobante();
            frm.lblBandera.Text = "5";
            frm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAbonar_Click(object sender, EventArgs e)
        {
            frmAbono frm = new frmAbono();
            if(lblBanderaAbono.Text == "0")
            {
                if (dataListado.SelectedRows.Count == dataListado.Rows.Count && dataListado.Rows.Count > 1)
                {
                    frm.lblBandera.Text = "0";
                    frm.lblSaldoAnterior.Text = this.lblUltimoSaldo.Text;
                    frm.lblIdVenta.Text = cbCliente.SelectedValue.ToString();
                    frm.lblTotal.Text = dataListado.SelectedRows[0].Cells[9].Value.ToString();
                    decimal totalPago = Convert.ToDecimal(dataListado.SelectedRows[0].Cells[11].Value) + Convert.ToDecimal(dataListado.SelectedRows[0].Cells[9].Value.ToString());
                    decimal totalPagoR = NRedondeo.redondearParcial(totalPago);
                    frm.lblTotalPagar.Text = totalPagoR.ToString();
                }
                else if (dataListado.SelectedRows.Count <= dataListado.Rows.Count && dataListado.SelectedRows.Count != 1)
                {
                    frm.lblBandera.Text = "1";
                    frm.lblSaldoAnterior.Text = this.lblUltimoSaldo.Text;
                    frm.lblIdVenta.Text = cbCliente.SelectedValue.ToString();
                    frm.lblTotal.Text = dataListado.SelectedRows[0].Cells[9].Value.ToString();
                    decimal totalPago = Convert.ToDecimal(dataListado.SelectedRows[0].Cells[11].Value) + Convert.ToDecimal(dataListado.SelectedRows[0].Cells[9].Value.ToString());
                    decimal totalPagoR = NRedondeo.redondearParcial(totalPago);
                    frm.lblTotalPagar.Text = totalPagoR.ToString();
                }
                else if (dataListado.SelectedRows.Count == 1 && dataListado.Rows.Count>1)
                {
                    frm.lblBandera.Text = "2";
                    decimal cargo = 00.00m, abono = 00.00m, total = 00.00m, adelanto = 00.00m;
                    cargo = Convert.ToDecimal(dataListado.SelectedRows[0].Cells[6].Value.ToString());
                    abono = Convert.ToDecimal(dataListado.SelectedRows[0].Cells[8].Value.ToString());
                    adelanto = Convert.ToDecimal(dataListado.SelectedRows[0].Cells[7].Value.ToString());
                    total = cargo - abono - adelanto;
                    frm.lblTotal.Text = total.ToString();
                    frm.lblTotalPagar.Text = total.ToString();
                    frm.lblUltimoSaldo.Text = dataListado.SelectedRows[0].Cells[11].Value.ToString();
                    frm.lblIdDetalle.Text = this.lblIdDetalle.Text;
                }
                else if (dataListado.SelectedRows.Count == 1 && dataListado.Rows.Count == 1)
                {
                    frm.lblBandera.Text = "1";
                    frm.lblSaldoAnterior.Text = this.lblUltimoSaldo.Text;
                    frm.lblIdVenta.Text = cbCliente.SelectedValue.ToString();
                    frm.lblTotal.Text = dataListado.SelectedRows[0].Cells[9].Value.ToString();
                    decimal totalPago = Convert.ToDecimal(dataListado.SelectedRows[0].Cells[11].Value) + Convert.ToDecimal(dataListado.SelectedRows[0].Cells[9].Value.ToString());
                    decimal totalPagoR = NRedondeo.redondearParcial(totalPago);
                    frm.lblTotalPagar.Text = totalPagoR.ToString();
                }
            }
            else
            {
                frm.lblBandera.Text = "3";
                frm.lblIdVenta.Text = cbCliente.SelectedValue.ToString();
                frm.lblTotal.Text = dataListado.SelectedRows[0].Cells[2].Value.ToString();
                frm.lblTotalPagar.Text = dataListado.SelectedRows[0].Cells[2].Value.ToString();
            }
           

            frm.Show();

        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmReporteDetalleVenta form = new frmReporteDetalleVenta();
            form.lblIdVenta.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            //form.lblTipo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Estado_Venta"].Value);
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMostrarAbono_Venta frm = new frmMostrarAbono_Venta();
            frm.lblIdVenta.Text = this.lblIdVenta.Text;
            frm.lblCliente.Text = this.lblCliente.Text;
            frm.lblTotal.Text = this.lblTotal.Text;

            frm.Show();
            frm.dataListado.ClearSelection();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (cbCliente.SelectedIndex != -1)
            {
                dataListado.DataSource = null;
                dataListado.Refresh();
                Mostrar();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(lblBanderaAbono.Text == "0")
                {
                    int count = dataListado.SelectedRows.Count;
                    if (count == 0)
                    {
                        frmRPagoCredito frm = new frmRPagoCredito();
                        dsCuotas ds = new dsCuotas();
                        int filas = dataListado.Rows.Count;
                        for (int i = 0; i <= filas - 1; i++)
                        {
                            ds.Tables[0].Rows.Add
                                (new object[] {
                            dataListado[1,i].Value.ToString(),
                            dataListado[2,i].Value.ToString(),
                            dataListado[3,i].Value.ToString(),
                            dataListado[4,i].Value.ToString(),
                            dataListado[5,i].Value.ToString(),
                            dataListado[6,i].Value.ToString(),
                            dataListado[7,i].Value.ToString(),
                            dataListado[8,i].Value.ToString(),
                            dataListado[9,i].Value.ToString(),
                            dataListado[10,i].Value.ToString(),
                             dataListado[11,i].Value.ToString(),
                              dataListado[12,i].Value.ToString()
                                 });
                        }
                        ReportDocument repdoc = new ReportDocument();

                        repdoc.Load(@"D:\Reportes\RImprimirCuotas.rpt");
                        repdoc.SetDataSource(ds);
                        frm.cvVentas.ReportSource = repdoc;
                        frm.cvVentas.Refresh();
                        frm.Show();
                    }
                    else
                    {
                        frmRPagoCredito frm = new frmRPagoCredito();
                        dsCuotas ds = new dsCuotas();
                        int filas = dataListado.SelectedRows.Count;
                        for (int i = 0; i <= filas - 1; i++)
                        {
                            ds.Tables[0].Rows.Add
                                (new object[] {
                            dataListado[1,i].Value.ToString(),
                            dataListado[2,i].Value.ToString(),
                            dataListado[3,i].Value.ToString(),
                            dataListado[4,i].Value.ToString(),
                            dataListado[5,i].Value.ToString(),
                            dataListado[6,i].Value.ToString(),
                            dataListado[7,i].Value.ToString(),
                             dataListado[7,i].Value.ToString(),
                            dataListado[9,i].Value.ToString(),
                            dataListado[10,i].Value.ToString(),
                             dataListado[11,i].Value.ToString(),
                              dataListado[12,i].Value.ToString()
                                 });
                        }
                        ReportDocument repdoc = new ReportDocument();

                        repdoc.Load(@"D:\Reportes\RImprimirCuotas.rpt");
                        repdoc.SetDataSource(ds);
                        frm.cvVentas.ReportSource = repdoc;
                        frm.cvVentas.Refresh();
                        frm.Show();
                    }
                }
               
               

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dataListado.ClearSelection();
            btnAbonar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAbono frm = new frmAbono();
            frm.lblSaldoAnterior.Text = dataListado.Rows[0].Cells[11].Value.ToString();
            frm.lblTotalPagar.Text = dataListado.Rows[0].Cells[11].Value.ToString();
            frm.lblIdVenta.Text = cbCliente.SelectedValue.ToString();
            frm.lblBandera.Text = "4";
            frm.ShowDialog();
        }

        // repdoc.Load(@"C:\Users\vioma\OneDrive\Documentos\Visual Studio 2017\Projects\SisVentas_ResAlm\CapaPresentacion\Reportes/RComprasProducto.rpt");

    }

}
