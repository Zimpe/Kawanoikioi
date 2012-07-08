<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Show.aspx.cs" Inherits="Kawanoikioi.Media.Articles.Show" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../../App_Themes/Default/Styles/Site.css" rel="stylesheet" 
        type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource1" CssClass="showArticleView">
        <EditItemTemplate>
            ID:
            <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
            <br />
            UniqueName:
            <asp:TextBox ID="UniqueNameTextBox" runat="server" Text='<%# Bind("UniqueName") %>' />
            <br />
            Name:
            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
            <br />
            Content:
            <asp:TextBox ID="ContentTextBox" runat="server" Text='<%# Bind("Content") %>' />
            <br />
            Author:
            <asp:TextBox ID="AuthorTextBox" runat="server" Text='<%# Bind("Author") %>' />
            <br />
            IsPublished:
            <asp:CheckBox ID="IsPublishedCheckBox" runat="server" Checked='<%# Bind("IsPublished") %>' />
            <br />
            SubmissionDate:
            <asp:TextBox ID="SubmissionDateTextBox" runat="server" Text='<%# Bind("SubmissionDate") %>' />
            <br />
            LastModified:
            <asp:TextBox ID="LastModifiedTextBox" runat="server" Text='<%# Bind("LastModified") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>
            ID:
            <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
            <br />
            UniqueName:
            <asp:TextBox ID="UniqueNameTextBox" runat="server" Text='<%# Bind("UniqueName") %>' />
            <br />
            Name:
            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
            <br />
            Content:
            <asp:TextBox ID="ContentTextBox" runat="server" Text='<%# Bind("Content") %>' />
            <br />
            Author:
            <asp:TextBox ID="AuthorTextBox" runat="server" Text='<%# Bind("Author") %>' />
            <br />
            IsPublished:
            <asp:CheckBox ID="IsPublishedCheckBox" runat="server" Checked='<%# Bind("IsPublished") %>' />
            <br />
            SubmissionDate:
            <asp:TextBox ID="SubmissionDateTextBox" runat="server" Text='<%# Bind("SubmissionDate") %>' />
            <br />
            LastModified:
            <asp:TextBox ID="LastModifiedTextBox" runat="server" Text='<%# Bind("LastModified") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False"
                CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>' Font-Size="20px" />
            <p>
                <asp:Label ID="ContentLabel" runat="server" Text='<%# Bind("Content") %>' /></p>
            <p>
                Written by
                <asp:Label ID="AuthorLabel" runat="server" Text='<%# Bind("Author") %>' />
                <br />
                Submitted on
                <asp:Label ID="SubmissionDateLabel" runat="server" Text='<%# Bind("SubmissionDate") %>' />
                and was last modified:
                <asp:Label ID="LastModifiedLabel" runat="server" Text='<%# Bind("LastModified") %>' />
            </p>
        </ItemTemplate>
    </asp:FormView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetArticle"
        TypeName="Kawanoikioi.Models.KawanoikioiDbRepository">
        <SelectParameters>
            <asp:RouteParameter Name="uniqueName" RouteKey="ID" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
