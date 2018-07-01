using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NAbono
    {
        public static string Insertar (DateTime fecha, decimal monto, decimal saldo,int idCliente, int idTrabajador,string formaPago, decimal efectivo, decimal tarjeta, decimal dcto)
        {
            DAbono Obj = new DAbono();
            Obj.Fecha = fecha;
            Obj.Monto = monto;
            Obj.Saldo = saldo;
            Obj.IdCliente = idCliente;
            Obj.IdTrabajador = idTrabajador;
            Obj.FormaPago = formaPago;
            Obj.Efectivo = efectivo;
            Obj.Tarjeta = tarjeta;
            Obj.Dcto = dcto;
            return Obj.Insertar(Obj);
        }
        public static DataTable MostrarAbono_Venta(int idVenta)
        {
            return new DAbono().mostrarAbono_Venta(idVenta);
        }
        public static DataTable MostrarUltimoSaldo(int idCliente)
        {
            return new DAbono().mostrarUltimoSaldo(idCliente);
        }

        public static DataTable MostrarAbono_Cliente(int idCliente)
        {
            return new DAbono().mostrarAbono_Cliente(idCliente);
        }

        public static string InsertarAbonoDetalle(int idDetalle, decimal abono)
        {

            return new DAbono().InsertarAbonoDetalleVenta(idDetalle, abono);
        }

        public static DataTable MostrarSaldoCliente(int idCliente)
        {
            return new DAbono().mostrarSaldoCliente(idCliente);
        }

        public static DataTable reporteAbonos( DateTime fechaInicio, DateTime fechaFin)
        {
            DAbono Obj = new DAbono();
            return Obj.reporteAbonos(fechaInicio, fechaFin);
        }
    }
}
