<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Kawanoikioi.Forum.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/Default/Forum.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater ID="CategoryRepeater" runat="server" DataSourceID="ObjectDataSource1"
        OnItemCreated="CategoryRepeater_ItemCreated">
        <ItemTemplate>
            <asp:Label ID="CategoryHeaderLabel" runat="server" SkinID="PageHeaderLabel" />
            <asp:GridView ID="CategoryGridView" runat="server" AutoGenerateColumns="False" OnRowDataBound="CategoryGridView_RowDataBound" SkinID="ForumCategoryGrid">
                <Columns>
                    <asp:BoundField DataField="OrderID" HeaderText="#" SortExpression="OrderID" />
                    <asp:TemplateField HeaderText="Name" SortExpression="Name">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:HyperLink ID="ForumLink" runat="server"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                </Columns>
            </asp:GridView>
        </ItemTemplate>
        <SeparatorTemplate>
            <hr class="forumSeparator" />
        </SeparatorTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetForumCategories"
        TypeName="Kawanoikioi.Models.KawanoikioiDbRepository"></asp:ObjectDataSource>
</asp:Content>
