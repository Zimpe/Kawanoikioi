<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ShowMessage.aspx.cs" Inherits="Kawanoikioi.Forum.ShowMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/Default/Forum.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:FormView ID="OriginalPostView" runat="server" DataSourceID="ObjectDataSource1" CssClass="originalPost">
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
            IsReply:
            <asp:CheckBox ID="IsReplyCheckBox" runat="server" Checked='<%# Bind("IsReply") %>' />
            <br />
            ReplyTo:
            <asp:TextBox ID="ReplyToTextBox" runat="server" Text='<%# Bind("ReplyTo") %>' />
            <br />
            ForumID:
            <asp:TextBox ID="ForumIDTextBox" runat="server" Text='<%# Bind("ForumID") %>' />
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
            IsReply:
            <asp:CheckBox ID="IsReplyCheckBox" runat="server" Checked='<%# Bind("IsReply") %>' />
            <br />
            ReplyTo:
            <asp:TextBox ID="ReplyToTextBox" runat="server" Text='<%# Bind("ReplyTo") %>' />
            <br />
            ForumID:
            <asp:TextBox ID="ForumIDTextBox" runat="server" Text='<%# Bind("ForumID") %>' />
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
            <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>' />
            <br />
            <br />
            <asp:Label ID="ContentLabel" runat="server" Text='<%# Bind("Content") %>' />
            <br />
            <br />
            This post was written by <asp:Label ID="AuthorLabel" runat="server" Text='<%# Bind("Author") %>' />
            <br />
            Date of Creation:
            <asp:Label ID="SubmissionDateLabel" runat="server" Text='<%# Bind("SubmissionDate") %>' />
            <br />
            Last Modified:
            <asp:Label ID="LastModifiedLabel" runat="server" Text='<%# Bind("LastModified") %>' />
            <br />
        </ItemTemplate>
    </asp:FormView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetForumMessage"
        TypeName="Kawanoikioi.Models.KawanoikioiDbRepository">
        <SelectParameters>
            <asp:RouteParameter Name="uniqueName" RouteKey="id" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:ListView ID="ReplyListView" runat="server" 
        DataSourceID="ObjectDataSource2" onitemcreated="ReplyListView_ItemCreated" ItemPlaceholderID="ItemPlaceHolder">
        <LayoutTemplate>
        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server">
        </asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <asp:FormView ID="ReplyFormView" runat="server">
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
                    IsReply:
                    <asp:CheckBox ID="IsReplyCheckBox" runat="server" Checked='<%# Bind("IsReply") %>' />
                    <br />
                    ReplyTo:
                    <asp:TextBox ID="ReplyToTextBox" runat="server" Text='<%# Bind("ReplyTo") %>' />
                    <br />
                    ForumID:
                    <asp:TextBox ID="ForumIDTextBox" runat="server" Text='<%# Bind("ForumID") %>' />
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
                    IsReply:
                    <asp:CheckBox ID="IsReplyCheckBox" runat="server" Checked='<%# Bind("IsReply") %>' />
                    <br />
                    ReplyTo:
                    <asp:TextBox ID="ReplyToTextBox" runat="server" Text='<%# Bind("ReplyTo") %>' />
                    <br />
                    ForumID:
                    <asp:TextBox ID="ForumIDTextBox" runat="server" Text='<%# Bind("ForumID") %>' />
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
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>' />
                    <br />
                    <br />
                    <asp:Label ID="ContentLabel" runat="server" Text='<%# Bind("Content") %>' />
                    <br />
                    <br />
                    This post was written by <asp:Label ID="AuthorLabel" runat="server" Text='<%# Bind("Author") %>' />
                    <br />
                    Date of Creation:
                    <asp:Label ID="SubmissionDateLabel" runat="server" Text='<%# Bind("SubmissionDate") %>' />
                    <br />
                    Last Modified:
                    <asp:Label ID="LastModifiedLabel" runat="server" Text='<%# Bind("LastModified") %>' />
                    <br />
                </ItemTemplate>
            </asp:FormView>
        </ItemTemplate>
        <ItemSeparatorTemplate>
            <hr class="forumRepliesSeparator" />
        </ItemSeparatorTemplate>
    </asp:ListView>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetForumReplies"
        TypeName="Kawanoikioi.Models.KawanoikioiDbRepository">
        <SelectParameters>
            <asp:RouteParameter Name="uniqueName" RouteKey="id" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:DataPager ID="ReplyPager" runat="server" PagedControlID="ReplyListView" 
        Visible="false">
        <Fields>
            <asp:NextPreviousPagerField ShowFirstPageButton="True" 
                ShowNextPageButton="False" ShowPreviousPageButton="True" ShowLastPageButton="False" />
            <asp:NumericPagerField />
            <asp:NextPreviousPagerField ShowLastPageButton="True" 
                ShowNextPageButton="True" ShowPreviousPageButton="False" />
        </Fields>
    </asp:DataPager>
    <br />
    <br />
    <asp:Panel ID="ReplyPanel" runat="server" Visible="false">
        <asp:Label ID="ReplyHeader" runat="server"></asp:Label>
        <br />
        <asp:Label ID="TitleLabel" runat="server" Text="Title" />   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="A title is required." ControlToValidate="TitleTextBox" />
        <br />
        <asp:TextBox ID="TitleTextBox" runat="server" />
        <br />
        <asp:Label ID="ContentLabel" runat="server" Text="Content:" />    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Content must be specified." ControlToValidate="ContentTextBox" />
        <br />
        <asp:TextBox ID="ContentTextBox" runat="server" TextMode="MultiLine" Width="600px" Height="200px" />
        <ajaxToolkit:HtmlEditorExtender ID="ContentTextBox_HtmlEditorExtender" 
            runat="server" Enabled="True" TargetControlID="ContentTextBox">
        </ajaxToolkit:HtmlEditorExtender>
        <br />
        <asp:Label ID="ResultLabel"  runat="server" />
        <br />
        <asp:Button ID="ReplyButton" runat="server" Text="Submit" 
            onclick="ReplyButton_Click" style="height: 26px" />
    </asp:Panel>
</asp:Content>
