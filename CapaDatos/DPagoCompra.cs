using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DPagoCompra
    {
        private int _IdPagoCompra;
        private int _IdProveedor;
        private DateTime _Fecha;
        private decimal _Monto;
        private decimal _Dcto;
        private decimal _Saldo;
        private string _SalioCaja;
        private int _IdCompra;

        public int IdPagoCompra
        {
            get
            {
                return _IdPagoCompra;
            }

            set
            {
                _IdPagoCompra = value;
            }
        }

        public int IdProveedor
        {
            get
            {
                return _IdProveedor;
            }

            set
            {
                _IdProveedor = value;
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

        public string SalioCaja
        {
            get
            {
                return _SalioCaja;
            }

            set
            {
                _SalioCaja = value;
            }
        }

        public int IdCompra
        {
            get
            {
                return _IdCompra;
            }

            set
            {
                _IdCompra = value;
            }
        }

        public DPagoCompra() { }

        public DPagoCompra(int idPagoCompra, int idProveedor, DateTime fecha, decimal monto, decimal dcto, decimal saldo, string salioCaja,int idCompra)
        {
            this.IdPagoCompra = idPagoCompra;
            this.IdProveedor = idProveedor;
            this.Fecha = fecha;
            this.Monto = monto;
            this.Dcto = dcto;
            this.Saldo = saldo;
            this.SalioCaja = salioCaja;
            this.IdCompra = idCompra;
        }

        public string Insertar(DPagoCompra PagoCompra)
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
                sqlCmd.CommandText = "sp_insertarPagoCompra";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPagoCompra = new SqlParameter();
                ParIdPagoCompra.ParameterName = "@idPagoCompra";
                ParIdPagoCompra.SqlDbType = SqlDbType.Int;
                ParIdPagoCompra.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdPagoCompra);

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idProveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = PagoCompra.IdProveedor;
                sqlCmd.Parameters.Add(ParIdProveedor);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = PagoCompra.Fecha;
                sqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParMonto = new SqlParameter();
                ParMonto.ParameterName = "@monto";
                ParMonto.SqlDbType = SqlDbType.Decimal;
                ParMonto.Precision = 10;
                ParMonto.Scale = 2;
                ParMonto.Value = PagoCompra.Monto;
                sqlCmd.Parameters.Add(ParMonto);

 
                SqlParameter ParDcto = new SqlParameter();
                ParDcto.ParameterName = "@dcto";
                ParDcto.SqlDbType = SqlDbType.Char;
                ParDcto.Precision = 8;
                ParDcto.Scale = 2;
                ParDcto.Value = PagoCompra.Dcto;
                sqlCmd.Parameters.Add(ParDcto);

                SqlParameter ParSaldo= new SqlParameter();
                ParSaldo.ParameterName = "@saldo";
                ParSaldo.SqlDbType = SqlDbType.Decimal;
                ParSaldo.Precision = 10;
                ParSaldo.Scale = 2;
                ParSaldo.Value = PagoCompra.Saldo;
                sqlCmd.Parameters.Add(ParSaldo);

                SqlParameter ParCaja = new SqlParameter();
                ParCaja.ParameterName = "@salioCaja";
                ParCaja.SqlDbType = SqlDbType.Char;
                ParCaja.Size = 2;
                ParCaja.Value = PagoCompra.SalioCaja;
                sqlCmd.Parameters.Add(ParCaja);

                SqlParameter ParIdCompra = new SqlParameter();
                ParIdCompra.ParameterName = "@idCompra";
                ParIdCompra.SqlDbType = SqlDbType.Int;
                ParIdCompra.Value = PagoCompra.IdCompra;
                sqlCmd.Parameters.Add(ParIdCompra);


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

        public DataTable Mostrar(int idProveedor)
        {
            DataTable dtResultado = new DataTable("Adelanto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarCompraPagoPendiente";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idProveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = idProveedor;
                sqlCmd.Parameters.Add(ParIdProveedor);

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
