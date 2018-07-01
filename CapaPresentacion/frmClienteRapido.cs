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
    public partial class frmClienteRapido : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public frmClienteRapido()
        {
            InitializeComponent();
        }

        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cargarTipoCliente()
        {
            cbTipoCliente.DataSource = NTipoCliente.Mostrar();
            cbTipoCliente.ValueMember = "Codigo";
            cbTipoCliente.DisplayMember = "TipoCliente";
            cbTipoCliente.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }
        private void Guardar()
        {
            try
            {
                string rpta = "";
                string tipoDoc = "";
                int? idTipoCliente;
                if (this.txtNombre.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese el nombre del cliente");
                    errorIcono.SetError(txtNombre, "Ingrese el nombre");
                }
                else
                {

                    if (this.cbTipoDoc.SelectedIndex == -1)
                    {
                        tipoDoc = "";
                    }
                    else
                    {
                        tipoDoc = this.cbTipoDoc.SelectedItem.ToString();
                    }

                    if (cbTipoCliente.SelectedIndex == -1)
                    {
                        idTipoCliente = null;
                    }
                    else
                    {
                        idTipoCliente = Convert.ToInt32(cbTipoCliente.SelectedValue.ToString());
                    }

                    if (cbTipoDoc.SelectedIndex == 0 && txtNumDoc.Text.Trim().Length != 8)
                    {
                        MessageBox.Show("Ingrese un número de documento válido");
                        return;
                    }
                    else if (cbTipoDoc.SelectedIndex == 1 && txtNumDoc.Text.Trim().Length != 11)
                    {
                        MessageBox.Show("Ingrese un número de documento válido");
                        return;
                    }
                    else if (cbTipoDoc.SelectedIndex == 2 && txtNumDoc.Text.Trim().Length != 11)
                    {
                        MessageBox.Show("Ingrese un número de documento válido");
                        return;
                    }

                    IsNuevo = true;
                    if (this.IsNuevo)
                    {
                        /*rpta = NCliente.Insertar(this.txtNombre.Text.Trim().ToUpper(), fecNac, tipoDoc,
                                                 this.txtNumDoc.Text.Trim(), this.txtDireccion.Text.Trim(), this.txtEmail.Text.Trim(), this.txtTelefono.Text.Trim(),idTipoCliente,"C");*/
                        rpta = NPersona.Insertar(this.txtNombre.Text.Trim().ToUpper(), DateTime.MinValue, tipoDoc, this.txtNumDoc.Text.Trim(), this.txtDireccion.Text.Trim().ToUpper(),
                           "", "", idTipoCliente, "C", "", "", 00.00m, DateTime.MinValue, "A", null);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            frmVistaClientePagoVenta.f1.Mostrar();
                            this.Close();
                        }

                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = valor;
            this.cbTipoDoc.Enabled = !valor;
            this.txtNumDoc.ReadOnly = valor;
            this.txtDireccion.ReadOnly = valor;
            //  this.cbTipoDoc.SelectedIndex = -1;
        }
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        private void frmClienteRapido_Load(object sender, EventArgs e)
        {
            this.cargarTipoCliente();
            this.Habilitar(false);
            cbTipoDoc.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
    }
}
