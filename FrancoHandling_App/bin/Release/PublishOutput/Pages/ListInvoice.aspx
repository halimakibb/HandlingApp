<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeBehind="ListInvoice.aspx.cs" Inherits="FrancoHandling_App.Pages.ListInvoice" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <div class="container">
    <div class="row">
        <div class="page-header">
            <h1>List Invoice</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <dx:BootstrapGridView ID="gridListInvoice" runat="server" KeyFieldName="Invoice_ID" Width="100%"
                AutoGenerateColumns="False" EnableCallBacks="true"
                OnDataBinding="gridListInvoice_DataBinding"
                OnRowDeleting="gridListInvoice_RowDeleting"
                OnSelectionChanged="gridListInvoice_SelectionChanged"
                OnCommandButtonInitialize="gridListInvoice_CommandButtonInitialize">
                <ClientSideEvents SelectionChanged="function(s,e) { e.processOnServer = true; }" />
                <Settings ShowHeaderFilterButton="true" ShowGroupPanel="false" />
                <SettingsBehavior AllowSelectSingleRowOnly="true" ConfirmDelete="true" />
                <SettingsSearchPanel Visible="true" ShowApplyButton="true" />
                <SettingsPager Mode="ShowPager" ></SettingsPager>
                <SettingsCommandButton DeleteButton-IconCssClass="glyphicon glyphicon-remove"
                    SelectButton-IconCssClass="glyphicon glyphicon-open"></SettingsCommandButton>
                <SettingsDataSecurity AllowDelete="true"/>
                <Columns>
                    <dx:BootstrapGridViewDataColumn FieldName="InvoiceNumber" Caption="Nomor Invoice" />
                    <dx:BootstrapGridViewDateColumn FieldName="InvoiceDate" Caption="Tanggal Invoice" 
                        PropertiesDateEdit-DisplayFormatString="dd.MM.yyyy"/>
                    <dx:BootstrapGridViewDataColumn FieldName="StatusDesc" Caption="Status"/>
                    <dx:BootstrapGridViewDateColumn FieldName="UpdateDate" Caption="Tanggal Update" 
                        PropertiesDateEdit-DisplayFormatString="dd.MM.yyyy HH:MM:dd"/>
                    <dx:BootstrapGridViewDataColumn FieldName="UpdateBy" Caption="Nama Update"/>
                    <dx:BootstrapGridViewCommandColumn Caption=" " AllowDragDrop="False" ButtonRenderMode="Button" 
                       ShowSelectButton="true" ShowDeleteButton="true">
                    </dx:BootstrapGridViewCommandColumn>
                </Columns>
            </dx:BootstrapGridView> 

        </div>
    </div>
</div>

</asp:Content>
