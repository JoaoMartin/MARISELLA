using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalleCompra
    {
        private int _IdDetalleIngreso;
        private int _IdIngreso;
        private int _IdProducto;
        private decimal _PrecioVenta;
        private decimal _PrecioCompra;
        private decimal _Cantidad;
        private string _Tipo;
        private int _CantXJabas;
        private int _NroJabas;
        private decimal _PesoJabasVacias;
        private decimal _PVxMenor;
        private decimal _PVxMayor;
        private decimal _PV3;
        private decimal _PV4;
        private decimal _PV5;
        private decimal _NroUnidades;

        public int IdDetalleIngreso
        {
            get
            {
                return _IdDetalleIngreso;
            }

            set
            {
                _IdDetalleIngreso = value;
            }
        }

        public int IdIngreso
        {
            get
            {
                return _IdIngreso;
            }

            set
            {
                _IdIngreso = value;
            }
        }

        public int IdProducto
        {
            get
            {
                return _IdProducto;
            }

            set
            {
                _IdProducto = value;
            }
        }

        public decimal PrecioVenta
        {
            get
            {
                return _PrecioVenta;
            }

            set
            {
                _PrecioVenta = value;
            }
        }

        public decimal PrecioCompra
        {
            get
            {
                return _PrecioCompra;
            }

            set
            {
                _PrecioCompra = value;
            }
        }

        public decimal Cantidad
        {
            get
            {
                return _Cantidad;
            }

            set
            {
                _Cantidad = value;
            }
        }

        public string Tipo
        {
            get
            {
                return _Tipo;
            }

            set
            {
                _Tipo = value;
            }
        }

        public int CantXJabas
        {
            get
            {
                return _CantXJabas;
            }

            set
            {
                _CantXJabas = value;
            }
        }

        public int NroJabas
        {
            get
            {
                return _NroJabas;
            }

            set
            {
                _NroJabas = value;
            }
        }

        public decimal PesoJabasVacias
        {
            get
            {
                return _PesoJabasVacias;
            }

            set
            {
                _PesoJabasVacias = value;
            }
        }

        public decimal PVxMenor
        {
            get
            {
                return _PVxMenor;
            }

            set
            {
                _PVxMenor = value;
            }
        }

        public decimal PVxMayor
        {
            get
            {
                return _PVxMayor;
            }

            set
            {
                _PVxMayor = value;
            }
        }

        public decimal PV3
        {
            get
            {
                return _PV3;
            }

            set
            {
                _PV3 = value;
            }
        }

        public decimal PV4
        {
            get
            {
                return _PV4;
            }

            set
            {
                _PV4 = value;
            }
        }

        public decimal NroUnidades
        {
            get
            {
                return _NroUnidades;
            }

            set
            {
                _NroUnidades = value;
            }
        }

        public decimal PV5
        {
            get
            {
                return _PV5;
            }

            set
            {
                _PV5 = value;
            }
        }

        public DDetalleCompra() { }

        public DDetalleCompra(int idDetalleIngreso, int idIngreso, int idProducto, decimal precioVenta ,decimal precioCompra, decimal cantidad, string tipo, int cantXJabas, int nroJabas,
            decimal pesoJabaVacia, decimal pvxMenor, decimal pvxMayor, decimal pv3, decimal pv4, decimal pv5, decimal nroUnidades)
        {
            this.IdDetalleIngreso = idDetalleIngreso;
            this.IdIngreso = idIngreso;
            this.IdProducto = idProducto;
            this.PrecioVenta = precioVenta;
            this.PrecioCompra = precioCompra;
            this.Cantidad = cantidad;
            this.Tipo = tipo;
            this.CantXJabas = cantXJabas;
            this.NroJabas = nroJabas;
            this.PesoJabasVacias = pesoJabaVacia;
            this.PVxMenor = pvxMenor;
            this.PVxMayor = pvxMayor;
            this.PV3 = pv3;
            this.PV4 = pv4;
            this.PV5 = pv5;
            this.NroUnidades = nroUnidades;
        }

        public string Insertar(DDetalleCompra DetalleIngreso, ref SqlConnection sqlCon, ref SqlTransaction sqlTran)
        {
            string rpta = "";
            try
            {
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.Transaction = sqlTran;

                sqlCmd.CommandText = "sp_insertarDetalleCompra";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalleIngreso = new SqlParameter();
                ParIdDetalleIngreso.ParameterName = "@idDetalleIngreso";
                ParIdDetalleIngreso.SqlDbType = SqlDbType.Int;
                ParIdDetalleIngreso.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdDetalleIngreso);

                SqlParameter ParIdIngreso = new SqlParameter();
                ParIdIngreso.ParameterName = "@idIngreso";
                ParIdIngreso.SqlDbType = SqlDbType.Int;
                ParIdIngreso.Value = DetalleIngreso.IdIngreso;
                sqlCmd.Parameters.Add(ParIdIngreso);

                SqlParameter ParidProducto = new SqlParameter();
                ParidProducto.ParameterName = "@idProducto";
                ParidProducto.SqlDbType = SqlDbType.Int;
                ParidProducto.Value = DetalleIngreso.IdProducto;
                sqlCmd.Parameters.Add(ParidProducto);

                SqlParameter ParPrecioCompra = new SqlParameter();
                ParPrecioCompra.ParameterName = "@precioCompra";
                ParPrecioCompra.SqlDbType = SqlDbType.Money;
                ParPrecioCompra.Value = DetalleIngreso.PrecioCompra;
                sqlCmd.Parameters.Add(ParPrecioCompra);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Decimal;
                ParCantidad.Precision = 9;
                ParCantidad.Scale = 3;
                ParCantidad.Value = DetalleIngreso.Cantidad;
                sqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipo";
                ParTipo.SqlDbType = SqlDbType.Char;
                ParTipo.Size = 1;
                ParTipo.Value = DetalleIngreso.Tipo;
                sqlCmd.Parameters.Add(ParTipo);

                SqlParameter ParCantXJabas = new SqlParameter();
                ParCantXJabas.ParameterName = "@cantXJabas";
                ParCantXJabas.SqlDbType = SqlDbType.Int;
                ParCantXJabas.Value = DetalleIngreso.CantXJabas;
                sqlCmd.Parameters.Add(ParCantXJabas);

                SqlParameter ParNroJabas = new SqlParameter();
                ParNroJabas.ParameterName = "@nroJabas";
                ParNroJabas.SqlDbType = SqlDbType.Int;
                ParNroJabas.Value = DetalleIngreso.NroJabas;
                sqlCmd.Parameters.Add(ParNroJabas);

                SqlParameter ParPesoJabaVacias = new SqlParameter();
                ParPesoJabaVacias.ParameterName = "@pesoJabasVacias";
                ParPesoJabaVacias.SqlDbType = SqlDbType.Decimal;
                ParPesoJabaVacias.Precision = 9;
                ParPesoJabaVacias.Scale = 2;
                ParPesoJabaVacias.Value = DetalleIngreso.PesoJabasVacias;
                sqlCmd.Parameters.Add(ParPesoJabaVacias);

                SqlParameter ParPVxMenor = new SqlParameter();
                ParPVxMenor.ParameterName = "@pvxMenor";
                ParPVxMenor.SqlDbType = SqlDbType.Decimal;
                ParPVxMenor.Precision = 8;
                ParPVxMenor.Scale = 2;
                ParPVxMenor.Value = DetalleIngreso.PVxMenor;
                sqlCmd.Parameters.Add(ParPVxMenor);

                SqlParameter ParPVxMayor = new SqlParameter();
                ParPVxMayor.ParameterName = "@pvxMayor";
                ParPVxMayor.SqlDbType = SqlDbType.Decimal;
                ParPVxMayor.Precision = 8;
                ParPVxMayor.Scale = 2;
                ParPVxMayor.Value = DetalleIngreso.PVxMayor;
                sqlCmd.Parameters.Add(ParPVxMayor);

                SqlParameter ParPV3= new SqlParameter();
                ParPV3.ParameterName = "@pv3";
                ParPV3.SqlDbType = SqlDbType.Decimal;
                ParPV3.Precision = 8;
                ParPV3.Scale = 2;
                ParPV3.Value = DetalleIngreso.PV3;
                sqlCmd.Parameters.Add(ParPV3);

                SqlParameter ParPV4= new SqlParameter();
                ParPV4.ParameterName = "@pv4";
                ParPV4.SqlDbType = SqlDbType.Decimal;
                ParPV4.Precision = 8;
                ParPV4.Scale = 2;
                ParPV4.Value = DetalleIngreso.PV4;
                sqlCmd.Parameters.Add(ParPV4);

                SqlParameter ParPV5 = new SqlParameter();
                ParPV5.ParameterName = "@pv5";
                ParPV5.SqlDbType = SqlDbType.Decimal;
                ParPV5.Precision = 8;
                ParPV5.Scale = 2;
                ParPV5.Value = DetalleIngreso.PV5;
                sqlCmd.Parameters.Add(ParPV5);

                SqlParameter ParNroUnidades = new SqlParameter();
                ParNroUnidades.ParameterName = "@nroUnidades";
                ParNroUnidades.SqlDbType = SqlDbType.Decimal;
                ParNroUnidades.Precision = 8;
                ParNroUnidades.Scale = 2;
                ParNroUnidades.Value = DetalleIngreso.NroUnidades;
                sqlCmd.Parameters.Add(ParNroUnidades);

                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";
                //sqlCmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }
    }
}
