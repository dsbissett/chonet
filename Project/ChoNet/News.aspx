<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" Title="Tin tức" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
<table width="80%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="left" valign="top" style="height: 18px; padding: 10px">
                <table width="90%" cellpadding="0" cellspacing="0" class="box1" border="0">
                    <tr>
                        <td>
                            <b>
                                <asp:Label runat="server" ID="lblTieuDe" Text=""></asp:Label>
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span runat="server" id="spnImage"></span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="tintuc" runat="server" id="spnTinTuc"></span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

