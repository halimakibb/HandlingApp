using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using FrancoHandling_Lib;
using FrancoHandling_Lib.Model;

namespace FrancoHandling_App
{
    public partial class Layout : System.Web.UI.MasterPage
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();

            if (Session["EnableMenu"] == null)
                Session["EnableMenu"] = false;

            if (!string.IsNullOrEmpty(UserProfile.Username))
            {
                //show menu
                Session["EnableMenu"] = true;
                NavMenu.ClientVisible = (bool)Session["EnableMenu"];
                //btnLogout.ClientVisible = (bool)Session["EnableMenu"];

                //set menu
                if (NavMenu.IsVisible() == true)
                    SetMenu(UserProfile.Roles);

                //set btn logon tooltip
                //btnLogout.ToolTip = UserProfile.Username;
            }
            else
            {
                Logout();

                if (HttpContext.Current.Request.Url.AbsolutePath.ToLower() != ResolveUrl("~/Pages/Home.aspx").ToLower())
                    Response.Redirect("~/Pages/Home.aspx", false);
            }

        }

        protected void Logout()
        {
            Session["EnableMenu"] = false;
            Session.Clear();
            HttpContext.Current.Session.Clear();
            UserProfile.Clear();

            NavMenu.ClientVisible = false;
            //btnLogout.ClientVisible = false;
            //btnLogout.ToolTip = string.Empty;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();
            Response.Redirect("~/Pages/Home.aspx", false);
        }

        protected void SetMenu(List<MasterDataModel.MasterDataRole> roles)
        {
            foreach (MasterDataModel.MasterDataRole role in roles)
            {
                switch (role.RoleName)
                {
                    case "USER_EKSTERNAL":
                        NavMenu.Items.FindByName("home").ClientVisible = true;
                        NavMenu.Items.FindByName("sp3m").ClientVisible = true;
                        NavMenu.Items.FindByName("sppb").ClientVisible = true;
                        break;
                    case "USER_INTERNAL":
                        NavMenu.Items.FindByName("home").ClientVisible = true;
                        NavMenu.Items.FindByName("sp3m").ClientVisible = true;
                        NavMenu.Items.FindByName("sppb").ClientVisible = true;
                        NavMenu.Items.FindByName("loading").ClientVisible = true;
                        NavMenu.Items.FindByName("unloading").ClientVisible = true;
                        NavMenu.Items.FindByName("invoice").ClientVisible = true;
                        break;
                    case "USER_ADMIN":
                        NavMenu.Items.FindByName("home").ClientVisible = true;
                        NavMenu.Items.FindByName("masterdata").ClientVisible = true;
                        break;
                    case "USER_REPORT":
                        NavMenu.Items.FindByName("home").ClientVisible = true;
                        NavMenu.Items.FindByName("laporan").ClientVisible = true;
                        break;
                    default:
                        NavMenu.Items.FindByName("home").ClientVisible = true;
                        break;
                }
            }
        }
        
    }
}
