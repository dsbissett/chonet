<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="RegionHome.aspx.cs"
    Inherits="_RegionHome" Title="Thái Nguyên" %>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<%@ MasterType VirtualPath="~/Default.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">

    <script src="Scripts/Common.js" type="text/javascript"></script>

    <script id="igClientScript" type="text/javascript">
    function NewsUpDown(direction)
    {
        var warp = ig$('<%=pnlTinTuc.ClientID%>'); 
        var hid = document.getElementById('<%=HidTinTuc.ClientID%>');   	
        if(hid != null)
        {
            hid.value=direction;
	        if(!warp) return;
	        warp.refresh();
	    }		
    }
    function RefreshProduct04(tid)
    {
        var warp = ig$('<%=pnlSanPham04.ClientID%>'); 
        var hid = document.getElementById('<%=hidCatId.ClientID%>');   	
        if(hid != null)
        {
            hid.value=tid;
	        if(!warp) return;
	        warp.refresh();
	    }		
    }
    
    function Refresh()
    {        
        CloseDialogWindow();
    } 
    
     function LostPassword()
    {        
        //OpenDialogWindow('Quên mật khẩu', 320, 150, 'page', 'LostPassword.aspx');        
        ShowModalDialog('LostPassword.aspx','Quên mật khẩu', 320, 150);        
    }
    </script>

    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="background: url(KhuVuc/images/leftcenterbody.jpg) repeat-y right">
                            &nbsp;</td>
                        <td style="padding: 2px;">
                            <span id="spnQuangCao10" runat="server"></span>
                        </td>
                        <td style="background: url(KhuVuc/images/rightcenterbody.jpg) repeat-y left; width: 5px;">
                            &nbsp;</td>
                    </tr>
                    <tr style="height: auto">
                        <td style="background: url(KhuVuc/images/leftcenterbody.jpg) repeat-y right">
                            &nbsp;</td>
                        <td colspan="2" style="background: url(KhuVuc/images/rightcenterbody.jpg) repeat-y left 50%">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="center" width="207">
                                        <table border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <a href="#">
                                                        <img src="KhuVuc/images/sky.jpg" width="70" height="29" border="0" /></a></td>
                                                <td>
                                                    <a href="#">
                                                        <img src="KhuVuc/images/ym.jpg" width="81" height="31" border="0" /></a></td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 8px; background-image: url(KhuVuc/images/seperate1.jpg); background-position-y: bottom;
                                        background-repeat: no-repeat; background-color: transparent;">
                                    </td>
                                    <td>
                                        <strong runat="server" id="region"></strong>
                                    </td>
                                    <td style="background-position-y: bottom; background-image: url(KhuVuc/images/seperate1.jpg);
                                        width: 8px; background-repeat: no-repeat; background-color: transparent">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="background-color: #f0aa30; height: 8px;">
                                    </td>
                                    <td style="background-color: #f0aa30;">
                                    </td>
                                    <td style="background-color: #e3e3e3">
                                    </td>
                                    <td style="background-color: #f0aa30">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="background: url(KhuVuc/images/leftcenterbody.jpg) repeat-y right">
                            &nbsp;</td>
                        <td width="977">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="207" align="left" valign="top" style="background: url(KhuVuc/images/bgleftmenu.jpg) fixed left top;">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                        <tr>
                                                            <td>
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
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td class="title">
                                                                SẢN PHẨM ĐÃ XEM
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Table ID="tblSanPhamDaXem" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0">
                                                                </asp:Table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td class="title">
                                                                <table border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="28%" align="center">
                                                                            <img src="KhuVuc/images/spmoi.png" width="30" height="27" /></td>
                                                                        <td width="72%" nowrap="nowrap" class="title">
                                                                            SẢN PHẨM MỚI
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Table ID="tblSanPham07" runat="server" Width="100%" BorderStyle="none" CellSpacing="0"
                                                                    CellPadding="0">
                                                                </asp:Table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                        <tr>
                                                            <td width="207" align="left" valign="top">
                                                                <asp:Table ID="tblQuangCao04" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0">
                                                                </asp:Table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="207" valign="top">
                                                                <asp:Table ID="tblQuangCao06" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0">
                                                                </asp:Table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="left" valign="top">
                                        <table width="100%" border="0" cellspacing="2" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <span id="spnQuangCao01" runat="server"></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td>
                                                                            <span id="spnQuangCao02" runat="server"></span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding-top: 4px;">
                                                                            <asp:Table ID="tblSanPham02" runat="server" Width="100%" BorderStyle="none" CellSpacing="0"
                                                                                CellPadding="0">
                                                                            </asp:Table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td align="left" valign="top" width="300px">
                                                                <table width="100%">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td>
                                                                                <strong>THÔNG TIN HƯỚNG DẪN</strong></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <a href="#">+ Đăng ký</a></td>
                                                                                            <td>
                                                                                                <a href="#">+ Thanh toán</a></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <a href="#">+ Mua Hàng</a></td>
                                                                                            <td>
                                                                                                <a href="#">+ Vận chuyển</a></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <a href="#">+ Bán Hàng</a></td>
                                                                                            <td>
                                                                                                <a href="#">+ Gian Hàng</a></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <a href="#">+ Giao dịch</a></td>
                                                                                            <td>
                                                                                                <a href="#">+ Quy Định</a></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <a href="#">+ Quảng cáo</a></td>
                                                                                            <td>
                                                                                                <a href="#">+ Tài trợ</a></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <igmisc:WebAsyncRefreshPanel ID="pnlTinTuc" runat="server" Height="" Width="100%"
                                                                                    OnContentRefresh="pnlTinTuc_ContentRefresh">
                                                                                    <table width="100%" style="height: 100%">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <strong>THÔNG TIN MỚI TỪ CHỢ NET</strong></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Label ID="lblTieuDe" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="center">
                                                                                                <a href="javascript:NewsUpDown('up');">
                                                                                                    <img src="KhuVuc/images/len.jpg" width="26" height="25" border="0" id="imgLen" runat="server"></a></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <div align="justify" id="divTinTuc" runat="server" style="overflow: auto; height: 100%;
                                                                                                    width: 200px">
                                                                                                </div>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="center">
                                                                                                <a href="javascript:NewsUpDown('down');">
                                                                                                    <img src="KhuVuc/images/xuong.jpg" width="26" height="25" border="0" id="imgXuong"
                                                                                                        runat="server"></a></td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </igmisc:WebAsyncRefreshPanel>
                                                                                <input type="hidden" runat="server" id="HidTinTuc" />
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table id="tblQuangCao03" runat="server" width="100%" border="0" cellspacing="4"
                                                        cellpadding="0">
                                                        <tr>
                                                            <td width="50%" align="left">
                                                                <span id="spnQuangCao03a" runat="server"></span>
                                                            </td>
                                                            <td width="50%" align="center">
                                                                <span id="spnQuangCao03b" runat="server"></span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td align="left" valign="top" style="padding: 4px;">
                                                                <igmisc:WebAsyncRefreshPanel ID="pnlSanPham04" runat="server" Height="" Width="100%"
                                                                    OnContentRefresh="pnlSanPham04_ContentRefresh">
                                                                    <input type="hidden" id="hidCatId" runat="server" />
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td class="titleto">
                                                                                <asp:Table ID="tblDanhMuc04" CssClass="titleto" runat="server" CellPadding="0" CellSpacing="0"
                                                                                    BorderStyle="none" Width="100%">
                                                                                </asp:Table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Table ID="tblSanPham04" CssClass="tab" runat="server" CellPadding="0" CellSpacing="0"
                                                                                    BorderStyle="none" Width="100%">
                                                                                </asp:Table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </igmisc:WebAsyncRefreshPanel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table id="tblQuangCao05" runat="server" width="100%" border="0" cellspacing="4"
                                                        cellpadding="0">
                                                        <tr>
                                                            <td width="50%" align="left" style="height: 2px">
                                                                <span id="spnQuangCao05a" runat="server"></span>
                                                            </td>
                                                            <td width="50%" align="center" style="height: 2px">
                                                                <span id="spnQuangCao05b" runat="server"></span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td class="titleto" align="left">
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="7%" class="nd1">
                                                                            <img src="KhuVuc/images/km.png" width="50" height="44" /></td>
                                                                        <td width="17%" nowrap="nowrap" class="nd1">
                                                                            <a href="promotion.aspx?pcode=km">SẢN PHẨM KHUYẾN MÃI </a>
                                                                        </td>
                                                                        <td width="76%" align="right" class="pages" style="padding-right: 25px">
                                                                            <a href="promotion.aspx?pcode=km">Xem tất cả</a>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td align="left" valign="top">
                                                                            <asp:Table ID="tblSanPham06" runat="server" Width="100%" BorderStyle="none" CellSpacing="0"
                                                                                CellPadding="0">
                                                                            </asp:Table>
                                                                        </td>
                                                                        <td align="right" valign="top">
                                                                            <table class="khuyenmai" width="95%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td class="tit_khuyenmai">
                                                                                        Khuyến mãi sắp hết hạn
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <asp:Table ID="tblSanPham06b" CssClass="khuyenmai" runat="server" Width="95%" BorderStyle="none"
                                                                                CellSpacing="0" CellPadding="0">
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
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table id="tblQuangCao07" runat="server" width="100%" border="0" cellspacing="4"
                                                        cellpadding="0">
                                                        <tr>
                                                            <td width="50%" align="left">
                                                                <span id="spnQuangCao07a" runat="server"></span>
                                                            </td>
                                                            <td width="50%" align="center">
                                                                <span id="spnQuangCao07b" runat="server"></span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td class="titleto" align="left">
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="7%" class="nd1">
                                                                            <img src="KhuVuc/images/gg.png" width="40" height="44" /></td>
                                                                        <td width="17%" nowrap="nowrap" class="nd1">
                                                                            <a href="promotion.aspx?pcode=gg">SẢN PHẨM GIẢM GIÁ</a></td>
                                                                        <td width="76%" align="right" class="pages" style="padding-right: 25px">
                                                                            <a href="promotion.aspx?pcode=gg">Xem tất cả</a>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Table ID="tblSanPham05" runat="server" Width="100%" BorderStyle="none" CellSpacing="0"
                                                                    CellPadding="0">
                                                                </asp:Table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table id="tblQuangCao08" runat="server" width="100%" border="0" cellspacing="4"
                                                        cellpadding="0">
                                                        <tr>
                                                            <td width="50%" align="left">
                                                                <span id="spnQuangCao08a" runat="server"></span>
                                                            </td>
                                                            <td width="50%" align="center">
                                                                <span id="spnQuangCao08b" runat="server"></span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" style="padding: 4px;">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td class="titleto" align="left">
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="17%" nowrap="nowrap" class="nd1">
                                                                            <a href="promotion.aspx?pcode=uc">SẢN PHẨM ĐƯỢC ƯA CHUỘNG </a>
                                                                        </td>
                                                                        <td width="83%" align="right" class="pages" style="padding-right: 25px">
                                                                            <a href="promotion.aspx?pcode=uc">Xem tất cả</a>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Table ID="tblSanPham03" runat="server" Width="100%" BorderStyle="none" CellSpacing="0"
                                                                    CellPadding="0">
                                                                </asp:Table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table id="tblQuangCao09" runat="server" width="100%" border="0" cellspacing="4"
                                                        cellpadding="0">
                                                        <tr>
                                                            <td width="50%" align="left">
                                                                <span id="spnQuangCao09a" runat="server"></span>
                                                            </td>
                                                            <td width="50%" align="center">
                                                                <span id="spnQuangCao09b" runat="server"></span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                        <tr>
                                                            <td>
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td rowspan="3" align="center" valign="top">
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td class="titleto" align="left">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td class="nd1" width="17%" nowrap="nowrap">
                                                                                                        GIAN HÀNG TIÊU BIỂU
                                                                                                    </td>
                                                                                                    <td class="pages" align="right">
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </tbody>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Table ID="tblGianHang" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0">
                                                                                        </asp:Table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="34">
                                                                                        &nbsp;</td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border-bottom: #CCCCCC dashed 1px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td height="30" style="font-weight: bold; padding-left: 10px; text-align: left">
                                                    <a href="#">GIỚI THIỆU</a> | <a href="#">LIÊN HỆ</a> | <a href="EstoreHome.aspx">GIAN
                                                        HÀNG</a> | <a href="#">HƯỚNG DẪN</a> | <a href="#">TIN TỨC</a></td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="15" align="left" valign="top" style="background: url(KhuVuc/images/bgrightdoc.jpg) repeat-y left">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td style="background: url(KhuVuc/images/rightcenterbody.jpg) repeat-y left; width: 5px;">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
