using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTransporte
    {
        private int _IdTransporte;
        private int? _IdPersona;
        private DateTime _FechaSalida;
        private DateTime _FechaLlegada;
        private decimal _Viaticos;
        private decimal _Peaje;
        private decimal _Combustible;
        private decimal _Mantenimiento;
        private decimal _OtrosGastos;
        private string _FormaPago;
        private decimal _Adelanto;
        private decimal _Saldo;
        private string _Estado;
        private decimal _Flete;
        private int? _IdCompra;

        public int IdTransporte
        {
            get
            {
                return _IdTransporte;
            }

            set
            {
                _IdTransporte = value;
            }
        }

        public int? IdPersona
        {
            get
            {
                return _IdPersona;
            }

            set
            {
                _IdPersona = value;
            }
        }

        public DateTime FechaSalida
        {
            get
            {
                return _FechaSalida;
            }

            set
            {
                _FechaSalida = value;
            }
        }

        public DateTime FechaLlegada
        {
            get
            {
                return _FechaLlegada;
            }

            set
            {
                _FechaLlegada = value;
            }
        }

        public decimal Viaticos
        {
            get
            {
                return _Viaticos;
            }

            set
            {
                _Viaticos = value;
            }
        }

        public decimal Peaje
        {
            get
            {
                return _Peaje;
            }

            set
            {
                _Peaje = value;
            }
        }

        public decimal Mantenimiento
        {
            get
            {
                return _Mantenimiento;
            }

            set
            {
                _Mantenimiento = value;
            }
        }

        public decimal OtrosGastos
        {
            get
            {
                return _OtrosGastos;
            }

            set
            {
                _OtrosGastos = value;
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

        public decimal Adelanto
        {
            get
            {
                return _Adelanto;
            }

            set
            {
                _Adelanto = value;
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

        public string Estado
        {
            get
            {
                return _Estado;
            }

            set
            {
                _Estado = value;
            }
        }

        public decimal Combustible
        {
            get
            {
                return _Combustible;
            }

            set
            {
                _Combustible = value;
            }
        }

        public decimal Flete
        {
            get
            {
                return _Flete;
            }

            set
            {
                _Flete = value;
            }
        }

        public int? IdCompra
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

        public DTransporte() { }

        public DTransporte(int idTransporte, int idPersona, DateTime fechaSalida, DateTime fechaLlegada, decimal viaticos, decimal peaje, decimal mantenimiento, decimal combustible,
            decimal otrosGastos,string formaPago, decimal adelanto, decimal saldo, string estado, decimal flete, int idCompra)
        {
            this.IdTransporte = IdTransporte;
            this.IdPersona = idPersona;
            this.FechaSalida = fechaSalida;
            this.FechaLlegada = fechaLlegada;
            this.Viaticos = viaticos;
            this.Peaje = peaje;
            this.Combustible = combustible;
            this.Mantenimiento = mantenimiento;
            this.OtrosGastos = otrosGastos;
            this.FormaPago = formaPago;
            this.Adelanto = adelanto;
            this.Saldo = saldo;
            this.Estado = estado;
            this.Flete = flete;
            this.IdCompra = idCompra;
        }

        public string Insertar(DTransporte Transporte)
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
                sqlCmd.CommandText = "sp_insertarTransporte";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTransporte = new SqlParameter();
                ParIdTransporte.ParameterName = "@idTransporte";
                ParIdTransporte.SqlDbType = SqlDbType.Int;
                ParIdTransporte.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdTransporte);

                SqlParameter ParIdPersona = new SqlParameter();
                ParIdPersona.ParameterName = "@idPersona";
                ParIdPersona.SqlDbType = SqlDbType.Int;
                ParIdPersona.Value = Transporte.IdPersona;
                sqlCmd.Parameters.Add(ParIdPersona);

                SqlParameter ParFechaSalida = new SqlParameter();
                ParFechaSalida.ParameterName = "@fechaSalida";
                ParFechaSalida.SqlDbType = SqlDbType.Date;
                ParFechaSalida.Value = Transporte.FechaSalida;
                sqlCmd.Parameters.Add(ParFechaSalida);

                SqlParameter ParFechaLlegada = new SqlParameter();
                ParFechaLlegada.ParameterName = "@fechaLlegada";
                ParFechaLlegada.SqlDbType = SqlDbType.Date;
                ParFechaLlegada.Value = Transporte.FechaLlegada;
                sqlCmd.Parameters.Add(ParFechaLlegada);

                SqlParameter ParViaticos = new SqlParameter();
                ParViaticos.ParameterName = "@viaticos";
                ParViaticos.SqlDbType = SqlDbType.Decimal;
                ParViaticos.Precision = 8;
                ParViaticos.Scale = 2;
                ParViaticos.Value = Transporte.Viaticos;
                sqlCmd.Parameters.Add(ParViaticos);

                SqlParameter ParPeaje = new SqlParameter();
                ParPeaje.ParameterName = "@peaje";
                ParPeaje.SqlDbType = SqlDbType.Decimal;
                ParPeaje.Precision = 8;
                ParPeaje.Scale = 2;
                ParPeaje.Value = Transporte.Peaje;
                sqlCmd.Parameters.Add(ParPeaje);

                SqlParameter ParCombustible = new SqlParameter();
                ParCombustible.ParameterName = "@combustible";
                ParCombustible.SqlDbType = SqlDbType.Decimal;
                ParCombustible.Precision = 8;
                ParCombustible.Scale = 2;
                ParCombustible.Value = Transporte.Combustible;
                sqlCmd.Parameters.Add(ParCombustible);

                SqlParameter ParMantenimiento = new SqlParameter();
                ParMantenimiento.ParameterName = "@mantenimiento";
                ParMantenimiento.SqlDbType = SqlDbType.Decimal;
                ParMantenimiento.Precision = 8;
                ParMantenimiento.Scale = 2;
                ParMantenimiento.Value = Transporte.Mantenimiento;
                sqlCmd.Parameters.Add(ParMantenimiento);

                SqlParameter ParOtrosGastos = new SqlParameter();
                ParOtrosGastos.ParameterName = "@otrosGastos";
                ParOtrosGastos.SqlDbType = SqlDbType.Decimal;
                ParOtrosGastos.Precision = 8;
                ParOtrosGastos.Scale = 2;
                ParOtrosGastos.Value = Transporte.OtrosGastos;
                sqlCmd.Parameters.Add(ParOtrosGastos);

                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@formaPago";
                ParFormaPago.SqlDbType = SqlDbType.VarChar;
                ParFormaPago.Size = 20;
                ParFormaPago.Value = Transporte.FormaPago;
                sqlCmd.Parameters.Add(ParFormaPago);

                SqlParameter ParAdelanto = new SqlParameter();
                ParAdelanto.ParameterName = "@adelanto";
                ParAdelanto.SqlDbType = SqlDbType.Decimal;
                ParAdelanto.Precision = 8;
                ParAdelanto.Scale = 2;
                ParAdelanto.Value = Transporte.Adelanto;
                sqlCmd.Parameters.Add(ParAdelanto);

                SqlParameter ParSaldo = new SqlParameter();
                ParSaldo.ParameterName = "@saldo";
                ParSaldo.SqlDbType = SqlDbType.Decimal;
                ParSaldo.Precision = 8;
                ParSaldo.Scale = 2;
                ParSaldo.Value = Transporte.Saldo;
                sqlCmd.Parameters.Add(ParSaldo);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 25;
                ParEstado.Value = Transporte.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParFlete = new SqlParameter();
                ParFlete.ParameterName = "@flete";
                ParFlete.SqlDbType = SqlDbType.Decimal;
                ParFlete.Precision = 10;
                ParFlete.Scale = 2;
                ParFlete.Value = Transporte.Flete;
                sqlCmd.Parameters.Add(ParFlete);

                SqlParameter ParIdCompra = new SqlParameter();
                ParSaldo.ParameterName = "@idCompra";
                ParIdCompra.SqlDbType = SqlDbType.Int;
                ParIdCompra.Value = IdCompra;
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

        public DataTable Mostrar()
        {
            DataTable dtResultado = new DataTable("Categoria");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarTransporte";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public string Insertar1(DTransporte Transporte, ref SqlConnection sqlCon, ref SqlTransaction sqlTran)
        {
            string rpta = "";
           
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.Transaction = sqlTran;
                //Comandos
                sqlCmd.CommandText = "sp_insertarTransporte";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTransporte = new SqlParameter();
                ParIdTransporte.ParameterName = "@idTransporte";
                ParIdTransporte.SqlDbType = SqlDbType.Int;
                ParIdTransporte.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdTransporte);

                SqlParameter ParIdPersona = new SqlParameter();
                ParIdPersona.ParameterName = "@idPersona";
                ParIdPersona.SqlDbType = SqlDbType.Int;
                ParIdPersona.Value = Transporte.IdPersona;
                sqlCmd.Parameters.Add(ParIdPersona);

                SqlParameter ParFechaSalida = new SqlParameter();
                ParFechaSalida.ParameterName = "@fechaSalida";
                ParFechaSalida.SqlDbType = SqlDbType.Date;
                ParFechaSalida.Value = Transporte.FechaSalida;
                sqlCmd.Parameters.Add(ParFechaSalida);

                SqlParameter ParFechaLlegada = new SqlParameter();
                ParFechaLlegada.ParameterName = "@fechaLlegada";
                ParFechaLlegada.SqlDbType = SqlDbType.Date;
                ParFechaLlegada.Value = Transporte.FechaLlegada;
                sqlCmd.Parameters.Add(ParFechaLlegada);

                SqlParameter ParViaticos = new SqlParameter();
                ParViaticos.ParameterName = "@viaticos";
                ParViaticos.SqlDbType = SqlDbType.Decimal;
                ParViaticos.Precision = 8;
                ParViaticos.Scale = 2;
                ParViaticos.Value = Transporte.Viaticos;
                sqlCmd.Parameters.Add(ParViaticos);

                SqlParameter ParPeaje = new SqlParameter();
                ParPeaje.ParameterName = "@peaje";
                ParPeaje.SqlDbType = SqlDbType.Decimal;
                ParPeaje.Precision = 8;
                ParPeaje.Scale = 2;
                ParPeaje.Value = Transporte.Peaje;
                sqlCmd.Parameters.Add(ParPeaje);

                SqlParameter ParCombustible = new SqlParameter();
                ParCombustible.ParameterName = "@combustible";
                ParCombustible.SqlDbType = SqlDbType.Decimal;
                ParCombustible.Precision = 8;
                ParCombustible.Scale = 2;
                ParCombustible.Value = Transporte.Combustible;
                sqlCmd.Parameters.Add(ParCombustible);

                SqlParameter ParMantenimiento = new SqlParameter();
                ParMantenimiento.ParameterName = "@mantenimiento";
                ParMantenimiento.SqlDbType = SqlDbType.Decimal;
                ParMantenimiento.Precision = 8;
                ParMantenimiento.Scale = 2;
                ParMantenimiento.Value = Transporte.Mantenimiento;
                sqlCmd.Parameters.Add(ParMantenimiento);

                SqlParameter ParOtrosGastos = new SqlParameter();
                ParOtrosGastos.ParameterName = "@otrosGastos";
                ParOtrosGastos.SqlDbType = SqlDbType.Decimal;
                ParOtrosGastos.Precision = 8;
                ParOtrosGastos.Scale = 2;
                ParOtrosGastos.Value = Transporte.OtrosGastos;
                sqlCmd.Parameters.Add(ParOtrosGastos);

                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@formaPago";
                ParFormaPago.SqlDbType = SqlDbType.VarChar;
                ParFormaPago.Size = 20;
                ParFormaPago.Value = Transporte.FormaPago;
                sqlCmd.Parameters.Add(ParFormaPago);

                SqlParameter ParAdelanto = new SqlParameter();
                ParAdelanto.ParameterName = "@adelanto";
                ParAdelanto.SqlDbType = SqlDbType.Decimal;
                ParAdelanto.Precision = 8;
                ParAdelanto.Scale = 2;
                ParAdelanto.Value = Transporte.Adelanto;
                sqlCmd.Parameters.Add(ParAdelanto);

                SqlParameter ParSaldo = new SqlParameter();
                ParSaldo.ParameterName = "@saldo";
                ParSaldo.SqlDbType = SqlDbType.Decimal;
                ParSaldo.Precision = 8;
                ParSaldo.Scale = 2;
                ParSaldo.Value = Transporte.Saldo;
                sqlCmd.Parameters.Add(ParSaldo);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 25;
                ParEstado.Value = Transporte.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParFlete = new SqlParameter();
                ParFlete.ParameterName = "@flete";
                ParFlete.SqlDbType = SqlDbType.Decimal;
                ParFlete.Precision = 10;
                ParFlete.Scale = 2;
                ParFlete.Value = Transporte.Flete;
                sqlCmd.Parameters.Add(ParFlete);

                SqlParameter ParIdCompra = new SqlParameter();
                ParIdCompra.ParameterName = "@idCompra";
                ParIdCompra.SqlDbType = SqlDbType.Int;
                ParIdCompra.Value = Transporte.IdCompra;
                sqlCmd.Parameters.Add(ParIdCompra);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;
        }
    }
}
