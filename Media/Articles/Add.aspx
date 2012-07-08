<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Kawanoikioi.Media.Articles.Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
    ScriptMode="Debug">
</ajaxToolkit:ToolkitScriptManager>
    <asp:Label ID="HeaderLabel" runat="server" SkinID="PageHeaderLabel" 
        Text="Write a New Article"></asp:Label>
    <br />
<asp:Label ID="TitleLabel" runat="server" Text="Title:"></asp:Label>
&nbsp;&nbsp;&nbsp;
<asp:RequiredFieldValidator ID="TitleValidator" runat="server" 
    ControlToValidate="TitleTextBox" 
    ErrorMessage="A title &lt;b&gt;must&lt;/b&gt; be specified."></asp:RequiredFieldValidator>
<br />
<asp:TextBox ID="TitleTextBox" runat="server"></asp:TextBox>
<br />
<br />
<asp:Label ID="ContentLabel" runat="server" Text="Content:"></asp:Label>
&nbsp;&nbsp;&nbsp;
<asp:RequiredFieldValidator ID="ContentValidator" runat="server" 
    ControlToValidate="ContentTextBox" 
    ErrorMessage="The &quot;Content&quot;-Textbox &lt;u&gt;must not&lt;/u&gt; be empty."></asp:RequiredFieldValidator>
<br />
<asp:TextBox ID="ContentTextBox" runat="server" Height="200px" 
    TextMode="MultiLine" Width="600px"></asp:TextBox>
<ajaxToolkit:HtmlEditorExtender ID="ContentTextBox_HtmlEditorExtender" 
    runat="server" Enabled="True" TargetControlID="ContentTextBox">
</ajaxToolkit:HtmlEditorExtender>
<br />
<asp:Button ID="SubmitButton" runat="server" onclick="SubmitButton_Click" 
    Text="Add" />
    <br />
    <br />
    <asp:Label ID="ResultLabel" runat="server"></asp:Label>
</asp:Content>
