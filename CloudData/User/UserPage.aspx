<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="CloudData.User.UserPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Add File:</h3>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <hr />
    <asp:Label ID="LabelAddDescription"
        runat="server">Description:</asp:Label>
    <asp:TextBox ID="AddFileDescription"
        runat="server"></asp:TextBox>
    <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="UploadFile" />
    <br />
    <asp:Label ID="lblMessage" ForeColor="Green" runat="server" />
</asp:Content>
