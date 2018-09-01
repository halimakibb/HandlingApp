<%@ Page Title="KENDARAAN" Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout.master" CodeBehind="MasterDataKendaraan.aspx.cs" Inherits="FrancoHandling_App.Pages.MasterData.MasterDataKendaraan" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<div class="container">
    <div class="row">
        <div class="col-md-12" >
            <div class="page-header">
                <h1>Master Data Kendaraan</h1>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12" >
            
            <dx:ASPxPanel ID="panGv" ClientInstanceName="panGV" Width="100%" runat="server" ScrollBars="Horizontal">
                <PanelCollection>
                    <dx:PanelContent>
                        <dx:BootstrapGridView ID="gv" ClientInstanceName="gv" runat="server" KeyFieldName="Vehicle_ID" AutoGenerateColumns="False"
                            ClientSideEvents-CallbackError="function(s,e){ ShowModalPopupMsg(e.message); }" 
                            ClientSideEvents-EndCallback="GvEndCallbackShowModalPopupMsg"
                            OnDataBinding="gv_DataBinding"
                            OnRowInserting="gv_RowInserting"
                            OnRowUpdating="gv_RowUpdating"
                            OnRowDeleting="gv_RowDeleting"
                            >
                            <Settings ShowHeaderFilterButton="true" ShowGroupPanel="false" />
                            <SettingsDataSecurity AllowInsert="true" AllowEdit="true" AllowDelete="true"/>
                            <SettingsEditing Mode="PopupEditForm"></SettingsEditing>
                            <SettingsPopup EditForm-HorizontalAlign="WindowCenter" EditForm-VerticalAlign="WindowCenter" EditForm-Modal="true" EditForm-ShowHeader="true"></SettingsPopup>
                            <SettingsText PopupEditFormCaption="Add / Edit Kendaraan"/>
                            <SettingsSearchPanel Visible="true" ShowApplyButton="true" HighlightResults="true" />
                            <SettingsBehavior ConfirmDelete="true" />
                            <SettingsLoadingPanel Mode="ShowAsPopup" />
                            <SettingsPager Mode="ShowPager" PageSize="10"></SettingsPager>
                            <Columns>
                                <dx:BootstrapGridViewCommandColumn  Caption="Action" ShowNewButtonInHeader="true" ShowEditButton="true" ShowDeleteButton="true" AllowDragDrop="False" ButtonRenderMode="Button"  Width="1px"  />
                                <dx:BootstrapGridViewTextColumn FieldName="Number" Caption="Nomor Kendaraan" Settings-AllowDragDrop="False"/>
                                <dx:BootstrapGridViewDataColumn FieldName="Transporter_ID" Visible="false" Settings-AllowDragDrop="False"></dx:BootstrapGridViewDataColumn>
                                <dx:BootstrapGridViewTextColumn FieldName="TransporterName" Caption="Transportir" Settings-AllowDragDrop="False"></dx:BootstrapGridViewTextColumn>
                                <dx:BootstrapGridViewTextColumn FieldName="Code" Caption="Kode Kendaraan" Settings-AllowDragDrop="False"/>
                                <dx:BootstrapGridViewTextColumn FieldName="Merk" Caption="Merk Kendaraan" Settings-AllowDragDrop="False"/>
                                <dx:BootstrapGridViewSpinEditColumn FieldName="YearManufacture" Caption="Tahun Pembuatan" PropertiesSpinEdit-NumberType="Integer" Settings-AllowDragDrop="False" />
                                <dx:BootstrapGridViewDataColumn FieldName="Type_ID" Visible="false" Settings-AllowDragDrop="False"></dx:BootstrapGridViewDataColumn>
                                <dx:BootstrapGridViewTextColumn FieldName="VehicleType" Caption="Tipe Kendaraan" Settings-AllowDragDrop="False"></dx:BootstrapGridViewTextColumn>
                                <dx:BootstrapGridViewDataColumn FieldName="VehicleCategory_ID" Visible="false" Settings-AllowDragDrop="False"></dx:BootstrapGridViewDataColumn>
                                <dx:BootstrapGridViewTextColumn FieldName="VehicleCategory" Caption="Kategori Kendaraan" Settings-AllowDragDrop="False"></dx:BootstrapGridViewTextColumn>
                                <dx:BootstrapGridViewSpinEditColumn FieldName="Capacity" Caption="Kapasitas Angkut" PropertiesSpinEdit-NumberType="Integer" PropertiesSpinEdit-DisplayFormatString="{0:N0}"  Settings-AllowDragDrop="False"/>
                                <dx:BootstrapGridViewDataColumn FieldName="UnitCapacity_ID" Visible="false" Settings-AllowDragDrop="False"></dx:BootstrapGridViewDataColumn>
                                <dx:BootstrapGridViewTextColumn FieldName="UnitCapacity" Caption="Satuan Kapasitas" Settings-AllowDragDrop="False"></dx:BootstrapGridViewTextColumn>
                                <dx:BootstrapGridViewDateColumn FieldName="CreationDate" PropertiesDateEdit-DisplayFormatString="dd-MM-yyyy HH:mm:ss" Visible="False" Settings-AllowDragDrop="False"/>
                                <dx:BootstrapGridViewDataColumn FieldName="CreationBy" Visible="False" Settings-AllowDragDrop="False"/>
                                <dx:BootstrapGridViewDateColumn FieldName="UpdateDate" PropertiesDateEdit-DisplayFormatString="dd-MM-yyyy HH:mm:ss" Visible="False" Settings-AllowDragDrop="False"/>
                                <dx:BootstrapGridViewDataColumn FieldName="UpdateBy" Visible="False" Settings-AllowDragDrop="False"/>
                            </Columns>
                            <Templates>
                                <EditForm>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <dx:BootstrapTextBox runat="server" ID="txtNumber" Caption="Nomor Kendaraan" Text='<%# Eval("Number") %>'>
                                                <ValidationSettings RequiredField-IsRequired="true" RequiredField-ErrorText="Field is Required"></ValidationSettings>
                                            </dx:BootstrapTextBox>
                                            <br />
                                            <dx:BootstrapComboBox runat="server" ID="cmbTransportir" Caption="Transportir" ValueField="Transporter_ID" TextField="TransporterName" IncrementalFilteringMode="Contains" OnInit="cmbTransportir_Init">
                                                <ValidationSettings RequiredField-IsRequired="true" RequiredField-ErrorText="Field is Required"></ValidationSettings>
                                            </dx:BootstrapComboBox>
                                            <br />    
                                            <dx:BootstrapTextBox runat="server" ID="txtCode" Caption="Kode Kendaraan" Text='<%# Eval("Code") %>'>
                                            </dx:BootstrapTextBox>
                                            <br />
                                            <dx:BootstrapTextBox runat="server" ID="txtMerk" Caption="Merk Kendaraan" Text='<%# Eval("Merk") %>'>
                                            </dx:BootstrapTextBox>
                                            <br />
                                            <dx:BootstrapSpinEdit runat="server" ID="spinYearManufacture" Caption="Tahun Pembuatan" Number='<%# Convert.ToDecimal(Eval("YearManufacture")) %>' MaxLength="4" AllowNull="true">
                                            </dx:BootstrapSpinEdit>
                                            <br />
                                        </div>
                                        <div class="col-md-6">   
                                            <dx:BootstrapComboBox runat="server" ID="cmbVehicleType" Caption="Tipe Kendaraan" ValueField="Type_ID" TextField="VehicleType" ValidationSettings-RequiredField-IsRequired="true" IncrementalFilteringMode="Contains" OnInit="cmbVehicleType_Init">
                                            </dx:BootstrapComboBox>
                                            <br />  
                                            <dx:BootstrapComboBox runat="server" ID="cmbVehicleCategory" Caption="Kategori Kendaraan" ValueField="VehicleCategory_ID" TextField="VehicleCategory" ValidationSettings-RequiredField-IsRequired="true" IncrementalFilteringMode="Contains" OnInit="cmbVehicleCategory_Init">
                                            </dx:BootstrapComboBox>
                                            <br />  
                                            <dx:BootstrapSpinEdit runat="server" ID="spinCapacity" Caption="Kapasitas Angkut" Number='<%# Convert.ToDecimal(Eval("Capacity")) %>' ValidationSettings-RequiredField-IsRequired="true" NumberType="Integer" DisplayFormatString="{0:N0}">
                                            </dx:BootstrapSpinEdit>
                                            <br />  
                                            <dx:BootstrapComboBox runat="server" ID="cmbUnitCapacity" Caption="Satuan Kapasitas" ValueField="UnitCapacity_ID" TextField="UnitCapacity" IncrementalFilteringMode="Contains" ValidationSettings-RequiredField-IsRequired="true" OnInit="cmbUnitCapacity_Init">
                                            </dx:BootstrapComboBox>
                                        </div>
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