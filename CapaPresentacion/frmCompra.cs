using CapaNegocios;
using System;
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
    public partial class frmCompra : Form
    {
        public int idUsuario;
        private bool isNuevo;
        public DataTable dtDetalle;
        private decimal subTotal = 0;
        private decimal totalIgv = 0;
        private decimal totalPagado = 0;
        private decimal totalSubTotal = 0;
        public static frmCompra f1;

        private static frmCompra _instancia;

        public static frmCompra GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new frmCompra();
            }
            return _instancia;

        }

        public void setProveedor(string idProveedor, string razonSocial, string direccion)
        {
            this.txtIdProveedor.Text = idProveedor;
            this.txtProveedor.Text = razonSocial;
            this.txtDireccion.Text = direccion;
        }

        public void setProducto(string idProducto, string nombreProducto, string precioVenta)
        {
            this.txtIdArticulo.Text = idProducto;
            this.txtProducto.Text = nombreProducto;
            this.txtPrecioVenta.Text = precioVenta;
        }



        public frmCompra()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtProveedor, "Seleccione el proveedor");
            this.ttMensaje.SetToolTip(this.txtSerie, "Ingrese la serie del comprobante");
            this.ttMensaje.SetToolTip(this.txtCorrelativo, "Seleccione el número del comprobante");
            this.ttMensaje.SetToolTip(this.txtProducto, "Seleccione el Producto de compra");
            this.txtIdProveedor.ReadOnly = true;

            frmCompra.f1 = this;

        }

        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar
        private void Limpiar()
        {
            this.txtIdProveedor.Text = string.Empty;
            this.txtProveedor.Text = string.Empty;
            this.txtSerie.Text = string.Empty;
            this.txtCorrelativo.Text = string.Empty;
            this.txtAdelanto.Text = string.Empty;
            this.txtDcto.Text = string.Empty;
            this.txtNroTotalJabas.Text = string.Empty;
            this.txtNroTotalPollos.Text = string.Empty;
            this.txtTotalPagado.Text = "00.00";
            this.txtSubTotal.Text = "00.00";
            this.txtIgv.Text = "00.00";
            this.txtPesoBruto.Text = "00.00";
            this.txtPesoJabasVacias.Text = "00.00";
            this.txtPesoNetoPollosVivos.Text = "00.00";
            this.txtDireccion.Text = string.Empty;
            this.txtMerma.Text = string.Empty;
            this.txtMermaTotal.Text = string.Empty;
            this.cbTipoComprobante.SelectedIndex = -1;
            this.cbMoneda.SelectedIndex = -1;
            this.cbFormaPago.SelectedIndex = -1;
            this.lblAdelantoTransporte.Text = "00.00";
            this.lblViaticos.Text = "00.00";
            this.lblFlete.Text = "00.00";
            this.lblCombustible.Text = "00.00";
            this.lblMantenimiento.Text = "00.00";
            this.lblOtroGastos.Text = "00.00";
            this.lblPeaje.Text = "00.00";
            this.lblComisiones.Text = "00.00";
            this.lblGastosCarga.Text = "00.00";
            this.lblLavadoJaba.Text = "00.00";
            this.crearTabla();

        }

        private void limpiarDetalle()
        {
            this.txtIdArticulo.Text = string.Empty;
            this.txtProducto.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
            this.txtUnidad.Text = string.Empty;
            this.txtImporte.Text = string.Empty;
        }

        //Habilitar Controles
        private void Habilitar(bool valor)
        {
            this.txtSerie.Enabled = valor;
            this.txtCorrelativo.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.cbTipoComprobante.Enabled = valor;
            this.txtPrecioVenta.ReadOnly = !valor;
            this.txtImporte.ReadOnly = !valor;
            cbCaja.Enabled = valor;

            this.btnBuscarArticulo.Enabled = valor;
            this.btnVistaInsumo.Enabled = valor;
            this.btnBuscarProveedor.Enabled = valor;
            this.btnGastos.Enabled = valor;
            this.btnQuitar.Enabled = !valor;
            this.btnTransporte.Enabled = valor;

            this.errorIcono.Clear();
        }

        //Habilitar Botones
        private void Botones()
        {
            if (this.isNuevo)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;

                // this.rbPlato.Checked = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }


        private void crearTabla()
        {

            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("Codigo", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Producto", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Cantidad", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Neto", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("NroJabas", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("CantxJaba", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("PJabaVacia", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Costo_Uni", System.Type.GetType("System.Decimal"));

            this.dtDetalle.Columns.Add("Tipo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("PVxMenor", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("PVxMayor", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("PV3", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("PV4", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("PV5", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Importe", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("NroUnidades", System.Type.GetType("System.Decimal"));

            this.dataListadoDetalle.DataSource = this.dtDetalle;
        }


        private void formatoTabla()
        {
            this.dataListadoDetalle.Columns[0].Visible = false;
            this.dataListadoDetalle.Columns[8].Visible = false;
            this.dataListadoDetalle.Columns[15].Visible = false;
            // DataGridView1.Columns(1).Width = 150
            this.dataListadoDetalle.Columns[1].Width = 150;
            this.dataListadoDetalle.Columns[2].Width = 100;
            this.dataListadoDetalle.Columns[3].Width = 100;
            this.dataListadoDetalle.Columns[4].Width = 80;
            this.dataListadoDetalle.Columns[5].Width = 80;
            this.dataListadoDetalle.Columns[6].Width = 80;
            this.dataListadoDetalle.Columns[7].Width = 80;
            this.dataListadoDetalle.Columns[9].Width = 80;
            this.dataListadoDetalle.Columns[10].Width = 80;
            this.dataListadoDetalle.Columns[11].Width = 80;
            this.dataListadoDetalle.Columns[12].Width = 80;
            this.dataListadoDetalle.Columns[13].Width = 90;


            this.dataListadoDetalle.ClearSelection();
            this.dataListadoDetalle.ColumnHeadersDefaultCellStyle.Font = new Font(dataListadoDetalle.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListadoDetalle.GridColor = SystemColors.ActiveBorder;
            this.dataListadoDetalle.Font = new Font("Roboto", 8);
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.isNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtProveedor.Focus();
            this.limpiarDetalle();
            this.lblBander.Text = "1";
            this.cbTipoComprobante.SelectedIndex = 0;
            this.cbFormaPago.SelectedIndex = 0;
            this.cbMoneda.SelectedIndex = 0;
        }

        private void frmIngresoAlmacen_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Habilitar(false);
            this.Botones();

            this.crearTabla();
            this.formatoTabla();
            this.btnQuitar.Enabled = false;
        }

        private void frmIngresoAlmacen_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            frmVistaProveedorIngreso vistaProveedor = new frmVistaProveedorIngreso();
            vistaProveedor.lblPrueba.Text = "0";
            vistaProveedor.ShowDialog();
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            frmVistaProducto_Compra frm = new frmVistaProducto_Compra();
            frm.Show();
            frm.dataListado.ClearSelection();
            frm.txtBuscar.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.isNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.limpiarDetalle();
            this.lblBander.Text = "0";
            this.cbTipoComprobante.SelectedIndex = -1;
            limpiarDetalleHembra();
            limpiarDetalleMacho();
            mostrarTotalesPollos();
        }

        public void mostrarTotales()
        {
            if (dataListadoDetalle.Rows.Count > 0)
            {
                decimal subtotalM, igv, total = 00.00m, promCosto = 00.00m, costo = 00.00m;
                for (int i = 0; i < dataListadoDetalle.Rows.Count; i++)
                {
                    costo = costo + Convert.ToDecimal(this.dataListadoDetalle.Rows[i].Cells[7].Value.ToString());
                }
                promCosto = costo / dataListadoDetalle.Rows.Count;
                total = Convert.ToDecimal(txtPesoNetoPollosVivos.Text) * promCosto;

                subtotalM = total / 1.18m;
                this.txtSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(subtotalM));
                decimal subtotal1 = Convert.ToDecimal(txtSubTotal.Text);
                igv = total - subtotal1;
                txtIgv.Text = igv.ToString();

                txtTotalPagado.Text = total.ToString();
                mostrarDcto();

            }
            else
            {
                txtSubTotal.Text = "00.00";
                txtIgv.Text = "00.00";
                txtTotalPagado.Text = "00.00";
            }

        }



        public void mostrarTotalesPollos()
        {
            decimal pesoBruto = 00.00m, pesoJabasVacias = 00.00m, pesoBrutoMacho = 00.00m, pesoBrutoHembra = 00.00m, pesoTaraMacho = 00.00m, pesoTaraHembra = 00.00m,
                    pesoNetoMacho = 00.00m, pesoNetoHembra = 00.00m, unidadMacho = 00.00m, unidadHembra = 00.00m, merma = 00.00m;
            int nroJabasMacho = 0, nroJabasHembra = 0, cantPorJabaMacho = 0, cantPorJabaHembra = 0;
            for (int i = 0; i < dataListadoDetalle.Rows.Count; i++)
            {
                pesoBruto = pesoBruto + Convert.ToDecimal(this.dataListadoDetalle.Rows[i].Cells[2].Value.ToString());
                pesoJabasVacias = pesoJabasVacias + Convert.ToDecimal(this.dataListadoDetalle.Rows[i].Cells[6].Value.ToString());
                if (dataListadoDetalle.Rows[i].Cells[1].Value.ToString() == "POLLO MACHO" || dataListadoDetalle.Rows[i].Cells[1].Value.ToString() == "POLLOS MACHOS" ||
                        dataListadoDetalle.Rows[i].Cells[1].Value.ToString() == "MACHO" || dataListadoDetalle.Rows[i].Cells[1].Value.ToString() == "POLLO M")
                {
                    pesoBrutoMacho = pesoBrutoMacho + Convert.ToDecimal(this.dataListadoDetalle.Rows[i].Cells[2].Value.ToString());
                    pesoTaraMacho = pesoTaraMacho + Convert.ToDecimal(this.dataListadoDetalle.Rows[i].Cells[6].Value.ToString());
                }
                else if (dataListadoDetalle.Rows[i].Cells[1].Value.ToString() == "POLLO HEMBRA" || dataListadoDetalle.Rows[i].Cells[1].Value.ToString() == "POLLOS HEMBRAS" ||
                     dataListadoDetalle.Rows[i].Cells[1].Value.ToString() == "HEMBRA" || dataListadoDetalle.Rows[i].Cells[1].Value.ToString() == "POLLO H")
                {
                    pesoBrutoHembra = pesoBrutoHembra + Convert.ToDecimal(this.dataListadoDetalle.Rows[i].Cells[2].Value.ToString());
                    pesoTaraHembra = pesoTaraHembra + Convert.ToDecimal(this.dataListadoDetalle.Rows[i].Cells[6].Value.ToString());
                }

            }
            //MACHO
            if (txtNroJabasMacho.Text.Trim().Length == 0)
            {
                nroJabasMacho = 0;
            }
            else
            {
                nroJabasMacho = Convert.ToInt32(txtNroJabasMacho.Text.Trim());
            }
            if (txtCantPorJabaMacho.Text.Trim().Length == 0)
            {
                cantPorJabaMacho = 0;
            }
            else
            {
                cantPorJabaMacho = Convert.ToInt32(txtCantPorJabaMacho.Text);
            }
            //HEMBRA
            if (txtNroJabasHembra.Text.Trim().Length == 0)
            {
                nroJabasHembra = 0;
            }
            else
            {
                nroJabasHembra = Convert.ToInt32(txtNroJabasHembra.Text.Trim());
            }
            if (txtCantPorJabaHembra.Text.Trim().Length == 0)
            {
                cantPorJabaHembra = 0;
            }
            else
            {
                cantPorJabaHembra = Convert.ToInt32(txtCantPorJabaHembra.Text);
            }

            if(txtMerma.Text.Trim().Length == 0)
            {
                merma = 00.00m;
            }else
            {
                merma = Convert.ToDecimal(txtMerma.Text.Trim());
            }

            pesoNetoMacho = pesoBrutoMacho - pesoTaraMacho;
            pesoNetoHembra = pesoBrutoHembra - pesoTaraHembra;
            unidadMacho = cantPorJabaMacho * nroJabasMacho;
            unidadHembra = cantPorJabaHembra * nroJabasHembra;


            this.txtNroJabasMacho.Text = nroJabasMacho.ToString();
            this.txtNroJabasHembra.Text = nroJabasHembra.ToString();
            this.txtCantPorJabaMacho.Text = cantPorJabaMacho.ToString();
            this.txtCantPorJabaHembra.Text = cantPorJabaHembra.ToString();
            this.txtPesoBrutoMacho.Text = pesoBrutoMacho.ToString("#0.00#");
            this.txtPesoBrutoHembra.Text = pesoBrutoHembra.ToString("#0.00#");
            this.txtPesoTaraMacho.Text = pesoTaraMacho.ToString("#0.00#");
            this.txtPesoTaraHembra.Text = pesoTaraHembra.ToString("#0.00#");
            this.txtUnidadPolloMacho.Text = (unidadMacho).ToString("#0.00#");
            this.txtUnidadPolloHembra.Text = (unidadHembra).ToString("#0.00#");
            this.txtPesoNetoMacho.Text = (pesoNetoMacho).ToString("#0.00#");
            this.txtPesoNetoHembra.Text = (pesoNetoHembra).ToString("#0.00#");

            if (unidadMacho <= 0)
            {
                txtPromedioMacho.Text = "00.00";
            }
            else
            {
                decimal promedio = (pesoBrutoMacho - pesoTaraMacho) / unidadMacho;

                this.txtPromedioMacho.Text = (Math.Round(promedio, 2)).ToString("#0.00#");
            }

            if (unidadHembra <= 0)
            {
                txtPromedioHembra.Text = "00.00";
            }
            else
            {
                decimal promedioH = (pesoBrutoHembra - pesoTaraHembra) / unidadHembra;
                this.txtPromedioHembra.Text = (Math.Round(promedioH, 2)).ToString("#0.00#");
            }

            this.txtNroTotalPollos.Text = ((cantPorJabaHembra * nroJabasHembra) + (cantPorJabaMacho * nroJabasMacho)).ToString("#0.00#");
            this.txtNroTotalJabas.Text = (nroJabasMacho + nroJabasHembra).ToString("#0.00#");
            this.txtPesoBruto.Text = pesoBruto.ToString("#0.00#");
            this.txtPesoJabasVacias.Text = pesoJabasVacias.ToString("#0.00#");
            this.txtPesoNetoPollosVivos.Text = (pesoBruto - pesoJabasVacias -merma).ToString("#0.00#");
            this.lblFlete.Text = Convert.ToString((Convert.ToDecimal(txtNroJabasHembra.Text) + Convert.ToDecimal(txtNroJabasMacho.Text)) * 12);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.dataListadoDetalle.Rows.Count == 0)
            {
                MensajeError("No hay productos en la lista");
            }
            else
            {
                try
                {
                    string rpta = "";
                    string igv = "";
                    string formaPago = "";
                    string estado = "";
                    decimal adelanto = 00.00m, dcto = 00.00m, saldo = 00.00m, merma = 00.00m;

                    if (this.txtIdProveedor.Text == string.Empty)
                    {
                        MensajeError("Seleccione un proveedor");
                        errorIcono.SetError(txtProveedor, "Seleccione un valor");
                    }

                    else if (this.txtCorrelativo.Text.Trim() == string.Empty)
                    {
                        MensajeError("Ingrese el número documento");
                        errorIcono.SetError(txtCorrelativo, "Ingrese un valor");
                    }

                    else if (this.txtIgv.Text.Trim() == string.Empty && this.cbTipoComprobante.SelectedItem.ToString().Equals("FACTURA"))
                    {
                        MensajeError("Ingrese el IGV");
                        errorIcono.SetError(txtIgv, "Ingrese un valor");

                    }

                    else
                    {

                        if (this.isNuevo)
                        {
                            if (this.cbTipoComprobante.SelectedItem.ToString().Equals("FACTURA"))
                            {
                                igv = this.txtIgv.Text.Trim();
                            }
                            else if (!this.cbTipoComprobante.SelectedItem.ToString().Equals("FACTURA"))
                            {
                                igv = "00.00";
                            }
                            if (cbFormaPago.SelectedIndex == 0)
                            {
                                formaPago = "CREDITO";
                                estado = "CREDITO-PENDIENTE";
                            }
                            else if (cbFormaPago.SelectedIndex == 1)
                            {
                                formaPago = "EFECTIVO";
                                estado = "CANCELADO";
                            }

                            if (txtAdelanto.Text.Trim().Length == 0)
                            {
                                adelanto = 00.00m;
                            }
                            else
                            {
                                adelanto = Convert.ToDecimal(txtAdelanto.Text.Trim());
                            }

                            if (txtDcto.Text.Trim().Length == 0)
                            {
                                dcto = 00.00m;
                            }
                            else
                            {
                                dcto = Convert.ToDecimal(txtDcto.Text.Trim());
                            }
                            int? idPersona = null;
                            DateTime FechaLlegada, FechaSalida;
                            if (lblIdPersonaTransporte.Text == "0" || lblIdPersonaTransporte.Text == "")
                            {
                                idPersona = null;
                            }
                            else
                            {
                                idPersona = Convert.ToInt32(lblIdPersonaTransporte.Text);
                            }

                            if (lblFechaLLegada.Text == "0")
                            {
                                FechaLlegada = DateTime.MinValue;
                            }
                            else
                            {
                                FechaLlegada = Convert.ToDateTime(lblFechaLLegada.Text);
                            }

                            if (lblFechaSalida.Text == "0")
                            {
                                FechaSalida = DateTime.MinValue;
                            }
                            else
                            {
                                FechaSalida = Convert.ToDateTime(lblFechaSalida.Text);
                            }
                            if(txtMerma.Text.Trim().Length == 0)
                            {
                                merma = 00.00m;
                            }else
                            {
                                merma = Convert.ToDecimal(txtMerma.Text.Trim());
                            }

                            saldo = Convert.ToDecimal(txtTotalPagado.Text) - dcto - adelanto;
                            rpta = NCompra.Insertar1(Convert.ToInt32(this.lblIdUsuario.Text), Convert.ToInt32(this.txtIdProveedor.Text), dtFecha.Value, cbTipoComprobante.Text,
                                 this.txtSerie.Text, this.txtCorrelativo.Text, Convert.ToDecimal(igv), formaPago, "SOLES", estado, Convert.ToDecimal(this.txtTotalPagado.Text),
                                 dtDetalle, adelanto, dcto, Convert.ToDecimal(lblFlete.Text), Convert.ToDecimal(lblComisiones.Text), Convert.ToDecimal(lblLavadoJaba.Text),
                                 Convert.ToDecimal(lblGastosCarga.Text), saldo, idPersona, FechaSalida, FechaLlegada, Convert.ToDecimal(lblViaticos.Text), Convert.ToDecimal(lblPeaje.Text),
                                 Convert.ToDecimal(lblCombustible.Text), Convert.ToDecimal(lblMantenimiento.Text), Convert.ToDecimal(lblOtroGastos.Text), lblFormaPagoTransporte.Text,
                           Convert.ToDecimal(lblAdelantoTransporte.Text),Convert.ToDecimal(lblSaldoTransporte.Text), estado,merma);
                            if (rpta == "OK")
                            {



                                if (Convert.ToDecimal(lblAdelantoTransporte.Text) > 0 && lblFormaPagoTransporte.Text == "CREDITO")
                                {
                                    rpta = NCaja.Insertar(Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "2", "EGRESO", Convert.ToDecimal(lblAdelantoTransporte.Text), "PAGO TRANSPORTE", lblTipoMonto.Text);
                                }
                                else if (adelanto <= 0 && cbFormaPago.SelectedIndex == 0)
                                {
                                    rpta = NCaja.Insertar(Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "2", "EGRESO", Convert.ToDecimal(lblTotalTransporte.Text), "PAGO TRANSPORTE", lblTipoMonto.Text);
                                }


                            }
                        }
                        if (rpta.Equals("OK"))
                        {
                            if (this.isNuevo)
                            {


                                if (txtAdelanto.Text.Trim().Length == 0)
                                {
                                    adelanto = 00.00m;
                                }
                                else
                                {
                                    adelanto = Convert.ToDecimal(txtAdelanto.Text.Trim());
                                }

                                if (cbCaja.Checked == true && formaPago == "EFECTIVO")
                                {
                                    rpta = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "1", "EGRESO", Convert.ToDecimal(this.txtTotalPagado.Text), "COMPRA", "EFECTIVO");

                                }
                                else if (cbCaja.Checked == true && formaPago == "CREDITO" && txtAdelanto.Text.Trim().Length > 0)
                                {
                                    rpta = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "1", "EGRESO", adelanto, "COMPRA", "EFECTIVO");
                                }
                                else if (cbCaja.Checked == true && formaPago == "CREDITO" && txtAdelanto.Text.Trim().Length == 0)
                                {

                                }

                                this.MensajeOK("Se insertó correctamente");
                            }
                        }
                        else
                        {
                            this.MensajeError(rpta);
                        }

                        this.isNuevo = false;
                        this.Botones();
                        this.Limpiar();
                        this.limpiarDetalle();
                        this.limpiarDetalleHembra();
                        this.limpiarDetalleMacho();
                        this.btnQuitar.Enabled = false;
                        subTotal = 0;
                        totalPagado = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataListadoDetalle.Rows.Count <= 0)
                {
                    MensajeError("No existen filas en la tabla");
                }
                else if (this.dataListadoDetalle.SelectedRows.Count > 0)
                {
                    int indiceFila = this.dataListadoDetalle.CurrentRow.Index;
                    DataRow row = this.dtDetalle.Rows[indiceFila];
                    /*
                                        this.totalPagado = this.totalPagado - Convert.ToDecimal(row["Importe"].ToString());

                                        this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");

                                        if (this.cbTipoComprobante.SelectedItem.ToString().Equals("FACTURA"))
                                        {
                                            totalSubTotal = totalPagado / 1.18m;

                                            //txtSubTotal.Text = totalSubTotal.ToString("#0.00#");
                                            txtSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalSubTotal));
                                            totalIgv = totalPagado - totalSubTotal;

                                            txtIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalIgv));
                                        }
                                        else
                                        {
                                            this.txtSubTotal.Text = this.txtTotalPagado.Text;
                                        }
                                        */

                    if (lblProducto.Text == "POLLO MACHO" || lblProducto.Text == "POLLOS MACHOS" || lblProducto.Text == "MACHO" || lblProducto.Text == "POLLO M")
                    {
                        limpiarDetalleMacho();

                    }
                    else if (lblProducto.Text == "POLLO HEMBRA" || lblProducto.Text == "POLLOS HEMBRAS" || lblProducto.Text == "HEMBRA" || lblProducto.Text == "POLLO H")
                    {
                        limpiarDetalleHembra();

                    }

                    this.dtDetalle.Rows.Remove(row);
                    mostrarTotales();
                    mostrarTotalesPollos();
                    this.dataListadoDetalle.ClearSelection();
                    btnQuitar.Enabled = false;
                    btnEditar.Enabled = false;
                }
                else
                {
                    MensajeError("Seleccione una fila");
                }


            }
            catch (Exception ex)
            {
                MensajeError("No hay filas para remover");
            }
        }

        public void limpiarDetalleHembra()
        {
            txtNroJabasHembra.Text = string.Empty;
            txtCantPorJabaHembra.Text = string.Empty;
            txtUnidadPolloHembra.Text = string.Empty;
            txtPesoBrutoHembra.Text = string.Empty;
            txtPesoTaraHembra.Text = string.Empty;
            txtPesoNetoHembra.Text = string.Empty;
            txtPromedioHembra.Text = string.Empty;

        }

        public void limpiarDetalleMacho()
        {
            txtNroJabasMacho.Text = string.Empty;
            txtCantPorJabaMacho.Text = string.Empty;
            txtUnidadPolloMacho.Text = string.Empty;
            txtPesoBrutoMacho.Text = string.Empty;
            txtPesoTaraMacho.Text = string.Empty;
            txtPesoNetoMacho.Text = string.Empty;
            txtPromedioMacho.Text = string.Empty;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataListadoDetalle_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            bool registrar = true;
            if (registrar)
            {
                frmVistaProducto_Compra frm = new frmVistaProducto_Compra();
                frm.btnGuardar.Text = "Editar";
                frm.btnLimpiar.Enabled = false;
                this.lblPosic.Text = dataListadoDetalle.CurrentRow.Index.ToString();
                frm.lblCodigo.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells[0].Value);
                frm.lblProducto.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells[1].Value);
                frm.txtCantidad.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells[2].Value);
                frm.lblNeto.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells[4].Value);
                frm.txtNroJabas.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells[4].Value);
                frm.txtCantJabas.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells[5].Value);
                frm.txtPesoJabaVacia.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells[6].Value);
                frm.txtPrecioCompra.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells[7].Value);
                // frm.txtCantidad.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells[7].Value);
                frm.txtPVMenor.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells[9].Value);
                frm.txtPVMayor.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells[10].Value);
                frm.txtPV3.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells[11].Value);
                frm.txtPV4.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells[12].Value);
                frm.txtPV5.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells[13].Value);
                frm.txtImporte.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells[14].Value);
                frm.dataListado.Enabled = false;
                frm.txtBuscar.ReadOnly = true;
                frm.Show();



            }

        }

        private void cbTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoComprobante.SelectedIndex == 1)
            {
                if (this.txtTotalPagado.Text != string.Empty)
                {
                    decimal totalText = Convert.ToDecimal(this.txtTotalPagado.Text);
                    decimal totalSubTotalText = totalText / 1.18m;
                    //this.redondear(totalSubTotal);

                    //txtSubTotal.Text = totalSubTotal.ToString("#0.00#");
                    txtSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalSubTotalText));
                    decimal totalIgvText = totalText - totalSubTotalText;

                    txtIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalIgvText));
                }

            }
            else
            {

                string totalText1 = this.txtTotalPagado.Text;
                this.txtIgv.Text = "00.00";
                this.txtSubTotal.Text = totalText1;
            }
        }

        private void txtIgv_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtPrecioVenta.Text.Length; i++)
            {
                if (txtPrecioVenta.Text[i] == '.')
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

        }

        private void txtPrecioCompra_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void cbCaja_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCaja.Checked == true)
            {
                if (frmPrincipal.f1.lblEstadoCaja.Text == "0")
                {
                    MessageBox.Show("Aperture la caja antes de realizar esta operación");
                    btnGuardar.Enabled = false;
                }
                else
                {
                    btnGuardar.Enabled = true;
                }
            }
            else
            {
                btnGuardar.Enabled = true;
            }

        }

        private void frmCompra_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void dataListadoDetalle_Click(object sender, EventArgs e)
        {
            btnQuitar.Enabled = true;
            btnEditar.Enabled = true;
            lblProducto.Text = dataListadoDetalle.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            frmGastosCompra frm = new frmGastosCompra();
            frm.txtFlete.Text = lblFlete.Text;
            frm.txtGastosCarga.Text = lblGastosCarga.Text;
            frm.txtLavadoJaba.Text = lblLavadoJaba.Text;
            frm.txtComisiones.Text = lblComisiones.Text;
            frm.Show();

        }

        private void txtAdelanto_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarDcto();
        }

        private void txtAdelanto_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtAdelanto.Text.Length; i++)
            {
                if (txtAdelanto.Text[i] == '.')
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

        private void txtDcto_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtDcto.Text.Length; i++)
            {
                if (txtDcto.Text[i] == '.')
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

        public void mostrarDcto()
        {
            decimal total = 00.00m, dcto = 00.00m, nuevoTotal = 00.00m, igv = 00.00m, subTotal = 00.00m;

            if (txtIgv.Text.Trim().Length == 0)
            {
                igv = 00.00m;
            }
            else
            {
                igv = Convert.ToDecimal(txtIgv.Text.Trim());
            }

            if (txtSubTotal.Text.Trim().Length == 0)
            {
                subTotal = 00.00m;
            }
            else
            {
                subTotal = Convert.ToDecimal(txtSubTotal.Text.Trim());
            }

            if (txtTotalPagado.Text.Trim().Length == 0)
            {
                total = 00.00m;
            }
            else
            {
                total = Convert.ToDecimal(txtTotalPagado.Text.Trim());
            }

            if (txtDcto.Text.Trim().Length == 0)
            {
                dcto = 00.00m;
                nuevoTotal = igv + subTotal;
            }
            else
            {
                dcto = Convert.ToDecimal(txtDcto.Text.Trim());
                nuevoTotal = subTotal + igv - dcto;
            }


            if (nuevoTotal <= 0)
            {
                txtTotalPagado.Text = "00.00";
            }
            else
            {
                txtTotalPagado.Text = nuevoTotal.ToString();
            }
        }

        private void txtDcto_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarDcto();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmTransporte frm = new frmTransporte();
            frm.txtFlete.Text = this.lblFlete.Text;
            frm.txtViatico.Text = this.lblViaticos.Text;
            frm.txtPeaje.Text = this.lblPeaje.Text;
            frm.txtCombustible.Text = this.lblCombustible.Text;
            frm.txtMantenimiento.Text = this.lblMantenimiento.Text;
            frm.txtOtrosGastos.Text = this.lblOtroGastos.Text;
            frm.cbFormaPago.Text = this.lblFormaPagoTransporte.Text;
            decimal adelanto = 00.00m, saldo = 00.00m;
            adelanto = Convert.ToDecimal(lblAdelantoTransporte.Text);
            saldo = Convert.ToDecimal(lblSaldoTransporte.Text);

            if (lblBanderaFecha.Text != "0")
            {
                frm.cargarTrabajador();
                frm.dtFechaLlegada.Value = Convert.ToDateTime(this.lblFechaLLegada.Text);
                frm.dtFechaSalida.Value = Convert.ToDateTime(this.lblFechaSalida.Text);
                int idPersona;
                if (lblIdPersonaTransporte.Text == "0" || lblIdPersonaTransporte.Text == "")
                {
                    frm.cbProducto.SelectedIndex = -1;
                }
                else
                {
                    idPersona = Convert.ToInt32(lblIdPersonaTransporte.Text);
                    frm.cbProducto.SelectedValue = idPersona;
                }

                if (lblFormaPagoTransporte.Text == "CREDITO")
                {
                    frm.txtAdelanto.Visible = true;
                    frm.txtAdelanto.Text = lblAdelantoTransporte.Text;
                    frm.txtSaldo.Visible = true;
                    frm.txtSaldo.Text = lblSaldoTransporte.Text;
                }
            }

            if (lblTotalTransporte.Text == "00.00")
            {
                frm.txtTotal.Text = this.lblFlete.Text;
            }
            else
            {
                frm.txtTotal.Text = this.lblTotalTransporte.Text;
            }

            frm.ShowDialog();

        }

        private void txtMerma_KeyUp(object sender, KeyEventArgs e)
        {
            this.txtMermaTotal.Text = this.txtMerma.Text;
            mostrarTotalesPollos();
        }
    }
}
