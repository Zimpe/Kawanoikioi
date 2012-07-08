<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="Kawanoikioi.Media.Images.Upload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="UploadHeaderLabel" runat="server" Text="Upload your image"></asp:Label>
    <br />
    <asp:FileUpload ID="ImageUpload" runat="server" />
    <br />
    <asp:Button ID="UploadButton" runat="server" onclick="UploadButton_Click" 
        Text="Upload" />
    <br />
    <asp:Label ID="ResultLabel" runat="server"></asp:Label>
    <br />
</asp:Content>
