<%@ Page Title="SPSH" Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout.master" CodeBehind="MasterDataSPSH.aspx.cs" Inherits="FrancoHandling_App.Pages.MasterData.MasterDataSPSH" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<div class="container">
    <div class="row">
        <div class="col-md-12" >
            <div class="page-header">
                <h1>Master Data SPSH (Ship To Party)</h1>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12" >
            
            <dx:ASPxPanel ID="panGv" ClientInstanceName="panGV" Width="100%" runat="server" ScrollBars="Horizontal">
                <PanelCollection>
                    <dx:PanelContent>

                        <dx:BootstrapGridView ID="gv" ClientInstanceName="gv" runat="server" KeyFieldName="SPSH_ID" AutoGenerateColumns="False"
                            ClientSideEvents-CallbackError="function(s,e){ ShowModalPopupMsg(e.message); }" 
                            ClientSideEvents-EndCallback="GvEndCallbackShowModalPopupMsg"
                            OnDataBinding="gv_DataBinding"
                            OnRowInserting="gv_RowInserting"
                            OnRowUpdating="gv_RowUpdating"
                            OnRowDeleting="gv_RowDeleting"
                            >
                            <Settings ShowHeaderFilterButton="true" ShowGroupPanel="false" />
                            <SettingsDataSecurity AllowDelete="true" AllowEdit="true" AllowInsert="true"/>
                            <SettingsEditing Mode="PopupEditForm"></SettingsEditing>
                            <SettingsPopup EditForm-HorizontalAlign="WindowCenter" EditForm-VerticalAlign="WindowCenter" EditForm-Modal="true" EditForm-ShowHeader="true"></SettingsPopup>
                            <SettingsText PopupEditFormCaption="Add / Edit SPSH"/>
                            <SettingsSearchPanel Visible="true" ShowApplyButton="true" HighlightResults="true" />
                            <SettingsBehavior ConfirmDelete="true" />
                            <SettingsLoadingPanel Mode="ShowAsPopup" />
                            <SettingsPager Mode="ShowPager" PageSize="10"></SettingsPager>
                            <Columns>
                                <dx:BootstrapGridViewCommandColumn Caption="Action" ShowNewButtonInHeader="true" ShowEditButton="true" ShowDeleteButton="true" AllowDragDrop="False" ButtonRenderMode="Button" Width="1px"  />
                                <dx:BootstrapGridViewTextColumn FieldName="SPSH_ID" Caption="ID" Settings-AllowDragDrop="False"></dx:BootstrapGridViewTextColumn>
                                <dx:BootstrapGridViewTextColumn FieldName="Name" Caption="Nama SPSH" Settings-AllowDragDrop="False"></dx:BootstrapGridViewTextColumn>
                                <dx:BootstrapGridViewDataColumn FieldName="Region_ID" Visible="false" Settings-AllowDragDrop="False"></dx:BootstrapGridViewDataColumn>
                                <dx:BootstrapGridViewTextColumn FieldName="RegionName" Caption="Region" Settings-AllowDragDrop="False"></dx:BootstrapGridViewTextColumn>
                                <dx:BootstrapGridViewMemoColumn FieldName="Address" Caption="Alamat" Settings-AllowDragDrop="False"/>
                                <dx:BootstrapGridViewTextColumn FieldName="Telp" Caption="No Telepon" Settings-AllowDragDrop="False"></dx:BootstrapGridViewTextColumn>
                                <dx:BootstrapGridViewTextColumn FieldName="Email" Caption="Email" Settings-AllowDragDrop="False"></dx:BootstrapGridViewTextColumn>
                                <dx:BootstrapGridViewDateColumn FieldName="CreationDate" PropertiesDateEdit-DisplayFormatString="dd-MM-yyyy HH:mm:ss" Visible="False" Settings-AllowDragDrop="False"/>
                                <dx:BootstrapGridViewDataColumn FieldName="CreationBy" Visible="False" Settings-AllowDragDrop="False"/>
                                <dx:BootstrapGridViewDateColumn FieldName="UpdateDate" PropertiesDateEdit-DisplayFormatString="dd-MM-yyyy HH:mm:ss" Visible="False" Settings-AllowDragDrop="False"/>
                                <dx:BootstrapGridViewDataColumn FieldName="UpdateBy" Visible="False" Settings-AllowDragDrop="False"/>
                            </Columns>
                            <Templates>
                                <EditForm>
                                    <div class="row">
                                        <div class="col-md-3"></div>
                                        <div class="col-md-6">
                                            <dx:BootstrapTextBox runat="server" ID="txtSPSH_ID" Caption="SPSH ID" Text='<%# Eval("SPSH_ID") %>' MaxLength="10">
                                                <ClientSideEvents KeyDown="InputDigitOnly" />
                                                <ValidationSettings RequiredField-IsRequired="true" RequiredField-ErrorText="Field is Required"></ValidationSettings>
                                            </dx:BootstrapTextBox>
                                            <br />
                                            <dx:BootstrapTextBox runat="server" ID="txtName" Caption="Nama SPSH" Text='<%# Eval("Name") %>'>
                                                <ValidationSettings RequiredField-IsRequired="true" RequiredField-ErrorText="Field is Required"></ValidationSettings>
                                            </dx:BootstrapTextBox>
                                            <br />
                                            <dx:BootstrapComboBox runat="server" ID="cmbRegion" Caption="Region" ValueField="Region_ID" TextField="RegionName" IncrementalFilteringMode="Contains" OnInit="cmbRegion_Init">
                                                <ValidationSettings RequiredField-IsRequired="true" RequiredField-ErrorText="Field is Required"></ValidationSettings>
                                            </dx:BootstrapComboBox>
                                            <br />
                                            <dx:BootstrapMemo runat="server" ID="txtAddress" Caption="Alamat" Text='<%# Eval("Address") %>' CssClasses-Control="MemoNoResize" >
                                            </dx:BootstrapMemo>
                                            <br /> 
                                            <dx:BootstrapTextBox runat="server" ID="txtTelp" Caption="No Telepon" Text='<%# Eval("Telp") %>' MaxLength="20">
                                                <ValidationSettings RequiredField-IsRequired="true" RequiredField-ErrorText="Field is Required"></ValidationSettings>
                                                <ClientSideEvents KeyDown="InputDigitOnly" />
                                            </dx:BootstrapTextBox>
                                            <br />
                                            <dx:BootstrapTextBox runat="server" ID="txtEmail" Caption="Email" Text='<%# Eval("Email") %>' >
                                                <ValidationSettings>
                                                    <RegularExpression ErrorText="Invalid Email Format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                                </ValidationSettings>
                                            </dx:BootstrapTextBox>
                                            <br />  
                                        </div>
                                        <div class="col-md-3"></div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12" style="text-align:center">
                                            <dx:BootstrapButton runat="server" ID="btnUpdate" CssClasses-Control="btn-success" Text="Save" AutoPostBack="false" Width="150px">
                                                <ClientSideEvents Click="function(s,e){ 
                                                                            if(ASPxClientEdit.ValidateGroup(null)) 
                                                                                gv.UpdateEdit();
                                                                            else 
                                                                                Alert('warning', 'Warning', 'Some required fields is still empty or have a wrong format. Please check again.');
                                                                         }"/>
                                            </dx:BootstrapButton>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12" style="text-align:center">
                                            <dx:BootstrapButton runat="server" ID="btnCancel" Text="Cancel" AutoPostBack="false" Width="150px">
                                                <ClientSideEvents Click="function(s,e){ gv.CancelEdit(); }" />
                                            </dx:BootstrapButton>
                                        </div>
                                    </div>
                                </EditForm>
                            </Templates>
                        </dx:BootstrapGridView>
                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxPanel>
            
        </div>
    </div>
</div>
</asp:Content>