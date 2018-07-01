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
    public partial class frmTransporte : Form
    {
        public frmTransporte()
        {
            InitializeComponent();
        }

        public void cargarTrabajador()
        {
            cbProducto.DataSource = NTrabajador.Mostrar();
            cbProducto.ValueMember = "Codigo";
            cbProducto.DisplayMember = "Nombre";
            cbProducto.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }
        public void cargarTrabajador1()
        {
            cbProducto.DataSource = NTrabajador.Mostrar();
            cbProducto.ValueMember = "Codigo";
            cbProducto.DisplayMember = "Nombre";
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }
        

        private void frmTransporte_Load(object sender, EventArgs e)
        {
            if(frmCompra.f1.lblBanderaFecha.Text == "0")
            {
                cargarTrabajador();
                totalPago();
            }else
            {
                totalPago();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formato(KeyPressEventArgs e, TextBox txtB)
        {
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

            for (int i = 0; i < txtB.Text.Length; i++)
            {
                if (txtB.Text[i] == '.')
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

        private void txtViatico_KeyPress(object sender, KeyPressEventArgs e)
        {
            formato(e, txtViatico);
        }

        private void txtPeaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            formato(e, txtPeaje);
        }

        private void txtCombustible_KeyPress(object sender, KeyPressEventArgs e)
        {
            formato(e, txtCombustible);
        }

        private void txtMantenimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            formato(e, txtMantenimiento);
        }

        private void txtOtrosGastos_KeyPress(object sender, KeyPressEventArgs e)
        {
            formato(e, txtOtrosGastos);
        }

        private void txtAdelanto_KeyPress(object sender, KeyPressEventArgs e)
        {
            formato(e, txtAdelanto);
        }

        private void totalPago()
        {
            decimal viaticos = 00.00m, peaje = 00.00m, combustible = 00.00m, mantenimiento = 00.00m, otrosGastos = 00.00m, total = 00.00m, flete = 00.00m;
            if (txtFlete.Text.Trim().Length == 0)
            {
                flete = 00.00m;
            }
            else
            {
                flete = Convert.ToDecimal(txtFlete.Text.Trim());
            }
            if (txtViatico.Text.Trim().Length == 0)
            {
                viaticos = 00.00m;
            }
            else
            {
                viaticos = Convert.ToDecimal(txtViatico.Text.Trim());
            }
            if (txtPeaje.Text.Trim().Length == 0)
            {
                peaje = 00.00m;
            }
            else
            {
                peaje = Convert.ToDecimal(txtPeaje.Text.Trim());
            }
            if (txtCombustible.Text.Trim().Length == 0)
            {
                combustible = 00.00m;
            }
            else
            {
                combustible = Convert.ToDecimal(txtCombustible.Text.Trim());
            }
            if (txtMantenimiento.Text.Trim().Length == 0)
            {
                mantenimiento = 00.00m;
            }
            else
            {
                mantenimiento = Convert.ToDecimal(txtMantenimiento.Text.Trim());
            }
            if (txtOtrosGastos.Text.Trim().Length == 0)
            {
                otrosGastos = 00.00m;
            }
            else
            {
                otrosGastos = Convert.ToDecimal(txtOtrosGastos.Text.Trim());
            }

            total = flete- viaticos - peaje - combustible - mantenimiento - otrosGastos;
            txtTotal.Text = total.ToString();

        }

        private void cbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFormaPago.SelectedIndex == 1)
            {
                lblAdelanto.Visible = true;
                lblSaldo.Visible = true;
                txtAdelanto.Visible = true;
                txtSaldo.Visible = true;
                txtSaldo.Text = txtTotal.Text;
            }
            else
            {
                lblAdelanto.Visible = false;
                lblSaldo.Visible = false;
                txtAdelanto.Visible = false;
                txtSaldo.Visible = false;
                txtAdelanto.Text = string.Empty;
                txtSaldo.Text = string.Empty;
            }
        }

        private void totalSaldo()
        {
            if (cbFormaPago.SelectedIndex == 1)
            {
                decimal total = Convert.ToDecimal(txtTotal.Text);
                decimal adelanto = 00.00m;
                if (txtAdelanto.Text.Trim().Length == 0)
                {
                    adelanto = 00.00m;
                }
                else
                {
                    adelanto = Convert.ToDecimal(txtAdelanto.Text.Trim());
                }

                decimal nuevoTotal = total - adelanto;
                txtSaldo.Text = nuevoTotal.ToString();
            }
        }
        private void txtViatico_KeyUp(object sender, KeyEventArgs e)
        {
            totalPago();
            totalSaldo();

        }

        private void txtPeaje_KeyUp(object sender, KeyEventArgs e)
        {
            totalPago();
            totalSaldo();
        }

        private void txtCombustible_KeyUp(object sender, KeyEventArgs e)
        {
            totalPago();
            totalSaldo();
        }

        private void txtMantenimiento_KeyUp(object sender, KeyEventArgs e)
        {
            totalPago();
            totalSaldo();
        }

        private void txtOtrosGastos_KeyUp(object sender, KeyEventArgs e)
        {
            totalPago();
            totalSaldo();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            decimal viaticos = 00.00m, peaje = 00.00m, combustible = 00.00m, mantenimiento = 00.00m, otrosGastos = 00.00m, adelanto = 00.00m, saldo = 00.00m, total = 00.00m;
            if (txtViatico.Text.Trim().Length == 0)
            {
                viaticos = 00.00m;
            }
            else
            {
                viaticos = Convert.ToDecimal(txtViatico.Text.Trim());
            }
            if (txtPeaje.Text.Trim().Length == 0)
            {
                peaje = 00.00m;
            }
            else
            {
                peaje = Convert.ToDecimal(txtPeaje.Text.Trim());
            }
            if (txtCombustible.Text.Trim().Length == 0)
            {
                combustible = 00.00m;
            }
            else
            {
                combustible = Convert.ToDecimal(txtCombustible.Text.Trim());
            }
            if (txtMantenimiento.Text.Trim().Length == 0)
            {
                mantenimiento = 00.00m;
            }
            else
            {
                mantenimiento = Convert.ToDecimal(txtMantenimiento.Text.Trim());
            }
            if (txtOtrosGastos.Text.Trim().Length == 0)
            {
                otrosGastos = 00.00m;
            }
            else
            {
                otrosGastos = Convert.ToDecimal(txtOtrosGastos.Text.Trim());
            }
            if (txtAdelanto.Text.Trim().Length == 0)
            {
                adelanto = 00.00m;
            }
            else
            {
                adelanto = Convert.ToDecimal(txtAdelanto.Text.Trim());
            }
            if (txtSaldo.Text.Trim().Length == 0)
            {
                saldo = 00.00m;
            }
            else
            {
                saldo = Convert.ToDecimal(txtSaldo.Text.Trim());
            }
            total = viaticos + peaje + combustible + mantenimiento + otrosGastos;

            string rpta = "", estado = "";
            int? idPersona = null;
            if (cbProducto.SelectedIndex == -1)
            {
                idPersona = null;
            }
            else
            {
                idPersona = Convert.ToInt32(cbProducto.SelectedValue.ToString());
            }

            if (cbFormaPago.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una forma de Pago");
            }
            else
            {
                string tipoMonto = "";
                if (cbFormaPago.SelectedIndex == 0)
                {
                    estado = "CANCELADO";
                    tipoMonto = "EFECTIVO";
                }
                else
                {
                    estado = "CREDITO-PENDIENTE";
                    tipoMonto = "EFECTIVO";
                }
                rpta = NTransporte.Insertar(idPersona, dtFechaSalida.Value, dtFechaLlegada.Value, viaticos, peaje, mantenimiento, combustible, otrosGastos, cbFormaPago.Text,
                    adelanto, saldo, estado,00.00m);
                if (rpta == "OK")
                {

                    if (adelanto > 0 && cbFormaPago.SelectedIndex == 1)
                    {
                        rpta = NCaja.Insertar(Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "2", "EGRESO", adelanto, "PAGO TRANSPORTE", tipoMonto);
                    }else if(adelanto<=0 && cbFormaPago.SelectedIndex == 0)
                    {
                        rpta = NCaja.Insertar(Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "2", "EGRESO", total, "PAGO TRANSPORTE", tipoMonto);
                    }
                    if (rpta == "OK")
                    {
                        MessageBox.Show("Se registró correctamente");
                        this.Close();
                    }
                }

            }


        }

        private void txtAdelanto_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTotal.Text.Trim().Length > 0 && txtAdelanto.Text.Trim().Length>0)
            {
                decimal total = Convert.ToDecimal(txtTotal.Text);
                decimal adelanto = Convert.ToDecimal(txtAdelanto.Text);
                decimal nuevoTotal = total - adelanto;
                txtSaldo.Text = nuevoTotal.ToString();
            }else
            {
                txtSaldo.Text = txtTotal.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal viaticos = 00.00m, peaje = 00.00m, combustible = 00.00m, mantenimiento = 00.00m, otrosGastos = 00.00m, adelanto = 00.00m, saldo = 00.00m, total = 00.00m, flete = 00.00m;
            if (txtFlete.Text.Trim().Length == 0)
            {
               flete = 00.00m;
            }
            else
            {
                flete = Convert.ToDecimal(txtFlete.Text.Trim());
            }
            if (txtViatico.Text.Trim().Length == 0)
            {
                viaticos = 00.00m;
            }
            else
            {
                viaticos = Convert.ToDecimal(txtViatico.Text.Trim());
            }
            if (txtPeaje.Text.Trim().Length == 0)
            {
                peaje = 00.00m;
            }
            else
            {
                peaje = Convert.ToDecimal(txtPeaje.Text.Trim());
            }
            if (txtCombustible.Text.Trim().Length == 0)
            {
                combustible = 00.00m;
            }
            else
            {
                combustible = Convert.ToDecimal(txtCombustible.Text.Trim());
            }
            if (txtMantenimiento.Text.Trim().Length == 0)
            {
                mantenimiento = 00.00m;
            }
            else
            {
                mantenimiento = Convert.ToDecimal(txtMantenimiento.Text.Trim());
            }
            if (txtOtrosGastos.Text.Trim().Length == 0)
            {
                otrosGastos = 00.00m;
            }
            else
            {
                otrosGastos = Convert.ToDecimal(txtOtrosGastos.Text.Trim());
            }
            if (txtAdelanto.Text.Trim().Length == 0)
            {
                adelanto = 00.00m;
            }
            else
            {
                adelanto = Convert.ToDecimal(txtAdelanto.Text.Trim());
            }
            if (txtSaldo.Text.Trim().Length == 0)
            {
                saldo = 00.00m;
            }
            else
            {
                saldo = Convert.ToDecimal(txtSaldo.Text.Trim());
            }

            total = flete- viaticos - peaje - combustible - mantenimiento - otrosGastos;

            string rpta = "", estado = "";
            int? idPersona = null;
            if (cbProducto.SelectedIndex == -1)
            {
                idPersona = null;
            }
            else
            {
                idPersona = Convert.ToInt32(cbProducto.SelectedValue.ToString());
            }

            if (cbFormaPago.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una forma de Pago");
            }
            else
            {
                string tipoMonto = "";
                if (cbFormaPago.SelectedIndex == 0)
                {
                    estado = "CANCELADO";
                    tipoMonto = "EFECTIVO";
                }
                else
                {
                    estado = "CREDITO-PENDIENTE";
                    tipoMonto = "EFECTIVO";
                }
                frmCompra.f1.lblViaticos.Text = viaticos.ToString();
                frmCompra.f1.lblPeaje.Text = peaje.ToString();
                frmCompra.f1.lblCombustible.Text = combustible.ToString();
                frmCompra.f1.lblMantenimiento.Text = mantenimiento.ToString();
                frmCompra.f1.lblOtroGastos.Text = otrosGastos.ToString();
                frmCompra.f1.lblTotalTransporte.Text = total.ToString();
                frmCompra.f1.lblFormaPagoTransporte.Text = cbFormaPago.Text;
                frmCompra.f1.lblFechaLLegada.Text = dtFechaLlegada.Value.ToShortDateString();
                frmCompra.f1.lblFechaSalida.Text = dtFechaSalida.Value.ToShortDateString();
                frmCompra.f1.lblAdelantoTransporte.Text = adelanto.ToString();
                frmCompra.f1.lblSaldoTransporte.Text = saldo.ToString();
                frmCompra.f1.lblIdPersonaTransporte.Text = idPersona.ToString();
                frmCompra.f1.lblBanderaFecha.Text = "1";
                frmCompra.f1.lblEstado.Text = estado;
                frmCompra.f1.lblTipoMonto.Text = tipoMonto;
                this.Close();

            }
        }
    }
}
