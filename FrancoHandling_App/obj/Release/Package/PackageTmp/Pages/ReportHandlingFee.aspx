<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeBehind="ReportHandlingFee.aspx.cs" Inherits="FrancoHandling_App.Pages.ReportHandlingFee" %>

<%@ Register Assembly="DevExpress.XtraReports.v17.1.Web, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <script type="text/javascript">

        function OnClick_Refresh(s, e) {
            //var dateStart = datePeriodeStart.GetValue() != null ? datePeriodeStart.GetDate() : Date.now();
            //var dateEnd = datePeriodeEnd.GetValue() != null ? datePeriodeEnd.GetDate() : Date.now();
            //var tbbm = cmbTBBM.GetSelectedItem() != null ? cmbTBBM.GetSelectedItem().value : "0";
            //var force = cmbForce.GetSelectedItem() != null ? cmbForce.GetSelectedItem().value : "0";
            //var unity = cmbUnity.GetSelectedItem() != null ? cmbUnity.GetSelectedItem().value : "0";
            //var param = dateStart + '#' + dateEnd + '#' + tbbm + '#' + force + '#' + unity

            if (datePeriodeStart.GetIsValid()
                && datePeriodeEnd.GetIsValid()
                && cmbTBBM.GetIsValid()
                && cmbForce.GetIsValid()
                && cmbForce.GetIsValid()) {
                cBackReport.PerformCallback();
            }
        }
        
    </script>


<div class="container">
    <div class="row">
        <div class="page-header">
            <h1>Laporan Handling Fee</h1>
        </div>
    </div>

    <div class="row">
        <div class="col-md-2">
            <dx:BootstrapDateEdit runat="server" ID="datePeriodeStart" ClientInstanceName="datePeriodeStart" Caption="Periode From" DisplayFormatString="dd.MM.yyyy">
                <ValidationSettings  RequiredField-IsRequired="true"  RegularExpression-ErrorText="Field is Required" SetFocusOnError="true"></ValidationSettings>
            </dx:BootstrapDateEdit>
        </div>
        <div class="col-md-2">
            <dx:BootstrapDateEdit runat="server" ID="datePeriodeEnd" ClientInstanceName="datePeriodeEnd" Caption="Periode To" DisplayFormatString="dd.MM.yyyy">
                <ValidationSettings  RequiredField-IsRequired="true"  RegularExpression-ErrorText="Field is Required" SetFocusOnError="true"></ValidationSettings>
            </dx:BootstrapDateEdit>
        </div>
        <div class="col-md-8">
            <dx:BootstrapComboBox runat="server" ID="cmbTBBM" ClientInstanceName="cmbTBBM" Caption="TBBM"
                ValueField="TBBM_ID_PK" TextField="Name">
                <ValidationSettings RequiredField-IsRequired="true" RequiredField-ErrorText="Field is Required" SetFocusOnError="true"></ValidationSettings>
            </dx:BootstrapComboBox>
        </div>
    </div><br />
    <div class="row">
        <div class="col-md-4">
            <dx:BootstrapComboBox runat="server" ID="cmbForce" ClientInstanceName="cmbForce" Caption="Angkatan"
                ValueField="Force" TextField="Force">
                <ValidationSettings RequiredField-IsRequired="true" RequiredField-ErrorText="Field is Required" SetFocusOnError="true"></ValidationSettings>
            </dx:BootstrapComboBox>
        </div>
        <div class="col-md-8">
            <dx:BootstrapComboBox runat="server" ID="cmbUnity" ClientInstanceName="cmbUnity" Caption="Kesatuan"
                ValueField="Unity" TextField="Unity">
                <ValidationSettings RequiredField-IsRequired="true" RequiredField-ErrorText="Field is Required" SetFocusOnError="true"></ValidationSettings>
            </dx:BootstrapComboBox>
        </div>
    </div><br />
   
    <div class="row">
        <div class="col-md-12" style="text-align:center">
            <dx:BootstrapButton runat="server" ID="btnRefresh" Text="Refresh" Width="120px" 
                ClientSideEvents-Click="OnClick_Refresh" AutoPostBack="false"
                style="background-color:#0477C0; color:white" CausesValidation="true">
            </dx:BootstrapButton>
        </div>
    </div><br />

    <div class="row">
        <div class="col-md-12" style="text-align:right">
            <dx:BootstrapCallbackPanel ID="cBackReport" ClientInstanceName="cBackReport" runat="server" OnCallback="cBackReport_Callback">
                <ContentCollection>
                    <dx:ContentControl>
                        <dx:ASPxWebDocumentViewer ID="docViewer" runat="server"></dx:ASPxWebDocumentViewer>
                    </dx:ContentControl>
                </ContentCollection>                
            </dx:BootstrapCallbackPanel>
        </div>
    </div>

</div>
</asp:Content>
