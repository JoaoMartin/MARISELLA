using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NCompra
    {
        public static string Insertar(int idUsuario, int idProveedor, DateTime fechaIngreso, string tipoComprobante, string serie, string correlativo, decimal igv,string formaPago, 
            string tipoMoneda ,string estado, decimal total, DataTable dtDetalle, decimal adelanto, decimal descuento, decimal flete, decimal comisiones, decimal lavadoJaba,
            decimal gastoCarga,decimal saldo, decimal merma)
        {
            DCompra Obj = new DCompra();
            Obj.IdUsuario = idUsuario;
            Obj.IdProveedor = idProveedor;
            Obj.FechaIngreso = fechaIngreso;
            Obj.TipoComprobante = tipoComprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            Obj.FormaPago = formaPago;
            Obj.TipoMoneda = tipoMoneda;
            Obj.Estado = estado;
            Obj.Total = total;
            Obj.Adelanto = adelanto;
            Obj.Descuento = descuento;
            Obj.Flete = flete;
            Obj.Comisiones = comisiones;
            Obj.LavadoJaba = lavadoJaba;
            Obj.GastoCarga = gastoCarga;
            Obj.Saldo = saldo;
            Obj.Merma = merma;

            List<DDetalleCompra> detalles = new List<DDetalleCompra>();
            foreach(DataRow row in dtDetalle.Rows)
            {
                DDetalleCompra detalle = new DDetalleCompra();
                detalle.IdProducto = Convert.ToInt32(row["Codigo"].ToString());
                detalle.Cantidad = Convert.ToDecimal(row["Cantidad"].ToString());
                detalle.PrecioCompra = Convert.ToDecimal(row["Costo_Uni"].ToString());
                detalle.CantXJabas = Convert.ToInt32(row["CantxJaba"].ToString());
                detalle.NroJabas = Convert.ToInt32(row["NroJabas"].ToString());
                detalle.PesoJabasVacias = Convert.ToDecimal(row["PJabaVacia"].ToString());
                detalle.Tipo = row["Tipo"].ToString();
                detalle.PVxMenor = Convert.ToDecimal(row["PVxMenor"].ToString());
                detalle.PVxMayor = Convert.ToDecimal(row["PVxMayor"].ToString());
                detalle.PV3= Convert.ToDecimal(row["PV3"].ToString());
                detalle.PV4= Convert.ToDecimal(row["PV4"].ToString());
                detalle.PV4 = Convert.ToDecimal(row["PV4"].ToString());
                detalle.PV5= Convert.ToDecimal(row["PV5"].ToString());
                detalle.NroUnidades = Convert.ToDecimal(row["NroUnidades"].ToString());
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj,detalles);
        }

        public static string Anular(int idIngreso)
        {
            DCompra Obj = new DCompra();
            Obj.IdIngreso = idIngreso;
            return Obj.Anular(Obj);
        }

        public static DataTable Mostrar(DateTime fechaInicio, DateTime fechaFin)
        {
            return new DCompra().Mostrar(fechaInicio,fechaFin);
        }

        public static DataTable BuscarFechas(string textoBuscar, string textoBuscar2)
        {
            DCompra Obj = new DCompra();
            return Obj.BuscarFecha(textoBuscar, textoBuscar2);
        }

        public static DataTable mostrarDetalleIngreso(int textoBuscar)
        {
            DCompra Obj = new DCompra();
            return Obj.MostrarDetalleIngreso(textoBuscar);
        }

        public static DataTable reporteCompraProducto(DateTime fechaInicio, DateTime fechaFin, int idProducto)
        {
            DCompra Obj = new DCompra();
            return Obj.reporteComprasProducto(fechaInicio, fechaFin, idProducto);
        }

        public static DataTable reporteCompraProveedor(DateTime fechaInicio, DateTime fechaFin, int idProveedor)
        {
            DCompra Obj = new DCompra();
            return Obj.reporteComprasProveedor(fechaInicio, fechaFin, idProveedor);
        }

        public static DataTable reporteCompraTrabajador(DateTime fechaInicio, DateTime fechaFin, int idTrabajador)
        {
            DCompra Obj = new DCompra();
            return Obj.reporteComprasTrabajador(fechaInicio, fechaFin, idTrabajador);
        }

        public static DataTable mostrarGastoCompra(int idCompra)
        {
            DCompra Obj = new DCompra();
            return Obj.mostrarGastoCompra(idCompra);
        }

        public static DataTable mostrarTransporteGasto(int idCompra)
        {
            DCompra Obj = new DCompra();
            return Obj.mostrarTransporteCompra(idCompra);
        }

        public static string Insertar1(int idUsuario, int idProveedor, DateTime fechaIngreso, string tipoComprobante, string serie, string correlativo, decimal igv, string formaPago,
           string tipoMoneda, string estado, decimal total, DataTable dtDetalle, decimal adelanto, decimal descuento, decimal flete, decimal comisiones, decimal lavadoJaba,
           decimal gastoCarga, decimal saldo,int? idPersona,DateTime fechaSalida, DateTime fechaLlegada, decimal viaticos, decimal peaje, decimal combustible,decimal mantenimiento,
           decimal otrosGasto, string formaPagoTran,decimal adelantoTra, decimal saldoTras, string estadoTran,decimal merma)
        {
            DCompra Obj = new DCompra();
            Obj.IdUsuario = idUsuario;
            Obj.IdProveedor = idProveedor;
            Obj.FechaIngreso = fechaIngreso;
            Obj.TipoComprobante = tipoComprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            Obj.FormaPago = formaPago;
            Obj.TipoMoneda = tipoMoneda;
            Obj.Estado = estado;
            Obj.Total = total;
            Obj.Adelanto = adelanto;
            Obj.Descuento = descuento;
            Obj.Flete = flete;
            Obj.Comisiones = comisiones;
            Obj.LavadoJaba = lavadoJaba;
            Obj.GastoCarga = gastoCarga;
            Obj.Saldo = saldo;
            Obj.Merma = merma;

            List<DDetalleCompra> detalles = new List<DDetalleCompra>();
            foreach (DataRow row in dtDetalle.Rows)
            {
                DDetalleCompra detalle = new DDetalleCompra();
                detalle.IdProducto = Convert.ToInt32(row["Codigo"].ToString());
                detalle.Cantidad = Convert.ToDecimal(row["Cantidad"].ToString());
                detalle.PrecioCompra = Convert.ToDecimal(row["Costo_Uni"].ToString());
                detalle.CantXJabas = Convert.ToInt32(row["CantxJaba"].ToString());
                detalle.NroJabas = Convert.ToInt32(row["NroJabas"].ToString());
                detalle.PesoJabasVacias = Convert.ToDecimal(row["PJabaVacia"].ToString());
                detalle.Tipo = row["Tipo"].ToString();
                detalle.PVxMenor = Convert.ToDecimal(row["PVxMenor"].ToString());
                detalle.PVxMayor = Convert.ToDecimal(row["PVxMayor"].ToString());
                detalle.PV3 = Convert.ToDecimal(row["PV3"].ToString());
                detalle.PV4 = Convert.ToDecimal(row["PV4"].ToString());
                detalle.PV4 = Convert.ToDecimal(row["PV4"].ToString());
                detalle.PV5 = Convert.ToDecimal(row["PV5"].ToString());
                detalle.NroUnidades = Convert.ToDecimal(row["NroUnidades"].ToString());
                detalles.Add(detalle);
            }

            DTransporte Obj1 = new DTransporte();
            Obj1.IdPersona = idPersona;
            Obj1.FechaSalida = fechaSalida;
            Obj1.FechaLlegada = fechaLlegada;
            Obj1.Viaticos = viaticos;
            Obj1.Peaje = peaje;
            Obj1.Combustible = combustible;
            Obj1.Mantenimiento = mantenimiento;
            Obj1.OtrosGastos = otrosGasto;
            Obj1.FormaPago = formaPagoTran;
            Obj1.Adelanto = adelantoTra;
            Obj1.Saldo = saldoTras;
            Obj1.Estado = estadoTran;
            Obj1.Flete = flete;

            return Obj.Insertar1(Obj, detalles,Obj1);
        }

        public static DataTable imprimirDetalleCompra(int idCompra)
        {
            DCompra Obj = new DCompra();
            return Obj.imprimirCompraDetalle(idCompra);
        }

        public static string Eliminar(int idIngreso)
        {
            DCompra Obj = new DCompra();
            return Obj.Eliminar(idIngreso);
        }

        public static string EditarStcok(int idProducto, decimal kgs, decimal nroUnidades)
        {
            DCompra Obj = new DCompra();
            return Obj.EditarStockCompra(idProducto, kgs, nroUnidades);
        }
    }
}
