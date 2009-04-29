<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/EstoreMaster.master"
    CodeFile="EStoreNews.aspx.cs" Inherits="eStoreNew" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphEstore">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="left" valign="top" style="height: 18px; padding: 10px">
                <table width="100%" cellpadding="0" cellspacing="0" class="box1" border="0">
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
