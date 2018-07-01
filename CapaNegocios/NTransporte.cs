using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NTransporte
    {
        public static string Insertar(int? idPersona, DateTime fechaSalida, DateTime fechaLlegada, decimal viaticos, decimal peaje, decimal mantenimiento, decimal combustible,
            decimal otrosGastos, string formaPago, decimal adelanto, decimal saldo, string estado, decimal flete)
        {
            DTransporte Obj = new DTransporte();
            Obj.IdPersona = idPersona;
            Obj.FechaSalida = fechaSalida;
            Obj.FechaLlegada = fechaLlegada;
            Obj.Viaticos = viaticos;
            Obj.Peaje = peaje;
            Obj.Mantenimiento = mantenimiento;
            Obj.Combustible = combustible;
            Obj.OtrosGastos = otrosGastos;
            Obj.FormaPago = formaPago;
            Obj.Adelanto = adelanto;
            Obj.Saldo = saldo;
            Obj.Estado = estado;
            Obj.Flete = flete;
            return Obj.Insertar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DTransporte().Mostrar();
        }
    }
}
