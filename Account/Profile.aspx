<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Profile.aspx.cs" Inherits="Kawanoikioi.Account.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Label ID="HeaderLabel" runat="server"></asp:Label>
    &nbsp;<asp:Label ID="IsOnlineLabel" runat="server"></asp:Label>
    <br />
    <asp:Label ID="CreationDateLabel" runat="server" Text="Registration Date: "></asp:Label>
    <br />
    <asp:Label ID="LastActivityLabel" runat="server" Text="Last Activity: "></asp:Label>
    <br />
    <br />
    <asp:Label ID="AccordionHeaderLabel" runat="server" Text="Other:"></asp:Label>
    <br />
    <ajaxToolkit:Accordion ID="ProfileAccordion" runat="server" RequireOpenedPane="False">
        <Panes>
            <ajaxToolkit:AccordionPane ID="ForumPane" runat="server">
                <Header>
                    <asp:Button ID="OpenForumPaneButton" runat="server" OnClick="OpenForumPaneButton_Click" />
                </Header>
                <Content>
                    <asp:ListView ID="ForumPostsView" runat="server" DataSourceID="ForumPostsDatasource">
                        <ItemTemplate>
                            <asp:HyperLink ID="DirectForumPostLink" runat="server" Text='<% Eval("Name") %>' />
                        </ItemTemplate>
                    </asp:ListView>
                    <asp:ObjectDataSource ID="ForumPostsDatasource" runat="server" SelectMethod="GetForumMessagesByUser"
                        TypeName="Kawanoikioi.Models.KawanoikioiDbRepository">
                        <SelectParameters>
                            <asp:RouteParameter Name="author" RouteKey="id" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="ImagePane" runat="server">
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="TwitterPane" runat="server">
            </ajaxToolkit:AccordionPane>
        </Panes>
    </ajaxToolkit:Accordion>
</asp:Content>
