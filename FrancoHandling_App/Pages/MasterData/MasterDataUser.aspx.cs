using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using FrancoHandling_Lib;
using FrancoHandling_Lib.Model;
using System.Web.UI.WebControls;
using DevExpress.Web.Bootstrap;


namespace FrancoHandling_App.Pages.MasterData
{
    public partial class MasterDataUser : System.Web.UI.Page
    {

        Alert alert = new Alert();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();

            if (!Page.IsPostBack)
            {
                UserProfile.SetAuthorization(UserProfile.USER_ADMIN);

                gvMasterDataUser.DataBind();
            }

        }

        protected void gvMasterDataUser_DataBinding(object sender, EventArgs e)
        {
            gvMasterDataUser.DataSource = ListUser();
        }

        protected void gvMasterDataUser_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string response = string.Empty;
            try
            {
                //initialize control
                BootstrapGridView gv = (BootstrapGridView)sender;
                BootstrapTextBox txtusername = (BootstrapTextBox)gv.FindEditFormTemplateControl("txtUserName");
                BootstrapTextBox txtpassword = (BootstrapTextBox)gv.FindEditFormTemplateControl("txtPassword");
                BootstrapTextBox txtpasswordconfirmation = (BootstrapTextBox)gv.FindEditFormTemplateControl("txtPasswordConfirmation");
                BootstrapTextBox txtemail = (BootstrapTextBox)gv.FindEditFormTemplateControl("txtEmail");
                BootstrapTextBox txttelephone = (BootstrapTextBox)gv.FindEditFormTemplateControl("txtTelephone");
                BootstrapCheckBoxList chkrole = (BootstrapCheckBoxList)gv.FindEditFormTemplateControl("chkRole");

                //validation input
                if (txtusername.IsValid == false ||
                    txtpassword.IsValid == false ||
                    txtpasswordconfirmation.IsValid == false ||
                    txtemail.IsValid == false ||
                    chkrole.IsValid == false)
                    return;

                if (txtpassword.Text != txtpasswordconfirmation.Text)
                {
                    response = "Password Confirmation is not valid";
                    return;
                }

                //set roles
                string roles = string.Empty;
                if (chkrole.SelectedValues.Count > 0)
                {
                    foreach (string item in chkrole.SelectedValues)
                    {
                        roles = roles + ";" + item;
                    }
                    roles = roles.Substring(1);
                }

                //execute query
                response = DbTransaction.DbToString("dbo.sp_AddMasterDataUser", new
                {
                    username = txtusername.Text,
                    password = Encryption.Encrypt(txtpassword.Text),
                    email = txtemail.Text,
                    telephone = txttelephone.Text,
                    roles = roles,
                    userlogin = UserProfile.Username
                }, true);
            }
            catch(Exception ex)
            {
                response = ex.Message;
            }
            finally
            {
                gvMasterDataUser.JSProperties["cpRes"] = response;
                e.Cancel = true;
                if (response.Contains("Success"))
                    gvMasterDataUser.CancelEdit();
            }
        }

        protected void gvMasterDataUser_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string response = string.Empty;
            try
            {
                //initialize control
                BootstrapGridView gv = (BootstrapGridView)sender;
                BootstrapTextBox txtusername = (BootstrapTextBox)gv.FindEditFormTemplateControl("txtUserName");
                BootstrapTextBox txtpassword = (BootstrapTextBox)gv.FindEditFormTemplateControl("txtPassword");
                BootstrapTextBox txtpasswordconfirmation = (BootstrapTextBox)gv.FindEditFormTemplateControl("txtPasswordConfirmation");
                BootstrapTextBox txtemail = (BootstrapTextBox)gv.FindEditFormTemplateControl("txtEmail");
                BootstrapTextBox txttelephone = (BootstrapTextBox)gv.FindEditFormTemplateControl("txtTelephone");
                BootstrapCheckBoxList chkrole = (BootstrapCheckBoxList)gv.FindEditFormTemplateControl("chkRole");

                //validation input
                if (txtusername.IsValid==false ||
                    txtpassword.IsValid == false ||
                    txtpasswordconfirmation.IsValid == false ||
                    txtemail.IsValid == false ||
                    chkrole.IsValid == false)
                    return;

                if (txtpassword.Text != txtpasswordconfirmation.Text)
                {
                    response = "Password Confirmation is not valid";
                    return;
                }

                //set roles
                string roles = string.Empty;
                if (chkrole.SelectedValues.Count > 0)
                {
                    foreach (string item in chkrole.SelectedValues)
                        roles = roles + ";" + item;
                    
                    roles = roles.Substring(1);
                }

                //execute query
                response = DbTransaction.DbToString("dbo.sp_EditMasterDataUser", new
                {
                    userid = (Guid)e.Keys[0],
                    username = txtusername.Text,
                    password = Encryption.Encrypt(txtpassword.Text),
                    email = txtemail.Text,
                    telephone = txttelephone.Text,
                    roles = roles,
                    userlogin = UserProfile.Username
                }, true);
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            finally
            {
                gvMasterDataUser.JSProperties["cpRes"] = response;
                e.Cancel = true;
                if (response.Contains("Success"))
                    gvMasterDataUser.CancelEdit();
            }
        }

        protected void gvMasterDataUser_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string response = string.Empty;
            try
            {
                response = DbTransaction.DbToString("dbo.sp_DeleteMasterDataUser", new
                {
                    userid = e.Keys[0],
                    userlogin = UserProfile.Username
                }, true);

            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            finally
            {
                gvMasterDataUser.JSProperties["cpRes"] = response;
                e.Cancel = true;
                if (response.Contains("Success"))
                    gvMasterDataUser.CancelEdit();
            }

        }
        
        protected void gvMasterDataUser_HtmlEditFormCreated(object sender, DevExpress.Web.ASPxGridViewEditFormEventArgs e)
        {
            string param = Request.Params.Get("__CALLBACKPARAM");
            if (!String.IsNullOrEmpty(param))
                if (!param.Contains("CANCELEDIT"))
                {
                    BootstrapGridView gv = (BootstrapGridView)sender;
                    BootstrapTextBox txtusername = (BootstrapTextBox)gv.FindEditFormTemplateControl("txtUserName");
                    BootstrapTextBox txtpassword = (BootstrapTextBox)gv.FindEditFormTemplateControl("txtPassword");
                    BootstrapTextBox txtpasswordconfirmation = (BootstrapTextBox)gv.FindEditFormTemplateControl("txtPasswordConfirmation");
                    BootstrapTextBox txtemail = (BootstrapTextBox)gv.FindEditFormTemplateControl("txtEmail");
                    BootstrapTextBox txttelephone = (BootstrapTextBox)gv.FindEditFormTemplateControl("txtTelephone");
                    BootstrapCheckBoxList chkrole =(BootstrapCheckBoxList)gv.FindEditFormTemplateControl("chkRole");
                    BootstrapGridView gridAuth = (BootstrapGridView)gv.FindEditFormTemplateControl("gvAuthParameter");

                                        
                    string username = gv.GetRowValues(gv.EditingRowVisibleIndex, "Username") == null ? string.Empty : gv.GetRowValues(gv.EditingRowVisibleIndex, "Username").ToString();
                    string password = gv.GetRowValues(gv.EditingRowVisibleIndex, "Password") == null ? string.Empty : gv.GetRowValues(gv.EditingRowVisibleIndex, "Password").ToString();
                    string email = gv.GetRowValues(gv.EditingRowVisibleIndex, "Email") == null ? string.Empty : gv.GetRowValues(gv.EditingRowVisibleIndex, "Email").ToString();
                    string telephone = gv.GetRowValues(gv.EditingRowVisibleIndex, "Telephone") == null ? string.Empty : gv.GetRowValues(gv.EditingRowVisibleIndex, "Telephone").ToString();
                    string roles = gv.GetRowValues(gv.EditingRowVisibleIndex, "RoleName") == null ? string.Empty : gv.GetRowValues(gv.EditingRowVisibleIndex, "RoleName").ToString();

                    //set textbox username
                    if (!String.IsNullOrWhiteSpace(username))
                        txtusername.Text = username;
                    txtusername.ValidationSettings.RequiredField.IsRequired = true;
                    txtusername.ValidationSettings.RequiredField.ErrorText = "Field is Required";

                    //set textbox password
                    if(!string.IsNullOrEmpty(password))
                    {
                        txtpassword.Text = Encryption.Decrypt(password);
                        txtpasswordconfirmation.Text = Encryption.Decrypt(password);
                    }
                    txtpassword.ValidationSettings.RequiredField.IsRequired = true;
                    txtpassword.ValidationSettings.RequiredField.ErrorText = "Field is Required";
                    txtpasswordconfirmation.ValidationSettings.RequiredField.IsRequired = true;
                    txtpasswordconfirmation.ValidationSettings.RequiredField.ErrorText = "Field is Required";                    

                    //set textbox email
                    if (!String.IsNullOrWhiteSpace(email))
                        txtemail.Text = email;
                    txtemail.ValidationSettings.RequiredField.IsRequired = true;
                    txtemail.ValidationSettings.RequiredField.ErrorText = "Field is Required";
                    txtemail.ValidationSettings.RegularExpression.ValidationExpression = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                    txtemail.ValidationSettings.RegularExpression.ErrorText = "Invalid Email Format";

                    //set textbox telephone
                    if (!String.IsNullOrWhiteSpace(telephone))
                        txttelephone.Text = telephone;
                    //txttelephone.ValidationSettings.RequiredField.IsRequired = true;
                    //txttelephone.ValidationSettings.RequiredField.ErrorText = "Field is Required";
                    txttelephone.MaskSettings.Mask = "99999999999999";

                    //set checkbox list role
                    //chkrole.DataSource = ListRole();
                    //chkrole.DataBind();
                    //chkrole.ValueField = "RoleID";
                    //chkrole.TextField = "RoleName";
                    chkrole.ValidationSettings.RequiredField.IsRequired = true;
                    chkrole.ValidationSettings.RequiredField.ErrorText = "Field is Required";
                    if(!string.IsNullOrEmpty(roles))
                    {
                        string[] rolesid = roles.Split(';');
                        foreach (string item in rolesid)
                        {
                            foreach (BootstrapListEditItem i in chkrole.Items)
                                if (i.Value.ToString() == item.ToString())
                                    i.Selected = true;
                        }
                        
                    }

                    // set grid auth parameter
                    if(ListAuthParameter(username).Count > 0)
                        gridAuth.DataBind();
                    
                }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                gvMasterDataUser.UpdateEdit();
            }
            catch (Exception ex)
            {
                alert.MessageString(Alert.ERROR, "Update Master Data User", ex.Message, this.Page, GetType());
            }

        }

        protected void gvAuthParameter_DataBinding(object sender, EventArgs e)
        {
            //initialize control
            BootstrapGridView gv = (BootstrapGridView)gvMasterDataUser;
            BootstrapTextBox txtusername = (BootstrapTextBox)gv.FindEditFormTemplateControl("txtUserName");
            BootstrapGridView gridAuth = (BootstrapGridView)gv.FindEditFormTemplateControl("gvAuthParameter");

            string username = gv.GetRowValues(gv.EditingRowVisibleIndex, "Username") == null ? string.Empty : gv.GetRowValues(gv.EditingRowVisibleIndex, "Username").ToString();

            gridAuth.DataSource = ListAuthParameter(username);
        }

        protected void gvAuthParameter_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string Response = string.Empty;

            try
            {
                //initialize control
                BootstrapGridView gv = (BootstrapGridView)gvMasterDataUser;
                BootstrapTextBox txtusername = (BootstrapTextBox)gv.FindEditFormTemplateControl("txtUserName");
                BootstrapGridView gridAuth = (BootstrapGridView)gv.FindEditFormTemplateControl("gvAuthParameter");

                if (string.IsNullOrEmpty((string)e.NewValues["ParameterName"]) || string.IsNullOrEmpty((string)e.NewValues["ParameterValue"]))
                {
                    alert.MessageString(Alert.WARNING, "Add Authentication", "Parameter is not complete", this.Page, GetType());
                    e.Cancel = true;
                    return;
                }

                Response = DbTransaction.DbToString("dbo.sp_AddUserAuthentication", new
                {
                    username = txtusername.Text,
	                name = e.NewValues["ParameterName"],
	                value = e.NewValues["ParameterValue"],
	                userlogin = UserProfile.Username
                }, true);

                if(Response.Contains("Success"))
                {
                    alert.MessageString(Alert.SUCCESS, "Add Authentication", Response, this.Page, GetType());
                    e.Cancel = true;
                    gridAuth.CancelEdit();
                }
                else
                {
                    alert.MessageString(Alert.WARNING, "Add Authentication", Response, this.Page, GetType());
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                alert.MessageString(Alert.ERROR, "Add Authentication", ex.Message, this.Page, GetType());
            }
        }

        protected void gvAuthParameter_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string Response = string.Empty;

            try
            {
                //initialize control
                BootstrapGridView gv = (BootstrapGridView)gvMasterDataUser;
                BootstrapGridView gridAuth = (BootstrapGridView)gv.FindEditFormTemplateControl("gvAuthParameter");

                if (string.IsNullOrEmpty((string)e.NewValues["ParameterName"]) || string.IsNullOrEmpty((string)e.NewValues["ParameterValue"]))
                {
                    alert.MessageString(Alert.WARNING, "Update Authentication", "Parameter is not complete", this.Page, GetType());
                    e.Cancel = true;
                    return;
                }

                Response = DbTransaction.DbToString("dbo.sp_EditUserAuthentication", new
                {
                    userid = e.Keys[0],
                    name = e.NewValues["ParameterName"],
                    value = e.NewValues["ParameterValue"],
                    userlogin = UserProfile.Username
                }, true);

                if (Response.Contains("Success"))
                {
                    alert.MessageString(Alert.SUCCESS, "Update Authentication", Response, this.Page, GetType());
                    e.Cancel = true;
                    gridAuth.CancelEdit();
                }
                else
                {
                    alert.MessageString(Alert.WARNING, "Update Authentication", Response, this.Page, GetType());
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                alert.MessageString(Alert.ERROR, "Update Authentication", ex.Message, this.Page, GetType());
            }
        }

        protected void gvAuthParameter_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string Response = string.Empty;

            try
            {
                //initialize control
                BootstrapGridView gv = (BootstrapGridView)gvMasterDataUser;
                BootstrapTextBox txtusername = (BootstrapTextBox)gv.FindEditFormTemplateControl("txtUserName");
                BootstrapGridView gridAuth = (BootstrapGridView)gv.FindEditFormTemplateControl("gvAuthParameter");

                Response = DbTransaction.DbToString("dbo.sp_DeleteUserAuthentication", new
                {
                    userid = e.Keys[0],
                    name = e.Values["ParameterName"],
                    value = e.Values["ParameterValue"],
                    userlogin = UserProfile.Username
                }, true);

                if (Response.Contains("Success"))
                {
                    alert.MessageString(Alert.SUCCESS, "Delete Authentication", Response, this.Page, GetType());
                    e.Cancel = true;
                    gridAuth.CancelEdit();
                }
                else
                {
                    alert.MessageString(Alert.WARNING, "Delete Authentication", Response, this.Page, GetType());
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                alert.MessageString(Alert.ERROR, "Delete Authentication", ex.Message, this.Page, GetType());
            }
        }

        protected List<MasterDataModel.MasterDataUser> ListUser()
        {
            List<MasterDataModel.MasterDataUser> listuser = new List<MasterDataModel.MasterDataUser>();
            listuser = DbTransaction.DbToList<MasterDataModel.MasterDataUser>("dbo.sp_GetMasterDataUsers", new { }, true);

            //for (int i = 1; i < 20; i++)
            //{
            //    listuser.Add(new MasterDataModel.MasterDataUser()
            //    {
            //        UserID = Guid.NewGuid(),
            //        Username = "admin_" + i,
            //        Password = "pass",
            //        Email = "admin_" + i + "@mail.com",
            //        Telephone = "0818081208" + i,
            //        IsActive = true,
            //        CreationBy = "arie",
            //        CreationDate = DateTime.Now,
            //        UpdateBy = "wibowo",
            //        UpdateDate = DateTime.Now
            //    });
            //}
            return listuser;
        }

        protected List<MasterDataModel.MasterDataRole> ListRole()
        {
            List<MasterDataModel.MasterDataRole> listrole = new List<MasterDataModel.MasterDataRole>();
            listrole = DbTransaction.DbToList<MasterDataModel.MasterDataRole>("dbo.sp_GetMasterDataRoles", new { }, true);

            //for (int i = 1; i < 4; i++)
            //{
            //    listrole.Add(new MasterDataModel.MasterDataRole()
            //    {
            //        RoleID = Guid.NewGuid(),
            //        RoleName = "USER_ADMIN"
            //    });
            //}
            return listrole;
        }

        protected List<MasterDataModel.AuthParameter> ListAuthParameter(string UserName)
        {
            return DbTransaction.DbToList<MasterDataModel.AuthParameter>("sp_GetUserAuthentication", new { username = UserName }, true);
        }

    }
}