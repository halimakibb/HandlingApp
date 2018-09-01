<%@ Page Title="HOME" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FrancoHandling_App.Pages.Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<div class="container-fluid">
    <div class="row">
        <dx:ASPxImageSlider ID="ImageSlider" runat="server" Width="100%" Height="400px" ImageSourceFolder="~/Content/Images/Components">
            <SettingsImageArea ImageSizeMode="FillAndCrop" NavigationButtonVisibility="Always" EnableLoopNavigation="true" />
            <SettingsNavigationBar Mode="Dots" />
            <SettingsSlideShow AutoPlay="true" PlayPauseButtonVisibility="OnMouseOver" />
        </dx:ASPxImageSlider>
    </div>
</div>
</asp:Content>