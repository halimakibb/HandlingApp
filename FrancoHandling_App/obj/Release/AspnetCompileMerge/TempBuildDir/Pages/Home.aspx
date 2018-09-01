<%@ Page Title="Home" Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout.master" CodeBehind="Home.aspx.cs" Inherits="FrancoHandling_App.Home" %>

<%@ Register Src="~/UserControls/Login.ascx" TagPrefix="uc" TagName="LoginForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    
<div class="container">
    <div class="row">        
        <uc:LoginForm runat="server" id="Login" />
    </div>
</div>
    
</asp:Content>