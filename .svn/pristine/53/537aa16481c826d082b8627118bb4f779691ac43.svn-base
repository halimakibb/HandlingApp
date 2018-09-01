using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrancoHandling_Lib;
using FrancoHandling_Lib.Model;
using DevExpress.Web.Bootstrap;
using DevExpress.Web;


namespace FrancoHandling_App.Pages
{
    public partial class ListSPPB : System.Web.UI.Page
    {
        Alert alert = new Alert();
        protected string response = string.Empty;
        protected const string QueryGetSPP = "dbo.sp_GetSPP";
        protected const string QueryGetSPPItem = "dbo.sp_GetSPPItem";
        protected const string QueryDeleteSPP = "dbo.sp_DeleteSPP";

        protected void Page_Load(object sender, EventArgs e)
        {
             Page.Header.DataBind();

             if (!IsPostBack)
             {
                 gridSPPB.DataBind();
             }
        }

        protected List<SPPBModel.SPPB> GetDataSPPB()
        {
            return DbTransaction.DbToList<SPPBModel.SPPB>(QueryGetSPP, true);
        }

        protected List<SPPBModel.SPPBItem> GetDataSPPBItem(int SPP_ID)
        {
            return DbTransaction.DbToList<SPPBModel.SPPBItem>(QueryGetSPPItem, new { SPP_ID = SPP_ID }, true);
        }

        protected void gridSPPB_DataBinding(object sender, EventArgs e)
        {
            gridSPPB.DataSource = GetDataSPPB();
        }

        protected void gridSPPBItems_DataBinding(object sender, EventArgs e)
        {
            int SPP_ID = Convert.ToInt32(Session["SPPItem_ID"] ?? 0);

            BootstrapGridView gv = (BootstrapGridView)sender;
            gv.DataSource = GetDataSPPBItem(SPP_ID);
        }

        protected void gridSPPBItems_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["SPPItem_ID"] = (sender as BootstrapGridView).GetMasterRowKeyValue();
        }

        protected void gridSPPB_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {            
            int SPP_ID = Convert.ToInt32(e.Keys[0]);
            try
            {
                response = DbTransaction.DbToString(QueryDeleteSPP, new { SPP_ID = SPP_ID, userlogin = UserProfile.Username }, true);

                e.Cancel = true;
                gridSPPB.DataBind();

                if (response.Contains("Success"))
                    alert.MessageString(Alert.SUCCESS, "Delete SPPB", response, this.Page, GetType());
                else
                    alert.MessageString(Alert.WARNING, "Delete SPPB", response, this.Page, GetType());

            }
            catch (Exception ex)
            {
                alert.MessageString(Alert.ERROR, "Delete SPPB", ex.Message, this.Page, GetType());
            }
        }

        protected void gridSPPB_SelectionChanged(object sender, EventArgs e)
        {
            BootstrapGridView grid = sender as BootstrapGridView;
            for (int i = 0; i < grid.VisibleRowCount; i++) // Loop through selected rows 
            {
                if (grid.Selection.IsRowSelected(i)) // do whatever you need to do with selected row values
                {
                    // now use pre-initialized List<object> selectedList to save 
                    string key = grid.GetRowValues(i, "SPP_ID_PK").ToString();
                    string status = grid.GetRowValues(i, "StatusDesc").ToString();
                    ASPxWebControl.RedirectOnCallback(string.Format("~/Pages/InputSPPB.aspx?SPP_ID={0}&StatusDesc={1}", key, status));
                }
            }
        }

        protected void gridSPPB_CommandButtonInitialize(object sender, BootstrapGridViewCommandButtonEventArgs e)
        {
            if (e.VisibleIndex == -1)
                return;

            if (e.ButtonType == ColumnCommandButtonType.Delete)
                e.Visible = DeleteButtonVisibleCriteria((ASPxGridView)sender, e.VisibleIndex);
        }

        private bool DeleteButtonVisibleCriteria(ASPxGridView grid, int visibleIndex)
        {
            object row = grid.GetRow(visibleIndex);
            return ((SPPBModel.SPPB)(row)).StatusDesc.ToString().ToUpper().Contains("SAVE");
        }
        
    }
}