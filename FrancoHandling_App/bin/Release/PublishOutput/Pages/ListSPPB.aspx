<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeBehind="ListSPPB.aspx.cs" Inherits="FrancoHandling_App.Pages.ListSPPB" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<div class="container">
    <div class="row">
        <div class="page-header">
            <h1>List SPPB</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <dx:BootstrapGridView ID="gridSPPB" runat="server" KeyFieldName="SPP_ID_PK" Width="100%"
                AutoGenerateColumns="False" EnableCallBacks="true" 
                OnDataBinding="gridSPPB_DataBinding"
                OnRowDeleting="gridSPPB_RowDeleting"
                OnSelectionChanged="gridSPPB_SelectionChanged"
                OnCommandButtonInitialize="gridSPPB_CommandButtonInitialize">
                <ClientSideEvents SelectionChanged="function(s,e) { e.processOnServer = true; }" 
                    CustomButtonClick="function(s,e) { e.processOnServer = true; }"/>
                <Settings ShowHeaderFilterButton="true" ShowGroupPanel="false" />
                <SettingsBehavior AllowSelectSingleRowOnly="true" ConfirmDelete="true" />
                <SettingsSearchPanel Visible="true" ShowApplyButton="true" />
                <SettingsPager Mode="ShowPager" ></SettingsPager>
                <SettingsDetail ShowDetailRow="true" AllowOnlyOneMasterRowExpanded="true"/>
                <SettingsCommandButton DeleteButton-IconCssClass="glyphicon glyphicon-remove"
                    SelectButton-IconCssClass="glyphicon glyphicon-open"></SettingsCommandButton>
                <SettingsDataSecurity AllowDelete="true"/>
                <Columns>
                    <dx:BootstrapGridViewDataColumn FieldName="NoSPP" Caption="Nomor SPPB" />
                    <dx:BootstrapGridViewDataColumn FieldName="NoSP3M" Caption="Nomor SP3M" />
                    <dx:BootstrapGridViewDataColumn FieldName="SPSHName" Caption="Delivery" />   
                    <dx:BootstrapGridViewDataColumn FieldName="TransporterName" Caption="Transportir" />   
                    <dx:BootstrapGridViewDataColumn FieldName="StatusDesc" Caption="Status" />
                    <dx:BootstrapGridViewDateColumn FieldName="UpdateDate" Caption="Update Date" PropertiesDateEdit-DisplayFormatString="dd.MM.yyyy HH:mm:ss" />
                    <dx:BootstrapGridViewDataColumn FieldName="UpdateBy" Caption="Update By" />
                    <dx:BootstrapGridViewCommandColumn Caption=" " AllowDragDrop="False" ButtonRenderMode="Button" 
                       ShowSelectButton="true" ShowDeleteButton="true">
                    </dx:BootstrapGridViewCommandColumn>
                </Columns>
                <Templates>
                    <DetailRow>
                        <dx:BootstrapGridView ID="gridSPPBItems" runat="server" KeyFieldName="SPP_Items_ID_PK"
                            AutoGenerateColumns="False" EnableCallBacks="true" 
                            OnDataBinding="gridSPPBItems_DataBinding"
                            OnBeforePerformDataSelect="gridSPPBItems_BeforePerformDataSelect">
                            <Columns>
                                <dx:BootstrapGridViewDataColumn FieldName="Product_ID_FK" Caption="ProductId" Visible="false" />
                                <dx:BootstrapGridViewDataColumn FieldName="ProductName" Caption="Product" />
                                <dx:BootstrapGridViewDataColumn FieldName="QtySPP" Caption="Quantity SPPB" />
                                <dx:BootstrapGridViewDataColumn FieldName="QtyUsed" Caption="Quantity Digunakan" />
                                <dx:BootstrapGridViewDataColumn FieldName="QtySP3M" Caption="Quantity SP3M" />
                            </Columns>
                        </dx:BootstrapGridView>
                    </DetailRow>
                </Templates>
            </dx:BootstrapGridView>
        </div>
    </div>
</div>
</asp:Content>
