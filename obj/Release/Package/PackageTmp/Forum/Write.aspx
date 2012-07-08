<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Write.aspx.cs" Inherits="Kawanoikioi.Forum.Write" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:Label ID="TitleLabel" runat="server" Text="Title:"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TitleTextBox" 
        ErrorMessage="A title is required."></asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="TitleTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="ContentLabel" runat="server" Text="Content"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ErrorMessage="Content is required." ControlToValidate="ContentTextBox"></asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="ContentTextBox" runat="server" TextMode="MultiLine" 
    Height="200px" Width="600px"></asp:TextBox>
    <ajaxToolkit:HtmlEditorExtender ID="ContentTextBox_HtmlEditorExtender" 
    runat="server" Enabled="True" TargetControlID="ContentTextBox">
</ajaxToolkit:HtmlEditorExtender>
<br />
    <asp:Button ID="AddButton" runat="server" Text="Submit" 
    onclick="AddButton_Click" />
</asp:Content>
