﻿using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmRFormaVenta : Form
    {
        public frmRFormaVenta()
        {
            InitializeComponent();
        }

        private void frmRFormaVenta_Load(object sender, EventArgs e)
        {
            try
            {
                string bandera = frmVentaFormaPago.f1.lblBandera.Text;
                string fechaInicio = "";
                string fechaFin = "";
                string forma = frmVentaFormaPago.f1.cbProducto.Text;
                DateTime fecIn;
                if (bandera == "1")
                {
                    fechaInicio = frmVentaFormaPago.f1.dtpFechaInicio.Value.ToString("yyyy-MM-dd" + " 00:00:00");
                    fechaFin = frmVentaFormaPago.f1.dtpFechaFin.Value.ToString("yyyy-MM-dd" + " 23:59:59");
                }
                else
                {
                    fecIn = Convert.ToDateTime(frmPrincipal.f1.lblFechaApertura.Text);
                    fechaInicio = fecIn.ToString("yyyy-MM-dd HH:mm:ss");

                    fechaFin = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }

                ReportDocument repdoc = new ReportDocument();
                // repdoc.Load(@"C:\Users\vioma\OneDrive\Documentos\Visual Studio 2017\Projects\SisVentas_ResAlm\CapaPresentacion\Reportes/RVentas.rpt");
                repdoc.Load(@"D:\Reportes\RFormaVenta.rpt");
                ParameterFieldDefinitions pfds;
                ParameterFieldDefinition pfd;

                ParameterValues pvs = new ParameterValues();
                ParameterDiscreteValue pdv = new ParameterDiscreteValue();

                pdv.Value = Convert.ToDateTime(fechaInicio);
                pfds = repdoc.DataDefinition.ParameterFields;
                pfd = pfds["@fechaInicio"];
                pvs.Add(pdv);
                pfd.ApplyCurrentValues(pvs);

                pdv.Value = Convert.ToDateTime(fechaFin);
                pfds = repdoc.DataDefinition.ParameterFields;
                pfd = pfds["@fechaFin"];
                pvs.Add(pdv);
                pfd.ApplyCurrentValues(pvs);

                pdv.Value = forma;
                pfds = repdoc.DataDefinition.ParameterFields;
                pfd = pfds["@forma"];
                pvs.Add(pdv);
                pfd.ApplyCurrentValues(pvs);

                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();
                Tables CrTables;
                crConnectionInfo.ServerName = @"EQUIPO\SQLEXPRESS";
                crConnectionInfo.DatabaseName = "SIS_AVICOLA";
                crConnectionInfo.UserID = "admin";
                crConnectionInfo.Password = "1234";
                /*
                crConnectionInfo.ServerName = @"EQUIPO\SQLEXPRESS";
                crConnectionInfo.DatabaseName = "db_restauranteAlmacen";
                crConnectionInfo.UserID = "martin";
                crConnectionInfo.Password = "1234";
                */
                CrTables = repdoc.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }


                cvVentas.ReportSource = repdoc;
                cvVentas.Refresh();

            }

            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
            }
        }
    }
}
