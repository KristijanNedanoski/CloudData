<%@ Page Title="File Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FileDetails.aspx.cs" Inherits="CloudData.FileDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="fileDetail" runat="server"
        ItemType="CloudData.Models.File" SelectMethod="GetFile"
        RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#:Item.OriginalFileName %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>

                        <img src="<%#:Item.FilePath%><%#:Item.FileName%>"
                            style="border: solid; height: 300px" alt="<%#:Item.OriginalFileName%>" />
                    </td>
                    <td>&nbsp;</td>
                    <td style="vertical-align: top; text-align: left;">
                        <b>Description:</b><br />
                        <%#:Item.Description %>
                        <br />
                        <span><b>Size: </b><%#:Math.Round((float)Item.FileSize / (1024 * 1024), 2)%> <b>MB</b></span>
                        <br />
                        <p>&nbsp;</p>
                        <p>&nbsp;</p>
                        <p>&nbsp;</p>
                        <p>&nbsp;</p>

                        <span>
                            <asp:Button ID="Button2" runat="server" Text="Download File"
                                OnClick="DownloadFileButton_Click" CausesValidation="false" />
                        </span>
                        </br>
                        <span>
                            <asp:Button ID="RemoveFileButton" runat="server" Text="Remove File"
                                OnClick="RemoveFileButton_Click" CausesValidation="false" />
                            <asp:Label ID="LabelRemoveStatus" runat="server" Text=""></asp:Label>
                        </span>

                </tr>
                <br />
                </td>
    </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
