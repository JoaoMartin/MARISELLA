using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NPagoCredito
    {
        public static string Insertar(int idProveedor, DateTime fecha, decimal monto, decimal dcto, decimal saldo, string salioCaja, int idCompra)
        {
            DPagoCompra Obj = new DPagoCompra();
            Obj.IdProveedor = idProveedor;
            Obj.Fecha = fecha;
            Obj.Monto = monto;
            Obj.Dcto = dcto;
            Obj.Saldo = saldo;
            Obj.SalioCaja = salioCaja;
            Obj.IdCompra = idCompra;
            return Obj.Insertar(Obj);
        }

        public static DataTable Mostrar(int idProveedor)
        {
            return new DPagoCompra().Mostrar(idProveedor);
        }
    }
}
