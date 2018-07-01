﻿using System;
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
    public partial class frmDescuentoTotal : Form
    {
        public frmDescuentoTotal()
        {
            InitializeComponent();
        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "1";
        }

        private void btnDos2_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += ".";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRetroceso_Click(object sender, EventArgs e)
        {
            if (this.txtNumero.Text.Length == 1)
            {
                this.txtNumero.Text = string.Empty;
            }
            else if (this.txtNumero.Text.Length != 0)
            {
                this.txtNumero.Text = this.txtNumero.Text.Substring(0, this.txtNumero.Text.Length - 1);
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar == (int)Keys.Enter && this.txtNumero.Text != string.Empty)
            {
                if (this.txtNumero.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Ingrese una cantidad");
                }
                else
                {
                    decimal totalVenta = 00.00m, totalPagado = 00.00m, precioVenta = 00.00m;
                    int cantidad = 0;

                    if (frmVenta.f1.txtDescuento.Text != "00.00")
                    {
                        decimal sumaTotal = 00.00m;
                        foreach (DataGridViewRow row in frmVenta.f1.dataListadoDetalle.Rows)
                        {
                            row.Cells[4].Value = 00.00m;
                            cantidad = Convert.ToInt32(row.Cells[2].Value);
                            precioVenta = Convert.ToInt32(row.Cells[3].Value);
                            row.Cells[5].Value = cantidad * precioVenta;
                            sumaTotal += cantidad * precioVenta;

                        }
                        frmVenta.f1.txtSubTotal.Text = sumaTotal.ToString();

                        frmVenta.f1.txtDescuento.Text = this.txtNumero.Text.Trim();
                        frmVenta.f1.txtTotalPagado.Text = (sumaTotal - Convert.ToDecimal(this.txtNumero.Text.Trim())).ToString();
                        frmVenta.f1.txtDescuento.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(this.txtNumero.Text));
                    }
                    else
                    {
                        totalVenta = Convert.ToDecimal(frmVenta.f1.txtSubTotal.Text);
                        totalPagado = totalVenta - Convert.ToDecimal(this.txtNumero.Text.Trim());

                        frmVenta.f1.txtDescuento.Text = this.txtNumero.Text.Trim();
                        frmVenta.f1.txtTotalPagado.Text = totalPagado.ToString();
                        frmVenta.f1.txtDescuento.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(this.txtNumero.Text));
                    }


                    this.Hide();
                }

            }

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            if (!(char.IsNumber(e.KeyChar)) && !(e.KeyChar == '.'))
            {
                e.Handled = true;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtNumero.Text.Length; i++)
            {
                if (txtNumero.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;


        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (this.txtNumero.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Ingrese una cantidad");
            }
            else
            {
                if (this.lblIdBandera.Text == "0")
                {

                    decimal subtotal, dctoInd, dctoGeneral, total, totalN, dctoAnt;

                    totalN = Convert.ToDecimal(frmPagar.f1.lblTotal.Text);
                    subtotal = Convert.ToDecimal(frmPagar.f1.lblSubTotal.Text);
                    dctoInd = Convert.ToDecimal(frmPagar.f1.lblDescuento.Text);
                    dctoAnt = Convert.ToDecimal(frmPagar.f1.lblDctoGeneral.Text);
                    dctoGeneral = Convert.ToDecimal(this.txtNumero.Text.Trim());
                    if (dctoGeneral == 0)
                    {
                        total = Convert.ToDecimal(frmPagar.f1.lblSubTotal.Text) + Convert.ToDecimal(frmPagar.f1.lblIgv.Text) - Convert.ToDecimal(frmPagar.f1.lblMontoAdelanto.Text)
                                + dctoAnt;
                    }
                    else
                    {
                        total = Convert.ToDecimal(frmPagar.f1.lblSubTotal.Text) + Convert.ToDecimal(frmPagar.f1.lblIgv.Text) + dctoAnt - dctoGeneral;
                    }


                    decimal totalSubTotalText = total / 1.18m;

                    //   frmPagar.f1.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalSubTotalText));
                    // decimal totalIgvText = total - totalSubTotalText;
                    //frmPagar.f1.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalIgvText));

                    frmPagar.f1.lblTotal.Text = total.ToString();
                    frmPagar.f1.lblDctoGeneral.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(this.txtNumero.Text));
                    frmPagar.f1.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalSubTotalText));
                    decimal igv = total - Convert.ToDecimal(frmPagar.f1.lblSubTotal.Text);
                    frmPagar.f1.lblIgv.Text = igv.ToString();
                    frmPagar.f1.mostrarTotales();
                    frmPagar.f1.MontosNuevosDescuento();
                    this.Close();
                    frmPagar.f1.dataListadoProducto.Select();

                }
                else if (this.lblIdBandera.Text == "1")
                {
                    decimal subtotal, dctoInd, dctoGeneral, total, dctoAnt;

                    subtotal = Convert.ToDecimal(frmPagarSeparada.f1.lblTotal.Text);
                    dctoInd = Convert.ToDecimal(frmPagarSeparada.f1.lblDescuento.Text);
                    dctoGeneral = Convert.ToDecimal(this.txtNumero.Text.Trim());
                    dctoAnt = Convert.ToDecimal(frmPagarSeparada.f1.lblDctoGeneral.Text);
                    if (dctoGeneral == 0)
                    {
                        total = Convert.ToDecimal(frmPagarSeparada.f1.lblSubTotal.Text) + Convert.ToDecimal(frmPagarSeparada.f1.lblIgv.Text) +
                           dctoAnt;
                    }
                    else
                    {
                        total = Convert.ToDecimal(frmPagarSeparada.f1.lblSubTotal.Text) + Convert.ToDecimal(frmPagarSeparada.f1.lblIgv.Text) + dctoAnt - dctoGeneral;
                    }


                    decimal totalSubTotalText = total / 1.18m;

                    // frmPagarSeparada.f1.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalSubTotalText));
                    //decimal totalIgvText = total - totalSubTotalText;
                    //frmPagarSeparada.f1.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalIgvText));

                    frmPagarSeparada.f1.lblTotal.Text = total.ToString();
                    frmPagarSeparada.f1.lblDctoGeneral.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(this.txtNumero.Text));
                    frmPagarSeparada.f1.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalSubTotalText));
                    decimal igv = total - Convert.ToDecimal(frmPagarSeparada.f1.lblSubTotal.Text);
                    frmPagarSeparada.f1.lblIgv.Text = igv.ToString();
                    frmPagarSeparada.f1.mostrarTotales();
                    this.Close();
                    frmPagarSeparada.f1.dataListadoProducto.Select();


                }
                else if (lblIdBandera.Text == "2")
                {

                    decimal subtotal, dctoInd, dctoGeneral, total, dctoAnt;

                    subtotal = Convert.ToDecimal(frmPagarDividida.f1.lblTotal.Text);
                    dctoInd = Convert.ToDecimal(frmPagarDividida.f1.lblDescuento.Text);
                    dctoGeneral = Convert.ToDecimal(this.txtNumero.Text.Trim());
                    dctoAnt = Convert.ToDecimal(frmPagarDividida.f1.lblDctoGeneral.Text);
                    if (dctoGeneral == 0)
                    {
                        total = Convert.ToDecimal(frmPagarDividida.f1.lblSubTotal.Text) + Convert.ToDecimal(frmPagarDividida.f1.lblIgv.Text) +
                                                      dctoAnt;
                    }
                    else
                    {
                        total = Convert.ToDecimal(frmPagarDividida.f1.lblSubTotal.Text) + Convert.ToDecimal(frmPagarDividida.f1.lblIgv.Text) + dctoAnt - dctoGeneral;
                    }


                    decimal totalSubTotalText = total / 1.18m;

                    // frmPagarDividida.f1.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalSubTotalText));
                    //decimal totalIgvText = total - totalSubTotalText;
                    //frmPagarDividida.f1.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalIgvText));

                    frmPagarDividida.f1.lblTotal.Text = total.ToString();
                    frmPagarDividida.f1.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalSubTotalText));
                    decimal igv = total - Convert.ToDecimal(frmPagarDividida.f1.lblSubTotal.Text);
                    frmPagarDividida.f1.lblIgv.Text = igv.ToString();
                    frmPagarDividida.f1.lblDctoGeneral.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(this.txtNumero.Text));
                    frmPagarDividida.f1.mostrarTotales();
                    this.Close();
                    frmPagarDividida.f1.dataListadoProducto.Select();

                }
                else if (lblIdBandera.Text == "3")
                {

                    decimal saldo = 00.00m, efectivo = 00.00m, tarjeta = 00.00m, nuevosaldo = 00.00m, dcto = 00.00m;

                    saldo = Convert.ToDecimal(frmAbono.f1.lblTotalPagar.Text);
                    if(frmAbono.f1.txtEfectivo.Text.Trim().Length > 0)
                    {
                        efectivo = Convert.ToDecimal(frmAbono.f1.txtEfectivo.Text);
                    }else
                    {
                        efectivo = 00.00m;
                    }

                    if (frmAbono.f1.txtTarjeta.Text.Trim().Length > 0)
                    {
                        tarjeta = Convert.ToDecimal(frmAbono.f1.txtTarjeta.Text);
                    }
                    else
                    {
                        tarjeta = 00.00m;
                    }

                    if(txtNumero.Text.Trim().Length > 0)
                    {
                        dcto = Convert.ToDecimal(txtNumero.Text.Trim());
                    }else
                    {
                        dcto = 00.00m;
                    }

                    nuevosaldo = saldo - efectivo - tarjeta - dcto;
                    this.Close();
                    frmAbono.f1.txtDcto.Text = dcto.ToString();
                    frmAbono.f1.txtVuelto.Text = nuevosaldo.ToString();

                }
                else if (lblIdBandera.Text == "4")
                {

                    decimal saldo = 00.00m, efectivo = 00.00m, tarjeta = 00.00m, nuevosaldo = 00.00m, dcto = 00.00m;

                    saldo = Convert.ToDecimal(frmAbonoCompra.f1.lblTotalPagar.Text);
                    if (frmAbonoCompra.f1.txtEfectivo.Text.Trim().Length > 0)
                    {
                        efectivo = Convert.ToDecimal(frmAbonoCompra.f1.txtEfectivo.Text);
                    }
                    else
                    {
                        efectivo = 00.00m;
                    }

                  

                    if (txtNumero.Text.Trim().Length > 0)
                    {
                        dcto = Convert.ToDecimal(txtNumero.Text.Trim());
                    }
                    else
                    {
                        dcto = 00.00m;
                    }

                    nuevosaldo = saldo - efectivo - tarjeta - dcto;
                    this.Close();
                    frmAbonoCompra.f1.txtDcto.Text = dcto.ToString();
                    frmAbonoCompra.f1.txtVuelto.Text = nuevosaldo.ToString();

                }



            }
        }

        private void frmDescuentoTotal_Load(object sender, EventArgs e)
        {

        }
    }
}
