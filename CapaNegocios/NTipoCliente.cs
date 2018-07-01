using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Windows.Forms;

namespace CapaNegocios
{
    public class NTipoCliente
    {
        public static string Insertar(string nombre, string descripcion)
        {
            DTipoCliente Obj = new DTipoCliente();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idTipoCliente, string nombre, string descripcion)
        {
            DTipoCliente Obj = new DTipoCliente();
            Obj.IdTipoCliente = idTipoCliente;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idTipoCliente)
        {
            DTipoCliente Obj = new DTipoCliente();
            Obj.IdTipoCliente = idTipoCliente;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DTipoCliente().Mostrar();
        }


        public static DataTable Buscar(string textoBuscar)
        {
            DTipoCliente Obj = new DTipoCliente();
            Obj.TextoBuscar = textoBuscar;
            return Obj.Buscar(Obj);
        }

        

        public static string GuardarCliente(string total, string totaladelanto,string banderaComprobante,string nroDoc,ComboBox cbTipoCliente, bool isNuevo,
            string nombre,string direccion, string idCliente)
        {
            string rpta = "";
            try
            {
                
                decimal monto = 00.00m;
                string tipoDoc = "";
                int? tipoCliente;
                monto = Convert.ToDecimal(total) + Convert.ToDecimal(totaladelanto);
                if (nroDoc.Length == 8)
                {
                    tipoDoc = "DNI";
                }
                else if (nroDoc.Length == 11)
                {
                    tipoDoc = "RUC";

                }
                else
                {
                    MessageBox.Show("Ingrese un número de documento válido");
                    return null;
                }

                if (cbTipoCliente.SelectedIndex == -1)
                {
                    tipoCliente = null;
                }
                else
                {
                    tipoCliente = Convert.ToInt32(cbTipoCliente.SelectedValue.ToString());
                }
                if (isNuevo)
                {
                    rpta = NCliente.InsertarVenta(nombre.ToUpper(), DateTime.MinValue, tipoDoc, nroDoc.Trim(), direccion, "", "", tipoCliente);

                }
                else
                {
                    rpta = NCliente.Editar(Convert.ToInt32(idCliente), nombre.ToUpper(), DateTime.MinValue, tipoDoc, nroDoc, direccion, "", "", tipoCliente);

                }

            }catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }

            return rpta;
        }
    }
}
