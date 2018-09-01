<%@ Page Title="SPPB" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeBehind="InputSPPB.aspx.cs" Inherits="FrancoHandling_App.Pages.InputSPPB" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<script type="text/javascript">
    function OnClearInputSPPB(s, e) {
        txtSPP_Number.Clear();
        //cmbForce.Clear();
        //cmbUnity.Clear();
        txtForce.Clear();
        txtUnity.Clear();
        txtSA_Number.Clear();
        txtSP2M_Number.Clear();
        cmbSP3M.Clear();
        gvProductSP3M.CancelEdit();
        cpSP3MProduct.PerformCallback(0);
        cpSP3M.PerformCallback(0);
        dateDelivery.Clear();
        cmbDeliveryFrom.Clear();
        txtAddressFrom.Clear();
        cmbDeliveryTo.Clear();
        txtAddressTo.Clear();
        cmbTransporter.Clear();
        cmbVehicleNumber.Clear();
        txtVehicleNumber.Clear();
        txtCapacity.Clear();
        cmbDriver.Clear();
        txtDriver.Clear();
        txtNote.Clear();
    }

    function QuantityChange(s, e) {
        SubTotal.SetValue(Quantity.GetValue() * PriceUnit.GetValue());
    }

    function PriceUnitChange(s, e) {
        SubTotal.SetValue(Quantity.GetValue() * PriceUnit.GetValue());
    }

    var vehicle = null;
    var driver = null;
    function OnSelectedTransportir(s, e) {
        var val = s.GetSelectedItem().value;

        //set combobox vehicle
        if (cmbVehicleNumber.InCallback())
            vehicle = val;
        else
            cmbVehicleNumber.PerformCallback(val);

        //set combobox driver
        if (cmbDriver.InCallback())
            driver = val;
        else
            cmbDriver.PerformCallback(val);
    }

    function OnEndCallback_VehicleNumber(s, e) {
        if (vehicle) {
            cmbVehicleNumber.PerformCallback(vehicle);
            vehicle = null;
        }
    }

    function OnEndCallback_Driver(s, e) {
        if (driver) {
            cmbDriver.PerformCallback(driver);
            driver = null;
        }
    }

    function OnSelectedVehicle(s, e) {
        cpCapacity.PerformCallback(s.GetSelectedItem().value);
    }

    var force = null;
    var unity = null;
    function OnSelected_SP3M(s, e) {
        var val = s.GetSelectedItem().value;
      
        //set sp3m
        cpSP3M.PerformCallback(val);
        cpSP3MProduct.PerformCallback(val);
    }
        
</script>


    <div class="container">
        <div class="row">
            <div class="page-header">
                <h1>Input SPPB</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <dx:BootstrapTextBox runat="server" ID="txtSPP_Number" ClientInstanceName="txtSPP_Number" Caption="Nomor SPPB">
                    <ValidationSettings RequiredField-IsRequired="true" RequiredField-ErrorText="Field is Required" SetFocusOnError="true"></ValidationSettings>
                </dx:BootstrapTextBox><br />
                <dx:BootstrapComboBox runat="server" ID="cmbSP3M" ClientInstanceName="cmbSP3M" Caption="Nomor SP3M"
                    ValueField="SP3M_ID_PK" TextField="NoSP3M">
                    <ClientSideEvents SelectedIndexChanged="OnSelected_SP3M" />
                    <ValidationSettings RequiredField-IsRequired="true" RequiredField-ErrorText="Field is Required" SetFocusOnError="true"></ValidationSettings>
                </dx:BootstrapComboBox><br />
                <dx:BootstrapCallbackPanel runat="server" ID="cpSP3M" ClientInstanceName="cpSP3M" OnCallback="cpSP3M_Callback">
                    <ContentCollection>
                        <dx:ContentControl>                           
                            <dx:BootstrapTextBox runat="server" ID="txtForce" ClientInstanceName="txtForce" Caption="Angkatan" ReadOnly="true"></dx:BootstrapTextBox><br />
                            <dx:BootstrapTextBox runat="server" ID="txtUnity" ClientInstanceName="txtUnity" Caption="Kesatuan" ReadOnly="true"></dx:BootstrapTextBox><br />
                            <dx:BootstrapTextBox runat="server" ID="txtSA_Number" ClientInstanceName="txtSA_Number" Caption="Nomor SA" ReadOnly="true"></dx:BootstrapTextBox><br />
                            <dx:BootstrapTextBox runat="server" ID="txtSP2M_Number" ClientInstanceName="txtSP2M_Number" Caption="Nomor SP2M" ReadOnly="true"></dx:BootstrapTextBox>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:BootstrapCallbackPanel>
            </div>
            <div class="col-md-6">
                <dx:BootstrapDateEdit runat="server" ID="dateDelivery" ClientInstanceName="dateDelivery" Caption="Tanggal Pengiriman" DisplayFormatString="dd.MM.yyyy"><ClientSideEvents GotFocus="function(s,e){s.ShowDropDown();}"/></dx:BootstrapDateEdit><br />
                <dx:BootstrapComboBox runat="server" ID="cmbDeliveryFrom" ClientInstanceName="cmbDeliveryFrom" Caption="Lokasi TBBM"  AutoPostBack="false"
                    ValueField="TBBM_ID_PK" TextField="Name">
                    <ClientSideEvents SelectedIndexChanged="function(s,e){ cpAddressFrom.PerformCallback(s.GetSelectedItem().value); }" />
                </dx:BootstrapComboBox><br />
                <dx:BootstrapCallbackPanel runat="server" ID="cpAddressFrom" ClientInstanceName="cpAddressFrom" OnCallback="cpAddressFrom_Callback">
                    <ContentCollection>
                        <dx:ContentControl>                            
                            <dx:BootstrapTextBox runat="server" ID="txtAddressFrom" ClientInstanceName="txtAddressFrom" Caption="Alamat TBBM" ReadOnly="true"></dx:BootstrapTextBox><br />
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:BootstrapCallbackPanel>       
                <dx:BootstrapComboBox runat="server" ID="cmbDeliveryTo" ClientInstanceName="cmbDeliveryTo" Caption="Penerima"  AutoPostBack="false"
                    ValueField="SPSH_ID" TextField="Name">
                    <ClientSideEvents SelectedIndexChanged="function(s,e){ cpAddressTo.PerformCallback(s.GetSelectedItem().value); }" />
                </dx:BootstrapComboBox><br />
                <dx:BootstrapCallbackPanel runat="server" ID="cpAddressTo" ClientInstanceName="cpAddressTo" OnCallback="cpAddressTo_Callback">
                    <ContentCollection>
                        <dx:ContentControl>                            
                            <dx:BootstrapTextBox runat="server" ID="txtAddressTo" ClientInstanceName="txtAddressTo" Caption="Alamat Penerima" ReadOnly="true"></dx:BootstrapTextBox><br />
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:BootstrapCallbackPanel>
            </div>
        </div><br />

        <div class="row" style="text-align:center;">
            <div class="col-md-12">
                <dx:BootstrapCallbackPanel runat="server" ID="cpSP3MProduct" ClientInstanceName="cpSP3MProduct" OnCallback="cpSP3MProduct_Callback">
                    <ContentCollection>
                        <dx:ContentControl>
                            <dx:BootstrapGridView ID="gvProductSP3M" ClientInstanceName="gvProductSP3M" runat="server" KeyFieldName="SP3M_Items_ID_PK"
                                OnRowUpdating="gvProductSP3M_RowUpdating">
                                <SettingsDataSecurity AllowEdit="true" />
                                <SettingsEditing Mode="Inline"></SettingsEditing>
                                <SettingsBehavior ConfirmDelete="true" AllowSort="false"/>
                                <Settings ShowHeaderFilterButton="false" ShowGroupPanel="false" ShowFooter="true"/>
                                <SettingsSearchPanel Visible="false" ShowApplyButton="false" />
                                <SettingsLoadingPanel Mode="ShowAsPopup" />
                                <SettingsPager Mode="ShowAllRecords"/>
                                <SettingsCommandButton EditButton-IconCssClass="glyphicon glyphicon-edit" DeleteButton-IconCssClass="glyphicon glyphicon-remove"
                                    UpdateButton-IconCssClass="glyphicon glyphicon-ok" CancelButton-IconCssClass="glyphicon glyphicon-remove-sign"></SettingsCommandButton>
                                <Columns>
                                    <dx:BootstrapGridViewCommandColumn Caption=" " AllowDragDrop="False" ButtonRenderMode="Button" Name="CommandColumnProduct" ShowEditButton="true"/>
                                    <dx:BootstrapGridViewComboBoxColumn Name="cmbProduct" FieldName="ProductName" Caption="Produk" ReadOnly="true" >
                                        <PropertiesComboBox DropDownButton-Visible="false"></PropertiesComboBox>       
                                    </dx:BootstrapGridViewComboBoxColumn>
                                    <dx:BootstrapGridViewSpinEditColumn FieldName="QuantityVolume" Caption="Kuantitas">
                                        <PropertiesSpinEdit ClientInstanceName="Quantity" NumberType="Float" DisplayFormatString="{0:N0} Liter" DisplayFormatInEditMode="true"
                                             ClientSideEvents-ValueChanged = "QuantityChange">
                                            <ValidationSettings RequiredField-IsRequired ="true" RequiredField-ErrorText="Field is Required" SetFocusOnError="true"/>
                                        </PropertiesSpinEdit>
                                    </dx:BootstrapGridViewSpinEditColumn>
                                    <dx:BootstrapGridViewSpinEditColumn FieldName="PriceUnit" Caption="Harga Satuan" SettingsEditForm-Visible="False" ReadOnly="true" >
                                        <PropertiesSpinEdit ClientInstanceName="PriceUnit" NumberType="Float" DisplayFormatString="IDR {0:N0}" DisplayFormatInEditMode="true"
                                            SpinButtons-ClientVisible="false"
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
                        </dx:ContentControl>                          
                    </ContentCollection>
                </dx:BootstrapCallbackPanel>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <dx:BootstrapComboBox runat="server" ID="cmbTransporter" ClientInstanceName="cmbTransporter" Caption="Transportir" EnableSynchronization="False"
                    ValueField="Transporter_ID" TextField="TransporterName">
                    <ClientSideEvents SelectedIndexChanged="OnSelectedTransportir" />
                </dx:BootstrapComboBox>
                <dx:ASPxHiddenField runat="server"  ID="hf" ClientInstanceName="hf"></dx:ASPxHiddenField>
                <dx:BootstrapComboBox runat="server" ID="cmbVehicleNumber" ClientInstanceName="cmbVehicleNumber" Caption="No. Kendaraan/ No. Polisi" AutoPostBack="false" EnableSynchronization="False"
                    ValueField="Vehicle_ID" TextField="Number" OnCallback="cmbVehicleNumber_Callback">
                    <ClientSideEvents EndCallback="OnEndCallback_VehicleNumber" SelectedIndexChanged="OnSelectedVehicle"/>
                </dx:BootstrapComboBox>
                <dx:BootstrapCallbackPanel runat="server" ID="cpCapacity" ClientInstanceName="cpCapacity" OnCallback="cpCapacity_Callback">
                    <ContentCollection>
                        <dx:ContentControl>                            
                            <dx:BootstrapTextBox runat="server" ID="txtCapacity" ClientInstanceName="txtCapacity" Caption="Kapasitas Angkut" ReadOnly="true"></dx:BootstrapTextBox><br />
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:BootstrapCallbackPanel>
            </div>
            <div class="col-md-6">                         
                <dx:BootstrapComboBox runat="server" ID="cmbDriver" ClientInstanceName="cmbDriver" Caption="Nama Pengemudi" EnableSynchronization="False"
                    ValueField="Driver_ID" TextField="Name" OnCallback="cmbDriver_Callback">
                    <ClientSideEvents EndCallback="OnEndCallback_Driver"/>
                </dx:BootstrapComboBox>
                <dx:BootstrapMemo runat="server" ID="txtNote" ClientInstanceName="txtNote" Caption="Catatan" Rows="3"></dx:BootstrapMemo>
            </div>
        </div><br />

        <div class="row" style="text-align:center;">
            <div class="col-md-12">
                <dx:BootstrapButton runat="server" ID="btnSave" ClientInstanceName="btnSave" Text="Save" style="background-color:#0477C0; color:white" CausesValidation="true"
                    OnClick="btnSave_Click" >
                    <ClientSideEvents Click="function(s,e){ 
                                                        if(ASPxClientEdit.ValidateGroup(null)) 
                                                        {
                                                            lpModal.Show();
                                                            e.processOnServer = true;
                                                        }
                                                        else 
                                                        {
                                                            e.processOnServer = false; 
                                                            Alert('warning', 'Warning', 'Some required fields is still empty or have a wrong format. Please check again.');
                                                        }
                                                    }"/>
                </dx:BootstrapButton>
                <dx:BootstrapButton runat="server" ID="btnSubmit" ClientInstanceName="btnSubmit" Text="Submit" style="background-color:#0477C0; color:white" 
                    OnClick="btnSubmit_Click" AutoPostBack="true"></dx:BootstrapButton>
                <dx:BootstrapButton runat="server" ID="btnCancel" ClientInstanceName="btnCancel" Text="Cancel" AutoPostBack="false" CausesValidation="false">
                    <ClientSideEvents Click="OnClearInputSPPB" />
                </dx:BootstrapButton>
                <dx:BootstrapButton runat="server" ID="btnClose" ClientInstanceName="btnClose" Text="Close" AutoPostBack="true" CausesValidation="false"
                    OnClick="btnClose_Click" />                
                <dx:BootstrapButton runat="server" ID="btnApprove" ClientInstanceName="btnApprove" Text="Approve" style="background-color:#0477C0;" 
                    AutoPostBack="true" CausesValidation="true"
                    OnClick="btnApprove_Click" />                
                <dx:BootstrapButton runat="server" ID="btnClarify" ClientInstanceName="btnClarify" Text="Clarify" ToolTip="Back to Previous Status"
                    AutoPostBack="true" CausesValidation="false" 
                    OnClick="btnClarify_Click" />
                <dx:BootstrapButton runat="server" ID="btnReject" ClientInstanceName="btnReject" Text="Reject" ToolTip="Rejected data SPP"
                    AutoPostBack="true" CausesValidation="false"
                    OnClick="btnReject_Click" />
            </div>
        </div>
    </div>
            
</asp:Content>

