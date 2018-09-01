<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="FrancoHandling_App.Pages.ErrorPage.ErrorPage" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <div class="container">
        <div class="row">
            <div class="text-center" style="width:240px; margin:auto; margin-top:20px;">
                <img src="../../Content/Images/Common/error.png" />          
            </div>
        </div>
        <div class="row">    
            <div class="text-center" style="width:80%; margin:auto; margin-top:20px;">
                <dx:BootstrapMemo runat="server" ID="MemoError" Caption="Error Message" ReadOnly="true"></dx:BootstrapMemo>
            </div>
        </div>
         <div class="row">
            <div class="text-center" style="width:240px; margin:auto; margin-top:20px;">
                 <h3>
                    <a href="../Default.aspx">Go to Default Page</a>
                </h3>
            </div>
        </div>

    </div>
</asp:Content>
