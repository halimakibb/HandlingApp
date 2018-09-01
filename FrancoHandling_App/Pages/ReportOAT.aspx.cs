using System;
using System.Data;
using System.IO;
using System.Web.UI;
using FrancoHandling_Lib.Entity;
using FrancoHandling_Lib.Model;

namespace FrancoHandling_App.Pages
{
    public partial class ReportOAT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                //binding force tbbm
                cmbTBBM.DataSource = MasterDataEntity.GetMasterDataTBBM(CommonDataModel.ActiveType.Active);
                cmbTBBM.DataBind();
                
                //binding force combobox 
                cmbForce.DataSource = MasterDataEntity.GetMasterDataForce();
                cmbForce.DataBind();

                //binding unity combobox
                cmbUnity.DataSource = MasterDataEntity.GetMasterDataUnity();
                cmbUnity.DataBind();

                //Report.xReportOAT report = new FrancoHandling_App.Report.xReportOAT();
                //docViewer.OpenReport(report);
            }
        }

        protected void cBackReport_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            ReportEntity dataReport = new ReportEntity();
            DataTable dTabel = dataReport.GetDataReportOAT(datePeriodeStart.Date, datePeriodeEnd.Date, Convert.ToInt32(cmbTBBM.SelectedItem.Value), cmbForce.SelectedItem.Value.ToString(), cmbUnity.SelectedItem.Value.ToString());
            string region = dataReport.GetRegion(cmbTBBM.SelectedItem.Value.ToString());
            Report.xReportOAT report = new FrancoHandling_App.Report.xReportOAT();                     

            report.xrLabel_Title1.Text = "REKAP PENYALURAN FRANCO BBM " + cmbForce.SelectedItem.Value.ToString().ToUpper() + " DI " + cmbTBBM.SelectedItem.Text.ToUpper() + " " + region;
            report.xrLabel_Title2.Text = "PERIODE " + datePeriodeStart.Date.ToString("dd MMM yyyy") + " SAMPAI DENGAN " + datePeriodeEnd.Date.ToString("dd MMM yyyy");
            report.xrLabel_TBBM.Text = ": " + cmbTBBM.SelectedItem.Text;
            report.xrLabel_Force.Text = ": " + cmbForce.SelectedItem.Text;
            report.xrLabel_Unity.Text = ": " + cmbUnity.SelectedItem.Text;
            report.DataSource = dTabel;
            report.DataMember = dTabel.TableName;

            docViewer.OpenReport(report);
            //docViewer.DataBind();
        }
        
    }
}