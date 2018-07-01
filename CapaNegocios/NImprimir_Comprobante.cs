using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace CapaNegocios
{
    public class NImprimir_Comprobante
    {

        public static void imprimirCom(int idVenta, string tipoCompr, string cliente, string direccion, string nroDoc, string mesero, string salon, string mesa, DataGridView dgGeneral, string dctoInd,
            string dctoGral, string subTotal, string igv, string total, string efectivo, string vuelto, string tarjeta, string formaPago, string modoProducto,
            string redondeo, string telefono, string aliento, string fecha, string adelanto, string saldo)
        {
            DataTable dtNroCompr;
            NTicket ticket = new NTicket();
            ticket.AbreCajon();

            dtNroCompr = NComprobante.mostrarNroComprobante(idVenta, tipoCompr);
            string nroComprobante = dtNroCompr.Rows[0][0].ToString();
            string nroImpr = "";
            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro("Comercializadora Avicola");
            ticket.TextoCentro("CRUZAVE");
            ticket.TextoCentro("Venta de pollos al Por Mayor y Menor");

            //  ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
            ticket.TextoCentro("Av. Libertad s/n Valle Dorado -Pichari");
            // ticket.TextoCentro("RUC: 10428317004");
            ticket.TextoCentro("CEL:999303086" + "-" + "999141424");
            //ticket.TextoIzquierda("RAZON SOCIAL: JUAN CARLOS RIVERA MEZA");
            //ticket.TextoIzquierda("TELEF: 066 30 3567");
            //ticket.TextoIzquierda("RUC: 10106813731");
            // ticket.TextoIzquierda("EMAIL: jmsolorzano19@gmail.com");//Es el mio por si me quieren contactar ...
            // ticket.TextoIzquierda("");
            for (int i = 0; i < 6 - nroComprobante.Length; i++)
            {
                nroImpr += "0";
            }
            if (tipoCompr == "FACTURA")
            {
                ticket.TextoExtremos("Caja 1", "F" + "001-" + nroImpr + nroComprobante);
            }
            else if (tipoCompr == "BOLETA")
            {
                ticket.TextoExtremos("Caja 1", "B" + "001-" + nroImpr + nroComprobante);
            }
            else
            {
                ticket.TextoExtremos("Caja 1", tipoCompr + "-" + nroImpr + nroComprobante);
            }

            ticket.lineasAsteriscos();

            //Sub cabecera.
            // ticket.TextoIzquierda("");
            if (tipoCompr != "TICKET")
            {
                // ticket.TextoIzquierda("ATENDIO:" + mesero);
            }
            //  ticket.TextoIzquierda("ATENDIO:" + mesero);
            if (tipoCompr == "FACTURA")
            {
                ticket.TextoIzquierda("Nro RUC: " + nroDoc);
                ticket.TextoIzquierda("CLIENTE: " + cliente);
                ticket.TextoIzquierda("Dir.: " + direccion);
                if (telefono != "")
                {
                    ticket.TextoIzquierda("Tel: " + telefono);
                }
                ticket.TextoIzquierda("");
            }
            else if (tipoCompr == "BOLETA" || tipoCompr == "NOTA DE PEDIDO")
            {
                if (cliente == "")
                {
                    //ticket.TextoIzquierda("CLIENTE: PUBLICO GENERAL ");
                }
                else
                {
                    ticket.TextoIzquierda("CLIENTE: " + cliente);
                    if (direccion != "")
                    {
                        ticket.TextoIzquierda("Dir: " + direccion);
                    }
                    if (telefono != "")
                    {
                        ticket.TextoIzquierda("Tel: " + telefono);
                    }
                    ticket.TextoIzquierda("");
                }

            }

            // ticket.TextoIzquierda("");
            if (tipoCompr != "TICKET")
            {
                //ticket.TextoIzquierda("Salón: " + salon + " Mesa: " + mesa);
            }
            //ticket.TextoIzquierda("Salón: " + salon + " Mesa: " + mesa);
            //ticket.TextoIzquierda("");
            ticket.TextoIzquierda("FECHA: " + fecha);
            ticket.lineasAsteriscos();

            //Articulos a vender.
            ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasAsteriscos();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
            if (modoProducto == "Detallado")
            {

                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    ticket.AgregaArticulo(Convert.ToDecimal(fila.Cells[3].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[6].Value.ToString()),
                        Convert.ToDecimal(fila.Cells[2].Value.ToString()), Convert.ToDecimal(fila.Cells[4].Value.ToString()));
                    //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
                    // decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
                }
            }
            else if (modoProducto == "Detallados")
            {
                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    //ticket.AgregaArticulo(Convert.ToDecimal(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[6].Value.ToString()));

                }
            }
            else if (modoProducto == "Detallado_Cr")
            {
                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    // ticket.AgregaArticulo(Convert.ToDecimal(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[6].Value.ToString()));

                }
            }
            else if (modoProducto == "Por Consumos")
            {
                ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total), Convert.ToDecimal(total), Convert.ToDecimal(total));
            }
            else if (modoProducto == "Por Consumo")
            {
                ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total), Convert.ToDecimal(total), Convert.ToDecimal(total));
            }

            /*
            ticket.AgregaArticulo("Articulo A", 2, 20, 40);
            ticket.AgregaArticulo("Articulo B", 1, 10, 10);
            ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);*/
            ticket.lineasIgual1();

            //Resumen de la venta. Sólo son ejemplos
            /*if(tipoCompr == "BOLETA" || tipoCompr !="FACTURA")
            {
                ticket.AgregarTotales("         SUBTOTAL......S/", Convert.ToDecimal(subTotal));

                if (dctoInd != "00.00")
                {
                    ticket.AgregarTotales("         DSCTO IND.....S/ ", Convert.ToDecimal(dctoInd));
                }
                if (dctoGral != "00.00")
                {
                    ticket.AgregarTotales("         DSCTO GENERAL.S/ ", Convert.ToDecimal(dctoGral));
                }
                if (redondeo != "00.00")
                {
                    ticket.AgregarTotales("         REDONDEO......S/ ", Convert.ToDecimal(redondeo));
                }
                ticket.AgregarTotales("         IGV...........S/", Convert.ToDecimal(igv));//La M indica que es un decimal en C#
               
            }*/

            ticket.AgregarTotales("         TOTAL...................S/", Convert.ToDecimal(total));
            ticket.TextoIzquierda("");


            if (formaPago == "EFECTIVO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "TARJETA")
            {
                ticket.TextoIzquierda("         PAGA CON TARJETA");
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "MIXTO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         TARJETA.......S/", Convert.ToDecimal(tarjeta));
            }
            else if (formaPago == "CREDITO_E")
            {
                if (adelanto.Length == 0)
                {

                }
                else
                {
                    ticket.AgregarTotales("         ADELANTO.....S/", Convert.ToDecimal(adelanto));
                    ticket.AgregarTotales("         SALDO........S/", Convert.ToDecimal(saldo));
                }

            }


            //Texto final del Ticket.
            // ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: 3");
            ticket.TextoIzquierda("");
            ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            if (tipoCompr == "TICKET")
            {
                ticket.TextoIzquierda("Este documento no es un comprobante fiscal");
                ticket.TextoIzquierda("Canjee este documento por una boleta/factura");
            }
            ticket.TextoCentro("");
            ticket.TextoCentro(aliento);
            ticket.CortaTicket();
            /*
            if(tipoCompr == "TICKET")
            {
                //ticket.ImprimirTicket("COCINA");//Nombre de la impresora ticketera
                ticket.ImprimirTicket("Microsoft XPS Document Writer");

            }
            else
            {
               // ticket.ImprimirTicket("EPSON TM-U220 Receipt");//Nombre de la impresora ticketera
                ticket.ImprimirTicket("Microsoft XPS Document Writer");

            }*/

            // ticket.ImprimirTicket("Microsoft XPS Document Writer");
            ticket.ImprimirTicket("CAJA");
            //  ticket.ImprimirTicket("EPSON TM-U220 Receipt");//Nombre de la impresora ticketera
        }


        public static void imprimirComRepetido(string nroComprobante, string tipoCompr, string cliente, string direccion, string nroDoc,
            string salon, string mesa, DataGridView dgGeneral, string dctoInd, string dctoGral, string subTotal, string igv, string total, string efectivo, string tarjeta,
            string formaPago, string modoProducto, string redondeo, string telefono, string vuelto, string fecha, string mesero, string aliento, string adelanto, string saldo)
        {

            NTicket ticket = new NTicket();
            ticket.AbreCajon();

            string nroImpr = "";
            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro("Comercializadora Avicola");
            ticket.TextoCentro("CRUZAVE");
            ticket.TextoCentro("Venta de pollos al Por Mayor y Menor");

            //  ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
            ticket.TextoCentro("Av. Libertad s/n Valle Dorado -Pichari");
            // ticket.TextoCentro("RUC: 10428317004");
            ticket.TextoCentro("CEL:999303086" + "-" + "999141424");


            //ticket.TextoIzquierda("RAZON SOCIAL: JUAN CARLOS RIVERA MEZA");
            //ticket.TextoIzquierda("TELEF: 066 30 3567");
            //ticket.TextoIzquierda("RUC: 10106813731");
            // ticket.TextoIzquierda("EMAIL: jmsolorzano19@gmail.com");//Es el mio por si me quieren contactar ...
            // ticket.TextoIzquierda("");
            for (int i = 0; i < 6 - nroComprobante.Length; i++)
            {
                nroImpr += "0";
            }
            if (tipoCompr == "FACTURA")
            {
                ticket.TextoExtremos("Caja 1", "F" + "001-" + nroImpr + nroComprobante);
            }
            else if (tipoCompr == "BOLETA")
            {
                ticket.TextoExtremos("Caja 1", "B" + "001-" + nroImpr + nroComprobante);
            }
            else
            {
                ticket.TextoExtremos("Caja 1", tipoCompr + "-" + nroImpr + nroComprobante);
            }

            ticket.lineasAsteriscos();

            //Sub cabecera.
            //ticket.TextoIzquierda("");
            // ticket.TextoIzquierda("ATENDIO:" + mesero);
            if (tipoCompr == "FACTURA")
            {
                ticket.TextoIzquierda("Nro RUC: " + nroDoc);
                ticket.TextoIzquierda("CLIENTE: " + cliente);
                ticket.TextoIzquierda("Dir.: " + direccion);
                if (telefono != "")
                {
                    ticket.TextoIzquierda("Tel: " + telefono);
                }
                ticket.TextoIzquierda("");
            }
            else if (tipoCompr == "BOLETA" || tipoCompr == "NOTA DE PEDIDO")
            {
                if (cliente == "")
                {
                    // ticket.TextoIzquierda("CLIENTE: PUBLICO GENERAL ");
                }
                else
                {
                    ticket.TextoIzquierda("CLIENTE: " + cliente);
                    if (direccion != "")
                    {
                        ticket.TextoIzquierda("Dir: " + direccion);
                    }
                    if (telefono != "")
                    {
                        ticket.TextoIzquierda("Tel: " + telefono);
                    }
                    ticket.TextoIzquierda("");
                }

            }

            // ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("Salón: " + salon + " Mesa: " + mesa);
            //ticket.TextoIzquierda("");
            ticket.TextoIzquierda("FECHA: " + fecha);
            ticket.lineasAsteriscos();

            //Articulos a vender.
            ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasAsteriscos();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
            if (modoProducto == "Detallado")
            {

                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    //ticket.AgregaArticulo(Convert.ToDecimal(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[5].Value.ToString()));
                    //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
                    // decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
                    ticket.AgregaArticulo(Convert.ToDecimal(fila.Cells[3].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[2].Value.ToString()) *
                        Convert.ToDecimal(fila.Cells[4].Value.ToString()),
                       Convert.ToDecimal(fila.Cells[2].Value.ToString()), Convert.ToDecimal(fila.Cells[4].Value.ToString()));
                }
            }
            else if (modoProducto == "Detallados")
            {
                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    ticket.AgregaArticulo(Convert.ToDecimal(fila.Cells[3].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[6].Value.ToString()),
                        Convert.ToDecimal(fila.Cells[2].Value.ToString()), Convert.ToDecimal(fila.Cells[4].Value.ToString()));

                }
            }
            else if (modoProducto == "Por Consumos")

            {
                // ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }
            else if (modoProducto == "Por Consumo")
            {
                // ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }

            /*
            ticket.AgregaArticulo("Articulo A", 2, 20, 40);
            ticket.AgregaArticulo("Articulo B", 1, 10, 10);
            ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);*/
            ticket.lineasIgual1();

            //Resumen de la venta. Sólo son ejemplos
            /* if(tipoCompr != "TICKET" || tipoCompr !="NOTA DE PEDIDO")
             {
                 ticket.AgregarTotales("         SUBTOTAL......S/", Convert.ToDecimal(subTotal));

                 if (dctoInd != "0.00")
                 {
                     ticket.AgregarTotales("         DSCTO IND.....S/ ", Convert.ToDecimal(dctoInd));
                 }
                 if (dctoGral != "0.00")
                 {
                     ticket.AgregarTotales("         DSCTO GENERAL.S/ ", Convert.ToDecimal(dctoGral));
                 }
                 if (redondeo != "0.00")
                 {
                     ticket.AgregarTotales("         REDONDEO......S/ ", Convert.ToDecimal(redondeo));
                 }
                 ticket.AgregarTotales("         IGV...........S/", Convert.ToDecimal(igv));//La M indica que es un decimal en C#
             }

             */

            ticket.AgregarTotales("         TOTAL......................S/", Convert.ToDecimal(total));
            // ticket.TextoIzquierda("");


            if (formaPago == "EFECTIVO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "TARJETA")
            {
                ticket.TextoIzquierda("         PAGA CON TARJETA");
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "MIXTO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         TARJETA.......S/", Convert.ToDecimal(tarjeta));
            }
            else if (formaPago == "CREDITO")
            {
                if (adelanto.Length == 0 || adelanto == "00.00" || adelanto == "0.00")
                {

                }
                else
                {
                    ticket.AgregarTotales("         ADELANTO.....S/", Convert.ToDecimal(adelanto));
                    ticket.AgregarTotales("         SALDO........S/", Convert.ToDecimal(saldo));
                }

            }

            //Texto final del Ticket.
            //ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: 3");
            ticket.TextoIzquierda("");
            ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            if (tipoCompr == "TICKET")
            {
                ticket.TextoIzquierda("Este documento no es un comprobante fiscal");
                ticket.TextoIzquierda("Canjee este documento por una boleta/factura");
            }
            ticket.TextoCentro("");
            ticket.TextoCentro(aliento);
            ticket.CortaTicket();
            /*
            if(tipoCompr == "TICKET")
            {
                //ticket.ImprimirTicket("COCINA");//Nombre de la impresora ticketera
                ticket.ImprimirTicket("Microsoft XPS Document Writer");

            }
            else
            {
               // ticket.ImprimirTicket("EPSON TM-U220 Receipt");//Nombre de la impresora ticketera
                ticket.ImprimirTicket("Microsoft XPS Document Writer");

            }*/
             ticket.ImprimirTicket("CAJA");
            //ticket.ImprimirTicket("CAJA1");
           // ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
            //ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
        }

        public static void imprimirCambioCompr(int idVenta, string tipoCompr, string cliente, string direccion, string nroDoc, string salon, string mesa, DataGridView dgGeneral, string dctoInd, string dctoGral, string subTotal, string igv, string total, string efectivo, string vuelto, string tarjeta, string formaPago, string modoProducto, string redondeo, string telefono)
        {
            DataTable dtNroCompr;
            NTicket ticket = new NTicket();
            ticket.AbreCajon();

            dtNroCompr = NComprobante.mostrarNroComprobante(idVenta, tipoCompr);
            string nroComprobante = dtNroCompr.Rows[0][0].ToString();
            string nroImpr = "";
            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro("Comercializadora de Aves & Transporte");
            ticket.TextoCentro("JAVICHO");
            ticket.TextoCentro("Venta de pollos al Por Mayo y Menor");

            //  ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");

            ticket.TextoCentro("Av. Libertad s/n Valle Dorado -Pichari");
            ticket.TextoCentro("RUC: 10428317004");
            ticket.TextoIzquierda("Claro:999342042" + "-" + "999342737" + "-" + "989861196");
            //ticket.TextoIzquierda("RAZON SOCIAL: JUAN CARLOS RIVERA MEZA");
            //ticket.TextoIzquierda("TELEF: 066 30 3567");
            //ticket.TextoIzquierda("RUC: 10106813731");
            // ticket.TextoIzquierda("EMAIL: jmsolorzano19@gmail.com");//Es el mio por si me quieren contactar ...
            //ticket.TextoIzquierda("");
            for (int i = 0; i < 7 - nroComprobante.Length; i++)
            {
                nroImpr += "0";
            }
            for (int i = 0; i < 7 - nroComprobante.Length; i++)
            {
                nroImpr += "0";
            }
            if (tipoCompr == "FACTURA")
            {
                ticket.TextoExtremos("Caja 1", "F" + "001-" + nroImpr + nroComprobante);
            }
            else if (tipoCompr == "BOLETA")
            {
                ticket.TextoExtremos("Caja 1", "B" + "001-" + nroImpr + nroComprobante);
            }
            else
            {
                ticket.TextoExtremos("Caja 1", tipoCompr + "001-" + nroImpr + nroComprobante);
            }
            ticket.lineasAsteriscos();

            //Sub cabecera.
            ticket.TextoIzquierda("");
            if (tipoCompr == "FACTURA")
            {
                ticket.TextoIzquierda("Nro RUC: " + nroDoc);
                ticket.TextoIzquierda("CLIENTE: " + cliente);
                ticket.TextoIzquierda("Dir.: " + direccion);
                if (telefono != "")
                {
                    ticket.TextoIzquierda("Tel: " + telefono);
                }
                ticket.TextoIzquierda("");
            }
            else if (tipoCompr == "BOLETA")
            {
                if (cliente == "")
                {
                    //ticket.TextoIzquierda("CLIENTE: PUBLICO GENERAL ");
                }
                else if (tipoCompr == "BOLETA" || tipoCompr == "NOTA DE PEDIDO")
                {
                    if (cliente == "")
                    {
                        //ticket.TextoIzquierda("CLIENTE: PUBLICO GENERAL ");
                    }
                    else
                    {
                        ticket.TextoIzquierda("CLIENTE: " + cliente);
                        if (direccion != "")
                        {
                            ticket.TextoIzquierda("Dir: " + direccion);
                        }
                        if (telefono != "")
                        {
                            ticket.TextoIzquierda("Tel: " + telefono);
                        }
                        ticket.TextoIzquierda("");
                    }

                }

            }

            // ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("Salón: " + salon + " Mesa: " + mesa);
            //ticket.TextoIzquierda("");
            ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
            ticket.lineasAsteriscos();

            //Articulos a vender.
            ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasAsteriscos();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
            if (modoProducto == "Detallado")
            {

                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    //ticket.AgregaArticulo(Convert.ToDecimal(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[5].Value.ToString()));
                    //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
                    // decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
                }
            }
            else if (modoProducto == "Detallados")
            {
                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    // ticket.AgregaArticulo(Convert.ToDecimal(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[6].Value.ToString()));

                }
            }
            else if (modoProducto == "Por Consumos")
            {
                // ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }
            else if (modoProducto == "Por Consumo")
            {
                //ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }

            /*
            ticket.AgregaArticulo("Articulo A", 2, 20, 40);
            ticket.AgregaArticulo("Articulo B", 1, 10, 10);
            ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);*/
            ticket.lineasIgual();

            if (tipoCompr != "TICKET")
            {
                //Resumen de la venta. Sólo son ejemplos
                ticket.AgregarTotales("         SUBTOTAL......S/", Convert.ToDecimal(subTotal));

                if (dctoInd != "00.00")
                {
                    ticket.AgregarTotales("         DSCTO IND.....S/ ", Convert.ToDecimal(dctoInd));
                }
                if (dctoGral != "00.00")
                {
                    ticket.AgregarTotales("         DSCTO GENERAL.S/ ", Convert.ToDecimal(dctoGral));
                }
                if (redondeo != "00.00")
                {
                    ticket.AgregarTotales("         REDONDEO......S/ ", Convert.ToDecimal(redondeo));
                }
                ticket.AgregarTotales("         IGV...........S/", Convert.ToDecimal(igv));//La M indica que es un decimal en C#
            }

            ticket.AgregarTotales("         TOTAL.........S/", Convert.ToDecimal(total));
            ticket.TextoIzquierda("");


            if (formaPago == "EFECTIVO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "TARJETA")
            {
                ticket.TextoIzquierda("         PAGA CON TARJETA");
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "MIXTO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         TARJETA.......S/", Convert.ToDecimal(tarjeta));
            }


            //Texto final del Ticket.
            // ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: 3");
            ticket.TextoIzquierda("");
            ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            if (tipoCompr == "TICKET")
            {
                ticket.TextoIzquierda("Este documento no es un comprobante fiscal");
                ticket.TextoIzquierda("Canjee este documento por una boleta/factura");
            }
            ticket.CortaTicket();
            /*
                      if(tipoCompr == "TICKET")
                      {
                          //ticket.ImprimirTicket("COCINA");//Nombre de la impresora ticketera
                          ticket.ImprimirTicket("Microsoft XPS Document Writer");

                      }
                      else
                      {
                         // ticket.ImprimirTicket("EPSON TM-U220 Receipt");//Nombre de la impresora ticketera
                          ticket.ImprimirTicket("Microsoft XPS Document Writer");

                      }*/
            // ticket.ImprimirTicket("CAJA");
            // ticket.ImprimirTicket("CAJA1");
            ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
                                                                   // ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
        }

        public static void imprimirComManual(int idVenta, string tipoCompr, string cliente, string serie, string nroCom, string direccion, string nroDoc, string mesero, string salon, string mesa, DataGridView dgGeneral, string dctoInd, string dctoGral, string subTotal, string igv, string total, string efectivo, string vuelto, string tarjeta, string formaPago, string modoProducto, string redondeo, string telefono)
        {

            NTicket ticket = new NTicket();
            ticket.AbreCajon();


            string nroImpr = "";
            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro("Comercializadora de Aves & Transporte");
            ticket.TextoCentro("Venta de pollos al Por Mayo y Menor");

            //  ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
            ticket.TextoCentro("Av. Libertad s/n Valle Dorado -Pichari");
            ticket.TextoCentro("RUC: 20304455463");
            //ticket.TextoIzquierda("RAZON SOCIAL: JUAN CARLOS RIVERA MEZA");
            //ticket.TextoIzquierda("TELEF: 066 30 3567");
            //ticket.TextoIzquierda("RUC: 10106813731");
            // ticket.TextoIzquierda("EMAIL: jmsolorzano19@gmail.com");//Es el mio por si me quieren contactar ...
            // ticket.TextoIzquierda("");
            for (int i = 0; i < 7 - nroCom.Length; i++)
            {
                nroImpr += "0";
            }
            for (int i = 0; i < 7 - nroCom.Length; i++)
            {
                nroImpr += "0";
            }
            if (tipoCompr == "FACTURA")
            {
                ticket.TextoExtremos("Caja 1", "F" + "001-" + nroImpr + nroCom);
            }
            else if (tipoCompr == "BOLETA")
            {
                ticket.TextoExtremos("Caja 1", "B" + "001-" + nroImpr + nroCom);
            }
            else
            {
                ticket.TextoExtremos("Caja 1", tipoCompr + "001-" + nroImpr + nroCom);
            }
            ticket.lineasAsteriscos();

            //Sub cabecera.
            ticket.TextoIzquierda("");
            // ticket.TextoIzquierda("ATENDIO:" + mesero);
            if (tipoCompr == "FACTURA MANUAL")
            {
                ticket.TextoIzquierda("Nro RUC: " + nroDoc);
                ticket.TextoIzquierda("CLIENTE: " + cliente);
                ticket.TextoIzquierda("Dir.: " + direccion);
                if (telefono != "")
                {
                    ticket.TextoIzquierda("Tel: " + telefono);
                }
                ticket.TextoIzquierda("");
            }
            else if (tipoCompr == "TICKET")
            {
                if (cliente == "")
                {
                    //ticket.TextoIzquierda("CLIENTE: PUBLICO GENERAL ");
                }
                else
                {
                    ticket.TextoIzquierda("CLIENTE: " + cliente);
                    if (direccion != "")
                    {
                        ticket.TextoIzquierda("Dir: " + direccion);
                    }
                    if (telefono != "")
                    {
                        ticket.TextoIzquierda("Tel: " + telefono);
                    }
                    ticket.TextoIzquierda("");
                }

            }

            //ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("Salón: " + salon + " Mesa: " + mesa);
            //ticket.TextoIzquierda("");
            ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
            ticket.lineasAsteriscos();

            //Articulos a vender.
            ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasAsteriscos();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
            if (modoProducto == "Detallado")
            {

                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    // ticket.AgregaArticulo(Convert.ToDecimal(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[5].Value.ToString()));
                    //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
                    // decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
                }
            }
            else if (modoProducto == "Detallados")
            {
                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    // ticket.AgregaArticulo(Convert.ToDecimal(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[6].Value.ToString()));

                }
            }
            else if (modoProducto == "Por Consumos")
            {
                // ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }
            else if (modoProducto == "Por Consumo")
            {
                // ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }

            /*
            ticket.AgregaArticulo("Articulo A", 2, 20, 40);
            ticket.AgregaArticulo("Articulo B", 1, 10, 10);
            ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);*/
            ticket.lineasIgual();

            //Resumen de la venta. Sólo son ejemplos
            if (tipoCompr != "TICKET")
            {
                ticket.AgregarTotales("         SUBTOTAL......S/", Convert.ToDecimal(subTotal));

                if (dctoInd != "00.00")
                {
                    ticket.AgregarTotales("         DSCTO IND.....S/ ", Convert.ToDecimal(dctoInd));
                }
                if (dctoGral != "00.00")
                {
                    ticket.AgregarTotales("         DSCTO GENERAL.S/ ", Convert.ToDecimal(dctoGral));
                }
                if (redondeo != "00.00")
                {
                    ticket.AgregarTotales("         REDONDEO......S/ ", Convert.ToDecimal(redondeo));
                }
                ticket.AgregarTotales("         IGV...........S/", Convert.ToDecimal(igv));//La M indica que es un decimal en C#
            }

            ticket.AgregarTotales("         TOTAL.........S/", Convert.ToDecimal(total));
            ticket.TextoIzquierda("");


            if (formaPago == "EFECTIVO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "TARJETA")
            {
                ticket.TextoIzquierda("         PAGA CON TARJETA");
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "MIXTO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         TARJETA.......S/", Convert.ToDecimal(tarjeta));
            }


            //Texto final del Ticket.
            //ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: 3");
            ticket.TextoIzquierda("");
            ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            if (tipoCompr == "TICKET")
            {
                ticket.TextoIzquierda("Este documento no es un comprobante fiscal");
                ticket.TextoIzquierda("Canjee este documento por una boleta/factura");
            }
            ticket.CortaTicket();
            /*
                   if(tipoCompr == "TICKET")
                   {
                       //ticket.ImprimirTicket("COCINA");//Nombre de la impresora ticketera
                       ticket.ImprimirTicket("Microsoft XPS Document Writer");

                   }
                   else
                   {
                      // ticket.ImprimirTicket("EPSON TM-U220 Receipt");//Nombre de la impresora ticketera
                       ticket.ImprimirTicket("Microsoft XPS Document Writer");

                   }*/
            //ticket.ImprimirTicket("Microsoft XPS Document Writer");
            ticket.ImprimirTicket("CAJA");
            //  ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
            // ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
        }


        public static void imprimirComRepetidoManual(string serie, string nroComprobante, string tipoCompr, string cliente, string direccion, string nroDoc, string salon,
            string mesa, DataGridView dgGeneral, string dctoInd, string dctoGral, string subTotal, string igv, string total, string efectivo, string tarjeta, string formaPago,
            string modoProducto, string redondeo, string telefono, string vuelto, string fecha)
        {

            NTicket ticket = new NTicket();
            ticket.AbreCajon();

            string nroImpr = "";
            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro("Comercializadora de Aves & Transporte");
            ticket.TextoCentro("Venta de pollos al Por Mayo y Menor");
            ticket.TextoCentro("Inversiones Lalos S.R.L");
            //  ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
            ticket.TextoCentro("Av. Libertad s/n Valle Dorado -Pichari");
            ticket.TextoCentro("RUC: 20304455463");
            //ticket.TextoIzquierda("RAZON SOCIAL: JUAN CARLOS RIVERA MEZA");
            //ticket.TextoIzquierda("TELEF: 066 30 3567");
            //ticket.TextoIzquierda("RUC: 10106813731");
            // ticket.TextoIzquierda("EMAIL: jmsolorzano19@gmail.com");//Es el mio por si me quieren contactar ...
            // ticket.TextoIzquierda("");
            for (int i = 0; i < 7 - nroComprobante.Length; i++)
            {
                nroImpr += "0";
            }
            for (int i = 0; i < 7 - nroComprobante.Length; i++)
            {
                nroImpr += "0";
            }
            if (tipoCompr == "FACTURA")
            {
                ticket.TextoExtremos("Caja 1", "F" + "001-" + nroImpr + nroComprobante);
            }
            else if (tipoCompr == "BOLETA")
            {
                ticket.TextoExtremos("Caja 1", "B" + "001-" + nroImpr + nroComprobante);
            }
            else
            {
                ticket.TextoExtremos("Caja 1", tipoCompr + "001-" + nroImpr + nroComprobante);
            }
            ticket.lineasAsteriscos();

            //Sub cabecera.
            //ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("ATENDIO:" + mesero);
            if (tipoCompr == "FACTURA MANUAL")
            {
                ticket.TextoIzquierda("Nro RUC: " + nroDoc);
                ticket.TextoIzquierda("CLIENTE: " + cliente);
                ticket.TextoIzquierda("Dir.: " + direccion);
                if (telefono != "")
                {
                    ticket.TextoIzquierda("Tel: " + telefono);
                }
                ticket.TextoIzquierda("");
            }
            else if (tipoCompr == "BOLETA")
            {
                if (cliente == "")
                {
                    ticket.TextoIzquierda("CLIENTE: PUBLICO GENERAL ");
                }
                else
                {
                    ticket.TextoIzquierda("CLIENTE: " + cliente);
                    if (direccion != "")
                    {
                        ticket.TextoIzquierda("Dir: " + direccion);
                    }
                    if (telefono != "")
                    {
                        ticket.TextoIzquierda("Tel: " + telefono);
                    }
                    ticket.TextoIzquierda("");
                }

            }

            // ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("Salón: " + salon + " Mesa: " + mesa);
            //ticket.TextoIzquierda("");
            ticket.TextoExtremos("FECHA: ", fecha);
            ticket.lineasAsteriscos();

            //Articulos a vender.
            ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasAsteriscos();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
            if (modoProducto == "Detallado")
            {

                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    // ticket.AgregaArticulo(Convert.ToDecimal(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[5].Value.ToString()));
                    //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
                    // decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
                }
            }
            else if (modoProducto == "Detallados")
            {
                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    //ticket.AgregaArticulo(Convert.ToDecimal(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[6].Value.ToString()));

                }
            }
            else if (modoProducto == "Por Consumos")
            {
                // ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }
            else if (modoProducto == "Por Consumo")
            {
                // ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }

            /*
            ticket.AgregaArticulo("Articulo A", 2, 20, 40);
            ticket.AgregaArticulo("Articulo B", 1, 10, 10);
            ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);*/
            ticket.lineasIgual();

            //Resumen de la venta. Sólo son ejemplos
            if (tipoCompr != "TICKET")
            {
                ticket.AgregarTotales("         SUBTOTAL......S/", Convert.ToDecimal(subTotal));

                if (dctoInd != "0.00")
                {
                    ticket.AgregarTotales("         DSCTO IND.....S/ ", Convert.ToDecimal(dctoInd));
                }
                if (dctoGral != "0.00")
                {
                    ticket.AgregarTotales("         DSCTO GENERAL.S/ ", Convert.ToDecimal(dctoGral));
                }
                if (redondeo != "0.00")
                {
                    ticket.AgregarTotales("         REDONDEO......S/ ", Convert.ToDecimal(redondeo));
                }
                ticket.AgregarTotales("         IGV...........S/", Convert.ToDecimal(igv));//La M indica que es un decimal en C#
            }


            ticket.AgregarTotales("         TOTAL.........S/", Convert.ToDecimal(total));
            ticket.TextoIzquierda("");


            if (formaPago == "EFECTIVO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "TARJETA")
            {
                ticket.TextoIzquierda("         PAGA CON TARJETA");
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "MIXTO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         TARJETA.......S/", Convert.ToDecimal(tarjeta));
            }


            //Texto final del Ticket.
            // ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: 3");
            ticket.TextoIzquierda("");
            ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            if (tipoCompr == "TICKET")
            {
                ticket.TextoIzquierda("Este documento no es un comprobante fiscal");
                ticket.TextoIzquierda("Canjee este documento por una boleta/factura");
            }
            ticket.CortaTicket();
            /*
                      if(tipoCompr == "TICKET")
                      {
                          //ticket.ImprimirTicket("COCINA");//Nombre de la impresora ticketera
                          ticket.ImprimirTicket("Microsoft XPS Document Writer");

                      }
                      else
                      {
                         // ticket.ImprimirTicket("EPSON TM-U220 Receipt");//Nombre de la impresora ticketera
                          ticket.ImprimirTicket("Microsoft XPS Document Writer");

                      }*/
            //
            //  ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
            ticket.ImprimirTicket("CAJA");//Nombre de la impresora ticketera
                                          // ticket.ImprimirTicket("CAJA1");

        }


        public static void imprimirComR(int idVenta, string tipoCompr, string cliente, string direccion, string nroDoc, DataGridView dgGeneral, string dctoInd, string dctoGral, string subTotal, string igv, string total,
            string efectivo, string vuelto, string tarjeta, string formaPago, string modoProducto, string redondeo, string telefono, string adelanto, string mesero, string aliento)
        {
            DataTable dtNroCompr;
            NTicket ticket = new NTicket();
            ticket.AbreCajon();

            dtNroCompr = NComprobante.mostrarNroComprobante(idVenta, tipoCompr);
            string nroComprobante = dtNroCompr.Rows[0][0].ToString();
            string nroImpr = "";
            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro("Comercializadora de Aves & Transporte");
            ticket.TextoCentro("Venta de pollos al Por Mayo y Menor");

            //  ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
            ticket.TextoCentro("Av. Libertad s/n Valle Dorado -Pichari");
            ticket.TextoCentro("RUC: 20304455463");
            //ticket.TextoIzquierda("RAZON SOCIAL: JUAN CARLOS RIVERA MEZA");
            //ticket.TextoIzquierda("TELEF: 066 30 3567");
            //ticket.TextoIzquierda("RUC: 10106813731");
            // ticket.TextoIzquierda("EMAIL: jmsolorzano19@gmail.com");//Es el mio por si me quieren contactar ...
            // ticket.TextoIzquierda("");
            for (int i = 0; i < 7 - nroComprobante.Length; i++)
            {
                nroImpr += "0";
            }
            for (int i = 0; i < 7 - nroComprobante.Length; i++)
            {
                nroImpr += "0";
            }
            if (tipoCompr == "FACTURA")
            {
                ticket.TextoExtremos("Caja 1", "F" + "001-" + nroImpr + nroComprobante);
            }
            else if (tipoCompr == "BOLETA")
            {
                ticket.TextoExtremos("Caja 1", "B" + "001-" + nroImpr + nroComprobante);
            }
            else
            {
                ticket.TextoExtremos("Caja 1", tipoCompr + "001-" + nroImpr + nroComprobante);
            }
            ticket.lineasAsteriscos();

            //Sub cabecera.
            // ticket.TextoIzquierda("");
            ticket.TextoIzquierda("ATENDIO:" + mesero);
            if (tipoCompr != "TICKET")
            {
                // ticket.TextoIzquierda("ATENDIO:" + mesero);
            }

            if (tipoCompr == "FACTURA")
            {
                ticket.TextoIzquierda("Nro RUC: " + nroDoc);
                ticket.TextoIzquierda("CLIENTE: " + cliente);
                ticket.TextoIzquierda("Dir.: " + direccion);
                if (telefono != "")
                {
                    ticket.TextoIzquierda("Tel: " + telefono);
                }
                ticket.TextoIzquierda("");
            }
            else if (tipoCompr == "BOLETA")
            {
                if (cliente == "")
                {
                    //ticket.TextoIzquierda("CLIENTE: PUBLICO GENERAL ");
                }
                else
                {
                    ticket.TextoIzquierda("CLIENTE: " + cliente);
                    if (direccion != "")
                    {
                        ticket.TextoIzquierda("Dir: " + direccion);
                    }
                    if (telefono != "")
                    {
                        ticket.TextoIzquierda("Tel: " + telefono);
                    }
                    ticket.TextoIzquierda("");
                }

            }

            // ticket.TextoIzquierda("");
            if (tipoCompr != "TICKET")
            {
                //ticket.TextoIzquierda("Salón: " + salon + " Mesa: " + mesa);
            }
            //ticket.TextoIzquierda("Salón: " + salon + " Mesa: " + mesa);
            //ticket.TextoIzquierda("");
            ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
            ticket.lineasAsteriscos();

            //Articulos a vender.
            ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasAsteriscos();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
            if (modoProducto == "Detallado")
            {

                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    // ticket.AgregaArticulo(Convert.ToDecimal(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[5].Value.ToString()));
                    //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
                    // decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
                }
            }
            else if (modoProducto == "Detallados")
            {
                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    //ticket.AgregaArticulo(Convert.ToDecimal(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[6].Value.ToString()));

                }
            }
            else if (modoProducto == "Por Consumos")
            {
                //ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }
            else if (modoProducto == "Por Consumo")
            {
                // ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }

            /*
            ticket.AgregaArticulo("Articulo A", 2, 20, 40);
            ticket.AgregaArticulo("Articulo B", 1, 10, 10);
            ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);*/
            ticket.lineasIgual();

            //Resumen de la venta. Sólo son ejemplos
            if (tipoCompr != "TICKET")
            {
                ticket.AgregarTotales("         SUBTOTAL......S/", Convert.ToDecimal(subTotal));

                if (dctoInd != "00.00")
                {
                    ticket.AgregarTotales("         DSCTO IND.....S/ ", Convert.ToDecimal(dctoInd));
                }
                if (dctoGral != "00.00")
                {
                    ticket.AgregarTotales("         DSCTO GENERAL.S/ ", Convert.ToDecimal(dctoGral));
                }
                if (redondeo != "00.00")
                {
                    ticket.AgregarTotales("         REDONDEO......S/ ", Convert.ToDecimal(redondeo));
                }




                ticket.AgregarTotales("         IGV...........S/", Convert.ToDecimal(igv));//La M indica que es un decimal en C#

            }
            ticket.AgregarTotales("         ADELANTO......S/ ", Convert.ToDecimal(adelanto));
            ticket.AgregarTotales("         TOTAL.........S/", Convert.ToDecimal(total));
            ticket.TextoIzquierda("");


            if (formaPago == "EFECTIVO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "TARJETA")
            {
                ticket.TextoIzquierda("         PAGA CON TARJETA");
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "MIXTO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         TARJETA.......S/", Convert.ToDecimal(tarjeta));
            }


            //Texto final del Ticket.
            // ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: 3");
            ticket.TextoIzquierda("");
            ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            if (tipoCompr == "TICKET")
            {
                ticket.TextoIzquierda("Este documento no es un comprobante fiscal");
                ticket.TextoIzquierda("Canjee este documento por una boleta/factura");
            }
            ticket.TextoCentro("");
            ticket.TextoCentro(aliento);
            ticket.CortaTicket();
            /*
            if(tipoCompr == "TICKET")
            {
                //ticket.ImprimirTicket("COCINA");//Nombre de la impresora ticketera
                ticket.ImprimirTicket("Microsoft XPS Document Writer");

            }
            else
            {
               // ticket.ImprimirTicket("EPSON TM-U220 Receipt");//Nombre de la impresora ticketera
                ticket.ImprimirTicket("Microsoft XPS Document Writer");

            }*/
            ticket.ImprimirTicket("Microsoft XPS Document Writer");
            //  ticket.ImprimirTicket("CAJA");
            //  ticket.ImprimirTicket("EPSON TM-U220 Receipt");//Nombre de la impresora ticketera
        }

        public static void imprimirComPrueba(int idVenta, string tipoCompr, string cliente, string direccion, string nroDoc, string mesero, string salon, string mesa, DataGridView dgGeneral, string dctoInd,
    string dctoGral, string subTotal, string igv, string total, string efectivo, string vuelto, string tarjeta, string formaPago, string modoProducto, string redondeo, string telefono,
    string aliento)
        {
            DataTable dtNroCompr;
            NTicket ticket = new NTicket();
            ticket.AbreCajon();

            dtNroCompr = NComprobante.mostrarNroComprobante(idVenta, tipoCompr);
            string nroComprobante = dtNroCompr.Rows[0][0].ToString();
            string nroImpr = "";
            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro("Comercializadora de Aves & Transporte");
            ticket.TextoCentro("Venta de pollos al Por Mayo y Menor");

            //  ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
            ticket.TextoCentro("Av. Libertad s/n Valle Dorado -Pichari");
            ticket.TextoCentro("RUC: 20304455463");
            //ticket.TextoIzquierda("RAZON SOCIAL: JUAN CARLOS RIVERA MEZA");
            //ticket.TextoIzquierda("TELEF: 066 30 3567");
            //ticket.TextoIzquierda("RUC: 10106813731");
            // ticket.TextoIzquierda("EMAIL: jmsolorzano19@gmail.com");//Es el mio por si me quieren contactar ...
            // ticket.TextoIzquierda("");
            for (int i = 0; i < 7 - nroComprobante.Length; i++)
            {
                nroImpr += "0";
            }
            if (tipoCompr == "FACTURA")
            {
                ticket.TextoExtremos("Caja 1", "F" + "001-" + nroImpr + nroComprobante);
            }
            else if (tipoCompr == "BOLETA")
            {
                ticket.TextoExtremos("Caja 1", "B" + "001-" + nroImpr + nroComprobante);
            }
            else
            {
                ticket.TextoExtremos("Caja 1", tipoCompr + "001-" + nroImpr + nroComprobante);
            }

            ticket.lineasAsteriscos();

            //Sub cabecera.
            // ticket.TextoIzquierda("");
            if (tipoCompr != "TICKET")
            {
                // ticket.TextoIzquierda("ATENDIO:" + mesero);
            }
            ticket.TextoIzquierda("ATENDIO:" + mesero);
            if (tipoCompr == "FACTURA")
            {
                ticket.TextoIzquierda("Nro RUC: " + nroDoc);
                ticket.TextoIzquierda("CLIENTE: " + cliente);
                ticket.TextoIzquierda("Dir.: " + direccion);
                if (telefono != "")
                {
                    ticket.TextoIzquierda("Tel: " + telefono);
                }
                ticket.TextoIzquierda("");
            }
            else if (tipoCompr == "BOLETA")
            {
                if (cliente == "")
                {
                    //ticket.TextoIzquierda("CLIENTE: PUBLICO GENERAL ");
                }
                else
                {
                    ticket.TextoIzquierda("CLIENTE: " + cliente);
                    if (direccion != "")
                    {
                        ticket.TextoIzquierda("Dir: " + direccion);
                    }
                    if (telefono != "")
                    {
                        ticket.TextoIzquierda("Tel: " + telefono);
                    }
                    ticket.TextoIzquierda("");
                }

            }

            // ticket.TextoIzquierda("");
            if (tipoCompr != "TICKET")
            {
                //ticket.TextoIzquierda("Salón: " + salon + " Mesa: " + mesa);
            }
            //ticket.TextoIzquierda("Salón: " + salon + " Mesa: " + mesa);
            //ticket.TextoIzquierda("");
            ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
            ticket.lineasAsteriscos();

            //Articulos a vender.
            ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasAsteriscos();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
            if (modoProducto == "Detallado")
            {

                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    // ticket.AgregaArticulo(Convert.ToDecimal(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[5].Value.ToString()));
                    //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
                    // decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
                }
            }
            else if (modoProducto == "Detallados")
            {
                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    // ticket.AgregaArticulo(Convert.ToDecimal(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[6].Value.ToString()));

                }
            }
            else if (modoProducto == "Por Consumos")
            {
                // ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }
            else if (modoProducto == "Por Consumo")
            {
                // ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }

            /*
            ticket.AgregaArticulo("Articulo A", 2, 20, 40);
            ticket.AgregaArticulo("Articulo B", 1, 10, 10);
            ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);*/
            ticket.lineasIgual();

            //Resumen de la venta. Sólo son ejemplos
            if (tipoCompr != "TICKET")
            {
                ticket.AgregarTotales("         SUBTOTAL......S/", Convert.ToDecimal(subTotal));

                if (dctoInd != "00.00")
                {
                    ticket.AgregarTotales("         DSCTO IND.....S/ ", Convert.ToDecimal(dctoInd));
                }
                if (dctoGral != "00.00")
                {
                    ticket.AgregarTotales("         DSCTO GENERAL.S/ ", Convert.ToDecimal(dctoGral));
                }
                if (redondeo != "00.00")
                {
                    ticket.AgregarTotales("         REDONDEO......S/ ", Convert.ToDecimal(redondeo));
                }
                ticket.AgregarTotales("         IGV...........S/", Convert.ToDecimal(igv));//La M indica que es un decimal en C#

            }

            ticket.AgregarTotales("         TOTAL.........S/", Convert.ToDecimal(total));
            ticket.TextoIzquierda("");


            if (formaPago == "EFECTIVO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "TARJETA")
            {
                ticket.TextoIzquierda("         PAGA CON TARJETA");
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "MIXTO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         TARJETA.......S/", Convert.ToDecimal(tarjeta));
            }


            //Texto final del Ticket.
            // ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: 3");
            ticket.TextoIzquierda("");
            ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            if (tipoCompr == "TICKET")
            {
                ticket.TextoIzquierda("Este documento no es un comprobante fiscal");
                ticket.TextoIzquierda("Canjee este documento por una boleta/factura");
            }
            ticket.TextoCentro("");
            ticket.TextoCentro(aliento);
            ticket.CortaTicket();
            /*
            if(tipoCompr == "TICKET")
            {
                //ticket.ImprimirTicket("COCINA");//Nombre de la impresora ticketera
                ticket.ImprimirTicket("Microsoft XPS Document Writer");

            }
            else
            {
               // ticket.ImprimirTicket("EPSON TM-U220 Receipt");//Nombre de la impresora ticketera
                ticket.ImprimirTicket("Microsoft XPS Document Writer");

            }*/

            ticket.ImprimirTicket("Microsoft XPS Document Writer");
            //ticket.ImprimirTicket("CAJA");
            //  ticket.ImprimirTicket("EPSON TM-U220 Receipt");//Nombre de la impresora ticketera
        }
    }
}
