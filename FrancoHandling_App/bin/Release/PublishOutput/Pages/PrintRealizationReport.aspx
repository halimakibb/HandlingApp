<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeBehind="PrintRealizationReport.aspx.cs" Inherits="FrancoHandling_App.Report.PrintRealizationReport" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.XtraReports.v17.1.Web, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <script type="text/javascript">

        function btnPrintClick(s, e) {
            if (txtYear.GetIsValid()) {
                cBackReport.PerformCallback();
            }
        }

    </script>

    <div class="container">
        <div class="row">
            <div class="page-header">
                <h1>Realization Report</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4" style="text-align:center"></div>
            <div class="col-md-4" style="text-align:center">
                <dx:BootstrapTextBox runat="server" ID="txtYear" ClientInstanceName="txtYear" Caption="Please input invoice year">
                    <ValidationSettings RequiredField-IsRequired="true"  RegularExpression-ErrorText="Field is Required" SetFocusOnError="true"></ValidationSettings>
                </dx:BootstrapTextBox>
                <%--<dx:ASPxTextBox ID="txtYear" runat="server" ClientInstanceName="txtYear" Caption="Please input invoice year"
                    ValidationSettings-RequiredField-IsRequired="true"></dx:ASPxTextBox>--%>
            </div>                
            <div class="col-md-4" style="text-align:center"></div>
        </div>        
        <div class="row">
            <div class="col-md-12" style="text-align:center"> 
                <dx:BootstrapButton runat="server" ID="btnPrint" ClientInstanceName="btnPrint" Text="Refresh" AutoPostBack="false" CausesValidation="false"
                    ClientSideEvents-Click="btnPrintClick"/>   
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-md-12">
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
