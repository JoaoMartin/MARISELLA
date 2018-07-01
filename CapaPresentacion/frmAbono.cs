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
    public partial class frmAbono : Form
    {
        public static frmAbono f1;
        public frmAbono()
        {
            InitializeComponent();
            frmAbono.f1 = this;
        }

        private void frmPagarCredito_Load(object sender, EventArgs e)
        {
            this.txtEfectivo.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmCreditosPendientes.f1.btnAbonar.Enabled = false;
            frmCreditosPendientes.f1.dataListado.ClearSelection();
        }
        public void mostrarTotales()
        {

            decimal total = Convert.ToDecimal(this.lblTotalPagar.Text);
            decimal tarjeta, dcto = 00.00m;
            decimal efectivo = 0;
            if (txtDcto.Text.Trim().Length == 0)
            {
                dcto = 00.00m;
            }
            else
            {
                dcto = Convert.ToDecimal(txtDcto.Text.Trim());
            }


            if (rbEfectivo.Checked)
            {
                if (this.txtEfectivo.Text.Trim().Length > 0)
                {
                    efectivo = Convert.ToDecimal(this.txtEfectivo.Text);
                    decimal vuelto = total - efectivo - dcto;
                    this.txtVuelto.Text = vuelto.ToString();
                }
                else
                {
                    this.txtVuelto.Text = string.Empty;
                }
            }
            else if (rbTarjeta.Checked)
            {
                if (this.txtTarjeta.Text.Trim().Length > 0)
                {
                    tarjeta = Convert.ToDecimal(this.txtTarjeta.Text);
                    decimal vuelto = total - tarjeta - dcto;
                    this.txtVuelto.Text = vuelto.ToString();
                }
            }
            else if (rbMixto.Checked)
            {
                if (this.txtEfectivo.Text.Trim().Length > 0 || this.txtTarjeta.Text.Trim().Length > 0)
                {
                    if (txtTarjeta.Text.Trim().Length <= 0)
                    {
                        tarjeta = 00.00m;
                    }
                    else
                    {
                        tarjeta = Convert.ToDecimal(this.txtTarjeta.Text);
                    }

                    if (txtEfectivo.Text.Trim().Length <= 0)
                    {
                        efectivo = 00.00m;
                    }
                    else
                    {
                        efectivo = Convert.ToDecimal(this.txtEfectivo.Text);
                    }


                    decimal vuelto = total - efectivo - tarjeta - dcto;
                    this.txtVuelto.Text = vuelto.ToString();
                }

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text = "10";

                mostrarTotales();
                this.txtEfectivo.Focus();

            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text = "20";

                mostrarTotales();
                this.txtEfectivo.Focus();

            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text = "50";

                mostrarTotales();
                this.txtEfectivo.Focus();

            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text = "100";

                mostrarTotales();
                this.txtEfectivo.Focus();

            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text = "200";

                mostrarTotales();
                this.txtEfectivo.Focus();

            }
        }

        private void txtEfectivo_KeyUp(object sender, KeyEventArgs e)
        {

            mostrarTotales();
        }

        private void rbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            txtTarjeta.ReadOnly = false;
            txtEfectivo.ReadOnly = true;
            txtEfectivo.Text = string.Empty;
            txtTarjeta.Text = string.Empty;
            txtVuelto.Text = string.Empty;
            txtTarjeta.Select();
        }

        private void rbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            txtTarjeta.ReadOnly = true;
            txtEfectivo.ReadOnly = false;
            txtEfectivo.Text = string.Empty;
            txtTarjeta.Text = string.Empty;
            txtVuelto.Text = string.Empty;
            txtEfectivo.Select();
        }

        private void rbMixto_CheckedChanged(object sender, EventArgs e)
        {
            txtEfectivo.ReadOnly = false;
            txtTarjeta.ReadOnly = false;
            txtEfectivo.Text = string.Empty;
            txtTarjeta.Text = string.Empty;
            txtVuelto.Text = string.Empty;
            txtEfectivo.Select();
        }

        private void txtTarjeta_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotales();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtVuelto.Text.Trim().Length > 0)
                {
                    decimal nSaldo = Convert.ToDecimal(txtVuelto.Text);
                    decimal efectivo = 00.00m, tarjeta = 00.00m, monto = 00.00m, dcto = 00.00m;
                    string formaPago = "";
                    if (nSaldo >= 0)
                    {
                        if (txtEfectivo.Text.Trim().Length > 0)
                        {
                            efectivo = Convert.ToDecimal(txtEfectivo.Text.Trim());
                        }
                        else
                        {
                            efectivo = 00.00m;
                        }

                        if (txtTarjeta.Text.Trim().Length > 0)
                        {
                            tarjeta = Convert.ToDecimal(txtTarjeta.Text.Trim());
                        }
                        else
                        {
                            tarjeta = 00.00m;
                        }

                        if (rbEfectivo.Checked == true)
                        {
                            formaPago = "EFECTIVO";
                            monto = Convert.ToDecimal(txtEfectivo.Text.Trim());
                        }
                        else if (rbTarjeta.Checked == true)
                        {
                            formaPago = "TARJETA";
                            monto = Convert.ToDecimal(txtTarjeta.Text.Trim());
                        }
                        else if (rbMixto.Checked == true)
                        {
                            formaPago = "MIXTO";
                            monto = Convert.ToDecimal(txtTarjeta.Text.Trim()) + Convert.ToDecimal(txtEfectivo.Text.Trim());
                        }

                        if (txtDcto.Text.Trim().Length > 0)
                        {
                            dcto = Convert.ToDecimal(txtDcto.Text.Trim());
                        }
                        else
                        {
                            dcto = 00.00m;
                        }

                        string rpta = "";
                        if (lblBandera.Text != "2")
                        {
                            rpta = NAbono.Insertar(DateTime.Now, monto, Convert.ToDecimal(txtVuelto.Text), Convert.ToInt32(lblIdVenta.Text),
                                                      Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), formaPago, efectivo, tarjeta, dcto);
                        }
                        else if (lblBandera.Text == "2")
                        {
                            rpta = NAbono.Insertar(DateTime.Now, monto, Convert.ToDecimal(lblUltimoSaldo.Text), Convert.ToInt32(lblIdVenta.Text),
                                                      Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), formaPago, efectivo, tarjeta, dcto);
                            decimal saldoUno = Convert.ToDecimal(txtVuelto.Text);
                            if(rpta == "OK")
                            {
                                rpta = NAbono.InsertarAbonoDetalle(Convert.ToInt32(lblIdDetalle.Text),Convert.ToDecimal(txtEfectivo.Text.Trim()));
                                if (rpta == "OK" && Convert.ToDecimal(txtVuelto.Text)==0)
                                {
                                    NDetalleVenta.EditarEstadoDetalle("DETALLE-PAGADO",Convert.ToInt32(lblIdDetalle.Text));
                                }
                            }
                        }else if(lblBandera.Text == "3")
                        {
                            rpta = NAbono.Insertar(DateTime.Now, monto, Convert.ToDecimal(txtVuelto.Text), Convert.ToInt32(lblIdVenta.Text),
                                                      Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), formaPago, efectivo, tarjeta, dcto);
                        }
                        else if (lblBandera.Text == "4")
                        {
                            rpta = NAbono.Insertar(DateTime.Now, monto, Convert.ToDecimal(txtVuelto.Text), Convert.ToInt32(lblIdVenta.Text),
                                                      Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), formaPago, efectivo, tarjeta, dcto);
                        }

                        if (rpta == "OK")
                        {
                            if (rbEfectivo.Checked == true)
                            {
                                rpta = NCaja.Insertar(Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "1", "INGRESO", efectivo, "ABONO", "EFECTIVO");
                            }
                            else if (rbTarjeta.Checked == true)
                            {
                                rpta = NCaja.Insertar(Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "1", "INGRESO", efectivo, "ABONO", "TARJETA");
                            }
                            else if (rbMixto.Checked == true)
                            {
                                rpta = NCaja.Insertar(Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "1", "INGRESO", efectivo, "ABONO", "TARJETA");
                                rpta = NCaja.Insertar(Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "1", "INGRESO", efectivo, "ABONO", "EFECTIVO");
                            }

                            if (rpta == "OK")
                            {
                                int nroDetalles = 0;
                                int filas = 0;
                                for (int i = 0; i < frmCreditosPendientes.f1.dataListado.SelectedRows.Count; i++)
                                {
                                    DataTable dtNroDetalle = NVenta.mostrarNroDetalle(Convert.ToInt32(frmCreditosPendientes.f1.dataListado.SelectedRows[i].Cells[0].Value));
                                    filas = dtNroDetalle.Rows.Count;
                                    for (int k = 0; k < dtNroDetalle.Rows.Count; k++)
                                    {
                                        if (k == 0)
                                        {
                                            nroDetalles = nroDetalles + 1;
                                        }
                                        else if (k != 0)
                                        {
                                            if (dtNroDetalle.Rows[k][0].ToString() == frmCreditosPendientes.f1.dataListado.SelectedRows[i].Cells[0].Value.ToString())
                                            {
                                                nroDetalles = nroDetalles + 1;
                                            }
                                        }

                                    }

                                    if(lblBandera.Text != "2" && lblBandera.Text !="3" && lblBandera.Text != "4")
                                    {
                                        if (filas == nroDetalles)
                                        {
                                            NVenta.EditarEstadoVentaCredito_Cortesia("CREDITO-PAGADO", Convert.ToInt32(frmCreditosPendientes.f1.dataListado.SelectedRows[i].Cells[0].Value));
                                        }
                                        nroDetalles = 0;
                                        NDetalleVenta.EditarEstadoDetalle("DETALLE-PAGADO", Convert.ToInt32(frmCreditosPendientes.f1.dataListado.SelectedRows[i].Cells[14].Value));
                                    }else if(lblBandera.Text == "2")
                                    {
 
                                        if(Convert.ToDecimal(txtVuelto.Text) == 0 && filas == nroDetalles)
                                        {
                                            NDetalleVenta.EditarEstadoDetalle("DETALLE-PAGADO",Convert.ToInt32(lblIdDetalle.Text));
                                            NVenta.EditarEstadoVentaCredito_Cortesia("CREDITO-PAGADO", Convert.ToInt32(frmCreditosPendientes.f1.dataListado.SelectedRows[i].Cells[0].Value));
                                        }else if (Convert.ToDecimal(txtVuelto.Text) == 0 && filas != nroDetalles)
                                        {
                                            NDetalleVenta.EditarEstadoDetalle("DETALLE-PAGADO", Convert.ToInt32(lblIdDetalle.Text));
                                        }


                                    }
                                   
                                }
                                this.Close();
                                // frmCreditosPendientes.f1.cbProducto.SelectedIndex = -1;
                                
                                frmCreditosPendientes.f1.Mostrar();
                                // frmCreditosPendientes.f1.Mostrar();
                            }
                        }


                    }
                    else if (nSaldo < 0)
                    {
                        MessageBox.Show("El monto abonado supera al saldo");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un monto a abonar");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        }

        private void btnDescuentoTotal_Click(object sender, EventArgs e)
        {
            frmDescuentoTotal frm = new frmDescuentoTotal();
            frm.lblIdBandera.Text = "3";
            frm.Show();
        }
    }
}
