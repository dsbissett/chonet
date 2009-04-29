<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="MainCategory.aspx.cs"
    Inherits="MainCategory" Title="Danh mục chính" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">

    <script language="javascript" type="text/javascript">
// <!CDATA[

// ]]>
    </script>

    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td style="padding-left: 20px; height: 25px; text-align: left" class="pathway">
                <b><a href="default.aspx" class="pathway">Trang chủ</a></b> &gt; <b>
                    <asp:Label ID="lblDanhMuc" runat="server"></asp:Label></b></td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="220px" align="left" valign="top" style="background: url(images/bgleftmenu.jpg) fixed left top;">
                            <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                <tr>
                                    <td align="left" valign="top">
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
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlAdvanceSearch" runat="server" DefaultButton="btnTimKiem" Width="100%">
                                            <table border="0" cellpadding="0" cellspacing="0" class="box2" width="100%">
                                                <tr>
                                                    <td class="title">
                                                        Tìm kiếm nâng cao
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-right: 4px; padding-left: 4px; padding-bottom: 4px; padding-top: 4px">
                                                        <table border="0" cellpadding="0" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td align="left" colspan="2" class="pages">
                                                                    Từ khóa
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="2">
                                                                    <input id="txtTuKhoa" runat="server" name="textfield2" style="font-size: 11px; width: 90%"
                                                                        type="text" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="2" class="pages">
                                                                    Tên sản phẩm
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="2">
                                                                    <input id="txtTenSanPham" runat="server" name="textfield22" style="font-size: 11px;
                                                                        width: 90%" type="text" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="2" class="pages">
                                                                    Mã sản phẩm
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="2">
                                                                    <input id="txtMaSanPham" runat="server" name="textfield22" style="font-size: 11px;
                                                                        width: 90%" type="text" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="2" class="pages">
                                                                    Trong danh mục
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="2">
                                                                    <select id="ddlDanhMuc" runat="server" name="select2" style="font-size: 11px; width: 90%">
                                                                        <option selected="selected">Máy tính để bàn nguyên bộ</option>
                                                                    </select>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="2" class="pages">
                                                                    Hãng sản xuất
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="2">
                                                                    <select id="ddlHangSanXuat" runat="server" name="select3" style="font-size: 11px;
                                                                        width: 90%">
                                                                        <option selected="selected">Hãng sản xuất</option>
                                                                    </select>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="2" class="pages">
                                                                    Tại khu vực</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="2">
                                                                    <select id="ddlKhuVuc" runat="server" name="select2" style="font-size: 11px; width: 90%">
                                                                        <option selected="selected">Việt Nam</option>
                                                                    </select>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="2" height="30">
                                                                    <asp:Button ID="btnTimKiem" runat="server" CssClass="button" OnClick="btnTimKiem_ServerClick"
                                                                        Text="Tìm kiếm" /></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Table ID="tblQuangCao13" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0">
                                        </asp:Table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                            <tr>
                                                <td align="left" valign="top">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td style="padding-bottom: 8px;">
                                                                <span id="spnQuangCao12" runat="server"></span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="border: solid 1px #CCCCCC;">
                                                                <asp:Table ID="tblSanPham11" runat="server" Width="100%" BorderStyle="none" CellSpacing="0"
                                                                    CellPadding="0">
                                                                </asp:Table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="padding: 4px;">
                                        <table width="100%" border="0" class="box4" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="title">
                                                    Gian hàng giới thiệu
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="box4_bor">
                                                    <asp:Table ID="tblGianHang" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0">
                                                    </asp:Table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="padding: 4px;">
                                        <table width="100%" border="0" class="box4" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td class="title">
                                                                Sản phẩm được ưa chuộng</td>
                                                            <td class="title" style="text-align: right;">
                                                                <a href="promotion.aspx?pcode=uc&cid=<%=Request.QueryString["mcid"].ToString()%>">[Xem
                                                                    tất cả]</a>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="box4_bor">
                                                    <asp:Table ID="tblSanPham12" runat="server" Width="100%" BorderStyle="none" CellSpacing="0"
                                                        CellPadding="0">
                                                    </asp:Table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="padding: 4px;">
                                        <table width="100%" border="0" class="box4" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td class="title">
                                                                Sản phẩm giảm giá</td>
                                                            <td class="title" style="text-align: right;">
                                                                <a href="promotion.aspx?pcode=gg&cid=<%=Request.QueryString["mcid"].ToString()%>">[Xem
                                                                    tất cả]</a>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="box4_bor">
                                                    <asp:Table ID="tblSanPham13" runat="server" Width="100%" BorderStyle="none" CellSpacing="0"
                                                        CellPadding="0">
                                                    </asp:Table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="padding: 4px;">
                                        <table width="100%" border="0" class="box4" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="title"">
                                                    Sản phẩm mới cập nhật</td>
                                            </tr>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="box4_bor">
                                        <asp:Table ID="tblSanPham14" runat="server" Width="100%" BorderStyle="none" CellSpacing="0"
                                            CellPadding="0">
                                        </asp:Table>
                                    </td>
                                </tr>
                            </table>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
