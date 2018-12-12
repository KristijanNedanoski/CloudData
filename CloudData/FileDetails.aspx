<%@ Page Title="File Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FileDetails.aspx.cs" Inherits="CloudData.FileDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="fileDetail" runat="server"
        ItemType="CloudData.Models.File" SelectMethod="GetFile"
        RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#:Item.FileName %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src="/Catalog/Images/<%#:Item.ImagePath %>"
                            style="border: solid; height: 300px" alt="<%#:Item.FileName %>" />
                    </td>
                    <td>&nbsp;</td>
                    <td style="vertical-align: top; text-align: left;">
                        <b>Description:</b><br />
                        <%#:Item.Description %>
                        <br />
                        <span><b>Price:</b>&nbsp;<%#: String.Format("{0:c}",Item.UnitPrice) %></span>
                        <br />
                        <span><b>File Number:</b>&nbsp;<%#:Item.FileID
                        %></span>
                        <br />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
