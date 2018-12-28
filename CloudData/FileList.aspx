<%@ Page Title="Files" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="FileList.aspx.cs" Inherits="CloudData.FileList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>
            <asp:ListView ID="fileList" runat="server"
                DataKeyNames="FileID" GroupItemCount="4"
                ItemType="CloudData.Models.File" SelectMethod="GetFiles">
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                    <a
                                        href="FileDetails.aspx?fileID=<%#:Item.FileID%>">
                                        <img
                                            src="<%#:Item.FilePath%><%#:Item.FileName%>"
                                            width="100" height="75" style="border: solid" /></a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a
                                        href="FileDetails.aspx?fileID=<%#:Item.FileID%>">
                                        <span>
                                            <%#:Item.OriginalFileName%>
                                        </span>
                                    </a>
                                    <br />
                                    <span>
                                        <b>Size: </b><%#:Math.Round((float)Item.FileSize / (1024 * 1024), 2)%> <b> MB</b>
                                    </span>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width: 100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer"
                                        runat="server" style="width: 100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </section>
</asp:Content>
