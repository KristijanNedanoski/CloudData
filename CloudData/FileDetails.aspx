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
                        <img src="<%#:Item.FilePath%><%#:Item.FileName%>"
                            style="border: solid; height: 300px" alt="<%#:Item.FileName %>" />
                    </td>
                    <td>&nbsp;</td>
                    <td style="vertical-align: top; text-align: left;">
                        <b>Description:</b><br />
                        <%#:Item.Description %>
                        <br />
                        <span><b>Size: </b><%#:Math.Round((float)Item.FileSize / (1024 * 1024), 2)%> <b> MB</b></span>
                        <br />
                        <span><b>File Number:</b>&nbsp;<%#:Item.FileID%></span>
                        <span><a href="Download.ashx?file=<%#:Item.FilePath%><%#:Item.FileName%>">cat pic</a></span>
                        <tr>
                            <td>
                            <asp:Label ID="LabelRemoveProduct"
                                     runat="server">File:</asp:Label></td>
                            <td>
                                <asp:DropDownList ID="DropDownRemoveFile" runat="server"
                                    ItemType="CloudData.Models.File"
                                    SelectMethod="GetFile" AppendDataBoundItems="true"
                                    DataTextField="FileName" DataValueField="FileID">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <asp:Button ID="RemoveFileButton" runat="server" Text="Remove File"
                            OnClick="RemoveFileButton_Click" CausesValidation="false" />
                        <asp:Label ID="LabelRemoveStatus" runat="server" Text=""></asp:Label>
                        <br />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
