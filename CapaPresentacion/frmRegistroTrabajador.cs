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
    public partial class frmRegistroTrabajador : Form
    {
        public frmRegistroTrabajador()
        {
            InitializeComponent();
        }

        private void Login()
        {
            if (this.txtDni.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el DNI");
            }else if (this.txtPass.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la clave");
            }
            else
            {
                DataTable datos = NRegistroTrabajador.Login(this.txtDni.Text,this.txtPass.Text);
                if (datos.Rows.Count == 0)
                {
                    MessageBox.Show("El usuario no existe", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    lblIdPersona.Text = datos.Rows[0][0].ToString();
                    string tipo = "";
                    if(rbIngreso.Checked == true)
                    {
                        tipo = "I";
                    }else if(rbSalida.Checked == true)
                    {
                        tipo = "S";
                    }
                    string rpta = NRegistroTrabajador.Insertar(DateTime.Now, tipo, Convert.ToInt32(lblIdPersona.Text));
                    if(rpta == "OK")
                    {
                        MessageBox.Show("Registro exitoso");
                        this.Close();
                    }
                }
            }
        }



        private void frmRegistroTrabajador_Load(object sender, EventArgs e)
        {
            txtDni.Select();
        }

        private void btnUno_Click(object sender, EventArgs e)
        {

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void btnIniciar_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.Login();

            }
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.Login();

            }
        }
    }
}
