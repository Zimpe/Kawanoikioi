<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="Kawanoikioi.Media.Videos.Upload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="PageHeaderLabel" runat="server" SkinID="PageHeaderLabel" 
        Text="Upload a Video"></asp:Label>
    <br />
    <asp:Label ID="ExplanationLabel" runat="server" SkinID="ExplanationLabel" 
        Text="While descriptions and titles are not required for videos, it is recommended that you specify atleast a title. If you wish to change either later you can edit them later at any time."></asp:Label>
    <br />
    <br />
    <asp:Label ID="TitleLabel" runat="server" 
        Text="Title (Optional) if a title is not specified the title will be based off the filename."></asp:Label>
    <br />
    <asp:TextBox ID="TitleTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="DescriptionLabel" runat="server" Text="Description (Optional)"></asp:Label>
    <br />
    <asp:TextBox ID="DescriptionTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
    <br />
    <asp:Label ID="VideoSpecLabel" runat="server" 
        Text="Please specify which video you wish to upload."></asp:Label>
    <br />
    <asp:FileUpload ID="VideoFileUpload" runat="server" />
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="ProgressLabel" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="UploadButton" runat="server" onclick="UploadButton_Click" 
        Text="Upload!" />
</asp:Content>
