using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NRegistroTrabajador
    {
        public static string Insertar(DateTime fecha, string tipo, int idPersona)
        {
            DRegistroTrabajador Obj = new DRegistroTrabajador();
            Obj.Fecha = fecha;
            Obj.Tipo = tipo;
            Obj.IdPersona = idPersona;
            return Obj.Insertar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DRegistroTrabajador().Mostrar();
        }

        public static DataTable Login(string dni, string password)
        {
            DPersona Obj = new DPersona();
            Obj.NumDoc = dni;
            Obj.Password = password;
            return Obj.LoginRegistro(Obj);
        }
    }
}
