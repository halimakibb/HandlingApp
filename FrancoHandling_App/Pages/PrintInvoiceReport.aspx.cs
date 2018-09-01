using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrancoHandling_Lib.Model;
using FrancoHandling_Lib.Entity;
using System.Data;
using System.ComponentModel;

namespace FrancoHandling_App.Report
{
    public partial class PrintInvoiceReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InvoiceEntity invoiceEntity = new InvoiceEntity();
            List<InvoiceModel.InvoiceReport> reportData = new List<InvoiceModel.InvoiceReport>();
            if (!string.IsNullOrEmpty(txtYear.Text))
            {
                
                reportData = invoiceEntity.GetInvoice_Report(txtYear.Text);
                
            }
            else
            {
                reportData = invoiceEntity.GetInvoice_Report(DateTime.Now.Year.ToString());
            }

            //gridInvoiceReport.DataSource = reportData;
            //gridInvoiceReport.DataBind();
        }
        
        protected void cBackReport_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            
            InvoiceEntity invoiceEntity = new InvoiceEntity();
            string year = txtYear.Text;

            xReportInvoice report = new xReportInvoice();
            if (!string.IsNullOrEmpty(year))
            {
                List<InvoiceModel.InvoiceReport> reportData = invoiceEntity.GetInvoice_Report(year);
                
                report.xrLabel2.Text = year;
                report.DataSource = reportData;
                report.CreateDocument(false);

            }
            docViewer.OpenReport(report);
            
        }

       

    }
}