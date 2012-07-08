<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Kawanoikioi.Media.Articles.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="HeaderLabel" runat="server" SkinID="PageHeaderLabel" Text="Articles"></asp:Label>
    <br />
    <asp:GridView ID="ArticlesListingView" runat="server" AutoGenerateColumns="False"
        DataSourceID="ObjectDataSource1" 
        OnRowDataBound="ArticlesListingView_RowDataBound">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="#" SortExpression="ID" />
            <asp:TemplateField HeaderText="Title" SortExpression="Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:HyperLink ID="ArticleLink" runat="server" Text='<%# Eval("Name") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" />
        </Columns>
        <EmptyDataTemplate>
            There does not seem to be any entries in the database.
        </EmptyDataTemplate>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetArticles"
        TypeName="Kawanoikioi.Models.KawanoikioiDbRepository" />
</asp:Content>
