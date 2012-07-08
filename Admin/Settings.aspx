<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="Kawanoikioi.Admin.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="SettingsHeader" runat="server" SkinID="PageHeaderLabel" 
        Text="Site Settings"></asp:Label>
    <br />
    <asp:Label ID="SiteNameLabel" runat="server" 
        Text="Site Name: (Change the value to modify Site Name):"></asp:Label>
    <br />
    <asp:TextBox ID="SiteNameTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="LogoLabel" runat="server" Text="Logotype:"></asp:Label>
    <br />
    <asp:Label ID="LogoDescriptionLabel" runat="server" 
        Text="In order to specify a logotype for this website please start by selecting a source from where the logotype may be retrieved below."></asp:Label>
    <br />
    <asp:RadioButtonList ID="LogoSourceSelectionList" runat="server" 
        AutoPostBack="True" 
        onselectedindexchanged="LogoSourceSelectionList_SelectedIndexChanged">
        <asp:ListItem Value="Computer">From My Computer</asp:ListItem>
        <asp:ListItem Value="Internet">From the Internet</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <asp:PlaceHolder ID="LogotypePlaceHolder" runat="server"></asp:PlaceHolder>
    <br />
    <asp:Button ID="SubmitChangesButton" runat="server" Height="26px" 
        onclick="SubmitChangesButton_Click" Text="Submit Changes" />
</asp:Content>
