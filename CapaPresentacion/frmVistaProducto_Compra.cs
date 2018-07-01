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
    public partial class frmVistaProducto_Compra : Form
    {
        public frmVistaProducto_Compra()
        {
            InitializeComponent();
        }

        private void ocultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;

            //this.dataListado.Columns[].Visible = false;
            // this.dataListado.Columns[9].Visible = false;
            this.dataListado.Columns[10].Visible = false;
            this.dataListado.Columns[11].Visible = false;
            this.dataListado.Columns[12].Visible = false;
            this.dataListado.Columns[13].Visible = false;
            this.dataListado.Columns[14].Visible = false;
            this.dataListado.Columns[15].Visible = false;
            this.dataListado.Columns[16].Visible = false;
            //this.dataListado.Columns[17].Visible = false;

            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[1].Width = 70;
            this.dataListado.Columns[2].Width = 152;
            this.dataListado.Columns[3].Width = 299;
            this.dataListado.Columns[4].Width = 152;
            this.dataListado.Columns[5].Width = 90;
            this.dataListado.Columns[6].Width = 97;
            this.dataListado.Columns[7].Width = 97;
            this.dataListado.Columns[8].Width = 97;
            this.dataListado.Columns[9].Width = 97;
            // this.dataListado.Columns[7].Width = 120;

            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.DefaultCellStyle.Font = new Font("Roboto", 9);
            this.dataListado.RowsDefaultCellStyle.BackColor = Color.White;
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        public void Mostrar()
        {
            this.dataListado.DataSource = NProducto.Mostrar();

            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {
                this.dataListado.Visible = true;
                this.ocultarColumnas();
            }
        }

        private void BuscarCategoriaArticulo()
        {
            this.dataListado.DataSource = NProducto.BuscarCategoriaProducto(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarNombreArticulo()
        {
            this.dataListado.DataSource = NProducto.BuscarNombeProducto(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void frmVistaProducto_Compra_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.rbNombre.Checked = true;
            this.txtBuscar.Select();
            dataListado.ClearSelection();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (rbNombre.Checked)
            {
                this.BuscarNombreArticulo();
            }
            else
            {
                this.BuscarCategoriaArticulo();
            }
        }

        private void rbCategoria_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            txtBuscar.Select();
        }

        private void rbNombre_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            txtBuscar.Select();
        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            limpiar();
            lblProducto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            lblCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            lblUnidad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Unidad"].Value);
            txtPVMenor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["PVxMenor"].Value);
            txtPVMayor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["PVxMayor"].Value);
            txtPV3.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["PV_3"].Value);
            txtPV4.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["PV_4"].Value);
            txtPV5.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["PV_5"].Value);
            txtCantidad.Select();
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtPrecioCompra.Text.Length; i++)
            {
                if (txtPrecioCompra.Text[i] == '.')
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

        private void txtJabasVacias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
              
                e.Handled = true;
                return;
            }


        }

        private void mostrarImporte()
        {
            decimal importe;
            decimal cantidad, pesoJabaVacia;
            decimal precioCompra;
            if ((txtPesoJabaVacia.Text.Trim() != "" && txtCantidad.Text != "")  && txtPrecioCompra.Text.Trim() != "")
            {

                cantidad = Convert.ToDecimal(this.txtCantidad.Text);
                pesoJabaVacia = Convert.ToDecimal(this.txtPesoJabaVacia.Text);
                precioCompra = Convert.ToDecimal(this.txtPrecioCompra.Text);
                importe = (cantidad - pesoJabaVacia) * precioCompra;
                this.txtImporte.Text = importe.ToString();
            }
            if ((txtPesoJabaVacia.Text.Trim() == "" || txtCantidad.Text == "") || txtPrecioCompra.Text.Trim() == "")
            {
                txtImporte.Text = string.Empty;
            }


        }

        private void txtPrecioCompra_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarImporte();
        }

        private void txtJabasVacias_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void limpiar()
        {
            txtCantidad.Text = string.Empty;
            txtPrecioCompra.Text = string.Empty;
            txtImporte.Text = string.Empty;
            txtNroJabas.Text = string.Empty;
            txtCantJabas.Text = string.Empty;
            txtPVMenor.Text = string.Empty;
            txtPVMayor.Text = string.Empty;
            txtPV3.Text = string.Empty;
            txtPV4.Text = string.Empty;
            txtPesoJabaVacia.Text = string.Empty;
        }

        private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarImporte();
        }

        private void txtCantJabas_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtCantidad.Text.Length; i++)
            {
                if (txtCantidad.Text[i] == '.')
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

        private void button1_Click(object sender, EventArgs e)
        {
            int nroJabas = 0, cantXJabas = 0;
            decimal pvxMenor = 00.00m, pvxMayor = 00.00m, pv3 = 00.00m, pv4 = 00.00m, pesoJabaVacia = 00.00m, pv5 = 00.00m;
            if (lblCodigo.Text == "0")
            {
                MessageBox.Show("Seleccione un Producto");
                return;
            }
            if (txtCantidad.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese la cantidad");
                txtCantidad.Select();
                return;
            }
            else if (txtPrecioCompra.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese el costo unitario");
                txtPrecioCompra.Select();
                return;
            }
            else
            {

                if (txtNroJabas.Text.Trim().Length == 0)
                {
                    nroJabas = 0;
                }
                else
                {
                    nroJabas = Convert.ToInt32(txtNroJabas.Text.Trim());
                }

                if (txtCantJabas.Text.Trim().Length == 0)
                {
                    cantXJabas = 0;
                }
                else
                {
                    cantXJabas = Convert.ToInt32(txtCantJabas.Text.Trim());
                }

                if (txtPVMenor.Text.Trim().Length == 0)
                {
                    pvxMenor = 00.00m;
                }
                else
                {
                    pvxMenor = Convert.ToDecimal(txtPVMenor.Text.Trim());
                }

                if (txtPVMayor.Text.Trim().Length == 0)
                {
                    pvxMayor = 00.00m;
                }
                else
                {
                    pvxMayor = Convert.ToDecimal(txtPVMayor.Text.Trim());
                }

                if (txtPV3.Text.Trim().Length == 0)
                {
                    pv3 = 00.00m;
                }
                else
                {
                    pv3 = Convert.ToDecimal(txtPV3.Text.Trim());
                }
                if (txtPV4.Text.Trim().Length == 0)
                {
                    pv4 = 00.00m;
                }
                else
                {
                    pv4 = Convert.ToDecimal(txtPV4.Text.Trim());
                }

                if (txtPV5.Text.Trim().Length == 0)
                {
                    pv5 = 00.00m;
                }
                else
                {
                    pv5 = Convert.ToDecimal(txtPV5.Text.Trim());
                }

                if (txtPesoJabaVacia.Text.Trim().Length == 0)
                {
                    pesoJabaVacia = 00.00m;
                }
                else
                {
                    pesoJabaVacia = Convert.ToDecimal(txtPesoJabaVacia.Text.Trim());
                }
                if (btnGuardar.Text == "Guardar")
                {
                    
                    bool registrar = true;
                    foreach (DataRow row in frmCompra.f1.dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["Codigo"]) == Convert.ToInt32(lblCodigo.Text))
                        {
                            registrar = false;
                            MessageBox.Show("El producto ya está el la lista");
                        }
                    }

                    if (registrar)
                    {

                        DataRow row = frmCompra.f1.dtDetalle.NewRow();
                        row["Codigo"] = Convert.ToInt32(lblCodigo.Text);
                        row["Producto"] = lblProducto.Text;
                        row["Cantidad"] = Convert.ToDecimal(txtCantidad.Text.Trim());
                        row["CantxJaba"] = cantXJabas;
                        row["NroJabas"] = nroJabas;
                        row["Costo_Uni"] = Convert.ToDecimal(this.txtPrecioCompra.Text.Trim());
                        row["Importe"] = Convert.ToDecimal(this.txtImporte.Text.Trim());
                        row["Tipo"] = "P";
                        row["PVxMenor"] = pvxMenor;
                        row["PVxMayor"] = pvxMayor;
                        row["PV3"] = pv3;
                        row["Neto"] = Convert.ToDecimal(txtCantidad.Text.Trim()) - pesoJabaVacia;
                        row["PJabaVacia"] = pesoJabaVacia;
                        row["PV4"] = pv4;
                        row["PV5"] = pv5;
                        row["NroUnidades"] = nroJabas * cantXJabas;
                        if (lblProducto.Text == "POLLO MACHO" || lblProducto.Text == "POLLOS MACHOS" || lblProducto.Text == "MACHO" || lblProducto.Text == "POLLO M")
                        {
                            frmCompra.f1.txtNroJabasMacho.Text = nroJabas.ToString();
                            frmCompra.f1.txtCantPorJabaMacho.Text = cantXJabas.ToString();
                        }
                        else if (lblProducto.Text == "POLLO HEMBRA" || lblProducto.Text == "POLLOS HEMBRAS" || lblProducto.Text == "HEMBRA" || lblProducto.Text == "POLLO H")
                        {
                            frmCompra.f1.txtNroJabasHembra.Text = nroJabas.ToString();
                            frmCompra.f1.txtCantPorJabaHembra.Text = cantXJabas.ToString();
                        }
                        frmCompra.f1.dtDetalle.Rows.Add(row);

                        this.Close();
                        frmCompra.f1.dataListadoDetalle.ClearSelection();
                        frmCompra.f1.mostrarTotalesPollos();
                        frmCompra.f1.mostrarTotales();
                    }
                }
                else if (btnGuardar.Text == "Editar")
                {
                    frmCompra.f1.dataListadoDetalle[0, Convert.ToInt32(frmCompra.f1.lblPosic.Text)].Value = lblCodigo.Text;
                    frmCompra.f1.dataListadoDetalle[1, Convert.ToInt32(frmCompra.f1.lblPosic.Text)].Value = lblProducto.Text;
                    frmCompra.f1.dataListadoDetalle[2, Convert.ToInt32(frmCompra.f1.lblPosic.Text)].Value = txtCantidad.Text;
                    frmCompra.f1.dataListadoDetalle[3, Convert.ToInt32(frmCompra.f1.lblPosic.Text)].Value = Convert.ToDecimal(txtCantidad.Text.Trim()) - pesoJabaVacia;
                    frmCompra.f1.dataListadoDetalle[4, Convert.ToInt32(frmCompra.f1.lblPosic.Text)].Value = nroJabas.ToString();
                    frmCompra.f1.dataListadoDetalle[5, Convert.ToInt32(frmCompra.f1.lblPosic.Text)].Value = cantXJabas.ToString();
                    frmCompra.f1.dataListadoDetalle[6, Convert.ToInt32(frmCompra.f1.lblPosic.Text)].Value = pesoJabaVacia.ToString();
                    frmCompra.f1.dataListadoDetalle[7, Convert.ToInt32(frmCompra.f1.lblPosic.Text)].Value = txtPrecioCompra.Text;
                    frmCompra.f1.dataListadoDetalle[8, Convert.ToInt32(frmCompra.f1.lblPosic.Text)].Value = "P";
                    frmCompra.f1.dataListadoDetalle[9, Convert.ToInt32(frmCompra.f1.lblPosic.Text)].Value = pvxMenor.ToString();
                    frmCompra.f1.dataListadoDetalle[10, Convert.ToInt32(frmCompra.f1.lblPosic.Text)].Value = pvxMayor.ToString();
                    frmCompra.f1.dataListadoDetalle[11, Convert.ToInt32(frmCompra.f1.lblPosic.Text)].Value = pv3.ToString();
                    frmCompra.f1.dataListadoDetalle[12, Convert.ToInt32(frmCompra.f1.lblPosic.Text)].Value = pv4.ToString();
                    frmCompra.f1.dataListadoDetalle[13, Convert.ToInt32(frmCompra.f1.lblPosic.Text)].Value = pv5.ToString();
                    frmCompra.f1.dataListadoDetalle[14, Convert.ToInt32(frmCompra.f1.lblPosic.Text)].Value = txtImporte.Text;
                    frmCompra.f1.dataListadoDetalle[15, Convert.ToInt32(frmCompra.f1.lblPosic.Text)].Value = (nroJabas * cantXJabas).ToString();

                  
                    if (lblProducto.Text == "POLLO MACHO" || lblProducto.Text == "POLLOS MACHOS" || lblProducto.Text == "MACHO" || lblProducto.Text == "POLLO M")
                    {
                        frmCompra.f1.txtNroJabasMacho.Text = nroJabas.ToString();
                        frmCompra.f1.txtCantPorJabaMacho.Text = cantXJabas.ToString();
                    }
                    else if (lblProducto.Text == "POLLO HEMBRA" || lblProducto.Text == "POLLOS HEMBRAS" || lblProducto.Text == "HEMBRA" || lblProducto.Text == "POLLO H")
                    {
                        frmCompra.f1.txtNroJabasHembra.Text = nroJabas.ToString();
                        frmCompra.f1.txtCantPorJabaHembra.Text = cantXJabas.ToString();
                    }
                    this.Close();
                    frmCompra.f1.dataListadoDetalle.ClearSelection();
                    frmCompra.f1.mostrarTotalesPollos();
                    frmCompra.f1.mostrarTotales();
                    frmCompra.f1.btnEditar.Enabled = false;
                    frmCompra.f1.btnQuitar.Enabled = false;
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
            lblCodigo.Text = "0";
            dataListado.ClearSelection();
            txtBuscar.Clear();
            txtBuscar.Select();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            frmCompra.f1.dataListadoDetalle.ClearSelection();
            frmCompra.f1.btnQuitar.Enabled = false;
            frmCompra.f1.btnEditar.Enabled = false;
        }

        private void txtImporte_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtPesoJabaVacia_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtPesoJabaVacia.Text.Length; i++)
            {
                if (txtPesoJabaVacia.Text[i] == '.')
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

        private void txtPesoJabaVacia_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarImporte();
        }

        private void txtCantJabas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {

                e.Handled = true;
                return;
            }
        }
    }
}
