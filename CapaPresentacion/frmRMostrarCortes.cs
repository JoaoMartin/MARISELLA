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
    public partial class frmRMostrarCortes : Form
    {
        public frmRMostrarCortes()
        {
            InitializeComponent();
        }

        private void frmRMostrarCortes_Load(object sender, EventArgs e)
        {
            try
            {
                

                ReportDocument repdoc = new ReportDocument();
                // repdoc.Load(@"C:\Users\vioma\OneDrive\Documentos\Visual Studio 2017\Projects\SisVentas_ResAlm\CapaPresentacion\Reportes/RVentas.rpt");
                repdoc.Load(@"D:\Reportes\RMostrarCortes.rpt");
                ParameterFieldDefinitions pfds;
                ParameterFieldDefinition pfd;

                ParameterValues pvs = new ParameterValues();
                ParameterDiscreteValue pdv = new ParameterDiscreteValue();

                pdv.Value = Convert.ToInt32(1);
                pfds = repdoc.DataDefinition.ParameterFields;
                pfd = pfds["@nro"];
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
