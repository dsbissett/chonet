<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Promotion.aspx.cs"
    Inherits="Promotion" Title="Mới nhập & Khuyến mại & Giảm giá" %>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">

    <script type="text/javascript">
    function GoToPage(page)
    {
        var hidPage = document.getElementById('<%=hidPage.ClientID %>');
        hidPage.value=page;
        var warp = ig$('<%=pnlPage.ClientID%>');
        if(!warp) return;
        warp.refresh();	
    }
    </script>

    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td colspan="2" style="text-align: left;">
                <b><a class="pathway" href="promotion.aspx?pcode=<%=promotion_code%>">SẢN PHẨM
                    <%=productType.Text.ToUpper()%>
                </a>&nbsp;<asp:Label CssClass="pathway" ID="lblCatName" runat="server"></asp:Label></b></td>
        </tr>
        <tr>
            <td width="230" align="left" valign="top" style="background: url(images/bgleftmenu.jpg) fixed center top;">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="title">
                            Danh mục sản phẩm
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Table ID="tblDanhMuc" runat="server" CssClass="leftmenu" Width="100%" CellPadding="0"
                                CellSpacing="0">
                            </asp:Table>
                            <asp:Menu ID="mnuNhomSanPham" runat="server" MaximumDynamicDisplayLevels="4" StaticEnableDefaultPopOutImage="False"
                                StaticSubMenuIndent="" Width="100%">
                                <LevelMenuItemStyles>
                                    <asp:MenuItemStyle CssClass="menulevel1" Font-Underline="False" Width="100%" />
                                    <asp:MenuItemStyle CssClass="menulevel2" Font-Underline="False" Width="200px" />
                                    <asp:MenuItemStyle CssClass="menulevel3" Font-Underline="False" Width="200px" />
                                </LevelMenuItemStyles>
                                <DynamicItemTemplate>
                                    <%# Eval("Text") %>
                                </DynamicItemTemplate>
                            </asp:Menu>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 770px; padding: 4px; vertical-align: top;">
                <table width="100%" border="0" class="box4" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="title">
                            <span class="textcam">Sản phẩm
                                <asp:Label ID="productType" runat="server"></asp:Label></span></td>
                    </tr>
                    <tr>
                        <td class="box4_bor">
                            <igmisc:WebAsyncRefreshPanel ID="pnlPage" runat="server" Height="" Width="100%" OnContentRefresh="pnlPage_ContentRefresh">
                                <input type="hidden" id="hidPage" runat="server" />
                                <asp:Table ID="tblSanPham" runat="server" Width="100%" BorderStyle="none" CellSpacing="0"
                                    CellPadding="0">
                                </asp:Table>
                                <br />
                                <b>
                                    <asp:Label ID="lblPage" runat="server"></asp:Label></b>
                            </igmisc:WebAsyncRefreshPanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
