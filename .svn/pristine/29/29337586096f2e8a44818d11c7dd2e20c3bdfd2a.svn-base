using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrancoHandling_App.Code;
using System.Data;
using FrancoHandling_Lib;
using FrancoHandling_Lib.Model;
using FrancoHandling_Lib.Entity;
using DevExpress.Web.Bootstrap;
using DevExpress.Web;

namespace FrancoHandling_App.Pages.MasterData
{
    public partial class MasterDataTransportir : System.Web.UI.Page {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserProfile.SetAuthorization(UserProfile.USER_ADMIN);
                gvMasterDataTransportir.DataBind();
            }
        }

        protected void gvMasterDataTransportir_DataBinding(object sender, EventArgs e)
        {
            gvMasterDataTransportir.DataSource = MasterDataEntity.GetMasterDataTransporter(CommonDataModel.ActiveType.Active);
        }

        protected void gvMasterDataTransportir_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            BootstrapGridView gv = (BootstrapGridView)sender;
            MasterDataModel.MasterDataTransporter item = GetGvValue(gv);
            
            string res = MasterDataEntity.AddMasterDataTransporter(item);

            gv.JSProperties["cpRes"] = res;

            e.Cancel = true;

            if (res.Contains("Success"))
            {
                gv.CancelEdit();
                gv.DataBind();
            }
        }
        
        protected void gvMasterDataTransportir_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            BootstrapGridView gv = (BootstrapGridView)sender;
            MasterDataModel.MasterDataTransporter item = GetGvValue(gv, (int)e.Keys[0]);
            
            string res = MasterDataEntity.EditMasterDataTransporter(item);

            gv.JSProperties["cpRes"] = res;

            e.Cancel = true;

            if (res.Contains("Success"))
            {
                gv.CancelEdit();
                gv.DataBind();
            }

        }

        protected void gvMasterDataTransportir_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            BootstrapGridView gv = (BootstrapGridView)sender;

            MasterDataModel.MasterDataTransporter item = new MasterDataModel.MasterDataTransporter();
            item.Transporter_ID = (int)e.Keys[0];
            item.UpdateBy = UserProfile.Username;

            string res = MasterDataEntity.DeleteMasterDataTransporter(item);

            gv.JSProperties["cpRes"] = res;

            e.Cancel = true;
            gv.DataBind();

        }

        protected void gvMasterDataTransportir_HtmlEditFormCreated(object sender, DevExpress.Web.ASPxGridViewEditFormEventArgs e)
        {
            ASPxPopupControl popup = e.EditForm.NamingContainer as ASPxPopupControl;
            popup.Maximized = true;
            popup.ScrollBars = ScrollBars.Vertical;
        }

        protected MasterDataModel.MasterDataTransporter GetGvValue(BootstrapGridView gv, int key = 0)
        {
            BootstrapTextBox txtName = gv.FindEditFormTemplateControl("txtName") as BootstrapTextBox;
            BootstrapMemo txtAddress = gv.FindEditFormTemplateControl("txtAddress") as BootstrapMemo;
            BootstrapTextBox txtEmail = gv.FindEditFormTemplateControl("txtEmail") as BootstrapTextBox;
            BootstrapTextBox txtPhone = gv.FindEditFormTemplateControl("txtPhone") as BootstrapTextBox;
            BootstrapTextBox txtContact1 = gv.FindEditFormTemplateControl("txtContact1") as BootstrapTextBox;
            BootstrapTextBox txtContact2 = gv.FindEditFormTemplateControl("txtContact2") as BootstrapTextBox;

            MasterDataModel.MasterDataTransporter item = new MasterDataModel.MasterDataTransporter();
            item.Transporter_ID = key;
            item.TransporterName = txtName.Text;
            item.Address = txtAddress.Text;
            item.Email = txtEmail.Text;
            item.Phone = txtPhone.Text;
            item.Contact1 = txtContact1.Text;
            item.Contact2 = txtContact2.Text;
            item.CreationBy = UserProfile.Username;
            item.UpdateBy = UserProfile.Username;

            return item;
        }

        protected void gvFee_BeforePerformDataSelect(object sender, EventArgs e)
        {
            BootstrapGridView gvFee = (BootstrapGridView)sender;

            int transporter_ID = Convert.ToInt32(gvFee.GetMasterRowKeyValue());
            
            gvFee.DataSource = MasterDataEntity.GetMasterDataTransporterFee(transporter_ID, CommonDataModel.ActiveType.Active);
        }

        protected void gvFee_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            BootstrapGridView gv = (BootstrapGridView)sender;

            MasterDataModel.MasterDataTransporterFee item = new MasterDataModel.MasterDataTransporterFee();
            item.Transporter_ID = Convert.ToInt32(e.Keys[0]);
            item.Region_ID = Convert.ToByte(e.Keys[1]);
            item.HandlingFee = Convert.ToDecimal(e.NewValues["HandlingFee"]);
            item.OATDistanceLimit = Convert.ToInt32(e.NewValues["OATDistanceLimit"]);
            item.OATPriceUnderEqualLimit = Convert.ToDecimal(e.NewValues["OATPriceUnderEqualLimit"]);
            item.OATPriceAboveLimit = Convert.ToDecimal(e.NewValues["OATPriceAboveLimit"]);
            item.UpdateBy = UserProfile.Username;
            
            string res = MasterDataEntity.EditMasterDataTransporterFee(item);

            gv.JSProperties["cpRes"] = res;

            e.Cancel = true;

            if (res.Contains("Success"))
            {
                gv.CancelEdit();
                gv.DataBind();
            }
        }
    }
}