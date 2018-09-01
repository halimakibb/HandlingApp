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
    public partial class MasterDataDriver : System.Web.UI.Page
    {
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
            gv.DataSource = MasterDataEntity.GetMasterDataDriver(CommonDataModel.ActiveType.Active);
        }

        protected void gv_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            BootstrapGridView gv = (BootstrapGridView)sender;
            MasterDataModel.MasterDataDriver item = GetGvValue(gv);

            string res = MasterDataEntity.AddMasterDataDriver(item);
            
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
            MasterDataModel.MasterDataDriver item = GetGvValue(gv, (int)e.Keys[0]);

            string res = MasterDataEntity.EditMasterDataDriver(item);

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

            MasterDataModel.MasterDataDriver item = new MasterDataModel.MasterDataDriver();
            item.Driver_ID = (int)e.Keys[0];
            item.UpdateBy = UserProfile.Username;

            string res = MasterDataEntity.DeleteMasterDataDriver(item);

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

        protected MasterDataModel.MasterDataDriver GetGvValue(BootstrapGridView gv, int key = 0)
        {
            BootstrapTextBox txtName = gv.FindEditFormTemplateControl("txtName") as BootstrapTextBox;
            BootstrapComboBox cmbTransportir = gv.FindEditFormTemplateControl("cmbTransportir") as BootstrapComboBox;
            BootstrapDateEdit deBirthday = gv.FindEditFormTemplateControl("deBirthday") as BootstrapDateEdit;
            BootstrapMemo txtAddress = gv.FindEditFormTemplateControl("txtAddress") as BootstrapMemo;
            BootstrapTextBox txtEmail = gv.FindEditFormTemplateControl("txtEmail") as BootstrapTextBox;
            BootstrapTextBox txtPhone1 = gv.FindEditFormTemplateControl("txtPhone1") as BootstrapTextBox;
            BootstrapTextBox txtPhone2 = gv.FindEditFormTemplateControl("txtPhone2") as BootstrapTextBox;

            MasterDataModel.MasterDataDriver item = new MasterDataModel.MasterDataDriver();
            item.Driver_ID = key;
            item.Name = txtName.Text;
            item.Transporter_ID = Convert.ToInt32(cmbTransportir.Value);
            if(deBirthday.Value != null)
                item.Birthday = deBirthday.Date;
            else
                item.Birthday = null;
            item.Address = txtAddress.Text;
            item.Email = txtEmail.Text;
            item.Phone1 = txtPhone1.Text;
            item.Phone2 = txtPhone2.Text;
            item.CreationBy = UserProfile.Username;
            item.UpdateBy = UserProfile.Username;
            if (Session["DriverPhotoImageName"] != null && Session["DriverPhotoImageBytes"] != null)
            {
                item.ImageName = Convert.ToString(Session["DriverPhotoImageName"]);
                item.ImageBytes = (byte[])Session["DriverPhotoImageBytes"];
                Session["DriverPhotoImageName"] = null;
                Session["DriverPhotoImageBytes"] = null;
            }

            return item;
        }

        protected void cmbTransportir_Init(object sender, EventArgs e)
        {
            BootstrapComboBox cmb = sender as BootstrapComboBox;
            cmb.DataSource = MasterDataEntity.GetMasterDataTransporter_CMB();
            cmb.DataBind();
            if (!gv.IsNewRowEditing)
                cmb.Value = Convert.ToString(gv.GetRowValues(gv.EditingRowVisibleIndex, "Transporter_ID"));
        }

        protected void imgPhoto_Init(object sender, EventArgs e)
        {
            BootstrapBinaryImage img = sender as BootstrapBinaryImage;
            if (!gv.IsNewRowEditing)
                img.Value = (byte[])gv.GetRowValues(gv.EditingRowVisibleIndex, "ImageBytes");
        }

        protected void deBirthday_Init(object sender, EventArgs e)
        {
            BootstrapDateEdit de = sender as BootstrapDateEdit;
            if (!gv.IsNewRowEditing)
                de.Date = Convert.ToDateTime(gv.GetRowValues(gv.EditingRowVisibleIndex, "Birthday"));

        }

        protected void ucPhoto_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            Session["DriverPhotoImageName"] = e.UploadedFile.FileName;
            Session["DriverPhotoImageBytes"] = e.UploadedFile.FileBytes;
        }

        protected void cpPhoto_Callback(object sender, CallbackEventArgsBase e)
        {
            BootstrapCallbackPanel cp = sender as BootstrapCallbackPanel;
            BootstrapBinaryImage img = cp.FindControl("imgPhoto") as BootstrapBinaryImage;
            img.Value = Session["DriverPhotoImageBytes"];
        }

        protected void gv_HtmlDataCellPrepared(object sender, BootstrapGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "ImageBytes")
            {
                BootstrapBinaryImage imgPhotoGrid = gv.FindRowCellTemplateControl(e.VisibleIndex, gv.Columns["ImageBytes"] as GridViewDataColumn, "imgPhotoGrid") as BootstrapBinaryImage;
                imgPhotoGrid.Value = e.CellValue;
            }
        }
    }
}