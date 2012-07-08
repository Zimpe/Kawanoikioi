<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowForum.aspx.cs" Inherits="Kawanoikioi.Forum.ShowForum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HyperLink ID="AddPostLink" runat="server">Write a new post</asp:HyperLink>
    <br />
    <asp:GridView ID="ForumGridView" runat="server" AutoGenerateColumns="False" 
        DataSourceID="ObjectDataSource1" AllowPaging="True" 
        onrowdatabound="ForumGridView_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Topic" SortExpression="Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:HyperLink ID="MessageLink" runat="server" Text='<%# Eval("Name") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Author" HeaderText="Author" 
                SortExpression="Author" />
            <asp:BoundField DataField="SubmissionDate" HeaderText="SubmissionDate" 
                SortExpression="SubmissionDate" />
            <asp:BoundField DataField="LastModified" HeaderText="LastModified" 
                SortExpression="LastModified" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetForumMessages" 
        TypeName="Kawanoikioi.Models.KawanoikioiDbRepository">
        <SelectParameters>
            <asp:RouteParameter Name="uniqueName" RouteKey="id" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
