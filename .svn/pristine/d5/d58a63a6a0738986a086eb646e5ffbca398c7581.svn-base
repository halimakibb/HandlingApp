using System;
using DevExpress.Web;
using FrancoHandling_Lib;
using FrancoHandling_Lib.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrancoHandling_App.UserControls
{
    public partial class Login : System.Web.UI.UserControl
    {

        Alert alert = new Alert();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //declare username and password
                string Username = txtUsername.Text;
                string Password = Encryption.Encrypt(txtPassword.Text);
                string ReturnValidate = UserProfile.GetUserProfileIsValidate(Username, Password);

                //validate user profile
                if (ReturnValidate == "Success")
                {
                    //set user profile
                    UserProfile.GetUserProfile(Username);
                    UserProfile.SetUserProfile();

                    if (UserProfile.Roles != null)
                    {
                        Session["EnableMenu"] = true;
                        Response.Redirect("~/Pages/Default.aspx", false);
                    }
                }
                else
                {
                    alert.MessageString(Alert.WARNING, "Gagal Login", ReturnValidate, this.Page, GetType());

                    Session["EnableMenu"] = false;
                    Session.Clear();
                    HttpContext.Current.Session.Clear();
                }
            }
            catch(Exception ex)
            {
                alert.MessageString(Alert.ERROR, "Gagal Login", ex.Message, this.Page, GetType());
            }
        }

    }
}