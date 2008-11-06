<%@ Page Language="C#" MasterPageFile="~/Adm/Admin.master" AutoEventWireup="true"
    CodeFile="Cat2Config.aspx.cs" Inherits="Admin_Cat2Config" Title="Danh mục cấp 2" %>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <!--[if lt IE 7]>
<script defer type="text/javascript" src="js/pngfix.js"></script>
<![endif]-->

    <script id="igClientScript" type="text/javascript">
<!--
function loadjscssfile(filename, filetype){
 if (filetype=="js"){ //if filename is a external JavaScript file
  var fileref=document.createElement('script')
  fileref.setAttribute("type","text/javascript")
  fileref.setAttribute("src", filename)
 }
 else if (filetype=="css"){ //if filename is an external CSS file
  var fileref=document.createElement("link")
  fileref.setAttribute("rel", "stylesheet")
  fileref.setAttribute("type", "text/css")
  fileref.setAttribute("href", filename)
 }
 if (typeof fileref!="undefined")
  document.getElementsByTagName("head")[0].appendChild(fileref)
}

//loadjscssfile("myscript.js", "js") //dynamically load and add this .js file
//loadjscssfile("javascript.php", "js") //dynamically load "javascript.php" as a JavaScript file
loadjscssfile("../Css/style.css", "css") ////dynamically load and add this .css file

function RefreshAdv(aid)
{  	
    var warp;
    switch(aid)
    {
        case 23: warp = ig$('<%=pnlQuangCao23.ClientID%>');
        break;
        case 22: warp = ig$('<%=pnlQuangCao22.ClientID%>');
        break;
    }    	
	if(!warp)
		return;
	warp.refresh();		
}

function ChangeAdv(aid)
{
    OpenDialogWindow('Thay đổi quảng cáo',680,420,'page','SelectAdv.aspx?aid=' + aid);
}

function RefreshComplete(oPanel){
	CloseDialogWindow();
}
// -->
    </script>

    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="center" valign="top">
                <table width="1000" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table class="form" width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="bgtopbanner" align="center" valign="bottom">
                                        <table border="0" cellpadding="0" cellspacing="0" width="987">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="blured">
                                                            <tbody>
                                                                <tr>
                                                                    <td width="6%">
                                                                        <a href="../default.aspx">
                                                                            <img src="../images/logo.png" border="0" width="228" height="86"></a></td>
                                                                    <td width="94%">
                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align="center" valign="top" height="28">
                                                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td style="border-right: 1px solid rgb(102, 102, 102);">
                                                                                                        <img src="../images/lefttopmenu3.jpg" width="11" height="24"></td>
                                                                                                    <td style="background: transparent url(../images/centertopmenu3.jpg) repeat-x scroll center top;
                                                                                                        -moz-background-clip: -moz-initial; -moz-background-origin: -moz-initial; -moz-background-inline-policy: -moz-initial;">
                                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                            <tbody>
                                                                                                                <tr>
                                                                                                                    <td class="topmenu3" nowrap="nowrap">
                                                                                                                        <a href="#">Gian hàng </a>
                                                                                                                    </td>
                                                                                                                    <td class="topmenu3" nowrap="nowrap">
                                                                                                                        <a href="#">Tin tức </a>
                                                                                                                    </td>
                                                                                                                    <td class="topmenu3" nowrap="nowrap">
                                                                                                                        <a href="#">Giúp đỡ </a>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </tbody>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <img src="../images/righttopmenu3.jpg" width="11" height="24"></td>
                                                                                                </tr>
                                                                                            </tbody>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="padding-right: 20px;" align="right">
                                                                                        <table border="0" cellpadding="0" cellspacing="3">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td style="text-align: center;" align="right">
                                                                                                        <a href="#"><strong>Giỏ hàng của bạn</strong><br>
                                                                                                            (có 0 sản phẩm) </a>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <a href="#">
                                                                                                            <img src="../images/cart.png" border="0" width="39" height="44"></a></td>
                                                                                                </tr>
                                                                                            </tbody>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="dangky" align="right">
                                                                                        Bạn hãy <a href="#">Đăng nhập</a> hoặc <a href="#">Đăng ký</a> thành viên, gian
                                                                                        hàng</td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="blured">
                                                            <tbody>
                                                                <tr>
                                                                    <td width="32">
                                                                        <img src="../images/lefttopmenu.jpg" width="32" height="44"></td>
                                                                    <td style="background: transparent url(../images/centermenu.jpg) repeat-x scroll center bottom;
                                                                        -moz-background-clip: -moz-initial; -moz-background-origin: -moz-initial; -moz-background-inline-policy: -moz-initial;"
                                                                        valign="bottom">
                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td class="menu_ac">
                                                                                        Trang chủ
                                                                                    </td>
                                                                                    <td class="menu">
                                                                                        <a href="#">Thái Nguyên </a>
                                                                                    </td>
                                                                                    <td class="menu">
                                                                                        <a href="#">Hải Phòng </a>
                                                                                    </td>
                                                                                    <td class="menu">
                                                                                        <a href="#">Quảng Ninh </a>
                                                                                    </td>
                                                                                    <td class="menu">
                                                                                        <a href="#">Hà Nội </a>
                                                                                    </td>
                                                                                    <td class="menu">
                                                                                        <a href="#">Hồ Chí Minh </a>
                                                                                    </td>
                                                                                    <td class="menu">
                                                                                        <a href="#">Đà Nẵng </a>
                                                                                    </td>
                                                                                    <td class="menu">
                                                                                        <a href="#">Lạng Sơn </a>
                                                                                    </td>
                                                                                    <td class="menu">
                                                                                        <a href="#">Lào Cai </a>
                                                                                    </td>
                                                                                    <td class="menu">
                                                                                        <a href="#">Nam Định </a>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                    <td width="32">
                                                                        <img src="../images/righttopmenu.jpg" width="32" height="44"></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="bgbanner2" align="center">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tbody>
                                                <tr>
                                                    <td style="">
                                                        &nbsp;</td>
                                                    <td class="topbanner2" width="977">
                                                        <table border="0" cellpadding="0" cellspacing="4" width="100%">
                                                            <tbody>
                                                                <tr>
                                                                    <td width="45%" class="blured">
                                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td>
                                                                                        <table class="search" border="0" cellpadding="0" cellspacing="2">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td class="text_sear" width="64" nowrap="nowrap">
                                                                                                        Tìm kiếm
                                                                                                    </td>
                                                                                                    <td width="144">
                                                                                                        <input class="field" name="textfield" type="text"></td>
                                                                                                    <td width="131">
                                                                                                        <label>
                                                                                                            <select name="select" class="field">
                                                                                                                <option>Nhóm sản phẩm</option>
                                                                                                            </select>
                                                                                                        </label>
                                                                                                    </td>
                                                                                                    <td width="73">
                                                                                                        <input class="button" name="Submit" value="Tìm kiếm" type="submit"></td>
                                                                                                </tr>
                                                                                            </tbody>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center">
                                                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <input name="checkbox" value="checkbox" type="checkbox"></td>
                                                                                                    <td nowrap="nowrap">
                                                                                                        <strong>Chọn nếu bạn muốn tìm kiếm có tiêu đề và nội dung</strong></td>
                                                                                                </tr>
                                                                                            </tbody>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="padding-left: 20px; padding-right: 20px;">
                                                                                        <strong>Từ khóa:</strong> máy tính, máy ảnh số, mp3, sách, laptop, ipod, mobile,
                                                                                        điều hòa, quạt điện, iphone, BlackBerry, điện thoại di động, tivi, điện thoại
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                    <td width="55%">
                                                                        <div onclick="ChangeProduct(1);" style="cursor: hand;">
                                                                            &nbsp;</div>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                    <td style="">
                                                        &nbsp;</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td style="background: url(./../images/bot.jpg); width: 20px">
                                                    <img src="./../images/bot1.jpg" width="20" height="23" /></td>
                                                <td style="background: url(./../images/bot.jpg); width: 96%;">
                                                    &nbsp;</td>
                                                <td style="width: 20px">
                                                    <img src="./../images/bot2.jpg" width="20" height="23" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="blured" height="25" align="left" style="padding-left: 20px;">
                                        <b><a class="pathway">Trang chủ</a></b> &gt; <b><a class="pathway">Điện tử điện lạnh
                                        </a></b>> <b><a class="pathway">Máy ảnh kỹ thuật số</a></b></td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="230" align="left" valign="top">
                                                    <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                        <tr>
                                                            <td class="blured">
                                                                <table class="box2" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td class="box2_name">
                                                                            Tìm kiếm nâng cao
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="box2_bor" style="padding: 4px;">
                                                                            <table width="100%" border="0" cellspacing="2" cellpadding="0">
                                                                                <tr>
                                                                                    <td width="10%" align="left">
                                                                                        <input type="checkbox" name="checkbox" value="checkbox" disabled="disabled" /></td>
                                                                                    <td width="90%" align="left" nowrap="nowrap">
                                                                                        Từ khóa
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" align="left">
                                                                                        <input name="textfield2" type="text" style="width: 170px; font-size: 11px;" disabled="disabled" /></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <input type="checkbox" name="checkbox2" value="checkbox" disabled="disabled" /></td>
                                                                                    <td align="left" nowrap="nowrap">
                                                                                        Mã sản phẩm
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" align="left">
                                                                                        <input name="textfield22" type="text" style="width: 170px; font-size: 11px;" disabled="disabled" /></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <input type="checkbox" name="checkbox22" value="checkbox" disabled="disabled" /></td>
                                                                                    <td align="left" nowrap="nowrap">
                                                                                        Trong danh mục
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" align="left">
                                                                                        <select name="select2" style="width: 170px; font-size: 11px;" disabled="disabled">
                                                                                            <option>Máy tính để bàn nguyên bộ</option>
                                                                                        </select>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <input type="checkbox" name="checkbox22" value="checkbox" disabled="disabled" /></td>
                                                                                    <td align="left" nowrap="nowrap">
                                                                                        Hãng sản xuất
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" align="left">
                                                                                        <select name="select3" style="width: 170px; font-size: 11px;" disabled="disabled">
                                                                                            <option>Hãng sản xuất</option>
                                                                                        </select>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <input type="checkbox" name="checkbox22" value="checkbox" disabled="disabled" /></td>
                                                                                    <td align="left" nowrap="nowrap">
                                                                                        Dòng sản phẩm
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" align="left">
                                                                                        <select name="select2" style="width: 170px; font-size: 11px;" disabled="disabled">
                                                                                            <option>Model sản phẩm</option>
                                                                                        </select>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <input type="checkbox" name="checkbox22" value="checkbox" disabled="disabled" /></td>
                                                                                    <td align="left" nowrap="nowrap">
                                                                                        Tại khu vực</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" align="left">
                                                                                        <select name="select2" style="width: 170px; font-size: 11px;" disabled="disabled">
                                                                                            <option>Việt Nam</option>
                                                                                        </select>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="30" colspan="2" align="left">
                                                                                        <input type="submit" class="button" name="Submit2" value="Tìm kiếm" disabled="disabled" /></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div onclick="ChangeAdv(22);" style="cursor: hand;">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                                            <td class="red-button">
                                                                                Thay đổi quảng cáo 22</td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <igmisc:WebAsyncRefreshPanel ID="pnlQuangCao22" runat="server" Height="" RefreshComplete="RefreshComplete"
                                                                    Width="100%" OnContentRefresh="pnlQuangCao22_ContentRefresh">
                                                                    <asp:Table ID="tblQuangCao22" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0">
                                                                    </asp:Table>
                                                                </igmisc:WebAsyncRefreshPanel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td align="left" valign="top">
                                                    <table width="100%" border="0" class="box6" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td>
                                                                <div onclick="ChangeAdv(23);" style="cursor: hand;">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                                            <td class="red-button">
                                                                                Thay đổi quảng cáo 23</td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <igmisc:WebAsyncRefreshPanel ID="pnlQuangCao23" runat="server" Height="" RefreshComplete="RefreshComplete"
                                                                    Width="100%" OnContentRefresh="pnlQuangCao23_ContentRefresh">
                                                                    <span id="spnQuangCao23" runat="server"></span>
                                                                </igmisc:WebAsyncRefreshPanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="box6_name">
                                                                <table class="tab" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td class="tab_noactive" width="10">
                                                                            &nbsp;</td>
                                                                        <td width="170" valign="bottom">
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td width="12">
                                                                                        <img src="../images/left_tab.jpg" width="12" height="27" /></td>
                                                                                    <td class="tab_active_right">
                                                                                        Tất cả các sản phẩm
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td class="tab_noactive">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="box6_bor">
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td>
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td width="18%">
                                                                                        <table border="0" cellspacing="4" cellpadding="0">
                                                                                            <tr>
                                                                                                <td nowrap="nowrap">
                                                                                                    <b>Xem theo</b></td>
                                                                                                <td>
                                                                                                    <a>
                                                                                                        <img src="../images/xs1.jpg" width="30" height="25" border="0" /></a></td>
                                                                                                <td>
                                                                                                    <a>
                                                                                                        <img src="../images/xs2.jpg" width="30" height="25" border="0" /></a></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td width="52%" align="center">
                                                                                        <b>Trang [1] 2 3 4 5 6 7 ... &gt; &gt;&gt; </b>
                                                                                    </td>
                                                                                    <td width="30%">
                                                                                        <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                            <tr>
                                                                                                <td nowrap="nowrap">
                                                                                                    <b>Sắp xếp theo</b></td>
                                                                                                <td>
                                                                                                    <select name="select4" style="width: 150px; font-size: 11px;" disabled="disabled">
                                                                                                        <option>Giá giảm dần</option>
                                                                                                    </select>
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
                                                                        <td style="border-bottom: #CCCCCC dotted 1px">
                                                                            <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                <tr>
                                                                                    <td width="3%">
                                                                                        <input type="checkbox" name="checkbox3" value="checkbox" disabled="disabled" /></td>
                                                                                    <td width="24%">
                                                                                        <img src="../images/sp4.jpg" width="179" height="159" style="border: #CCCCCC 1px solid" /></td>
                                                                                    <td width="73%">
                                                                                        <b><a>Canon ixus 70/ SD1000 - Tạo nên những bức ảnh sắc nét</a></b><br />
                                                                                        - Kiểu dáng thời trang gọn nhẹ SIÊU MỎNG với 7.1 MG Pixels, Công nghệ DIGIC III
                                                                                        dò tìm mặt chủ thể 9 điểm, độ nhạy sáng Auto, ISO 1600, Zoom quang học 3x, Zoom
                                                                                        KTS 4x, Màn hình 2.5”, tiêu cự 35-105mm, quay phim đến 2giờ, Trọng lượng 125g, Kích
                                                                                        thước 85,9 x 53,5 x 19,4 mm.<br />
                                                                                        - Khả năng Nhạy sáng cao giúp đạt được những hình ảnh sắc nét trong điều kiện ánh
                                                                                        sáng yếu mà không có đèn flash.<br />
                                                                                        <strong>Mã sản phẩm</strong>: 10119786<br />
                                                                                        <strong>Thời gian</strong>: Từ 16/05/2008 đến 31/05/2008<br />
                                                                                        <strong>Giá khuyến mãi</strong>: 230 USD</td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="border-bottom: #CCCCCC dotted 1px">
                                                                            <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                <tr>
                                                                                    <td width="3%">
                                                                                        <input type="checkbox" name="checkbox3" value="checkbox" disabled="disabled" /></td>
                                                                                    <td width="24%">
                                                                                        <img src="../images/sp4.jpg" width="179" height="159" style="border: #CCCCCC 1px solid" /></td>
                                                                                    <td width="73%">
                                                                                        <b><a>Canon ixus 70/ SD1000 - Tạo nên những bức ảnh sắc nét</a></b><br />
                                                                                        - Kiểu dáng thời trang gọn nhẹ SIÊU MỎNG với 7.1 MG Pixels, Công nghệ DIGIC III
                                                                                        dò tìm mặt chủ thể 9 điểm, độ nhạy sáng Auto, ISO 1600, Zoom quang học 3x, Zoom
                                                                                        KTS 4x, Màn hình 2.5”, tiêu cự 35-105mm, quay phim đến 2giờ, Trọng lượng 125g, Kích
                                                                                        thước 85,9 x 53,5 x 19,4 mm.<br />
                                                                                        - Khả năng Nhạy sáng cao giúp đạt được những hình ảnh sắc nét trong điều kiện ánh
                                                                                        sáng yếu mà không có đèn flash.<br />
                                                                                        <strong>Mã sản phẩm</strong>: 10119786<br />
                                                                                        <strong>Thời gian</strong>: Từ 16/05/2008 đến 31/05/2008<br />
                                                                                        <strong>Giá khuyến mãi</strong>: 230 USD</td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="border-bottom: #CCCCCC dotted 1px">
                                                                            <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                <tr>
                                                                                    <td width="3%">
                                                                                        <input type="checkbox" name="checkbox3" value="checkbox" disabled="disabled" /></td>
                                                                                    <td width="24%">
                                                                                        <img src="../images/sp4.jpg" width="179" height="159" style="border: #CCCCCC 1px solid" /></td>
                                                                                    <td width="73%">
                                                                                        <b><a>Canon ixus 70/ SD1000 - Tạo nên những bức ảnh sắc nét</a></b><br />
                                                                                        - Kiểu dáng thời trang gọn nhẹ SIÊU MỎNG với 7.1 MG Pixels, Công nghệ DIGIC III
                                                                                        dò tìm mặt chủ thể 9 điểm, độ nhạy sáng Auto, ISO 1600, Zoom quang học 3x, Zoom
                                                                                        KTS 4x, Màn hình 2.5”, tiêu cự 35-105mm, quay phim đến 2giờ, Trọng lượng 125g, Kích
                                                                                        thước 85,9 x 53,5 x 19,4 mm.<br />
                                                                                        - Khả năng Nhạy sáng cao giúp đạt được những hình ảnh sắc nét trong điều kiện ánh
                                                                                        sáng yếu mà không có đèn flash.<br />
                                                                                        <strong>Mã sản phẩm</strong>: 10119786<br />
                                                                                        <strong>Thời gian</strong>: Từ 16/05/2008 đến 31/05/2008<br />
                                                                                        <strong>Giá khuyến mãi</strong>: 230 USD</td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="border-bottom: #CCCCCC dotted 1px">
                                                                            <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                <tr>
                                                                                    <td width="3%">
                                                                                        <input type="checkbox" name="checkbox3" value="checkbox" disabled="disabled" /></td>
                                                                                    <td width="24%">
                                                                                        <img src="../images/sp4.jpg" width="179" height="159" style="border: #CCCCCC 1px solid" /></td>
                                                                                    <td width="73%">
                                                                                        <b><a>Canon ixus 70/ SD1000 - Tạo nên những bức ảnh sắc nét</a></b><br />
                                                                                        - Kiểu dáng thời trang gọn nhẹ SIÊU MỎNG với 7.1 MG Pixels, Công nghệ DIGIC III
                                                                                        dò tìm mặt chủ thể 9 điểm, độ nhạy sáng Auto, ISO 1600, Zoom quang học 3x, Zoom
                                                                                        KTS 4x, Màn hình 2.5”, tiêu cự 35-105mm, quay phim đến 2giờ, Trọng lượng 125g, Kích
                                                                                        thước 85,9 x 53,5 x 19,4 mm.<br />
                                                                                        - Khả năng Nhạy sáng cao giúp đạt được những hình ảnh sắc nét trong điều kiện ánh
                                                                                        sáng yếu mà không có đèn flash.<br />
                                                                                        <strong>Mã sản phẩm</strong>: 10119786<br />
                                                                                        <strong>Thời gian</strong>: Từ 16/05/2008 đến 31/05/2008<br />
                                                                                        <strong>Giá khuyến mãi</strong>: 230 USD</td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td width="82%" align="left">
                                                                                        <b>Trang [1] 2 3 4 5 6 7 ... &gt; &gt;&gt; </b>
                                                                                    </td>
                                                                                    <td width="18%">
                                                                                        <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                            <tr>
                                                                                                <td width="82%" nowrap="nowrap">
                                                                                                    <strong>Đi tới trang </strong>
                                                                                                </td>
                                                                                                <td width="18%">
                                                                                                    <select name="select5" style="width: 50px; font-size: 11px;" disabled="disabled">
                                                                                                        <option>08</option>
                                                                                                    </select>
                                                                                                </td>
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
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr class="blured">
                                    <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="120" align="center" style="background: url(../images/footer.jpg) top no-repeat center">
                                                    <table width="977" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="207">
                                                            </td>
                                                            <td align="left" style="line-height: 18px;">
                                                                <strong>© 2008 chợnét.vn - Cơ quan chủ quản: Công ty TNHH TM Quảng Cáo trực tuyến CN
                                                                </strong>
                                                                <br />
                                                                Giấy phép số: ................. Cấp ngày : .............. Bộ Văn hóa Thông tin -
                                                                Cục báo chí.<br />
                                                                Trụ sở chính: 12 Tổ 1 P. Hoàng Văn Thụ Thành phố Thái Nguyên Tel: 0280.858168.<br />
                                                                Chịu trách nhiệm chính : Bà Nguyễn Thị Hợi
                                                            </td>
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
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
