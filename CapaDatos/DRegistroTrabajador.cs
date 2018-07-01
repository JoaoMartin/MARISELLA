using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DRegistroTrabajador
    {
        private int _IdRegistro;
        private DateTime _Fecha;
        private string _Tipo;
        private int _IdPersona;

        public int IdRegistro
        {
            get
            {
                return _IdRegistro;
            }

            set
            {
                _IdRegistro = value;
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

        public int IdPersona
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

        public DRegistroTrabajador() { }

        public DRegistroTrabajador(int idRegistro, DateTime fecha, string tipo, int idPersona)
        {
            this.IdRegistro = idRegistro;
            this.Fecha = fecha;
            this.Tipo = tipo;
            this.IdPersona = idPersona;
        }

        public string Insertar(DRegistroTrabajador Registro)
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
                sqlCmd.CommandText = "sp_insertarRegistroTrabajador";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdRegistro = new SqlParameter();
                ParIdRegistro.ParameterName = "@idRegistroTrabajador";
                ParIdRegistro.SqlDbType = SqlDbType.Int;
                ParIdRegistro.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdRegistro);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Registro.Fecha;
                sqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipo";
                ParTipo.SqlDbType = SqlDbType.Char;
                ParTipo.Size = 1;
                ParTipo.Value = Registro.Tipo;
                sqlCmd.Parameters.Add(ParTipo);

                SqlParameter ParIdPersona = new SqlParameter();
                ParIdPersona.ParameterName = "@idPersona";
                ParIdPersona.SqlDbType = SqlDbType.Int;
                ParIdPersona.Value = Registro.IdPersona;
                sqlCmd.Parameters.Add(ParIdPersona);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el Registro";
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
                sqlCmd.CommandText = "sp_mostrarRegistroTrabajador";
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

       
    }
}
