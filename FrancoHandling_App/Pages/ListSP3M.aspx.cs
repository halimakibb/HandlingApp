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
using DevExpress.Web.Bootstrap;
using DevExpress.Web;

namespace FrancoHandling_App.Pages
{
    public partial class ListSP3M : System.Web.UI.Page {

        Alert alert = new Alert();
        List<SP3MModel.SP3M> LiSP3M = new List<SP3MModel.SP3M>();
        protected const string QueryGetSP3M = "dbo.sp_GetSP3M";

        protected void Page_Load(object sender, EventArgs e)
        {
            //load jscipt and css
            Page.Header.DataBind();

            if (!IsPostBack)
            {
                //set autorization page
                UserProfile.SetAuthorization(new string[] { UserProfile.USER_EKSTERNAL, UserProfile.USER_INTERNAL });

                //set grid
                gvListSP3M.DataBind();
            }


        }

        protected void gvListSP3M_DataBinding(object sender, EventArgs e)
        {
            
            //SP3MModel.ListSP3M SP3M = new SP3MModel.ListSP3M();
            //SP3M.SP3MID = 1;
            //SP3M.NoSP3M = "0111-004/0105-004/23/16";
            //SP3M.TanggalSP3M = DateTime.Now;
            //SP3M.Angkatan = "TNI - 2004, 190";
            //SP3M.Kesatuan = "Dandenbekang Paspampres (Satkai III)";
            //SP3M.NoSA = "0115-004/0125-004/23/16";
            //SP3M.TanggalSA = DateTime.Now.AddDays(-2);
            //SP3M.NoSP2M = "0117-004/0124-002/11/52";
            //SP3M.TanggalSP2M = DateTime.Now.AddDays(-1);
            //SP3M.Catatan = "Administrasi Lengkap";
            //SP3M.NamaPenandatangan = "Mamat Suramat";
            //LiSP3M.Add(SP3M);

            gvListSP3M.DataSource = GetDataSP3M();
        }

        protected List<SP3MModel.SP3M> GetDataSP3M()
        {
            return DbTransaction.DbToList<SP3MModel.SP3M>(QueryGetSP3M, true);
        }

        protected void gvListSP3M_SelectionChanged(object sender, EventArgs e)
        {
            BootstrapGridView grid = sender as BootstrapGridView;
            for (int i = 0; i < grid.VisibleRowCount; i++) // Loop through selected rows 
            {
                if (grid.Selection.IsRowSelected(i)) // do whatever you need to do with selected row values
                {
                    // now use pre-initialized List<object> selectedList to save 
                    string key = grid.GetRowValues(i, "SP3M_ID_PK").ToString();
                    string status = grid.GetRowValues(i, "Status").ToString();
                    ASPxWebControl.RedirectOnCallback(string.Format("~/Pages/InputSP3M.aspx?SP3M_ID={0}&Status={1}", key, status));
                }
            }
        }

        protected void gvListSP3M_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string response = string.Empty;
            int SP3M_ID = Convert.ToInt32(e.Keys[0]);
            try
            {
                response = DbTransaction.DbToString("dbo.sp_DeleteSP3M", new { SP3M_ID = SP3M_ID, userlogin = UserProfile.Username }, true);

                e.Cancel = true;
                gvListSP3M.DataBind();

                if(response.Contains("Success"))
                    alert.MessageString(Alert.SUCCESS, "Delete SP3M", response, this.Page, GetType());
                else
                    alert.MessageString(Alert.WARNING, "Delete SP3M", response, this.Page, GetType());

            }
            catch(Exception ex)
            {
                alert.MessageString(Alert.ERROR, "Delete SP3M", ex.Message, this.Page, GetType());
            }
        }
        
        protected void gvListSP3M_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {                     
            if (e.VisibleIndex == -1) 
                return;

            if (e.ButtonType == ColumnCommandButtonType.Delete)
                e.Visible = DeleteButtonVisibleCriteria((ASPxGridView)sender, e.VisibleIndex);
        }

        private bool DeleteButtonVisibleCriteria(ASPxGridView grid, int visibleIndex)
        {
            object row = grid.GetRow(visibleIndex);
            return ((SP3MModel.SP3M)(row)).Status.ToString().ToUpper().Contains("SAVE");
        }


    }
}