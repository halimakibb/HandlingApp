<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeBehind="MasterDataUser.aspx.cs" Inherits="FrancoHandling_App.Pages.MasterData.MasterDataUser" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <script type="text/javascript">
        function GridShowPopup(s, e) {
            if (gvMasterDataUser.cpRes != null && gvMasterDataUser.cpRes != "") {
                if (gvMasterDataUser.cpRes.includes("Succes")) {
                    Alert("success", "Master Data User", gvMasterDataUser.cpRes);
                }
                else if (gvMasterDataUser.cpRes.includes("Exist")) {
                    Alert("warning", "Master Data User", gvMasterDataUser.cpRes);
                }
                else {
                    Alert("error", "Master Data User", gvMasterDataUser.cpRes);
                }
                gvMasterDataUser.cpRes = null;
            }
        }
    </script>


    <div class="container">
        <div class="row">
            <div class="page-header">   
                <h1>Input User</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                
                <dx:BootstrapGridView ID="gvMasterDataUser" ClientInstanceName="gvMasterDataUser" runat="server" KeyFieldName="UserID" AutoGenerateColumns="False"
                    OnDataBinding="gvMasterDataUser_DataBinding"
                    OnRowInserting="gvMasterDataUser_RowInserting"
                    OnRowUpdating="gvMasterDataUser_RowUpdating"
                    OnRowDeleting="gvMasterDataUser_RowDeleting"
                    OnHtmlEditFormCreated="gvMasterDataUser_HtmlEditFormCreated">
                    <ClientSideEvents CallbackError="function(s,e){ Alert('error', 'Master Data User', e.message); }" 
                        EndCallback="GridShowPopup" />
                    <Settings ShowHeaderFilterButton="true" ShowGroupPanel="false" />
                    <SettingsDataSecurity AllowDelete="true" AllowEdit="true" AllowInsert="true"/>
                    <SettingsEditing Mode="EditFormAndDisplayRow"></SettingsEditing>
                    <SettingsSearchPanel Visible="true" ShowApplyButton="true" />
                    <SettingsBehavior ConfirmDelete="true" />
                    <SettingsLoadingPanel Mode="ShowAsPopup" />
                    <SettingsPager Mode="ShowPager" ></SettingsPager>
                    <Columns>
                        <dx:BootstrapGridViewCommandColumn Caption="Action" AllowDragDrop="False" ButtonRenderMode="Button" 
                            ShowNewButtonInHeader="true" ShowEditButton="true" ShowDeleteButton="true"  Width="1px" />
                        <dx:BootstrapGridViewTextColumn FieldName="Username" Caption="Username" />
                        <dx:BootstrapGridViewTextColumn FieldName="Password" Visible="false" />
                        <dx:BootstrapGridViewTextColumn FieldName="Email" Caption="Email" />
                        <dx:BootstrapGridViewTextColumn FieldName="Telephone" Caption="Telephone"/>
                        <dx:BootstrapGridViewTextColumn FieldName="RoleName" Caption="Roles" Visible="false" />
                        <dx:BootstrapGridViewDateColumn FieldName="CreationDate" Caption="CreationDate"
                            PropertiesDateEdit-DisplayFormatString="dd.MM.yyyy HH:mm:ss" Visible="False" />
                        <dx:BootstrapGridViewDataColumn FieldName="CreationBy" Caption="CreationBy" Visible="False" />
                        <dx:BootstrapGridViewDateColumn FieldName="UpdateDate" Caption="UpdateDate"
                            PropertiesDateEdit-DisplayFormatString="dd.MM.yyyy HH:mm:ss" Visible="False" />
                        <dx:BootstrapGridViewDataColumn FieldName="UpdateBy" Caption="UpdateBy" Visible="False" />
                    </Columns>
                    <Templates>
                        <EditForm>
                            <div class="container">
                                <div class="row">
                                    <div class="col-md-6">
                                        <dx:BootstrapTextBox runat="server" ID="txtUserName" Caption="Username">
                                            <ValidationSettings RequiredField-IsRequired="true" RequiredField-ErrorText="Field is Required"></ValidationSettings>
                                        </dx:BootstrapTextBox><br />
                                        <dx:BootstrapTextBox runat="server" ID="txtPassword" Caption="Password">
                                            <ValidationSettings RequiredField-IsRequired="true" RequiredField-ErrorText="Field is Required"></ValidationSettings>
                                        </dx:BootstrapTextBox><br />
                                        <dx:BootstrapTextBox runat="server" ID="txtPasswordConfirmation" Caption="Password Confirmation">
                                            <ValidationSettings RequiredField-IsRequired="true" RequiredField-ErrorText="Field is Required"></ValidationSettings>
                                        </dx:BootstrapTextBox><br />      
                                        <dx:BootstrapGridView runat="server" ID="gvAuthParameter" ClientInstanceName="gvAuthParameter" Caption="Authentication" 
                                            KeyFieldName="User_ID;ParameterName;ParameterValue" AutoGenerateColumns="false" EnableCallBacks="false"
                                            OnDataBinding="gvAuthParameter_DataBinding"
                                            OnRowInserting="gvAuthParameter_RowInserting" 
                                            OnRowUpdating="gvAuthParameter_RowUpdating" 
                                            OnRowDeleting="gvAuthParameter_RowDeleting" >
                                            <SettingsDataSecurity AllowDelete="true" AllowEdit="true" AllowInsert="true"/>
                                            <SettingsBehavior ConfirmDelete="true" />
                                            <SettingsEditing Mode="Inline" NewItemRowPosition="Bottom"></SettingsEditing>
                                            <SettingsCommandButton NewButton-IconCssClass="glyphicon glyphicon-plus" CancelButton-IconCssClass="glyphicon glyphicon-remove-circle"
                                                EditButton-IconCssClass="glyphicon glyphicon-edit" DeleteButton-IconCssClass="glyphicon glyphicon-remove" UpdateButton-IconCssClass="glyphicon glyphicon-ok"></SettingsCommandButton>
                                            <Columns>
                                                <dx:BootstrapGridViewCommandColumn ButtonRenderMode="Button" ShowNewButtonInHeader="true" ShowEditButton="true" ShowUpdateButton="true" ShowDeleteButton="true"></dx:BootstrapGridViewCommandColumn>
                                                <dx:BootstrapGridViewTextColumn FieldName="ParameterName" Caption="Parameter Name">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings RequiredField-IsRequired="true" RequiredField-ErrorText="Field is Required"></ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:BootstrapGridViewTextColumn>
                                                <dx:BootstrapGridViewTextColumn FieldName="ParameterValue" Caption="Parameter Value">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings RequiredField-IsRequired="true" RequiredField-ErrorText="Field is Required"></ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:BootstrapGridViewTextColumn>
                                            </Columns>
                                        </dx:BootstrapGridView>
                                    </div>
                                    <div class="col-md-6">                                        
                                        <dx:BootstrapTextBox runat="server" ID="txtEmail" Caption="Email">
                                        </dx:BootstrapTextBox><br />                                        
                                        <dx:BootstrapTextBox runat="server" ID="txtTelephone" Caption="Telephone">
                                        </dx:BootstrapTextBox><br />                                  
                                        <dx:BootstrapCheckBoxList runat="server" ID="chkRole" Caption="Roles">
                                            <Items>
                                                <dx:BootstrapListEditItem Text="USER_ADMIN" Value="D779693C-3606-4802-9DB5-A25FCCA0871A"/>
                                                <dx:BootstrapListEditItem Text="USER_INTERNAL" Value="8DD8448A-7CDE-45FA-B885-B571DF03B357"/>
                                                <dx:BootstrapListEditItem Text="USER_EKSTERNAL" Value="ADD7AF91-6AA8-4031-8C2E-08A1189CBDCC"/>
                                                <dx:BootstrapListEditItem Text="USER_REPORT" Value="420357B5-1C79-49D3-A40A-3F049DDD9CBC"/>
                                            </Items>
                                        </dx:BootstrapCheckBoxList>                                        
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12" style="text-align:center">
                                        <dx:BootstrapButton runat="server" ID="btnUpdate" Text="Update" AutoPostBack="false">
                                            <ClientSideEvents Click="function(s,e){ gvMasterDataUser.UpdateEdit(); }"/>
                                        </dx:BootstrapButton>                                            
                                        <%--<dx:BootstrapButton runat="server" ID="btnUpdate" Text="Update" OnClick="btnUpdate_Click" AutoPostBack="true">                                            
                                        </dx:BootstrapButton>--%>
                                        <dx:BootstrapButton runat="server" ID="btnCancel" Text="Cancel" AutoPostBack="false">
                                            <ClientSideEvents Click="function(s,e){ gvMasterDataUser.CancelEdit(); }" />
                                        </dx:BootstrapButton>
                                    </div>
                                </div>
                            </div>
                        </EditForm>
                    </Templates>
                </dx:BootstrapGridView>
            </div>    
        </div>
    </div>
</asp:Content>
