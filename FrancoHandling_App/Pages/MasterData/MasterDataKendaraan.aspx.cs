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
using DevExpress.Web;
using DevExpress.Web.Bootstrap;

namespace FrancoHandling_App.Pages.MasterData
{
    public partial class MasterDataKendaraan : System.Web.UI.Page {
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
            gv.DataSource = MasterDataEntity.GetMasterDataVehicle(CommonDataModel.ActiveType.Active);
        }

        protected void gv_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            BootstrapGridView gv = (BootstrapGridView)sender;
            MasterDataModel.MasterDataKendaraan item = GetGvValue(gv);

            string res = MasterDataEntity.AddMasterDataVehicle(item);

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
            MasterDataModel.MasterDataKendaraan item = GetGvValue(gv, (int)e.Keys[0]);

            string res = MasterDataEntity.EditMasterDataVehicle(item);

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

            MasterDataModel.MasterDataKendaraan item = new MasterDataModel.MasterDataKendaraan();
            item.Vehicle_ID = (int)e.Keys[0];
            item.UpdateBy = UserProfile.Username;

            string res = MasterDataEntity.DeleteMasterDataVehicle(item);

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

        protected MasterDataModel.MasterDataKendaraan GetGvValue(BootstrapGridView gv, int key = 0)
        {
            BootstrapComboBox cmbTransportir = gv.FindEditFormTemplateControl("cmbTransportir") as BootstrapComboBox;
            BootstrapTextBox txtNumber = gv.FindEditFormTemplateControl("txtNumber") as BootstrapTextBox;
            BootstrapTextBox txtCode = gv.FindEditFormTemplateControl("txtCode") as BootstrapTextBox;
            BootstrapTextBox txtMerk = gv.FindEditFormTemplateControl("txtMerk") as BootstrapTextBox;
            BootstrapSpinEdit spinYearManufacture = gv.FindEditFormTemplateControl("spinYearManufacture") as BootstrapSpinEdit;
            BootstrapComboBox cmbVehicleType = gv.FindEditFormTemplateControl("cmbVehicleType") as BootstrapComboBox;
            BootstrapComboBox cmbVehicleCategory = gv.FindEditFormTemplateControl("cmbVehicleCategory") as BootstrapComboBox;
            BootstrapSpinEdit spinCapacity = gv.FindEditFormTemplateControl("spinCapacity") as BootstrapSpinEdit;
            BootstrapComboBox cmbUnitCapacity = gv.FindEditFormTemplateControl("cmbUnitCapacity") as BootstrapComboBox;

            MasterDataModel.MasterDataKendaraan item = new MasterDataModel.MasterDataKendaraan();
            item.Vehicle_ID = key;
            item.Transporter_ID = Convert.ToInt32(cmbTransportir.Value);
            item.Number = txtNumber.Text;
            item.Code = txtCode.Text;
            item.Merk = txtMerk.Text;
            item.YearManufacture = Convert.ToInt32(spinYearManufacture.Value);
            item.Type_ID = Convert.ToInt16(cmbVehicleType.Value);
            item.VehicleCategory_ID = Convert.ToInt16(cmbVehicleCategory.Value);
            item.Capacity = Convert.ToInt32(spinCapacity.Value);
            item.UnitCapacity_ID = Convert.ToInt32(cmbUnitCapacity.Value);
            item.CreationBy = UserProfile.Username;
            item.UpdateBy = UserProfile.Username;

            return item;
        }

        protected void cmbTransportir_Init(object sender, EventArgs e)
        {
            BootstrapComboBox cmb = sender as BootstrapComboBox;
            cmb.DataSource = MasterDataEntity.GetMasterDataTransporter_CMB();
            cmb.DataBind();
            if(!gv.IsNewRowEditing)
                cmb.Value = Convert.ToString(gv.GetRowValues(gv.EditingRowVisibleIndex, "Transporter_ID"));
        }

        protected void cmbVehicleType_Init(object sender, EventArgs e)
        {
            BootstrapComboBox cmb = sender as BootstrapComboBox;
            cmb.DataSource = MasterDataEntity.GetMasterDataVehicleType_CMB();
            cmb.DataBind();
            if (!gv.IsNewRowEditing)
                cmb.Value = Convert.ToString(gv.GetRowValues(gv.EditingRowVisibleIndex, "Type_ID"));
        }

        protected void cmbVehicleCategory_Init(object sender, EventArgs e)
        {
            BootstrapComboBox cmb = sender as BootstrapComboBox;
            cmb.DataSource = MasterDataEntity.GetMasterDataVehicleCategory_CMB();
            cmb.DataBind();
            if (!gv.IsNewRowEditing)
                cmb.Value = Convert.ToString(gv.GetRowValues(gv.EditingRowVisibleIndex, "VehicleCategory_ID"));
        }

        protected void cmbUnitCapacity_Init(object sender, EventArgs e)
        {
            BootstrapComboBox cmb = sender as BootstrapComboBox;
            List<MasterDataModel.MasterDataKendaraan> liVehicle = MasterDataEntity.GetMasterDataUnitCapacity_CMB();
            cmb.DataSource = liVehicle;
            cmb.DataBind();
            if (liVehicle.Count == 1)
                cmb.SelectedIndex = 0;
            if (!gv.IsNewRowEditing)
                cmb.Value = Convert.ToString(gv.GetRowValues(gv.EditingRowVisibleIndex, "UnitCapacity_ID"));
        }
    }
}