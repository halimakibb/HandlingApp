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
    public partial class MasterDataJarak : System.Web.UI.Page {
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
            gv.DataSource = MasterDataEntity.GetMasterDataDistance(CommonDataModel.ActiveType.Active);
        }

        protected void gv_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            BootstrapGridView gv = (BootstrapGridView)sender;

            MasterDataModel.MasterDataDistance item = new MasterDataModel.MasterDataDistance();
            item.TBBM_ID = Convert.ToInt32(e.Keys[0]);
            item.SPSH_ID = Convert.ToString(e.Keys[1]);
            item.Distance = Convert.ToDecimal(e.NewValues["Distance"]);
            item.NormalRate = Convert.ToDecimal(e.NewValues["NormalRate"]);
            item.SpecialRate = Convert.ToDecimal(e.NewValues["SpecialRate"]);
            item.UpdateBy = UserProfile.Username;

            string res = MasterDataEntity.EditMasterDataDistance(item);

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