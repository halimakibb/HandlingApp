<%@ Page Title="SP3M" Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout.master" CodeBehind="InputSP3M.aspx.cs" Inherits="FrancoHandling_App.Pages.InputSP3M" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <script type="text/javascript">
        function OnAddProduct(s, e) {
            if (txtSP3M_Number.GetText() != "" && cmbForce.GetText() != "")
                gvProductSP3M.AddNewRow();
        }

        function OnClear(s, e) {
            txtSP3M_Number.Clear();
            dateSP3M_Date.Clear();
            cmbForce.Clear();
            cmbUnity.Clear();
            txtSA_Number.Clear();
            dateSA_Date.Clear();
            txtSP2M_Number.Clear();
            dateSP2M_Date.Clear();
            gvProductSP3M.CancelEdit();
        }

        function QuantityChange(s, e) {
            SubTotal.SetValue(Quantity.GetValue() * PriceUnit.GetValue());
        }

        function PriceUnitChange(s, e) {
            SubTotal.SetValue(Quantity.GetValue() * PriceUnit.GetValue());
        }
    </script>
<div class="container">
    <div class="row">
        <div class="page-header">
            <h1>Input SP3M</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <dx:BootstrapTextBox runat="server" ID="txtSP3M_Number" ClientInstanceName="txtSP3M_Number" Caption="Nomor SP3M">
                <ValidationSettings RequiredField-IsRequired="true" RequiredField-ErrorText="Field is Required"></ValidationSettings>
            </dx:BootstrapTextBox><br />
            <dx:BootstrapDateEdit runat="server" ID="dateSP3M_Date" ClientInstanceName="dateSP3M_Date" Caption="Tanggal SP3M" DisplayFormatString="dd.MM.yyyy" ><ClientSideEvents GotFocus="function(s,e){s.ShowDropDown();}"/></dx:BootstrapDateEdit><br />
            <%--<dx:BootstrapTextBox runat="server" ID="txtForce" ClientInstanceName="txtForce" Caption="Angkatan">
                <ValidationSettings RequiredField-IsRequired="true" RequiredField-ErrorText="Field is Required"></ValidationSettings>
            </dx:BootstrapTextBox><br />--%>
            <dx:BootstrapComboBox runat="server" ID="cmbForce" ClientInstanceName="cmbForce" Caption="Angakatan" ValueField="Force" TextField="Force">
                <ValidationSettings RequiredField-IsRequired="true" RequiredField-ErrorText="Field is Required"></ValidationSettings>
            </dx:BootstrapComboBox><br />
            <%--<dx:BootstrapTextBox runat="server" ID="txtUnity" ClientInstanceName="txtUnity" Caption="Kesatuan"></dx:BootstrapTextBox>--%><br />
            <dx:BootstrapComboBox runat="server" ID="cmbUnity" ClientInstanceName="cmbUnity" Caption="Kesatuan" ValueField="Unity" TextField="Unity">
            </dx:BootstrapComboBox><br />
            <dx:BootstrapTextBox runat="server" ID="txtApproval" ClientInstanceName="txtApproval" Caption="Penandatangan SP3M"></dx:BootstrapTextBox>            
        </div>
        <div class="col-md-6">
            <dx:BootstrapTextBox runat="server" ID="txtSA_Number" ClientInstanceName="txtSA_Number" Caption="Nomor SA"></dx:BootstrapTextBox><br />
            <dx:BootstrapDateEdit runat="server" ID="dateSA_Date" ClientInstanceName="dateSA_Date" Caption="Tanggal SA" DisplayFormatString="dd.MM.yyyy"><ClientSideEvents GotFocus="function(s,e){s.ShowDropDown();}"/></dx:BootstrapDateEdit><br />
            <dx:BootstrapTextBox runat="server" ID="txtSP2M_Number" ClientInstanceName="txtSP2M_Number" Caption="Nomor SP2M"></dx:BootstrapTextBox><br />
            <dx:BootstrapDateEdit runat="server" ID="dateSP2M_Date" ClientInstanceName="dateSP2M_Date" Caption="Tanggal SP2M" DisplayFormatString="dd.MM.yyyy"><ClientSideEvents GotFocus="function(s,e){s.ShowDropDown();}"/></dx:BootstrapDateEdit><br />
            <dx:BootstrapMemo runat="server" ID="txtNote" ClientInstanceName="txtNote" Caption="Catatan" Rows="3"></dx:BootstrapMemo>            
        </div>
    </div>
    <div class="row" style="text-align:center;">
        <div class="col-md-12">
            <br />
            <dx:BootstrapButton runat="server" ID="btnSave" ClientInstanceName="btnSave" Text="Save Data Header" ToolTip="Simpan data header" style="background-color:#0477C0; color:white" 
                OnClick="btnSave_Click" AutoPostBack="true"></dx:BootstrapButton>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
        <dx:BootstrapButton runat="server" ID="btnAdd" Text="Tambah Produk" style="background-color:#0477C0; color:white" AutoPostBack="false" CausesValidation="true">
            <ClientSideEvents Click="OnAddProduct"/>
        </dx:BootstrapButton>
        <dx:BootstrapGridView ID="gvProductSP3M" ClientInstanceName="gvProductSP3M" runat="server" KeyFieldName="SP3M_Items_ID_PK" Width="100%"
            AutoGenerateColumns="False" EnableCallBacks="false" 
            OnRowInserting="gvProductSP3M_RowInserting" 
            OnRowUpdating="gvProductSP3M_RowUpdating" 
            OnRowDeleting="gvProductSP3M_RowDeleting" 
            OnDataBinding="gvProductSP3M_DataBinding">
            <SettingsDataSecurity AllowDelete="true" AllowEdit="true" AllowInsert="true" />
            <SettingsEditing Mode="Inline"></SettingsEditing>
            <SettingsBehavior ConfirmDelete="true"/>
            <Settings ShowHeaderFilterButton="false" ShowGroupPanel="false" ShowFooter="true"/>
            <SettingsSearchPanel Visible="false" ShowApplyButton="false" />
            <SettingsLoadingPanel Mode="ShowAsPopup" />
            <SettingsPager Mode="ShowAllRecords"/>
            <SettingsCommandButton EditButton-IconCssClass="glyphicon glyphicon-edit" DeleteButton-IconCssClass="glyphicon glyphicon-remove"
                UpdateButton-IconCssClass="glyphicon glyphicon-ok" CancelButton-IconCssClass="glyphicon glyphicon-remove-sign"></SettingsCommandButton>
            <Columns>
                <dx:BootstrapGridViewCommandColumn Caption=" " AllowDragDrop="False" ButtonRenderMode="Button" Name="CommandColumnProduct"
                    ShowEditButton="true" ShowDeleteButton="true" />
                <dx:BootstrapGridViewComboBoxColumn Name="cmbProduct" FieldName="ProductName" Caption="Produk" >                    
                    <PropertiesComboBox ValueField ="Product_ID_PK" TextField="Name">
                        <ValidationSettings RequiredField-IsRequired ="true" RequiredField-ErrorText="Field is Required" SetFocusOnError="true"/>
                        <Items>
                            <dx:BootstrapListEditItem Value="1" Text="PERTAMAX" />
                            <dx:BootstrapListEditItem Value="2" Text="PERTAMINA DEX" />
                            <dx:BootstrapListEditItem Value="3" Text="KEROSINE" />
                            <dx:BootstrapListEditItem Value="4" Text="MT-88" />
                            <dx:BootstrapListEditItem Value="5" Text="HSD" />
                        </Items>
                    </PropertiesComboBox>
                </dx:BootstrapGridViewComboBoxColumn>
                <dx:BootstrapGridViewSpinEditColumn FieldName="QuantityVolume" Caption="Kuantitas">
                    <PropertiesSpinEdit ClientInstanceName="Quantity" NumberType="Float" DisplayFormatString="{0:N0} Liter" DisplayFormatInEditMode="true"
                         ClientSideEvents-ValueChanged = "QuantityChange">
                        <ValidationSettings RequiredField-IsRequired ="true" RequiredField-ErrorText="Field is Required" SetFocusOnError="true"/>
                    </PropertiesSpinEdit>
                </dx:BootstrapGridViewSpinEditColumn>
                <dx:BootstrapGridViewSpinEditColumn FieldName="PriceUnit" Caption="Harga Satuan">
                    <PropertiesSpinEdit ClientInstanceName="PriceUnit" NumberType="Float" DisplayFormatString="IDR {0:N0}" DisplayFormatInEditMode="true"
                        ClientSideEvents-ValueChanged="PriceUnitChange">
                        <ValidationSettings RequiredField-IsRequired ="true" RequiredField-ErrorText="Field is Required" SetFocusOnError="true"/>
                    </PropertiesSpinEdit>
                </dx:BootstrapGridViewSpinEditColumn>
                 <dx:BootstrapGridViewTextColumn FieldName="SubTotal" Caption="Harga SubTotal" ReadOnly="true" >
                    <PropertiesTextEdit ClientInstanceName="SubTotal" DisplayFormatString="IDR {0:N0}" DisplayFormatInEditMode="true"></PropertiesTextEdit>
                </dx:BootstrapGridViewTextColumn>
            </Columns>
            <TotalSummary>
                <dx:ASPxSummaryItem FieldName="SubTotal" SummaryType="Sum" />
            </TotalSummary>
        </dx:BootstrapGridView> 
        </div>
    </div>
    <div class="row" style="text-align:center;">
        <div class="col-md-12">
            <dx:BootstrapButton runat="server" ID="btnSubmit" ClientInstanceName="btnSubmit" Text="Submit" style="background-color:#0477C0; color:white" 
                OnClick="btnSubmit_Click" AutoPostBack="true"></dx:BootstrapButton>
            <dx:BootstrapButton runat="server" ID="btnCancel" ClientInstanceName="btnCancel" Text="Cancel" AutoPostBack="false" CausesValidation="false">
                <ClientSideEvents Click="OnClear" />
            </dx:BootstrapButton>
            <dx:BootstrapButton runat="server" ID="btnClose" ClientInstanceName="btnClose" Text="Close" AutoPostBack="true" CausesValidation="false"
                OnClick="btnClose_Click" />
                
            <dx:BootstrapButton runat="server" ID="btnApprove" ClientInstanceName="btnApprove" Text="Approve" style="background-color:#0477C0;" 
                AutoPostBack="true" CausesValidation="true"
                OnClick="btnApprove_Click" />                
            <dx:BootstrapButton runat="server" ID="btnClarify" ClientInstanceName="btnClarify" Text="Clarify" ToolTip="Back to Previous Status"
                AutoPostBack="true" CausesValidation="false" 
                OnClick="btnClarify_Click" />
             <%--style="background-color:#ffff00;"--%> 
            <dx:BootstrapButton runat="server" ID="btnReject" ClientInstanceName="btnReject" Text="Reject" ToolTip="Rejected data SP3M"
                AutoPostBack="true" CausesValidation="false"
                OnClick="btnReject_Click" />
             <%--style="background-color:#ff0000; color:white"--%> 
        </div>
    </div>
    
</div>
</asp:Content>