<%@ Page Title="SP3M" Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout.master" CodeBehind="ListSP3M.aspx.cs" Inherits="FrancoHandling_App.Pages.ListSP3M" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<script type="text/javascript">
    
</script>

<div class="container">
    <div class="row">
        <div class="page-header">
            <h1>List SP3M</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <dx:BootstrapGridView ID="gvListSP3M" runat="server" KeyFieldName="SP3M_ID_PK" Width="100%"
                AutoGenerateColumns="False" EnableCallBacks="true"
                OnDataBinding="gvListSP3M_DataBinding"
                OnRowDeleting="gvListSP3M_RowDeleting"
                OnSelectionChanged="gvListSP3M_SelectionChanged"
                OnCommandButtonInitialize="gvListSP3M_CommandButtonInitialize">
                <ClientSideEvents SelectionChanged="function(s,e) { e.processOnServer = true; }" />
                <Settings ShowHeaderFilterButton="true" ShowGroupPanel="false" />
                <SettingsBehavior AllowSelectSingleRowOnly="true" ConfirmDelete="true" />
                <SettingsSearchPanel Visible="true" ShowApplyButton="true" />
                <SettingsPager Mode="ShowPager" ></SettingsPager>
                <SettingsCommandButton DeleteButton-IconCssClass="glyphicon glyphicon-remove"
                    SelectButton-IconCssClass="glyphicon glyphicon-open"></SettingsCommandButton>
                <SettingsDataSecurity AllowDelete="true"/>
                <Columns>
                    <dx:BootstrapGridViewDataColumn FieldName="NoSP3M" Caption="Nomor SP3M" />
                    <dx:BootstrapGridViewDateColumn FieldName="SP3M_Date" Caption="Tanggal SP3M" 
                        PropertiesDateEdit-DisplayFormatString="dd.MM.yyyy"/>
                    <dx:BootstrapGridViewDataColumn FieldName="Force" Caption="Angkatan"/>
                    <dx:BootstrapGridViewDataColumn FieldName="Unity" Caption="Kesatuan" />
                    <dx:BootstrapGridViewDataColumn FieldName="Status" Caption="Status"/>
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