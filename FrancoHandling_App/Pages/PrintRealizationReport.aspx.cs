using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrancoHandling_Lib.Model;
using FrancoHandling_Lib.Entity;

namespace FrancoHandling_App.Report
{
    public partial class PrintRealizationReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        
        protected void cBackReport_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            SP3MEntity sP3MEntity = new SP3MEntity();
            
            string year = txtYear.Text;
            List<SP3MModel.SP3MRealization> reportData = sP3MEntity.GetRealization(year);

            xReportRealization report = new xReportRealization();
            if (!string.IsNullOrEmpty(year))
            {
                
                report.xrLabel2.Text = year;
                report.DataSource = reportData;
                report.CreateDocument(false);

            }
            docViewer.OpenReport(report);

        }
    }
}