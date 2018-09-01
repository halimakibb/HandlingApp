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
using DevExpress.Web;
using FrancoHandling_Lib.Entity;
using DevExpress.Web.Bootstrap;

namespace FrancoHandling_App.Pages.MasterData
{
    public partial class MasterDataTBBM : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserProfile.SetAuthorization(UserProfile.USER_ADMIN);
                gv.DataBind();
            }
        }

        protected void gv_DataBinding(object sender, EventArgs e)
        {
            gv.DataSource = MasterDataEntity.GetMasterDataTBBM(CommonDataModel.ActiveType.Active);
        }

        protected void gv_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            BootstrapGridView gv = (BootstrapGridView)sender;
            MasterDataModel.MasterDataTBBM item = GetGvValue(gv);

            string res = MasterDataEntity.AddMasterDataTBBM(item);

            gv.JSProperties["cpRes"] = res;

            e.Cancel = true;

            if (res.Contains("Success"))
            {
                gv.CancelEdit();
                gv.DataBind();
            }
        }

        protected void gv_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            BootstrapGridView gv = (BootstrapGridView)sender;
            MasterDataModel.MasterDataTBBM item = GetGvValue(gv, Convert.ToInt32(e.Keys[0].ToString()));

            string res = MasterDataEntity.EditMasterDataTBBM(item);

            gv.JSProperties["cpRes"] = res;

            e.Cancel = true;

            if (res.Contains("Success"))
            {
                gv.CancelEdit();
                gv.DataBind();
            }
        }

        protected void gv_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            BootstrapGridView gv = (BootstrapGridView)sender;

            MasterDataModel.MasterDataTBBM item = new MasterDataModel.MasterDataTBBM();
            item.TBBM_ID_PK = Convert.ToInt32(e.Keys[0].ToString());
            item.UpdateBy = UserProfile.Username;

            string res = MasterDataEntity.DeleteMasterDataTBBM(item);

            gv.JSProperties["cpRes"] = res;

            e.Cancel = true;

            gv.DataBind();

        }

        protected void gv_HtmlEditFormCreated(object sender, DevExpress.Web.ASPxGridViewEditFormEventArgs e)
        {
            ASPxPopupControl popup = e.EditForm.NamingContainer as ASPxPopupControl;
            popup.Maximized = true;
            popup.ScrollBars = ScrollBars.Vertical;
        }
        
        protected MasterDataModel.MasterDataTBBM GetGvValue(BootstrapGridView gv, int key = 0)
        {
            BootstrapTextBox txtName = gv.FindEditFormTemplateControl("txtName") as BootstrapTextBox;
            BootstrapComboBox cmbRegion = gv.FindEditFormTemplateControl("cmbRegion") as BootstrapComboBox;
            BootstrapMemo txtAddress = gv.FindEditFormTemplateControl("txtAddress") as BootstrapMemo;
            BootstrapTextBox txtTelp = gv.FindEditFormTemplateControl("txtTelp") as BootstrapTextBox;
            BootstrapTextBox txtEmail = gv.FindEditFormTemplateControl("txtEmail") as BootstrapTextBox;

            MasterDataModel.MasterDataTBBM item = new MasterDataModel.MasterDataTBBM();
            item.TBBM_ID_PK = key;
            item.Region_ID_FK = Convert.ToByte(cmbRegion.Value);
            item.Name = txtName.Text;
            item.Address = txtAddress.Text;
            item.Telp = txtTelp.Text;
            item.Email = txtEmail.Text;
            item.CreationBy = UserProfile.Username;
            item.UpdateBy = UserProfile.Username;

            return item;
        }

        protected void cmbRegion_Init(object sender, EventArgs e)
        {
            BootstrapComboBox cmb = sender as BootstrapComboBox;
            cmb.DataSource = MasterDataEntity.GetMasterDataRegion();
            cmb.DataBind();
            if (!gv.IsNewRowEditing)
                cmb.Value = Convert.ToString(gv.GetRowValues(gv.EditingRowVisibleIndex, "Region_ID_FK"));
        }
    }
}