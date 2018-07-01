using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DAbono
    {
        private int _IdAbono;
        private DateTime _Fecha;
        private decimal _Monto;
        private decimal _Saldo;
        private int _IdCliente;
        private int _IdTrabajador;
        private string _FormaPago;
        private decimal _Efectivo;
        private decimal _Tarjeta;
        private decimal _Dcto;

        public int IdAbono
        {
            get
            {
                return _IdAbono;
            }

            set
            {
                _IdAbono = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }

            set
            {
                _Fecha = value;
            }
        }

        public decimal Monto
        {
            get
            {
                return _Monto;
            }

            set
            {
                _Monto = value;
            }
        }

        public decimal Saldo
        {
            get
            {
                return _Saldo;
            }

            set
            {
                _Saldo = value;
            }
        }

        public int IdTrabajador
        {
            get
            {
                return _IdTrabajador;
            }

            set
            {
                _IdTrabajador = value;
            }
        }

        public string FormaPago
        {
            get
            {
                return _FormaPago;
            }

            set
            {
                _FormaPago = value;
            }
        }

        public decimal Efectivo
        {
            get
            {
                return _Efectivo;
            }

            set
            {
                _Efectivo = value;
            }
        }

        public decimal Tarjeta
        {
            get
            {
                return _Tarjeta;
            }

            set
            {
                _Tarjeta = value;
            }
        }

        public decimal Dcto
        {
            get
            {
                return _Dcto;
            }

            set
            {
                _Dcto = value;
            }
        }

        public int IdCliente
        {
            get
            {
                return _IdCliente;
            }

            set
            {
                _IdCliente = value;
            }
        }

        public DAbono() { }

        public DAbono(int idAbono, DateTime fecha, decimal monto, decimal saldo,int idCliente, int idTrabajador,string formaPago, decimal efectivo, decimal tarjeta, decimal dcto)
        {
            this.IdAbono = idAbono;
            this.Fecha = fecha;
            this.Monto = monto;
            this.Saldo = saldo;
            this.IdCliente = idCliente;
            this.IdTrabajador = idTrabajador;
            this.FormaPago = formaPago;
            this.Efectivo = efectivo;
            this.Tarjeta = tarjeta;
            this.Dcto = dcto;
        }

        public string Insertar(DAbono Abono)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                sqlCon.Open();
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_insertarAbono";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdAbono = new SqlParameter();
                ParIdAbono.ParameterName = "@idAbono";
                ParIdAbono.SqlDbType = SqlDbType.Int;
                ParIdAbono.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdAbono);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Abono.Fecha;
                sqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParMonto = new SqlParameter();
                ParMonto.ParameterName = "@monto";
                ParMonto.SqlDbType = SqlDbType.Decimal;
                ParMonto.Precision = 10;
                ParMonto.Scale = 2;
                ParMonto.Value = Abono.Monto;
                sqlCmd.Parameters.Add(ParMonto);

                SqlParameter ParSaldo = new SqlParameter();
                ParSaldo.ParameterName = "@saldo";
                ParSaldo.SqlDbType = SqlDbType.Decimal;
                ParSaldo.Precision = 10;
                ParSaldo.Scale = 2;
                ParSaldo.Value = Abono.Saldo;
                sqlCmd.Parameters.Add(ParSaldo);

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Abono.IdCliente;
                sqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Abono.IdTrabajador;
                sqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@formaPago";
                ParFormaPago.SqlDbType = SqlDbType.VarChar;
                ParFormaPago.Size = 20;
                ParFormaPago.Value = Abono.FormaPago;
                sqlCmd.Parameters.Add(ParFormaPago);

                SqlParameter PaEfectivo = new SqlParameter();
                PaEfectivo.ParameterName = "@efectivo";
                PaEfectivo.SqlDbType = SqlDbType.Decimal;
                PaEfectivo.Precision = 10;
                PaEfectivo.Scale = 2;
                PaEfectivo.Value = Abono.Efectivo;
                sqlCmd.Parameters.Add(PaEfectivo);

                SqlParameter ParTarjeta = new SqlParameter();
                ParTarjeta.ParameterName = "@tarjeta";
                ParTarjeta.SqlDbType = SqlDbType.Decimal;
                ParTarjeta.Precision = 10;
                ParTarjeta.Scale = 2;
                ParTarjeta.Value = Abono.Tarjeta;
                sqlCmd.Parameters.Add(ParTarjeta);

                SqlParameter ParDcto = new SqlParameter();
                ParDcto.ParameterName = "@dcto";
                ParDcto.SqlDbType = SqlDbType.Decimal;
                ParDcto.Precision = 8;
                ParDcto.Scale = 2;
                ParDcto.Value = Abono.Dcto;
                sqlCmd.Parameters.Add(ParDcto);


                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return rpta;
        }

        public DataTable mostrarAbono_Venta(int idVenta)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarAbono_Venta";
                sqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = idVenta;
                sqlCmd.Parameters.Add(ParIdVenta);


                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }


        public DataTable mostrarUltimoSaldo(int idCliente)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarUltimoSaldo";
                sqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = idCliente;
                sqlCmd.Parameters.Add(ParIdCliente);

             
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }


        public DataTable mostrarAbono_Cliente(int idCliente)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarAbono";
                sqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParIdPersona = new SqlParameter();
                ParIdPersona.ParameterName = "@idPersona";
                ParIdPersona.SqlDbType = SqlDbType.Int;
                ParIdPersona.Value = idCliente;
                sqlCmd.Parameters.Add(ParIdPersona);


                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public string InsertarAbonoDetalleVenta(int idDetalle, decimal abono)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                sqlCon.Open();
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_insertarAbonoDetalleVenta";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalle = new SqlParameter();
                ParIdDetalle.ParameterName = "@idDetalleVenta";
                ParIdDetalle.SqlDbType = SqlDbType.Int;
                ParIdDetalle.Value = idDetalle;
                sqlCmd.Parameters.Add(ParIdDetalle);

                SqlParameter ParMonto = new SqlParameter();
                ParMonto.ParameterName = "@abono";
                ParMonto.SqlDbType = SqlDbType.Decimal;
                ParMonto.Precision = 10;
                ParMonto.Scale = 2;
                ParMonto.Value = abono;
                sqlCmd.Parameters.Add(ParMonto);

                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return rpta;
        }

        public DataTable mostrarSaldoCliente(int idCliente)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarSaldoCliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParIdPersona = new SqlParameter();
                ParIdPersona.ParameterName = "@idCliente";
                ParIdPersona.SqlDbType = SqlDbType.Int;
                ParIdPersona.Value = idCliente;
                sqlCmd.Parameters.Add(ParIdPersona);


                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable reporteAbonos(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_reporteAbonos";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@fechaInicio";
                ParFechaInicio.SqlDbType = SqlDbType.DateTime;
                ParFechaInicio.Value = fechaInicio;
                sqlCmd.Parameters.Add(ParFechaInicio);

                SqlParameter ParFechaFin = new SqlParameter();
                ParFechaFin.ParameterName = "@fechaFin";
                ParFechaFin.SqlDbType = SqlDbType.DateTime;
                ParFechaFin.Value = fechaFin;
                sqlCmd.Parameters.Add(ParFechaFin);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

    }
}
