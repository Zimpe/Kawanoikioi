<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Kawanoikioi.Media.Images.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DataList ID="ImagesList" runat="server" DataSourceID="ObjectDataSource1" RepeatDirection="Horizontal"
        OnItemDataBound="ImagesList_ItemDataBound" RepeatLayout="Flow">
        <ItemTemplate>
            <asp:Panel ID="ImagePanel" runat="server" SkinID="ImagePanel">
                <asp:Label ID="FileNameLabel" runat="server" />
                <br />
                <asp:Image ID="ShowImage" runat="server" />
                <br />
                <br />
                Uploaded by
                <asp:Label ID="UploaderLabel" runat="server" />
                on the
                <asp:Label ID="SubmissionDateLabel" runat="server" />
            </asp:Panel>
        </ItemTemplate>
    </asp:DataList>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetImages"
        TypeName="Kawanoikioi.Models.KawanoikioiDbRepository"></asp:ObjectDataSource>
</asp:Content>
