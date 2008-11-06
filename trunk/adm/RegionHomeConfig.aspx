<%@ Page Language="C#" MasterPageFile="~/Adm/Admin.master" AutoEventWireup="true" CodeFile="RegionHomeConfig.aspx.cs" Inherits="Adm_RegionHomeConfig" Title="Cấu hình vùng" %>
<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <!--[if lt IE 7]>
<script defer type="text/javascript" src="../Scripts/pngfix.js"></script>
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

loadjscssfile("../Css/style.css", "css") ////dynamically load and add this .css file

function Add(){                              
        OpenDialogWindow('Thêm danh mục cha',350,150,'page','AddCat.aspx');    
}
function AddSub(id, ten){                              
        OpenDialogWindow('Thêm danh mục con',350,160,'page','AddSubCat.aspx?id=' + id + '&ten=' + ten);    
}
function Edit(id){                      
        OpenDialogWindow('Sửa danh mục cha',350,150,'page','AddCat.aspx?id=' + id);// + '&rand=' + rand_no);    
}
function EditSub(id, ten, subid){                      
        OpenDialogWindow('Sửa danh mục con',350,160,'page','AddSubCat.aspx?id=' + id + '&ten=' + ten + '&subid=' + subid);    
}
function Delete(id){                      
        OpenDialogWindow('Xóa danh mục',340,120,'page','Delete.aspx?id=' + id + '&type=nhomsanpham');    
}
function RefreshCat()
{  	var warp = ig$('<%=pnlDanhMuc.ClientID%>');	
	if(!warp)
		return;
	warp.refresh();		
}
function Refresh()
{  	var warp = ig$('<%=pnlDanhMuc.ClientID%>');	
	if(!warp)
		return;
	warp.refresh();		
}
function RefreshAdv(aid)
{  	
    var warp;
    switch(aid)
    {
        case 10: warp = ig$('<%=pnlQuangCao00.ClientID%>');
        break;
        case 1: warp = ig$('<%=pnlQuangCao01.ClientID%>');
        break;
        case 2: warp = ig$('<%=pnlQuangCao02.ClientID%>');
        break;
        case 3: warp = ig$('<%=pnlQuangCao03.ClientID%>');
        break;
        case 4: warp = ig$('<%=pnlQuangCao04.ClientID%>');
        break;
        case 5: warp = ig$('<%=pnlQuangCao05.ClientID%>');
        break;
        case 6: warp = ig$('<%=pnlQuangCao06.ClientID%>');
        break;
        case 6: warp = ig$('<%=pnlQuangCao06.ClientID%>');
        break;
        case 7: warp = ig$('<%=pnlQuangCao07.ClientID%>');
        break;
        case 8: warp = ig$('<%=pnlQuangCao08.ClientID%>');
        break;
        case 9: warp = ig$('<%=pnlQuangCao09.ClientID%>');
        break;
    }    	
	if(!warp)
		return;
	warp.refresh();		
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
function RefreshProduct(pid)
{
    var warp;
    switch(pid)
    {
        case 1: warp = ig$('<%=pnlSanPham01.ClientID%>');
        break;
        case 2: warp = ig$('<%=pnlSanPham02.ClientID%>');
        break;
        case 3: warp = ig$('<%=pnlSanPham03.ClientID%>');
        break;
        case 5: warp = ig$('<%=pnlSanPham05.ClientID%>');
        break;
        case 6: warp = ig$('<%=pnlSanPham06.ClientID%>');
        break;
        case 7: warp = ig$('<%=pnlSanPham07.ClientID%>');
        break;
    }    	
	if(!warp)
		return;
	warp.refresh();	
}
function RefreshComplete(oPanel){
	CloseDialogWindow();
}
function ChangeAdv(aid)
{
    OpenDialogWindow('Thay đổi quảng cáo',680,420,'page','SelectAdv.aspx?rid=<%=intKhuVucID %>&aid=' + aid);
}
function ChangeProduct(pid)
{

    if(pid == 4)
    {
        var cid = document.getElementById('<%=hidCatId.ClientID%>').value;
        OpenDialogWindow('Thay đổi sản phẩm',906,600,'page','SelectProduct.aspx?rid=<%=intKhuVucID %>&pid=' + pid + '&cid=' + cid);
    }
    else
    {
        OpenDialogWindow('Thay đổi sản phẩm',1006,700,'page','SelectProd.aspx?rid=<%=intKhuVucID %>&pid=' + pid);
    }
}
function ChangeCat()
{
    OpenDialogWindow('Thay đổi danh mục',680,420,'page','SelectCatRegion.aspx?rid=<%=intKhuVucID %>');
}
function ChangeStore(sid)
{
    OpenDialogWindow('Thay đổi gian hàng',780,620,'page','SelectStore.aspx?rid=<%=intKhuVucID %>&sid=' + sid);
}
function RefreshStore()
{  	var warp = ig$('<%=pnlGianHang.ClientID %>');	
	if(!warp)
		return;
	warp.refresh();		
}
// -->
    </script>

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
                                            <td width="55%" class="blured">
                                                
                                                <igmisc:WebAsyncRefreshPanel ID="pnlSanPham01" runat="server" Height="" OnContentRefresh="pnlSanPham01_ContentRefresh"
                                                    Width="100%" RefreshComplete="RefreshComplete">
                                                    <span id="spnSanPham01" runat="server" style="text-align: left"></span>
                                                </igmisc:WebAsyncRefreshPanel>
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
        <tr id="trContent">
            <td style="vertical-align: top;">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td style="background: url(../images/leftcenterbody.jpg) repeat-y right">
                                        &nbsp;</td>
                                    <td style="padding: 2px;">
                                        <div onclick="ChangeAdv(10);" style="cursor: hand;">
                                            <table cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td>
                                                        <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                    <td class="red-button">
                                                        Thay đổi quảng cáo 10</td>
                                                </tr>
                                            </table>
                                        </div>
                                        <igmisc:WebAsyncRefreshPanel ID="pnlQuangCao00" runat="server" Height="" Width="100%"
                                            RefreshComplete="RefreshComplete" OnContentRefresh="pnlQuangCao00_ContentRefresh">
                                            <span id="spnQuangCao00" runat="server"></span>
                                        </igmisc:WebAsyncRefreshPanel>
                                    </td>
                                    <td style="background: url(../images/rightcenterbody.jpg) repeat-y left; width: 5px;">
                                        &nbsp;</td>
                                </tr>
                                <tr style="height: auto">
                                    <td style="background: url(../images/leftcenterbody.jpg) repeat-y right">
                                        &nbsp;</td>
                                    <td colspan="2" style="background: url(../images/rightcenterbody.jpg) repeat-y left 50%">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="blured">
                                            <tr>
                                                <td align="center" width="207">
                                                    <table border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td>
                                                                <a href="#">
                                                                    <img src="../images/sky.jpg" width="70" height="29" border="0" /></a></td>
                                                            <td>
                                                                <a href="#">
                                                                    <img src="../images/ym.jpg" width="81" height="31" border="0" /></a></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 8px; background-image: url(../images/seperate1.jpg); background-position-y: bottom;
                                                    background-repeat: no-repeat; background-color: transparent;">
                                                </td>
                                                <td>
                                                    <strong>Trang chủ</strong>
                                                </td>
                                                <td style="background-position-y: bottom; background-image: url(../images/seperate1.jpg);
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
                                    <td style="background: url(../images/leftcenterbody.jpg) repeat-y right">
                                        &nbsp;</td>
                                    <td width="977">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="207" align="left" valign="top" style="background: url(../images/bgleftmenu.jpg) fixed left top;">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td>
                                                                <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                    <tr>
                                                                        <td>
                                                                            <igmisc:WebAsyncRefreshPanel ID="pnlDanhMuc" runat="server" Width="100%" Height="100%"
                                                                                RefreshComplete="RefreshComplete" OnContentRefresh="pnlDanhMuc_ContentRefresh">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td class="title">
                                                                                            Danh mục sản phẩm
                                                                                        </td>
                                                                                        <td style="cursor: hand" onclick="Add();">
                                                                                            <img src="../Images/Add.gif" alt="Thêm danh mục cha" /></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                            <table width="100%" class="leftmenuadmin" border="0" cellspacing="0" cellpadding="0"
                                                                                                id="tblDanhMuc" runat="server">
                                                                                            </table>
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
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td class="title">
                                                                            SẢN PHẨM ĐÃ XEM
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                <tr>
                                                                                    <td align="center">
                                                                                        <a href="#">
                                                                                            <img src="../images/sp1.jpg" width="66" border="0" /></a></td>
                                                                                    <td align="center">
                                                                                        <a href="#">
                                                                                            <img src="../images/sp1.jpg" width="66" border="0" /></a></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center">
                                                                                        <a href="#">
                                                                                            <img src="../images/sp1.jpg" width="66" border="0" /></a></td>
                                                                                    <td align="center">
                                                                                        <a href="#">
                                                                                            <img src="../images/sp1.jpg" width="66" border="0" /></a></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center">
                                                                                        <a href="#">
                                                                                            <img src="../images/sp1.jpg" width="66" border="0" /></a></td>
                                                                                    <td align="center">
                                                                                        <a href="#">
                                                                                            <img src="../images/sp1.jpg" width="66" border="0" /></a></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div onclick="ChangeProduct(7);" style="cursor: hand; visibility: hidden;">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                                            <td class="red-button">
                                                                                Thay đổi sản phẩm mới cập nhật 07</td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td class="title">
                                                                            <table border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td width="28%" align="center">
                                                                                        <img src="../images/spmoi.png" width="30" height="27" /></td>
                                                                                    <td width="72%" nowrap="nowrap" class="title">
                                                                                        SẢN PHẨM MỚI
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <igmisc:WebAsyncRefreshPanel ID="pnlSanPham07" runat="server" Height="" Width="100%"
                                                                                RefreshComplete="RefreshComplete" OnContentRefresh="pnlSanPham07_ContentRefresh">
                                                                                <asp:Table ID="tblSanPham07" runat="server" Width="100%" BorderStyle="none" CellSpacing="0"
                                                                                    CellPadding="0">
                                                                                </asp:Table>
                                                                            </igmisc:WebAsyncRefreshPanel>
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
                                                                            <div onclick="ChangeAdv(4);" style="cursor: hand;">
                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                                                        <td class="red-button">
                                                                                            Thay đổi quảng cáo 04</td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                            <igmisc:WebAsyncRefreshPanel ID="pnlQuangCao04" runat="server" Height="" RefreshComplete="RefreshComplete"
                                                                                Width="100%" OnContentRefresh="pnlQuangCao04_ContentRefresh">
                                                                                <asp:Table ID="tblQuangCao04" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0">
                                                                                </asp:Table>
                                                                            </igmisc:WebAsyncRefreshPanel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="207" valign="top">
                                                                            <div onclick="ChangeAdv(6);" style="cursor: hand;">
                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                                                        <td class="red-button">
                                                                                            Thay đổi quảng cáo 06</td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                            <igmisc:WebAsyncRefreshPanel ID="pnlQuangCao06" runat="server" Height="" RefreshComplete="RefreshComplete"
                                                                                Width="100%" OnContentRefresh="pnlQuangCao06_ContentRefresh">
                                                                                <asp:Table ID="tblQuangCao06" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0">
                                                                                </asp:Table>
                                                                            </igmisc:WebAsyncRefreshPanel>
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
                                                            <td style="height: 79px">
                                                                <div onclick="ChangeAdv(1);" style="cursor: hand;">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                                            <td class="red-button">
                                                                                Thay đổi quảng cáo 01</td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <igmisc:WebAsyncRefreshPanel ID="pnlQuangCao01" runat="server" Height="" Width="100%"
                                                                    OnContentRefresh="pnlQuangCao01_ContentRefresh" RefreshComplete="RefreshComplete">
                                                                    <span id="spnQuangCao01" runat="server"></span>
                                                                </igmisc:WebAsyncRefreshPanel>
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
                                                                                        <div onclick="ChangeAdv(2);" style="cursor: hand;">
                                                                                            <table cellpadding="0" cellspacing="0" border="0">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                                                                    <td class="red-button">
                                                                                                        Thay đổi quảng cáo 02</td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </div>
                                                                                        <igmisc:WebAsyncRefreshPanel ID="pnlQuangCao02" runat="server" Height="" Width="100%"
                                                                                            RefreshComplete="RefreshComplete" OnContentRefresh="pnlQuangCao02_ContentRefresh">
                                                                                            <span id="spnQuangCao02" runat="server"></span>
                                                                                        </igmisc:WebAsyncRefreshPanel>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="padding-top: 4px;">
                                                                                        <div onclick="ChangeProduct(2);" style="cursor: hand; margin-top: 3px">
                                                                                            <table cellpadding="0" cellspacing="0" border="0">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                                                                    <td class="red-button">
                                                                                                        Thay đổi sản phẩm 02</td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </div>
                                                                                        <igmisc:WebAsyncRefreshPanel ID="pnlSanPham02" runat="server" Height="" Width="100%"
                                                                                            RefreshComplete="RefreshComplete" OnContentRefresh="pnlSanPham02_ContentRefresh">
                                                                                            <asp:Table ID="tblSanPham02" runat="server" Width="100%" BorderStyle="none" CellSpacing="0"
                                                                                                CellPadding="0">
                                                                                            </asp:Table>
                                                                                        </igmisc:WebAsyncRefreshPanel>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td align="left" valign="top" class="blured">
                                                                            <span class="Apple-style-span" style="border-collapse: separate; color: rgb(51, 51, 51);
                                                                                font-family: Verdana; font-size: 11px; font-style: normal; font-variant: normal;
                                                                                font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2;
                                                                                text-align: auto; text-indent: 0px; text-transform: none; white-space: normal;
                                                                                widows: 2; word-spacing: 0px; -webkit-border-horizontal-spacing: 0px; -webkit-border-vertical-spacing: 0px;
                                                                                -webkit-text-decorations-in-effect: none; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0;">
                                                                                <table width="100%" border="0" cellspacing="2" cellpadding="0" style="border-right: 1pt solid;
                                                                                    border-top: 1pt solid; border-left: 1pt solid; border-bottom: 1pt solid">
                                                                                    <tbody>
                                                                                        <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(51, 51, 51);">
                                                                                            <td height="25" align="center" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                                font-size: 11px; color: rgb(51, 51, 51);">
                                                                                                <strong>THÔNG TIN HƯỚNG DẪN</strong></td>
                                                                                        </tr>
                                                                                        <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(51, 51, 51);">
                                                                                            <td style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(51, 51, 51);">
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tbody>
                                                                                                        <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(51, 51, 51);">
                                                                                                            <td height="20" align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                                                font-size: 11px; color: rgb(51, 51, 51);">
                                                                                                                <a href="#" style="font-size: 11px; color: rgb(51, 51, 51); text-decoration: none;
                                                                                                                    font-family: Verdana, Arial, Helvetica, sans-serif;">+ Đăng ký</a></td>
                                                                                                            <td height="20" align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                                                font-size: 11px; color: rgb(51, 51, 51);">
                                                                                                                <a href="#" style="font-size: 11px; color: rgb(51, 51, 51); text-decoration: none;
                                                                                                                    font-family: Verdana, Arial, Helvetica, sans-serif;">+ Thanh toán</a></td>
                                                                                                        </tr>
                                                                                                        <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(51, 51, 51);">
                                                                                                            <td height="20" align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                                                font-size: 11px; color: rgb(51, 51, 51);">
                                                                                                                <a href="#" style="font-size: 11px; color: rgb(51, 51, 51); text-decoration: none;
                                                                                                                    font-family: Verdana, Arial, Helvetica, sans-serif;">+ Mua Hàng</a></td>
                                                                                                            <td height="20" align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                                                font-size: 11px; color: rgb(51, 51, 51);">
                                                                                                                <a href="#" style="font-size: 11px; color: rgb(51, 51, 51); text-decoration: none;
                                                                                                                    font-family: Verdana, Arial, Helvetica, sans-serif;">+ Vận chuyển</a></td>
                                                                                                        </tr>
                                                                                                        <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(51, 51, 51);">
                                                                                                            <td height="20" align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                                                font-size: 11px; color: rgb(51, 51, 51);">
                                                                                                                <a href="#" style="font-size: 11px; color: rgb(51, 51, 51); text-decoration: none;
                                                                                                                    font-family: Verdana, Arial, Helvetica, sans-serif;">+ Bán Hàng</a></td>
                                                                                                            <td height="20" align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                                                font-size: 11px; color: rgb(51, 51, 51);">
                                                                                                                <a href="#" style="font-size: 11px; color: rgb(51, 51, 51); text-decoration: none;
                                                                                                                    font-family: Verdana, Arial, Helvetica, sans-serif;">+ Gian Hàng</a></td>
                                                                                                        </tr>
                                                                                                        <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(51, 51, 51);">
                                                                                                            <td height="20" align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                                                font-size: 11px; color: rgb(51, 51, 51);">
                                                                                                                <a href="#" style="font-size: 11px; color: rgb(51, 51, 51); text-decoration: none;
                                                                                                                    font-family: Verdana, Arial, Helvetica, sans-serif;">+ Giao dịch</a></td>
                                                                                                            <td height="20" align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                                                font-size: 11px; color: rgb(51, 51, 51);">
                                                                                                                <a href="#" style="font-size: 11px; color: rgb(51, 51, 51); text-decoration: none;
                                                                                                                    font-family: Verdana, Arial, Helvetica, sans-serif;">+ Quy Định</a></td>
                                                                                                        </tr>
                                                                                                        <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(51, 51, 51);">
                                                                                                            <td height="20" align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                                                font-size: 11px; color: rgb(51, 51, 51);">
                                                                                                                <a href="#" style="font-size: 11px; color: rgb(51, 51, 51); text-decoration: none;
                                                                                                                    font-family: Verdana, Arial, Helvetica, sans-serif;">+ Quảng cáo</a></td>
                                                                                                            <td height="20" align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                                                font-size: 11px; color: rgb(51, 51, 51);">
                                                                                                                <a href="#" style="font-size: 11px; color: rgb(51, 51, 51); text-decoration: none;
                                                                                                                    font-family: Verdana, Arial, Helvetica, sans-serif;">+ Tài trợ</a></td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(51, 51, 51);">
                                                                                            <td height="25" align="center" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                                font-size: 11px; color: rgb(51, 51, 51);">
                                                                                                <strong>THÔNG TIN MỚI TỪ CHỢ NET</strong></td>
                                                                                        </tr>
                                                                                        <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(51, 51, 51);">
                                                                                            <td height="25" align="center" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                                font-size: 11px; color: rgb(51, 51, 51);">
                                                                                                <a href="#" style="font-size: 11px; color: rgb(51, 51, 51); text-decoration: none;
                                                                                                    font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                                                                    <img src="../images/len.jpg" width="26" height="25" border="0"></a></td>
                                                                                        </tr>
                                                                                        <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(51, 51, 51);">
                                                                                            <td height="25" style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px;
                                                                                                color: rgb(51, 51, 51);">
                                                                                                <div runat="server" id="divtintuc">
                                                                                                    Các binh sĩ Thái bắt đầu đi tuần trên đường phố Bangkok sau khi đụng độ giữa cảnh
                                                                                                    sát và phe biểu tình khiến hai người chết và hơn 400 người bị thương.Các binh sĩ
                                                                                                    Thái bắt đầu đi tuần trên đường phố Bangkok sau khi đụng độ giữa cảnh sát và phe
                                                                                                    biểu tình khiến hai người chết và hơn 400 người bị thương.Các binh sĩ Thái bắt đầu
                                                                                                    đi tuần trên đường phố Bangkok sau khi đụng độ giữa cảnh sát</div>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(51, 51, 51);">
                                                                                            <td height="25" align="center" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                                font-size: 11px; color: rgb(51, 51, 51);">
                                                                                                <a href="#" style="font-size: 11px; color: rgb(51, 51, 51); text-decoration: none;
                                                                                                    font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                                                                    <img src="../images/xuong.jpg" width="26" height="25" border="0"></a></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </span>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div onclick="ChangeAdv(3);" style="cursor: hand;">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                                            <td class="red-button">
                                                                                Thay đổi quảng cáo 03</td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <igmisc:WebAsyncRefreshPanel ID="pnlQuangCao03" runat="server" Height="" Width="100%"
                                                                    OnContentRefresh="pnlQuangCao03_ContentRefresh" RefreshComplete="RefreshComplete">
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
                                                                </igmisc:WebAsyncRefreshPanel>
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
                                                                            <div onclick="ChangeCat();" style="cursor: hand;">
                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                                                        <td class="red-button">
                                                                                            Thay đổi danh mục</td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                            <igmisc:WebAsyncRefreshPanel ID="pnlSanPham04" runat="server" Height="" Width="100%"
                                                                                OnContentRefresh="pnlSanPham04_ContentRefresh" RefreshComplete="RefreshComplete">
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
                                                                                            <div onclick="ChangeProduct(4);" style="cursor: hand;">
                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                                                                        <td class="red-button">
                                                                                                            Thay đổi sản phẩm 04 (<asp:Label ID="lblTab" runat="server"></asp:Label>)</td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </div>
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
                                                                <div onclick="ChangeAdv(5);" style="cursor: hand;">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                                            <td class="red-button">
                                                                                Thay đổi quảng cáo 05</td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <igmisc:WebAsyncRefreshPanel ID="pnlQuangCao05" runat="server" Height="" Width="100%"
                                                                    OnContentRefresh="pnlQuangCao05_ContentRefresh" RefreshComplete="RefreshComplete">
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
                                                                </igmisc:WebAsyncRefreshPanel>
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
                                                                            <div onclick="ChangeProduct(6);" style="cursor: hand; visibility: hidden;">
                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                                                        <td class="red-button">
                                                                                            Thay đổi sản phẩm khuyến mại 06</td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td width="7%" class="nd1">
                                                                                        <img src="../images/km.png" width="50" height="44" /></td>
                                                                                    <td width="17%" nowrap="nowrap" class="nd1">
                                                                                        <a href="../promotion.aspx?pcode=km">SẢN PHẨM KHUYẾN MÃI </a>
                                                                                    </td>
                                                                                    <td width="76%" align="right" class="pages" style="padding-right: 10px">
                                                                                        <a href="../promotion.aspx?pcode=km">Xem tất cả</a>
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
                                                                                        <igmisc:WebAsyncRefreshPanel ID="pnlSanPham06" runat="server" Height="" Width="100%"
                                                                                            RefreshComplete="RefreshComplete" OnContentRefresh="pnlSanPham06_ContentRefresh">
                                                                                            <asp:Table ID="tblSanPham06b" CssClass="khuyenmai" runat="server" Width="95%" BorderStyle="none"
                                                                                                CellSpacing="0" CellPadding="0">
                                                                                            </asp:Table>
                                                                                        </igmisc:WebAsyncRefreshPanel>
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
                                                                <div onclick="ChangeAdv(7);" style="cursor: hand;">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                                            <td class="red-button">
                                                                                Thay đổi quảng cáo 07</td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <igmisc:WebAsyncRefreshPanel ID="pnlQuangCao07" runat="server" Height="" Width="100%"
                                                                    OnContentRefresh="pnlQuangCao07_ContentRefresh" RefreshComplete="RefreshComplete">
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
                                                                </igmisc:WebAsyncRefreshPanel>
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
                                                                            <div onclick="ChangeProduct(5);" style="cursor: hand; visibility: hidden;">
                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                                                        <td class="red-button">
                                                                                            Thay đổi sản phẩm giảm giá 05</td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td width="7%" class="nd1">
                                                                                        <img src="../images/gg.png" width="40" height="44" /></td>
                                                                                    <td width="17%" nowrap="nowrap" class="nd1">
                                                                                        <a href="../promotion.aspx?pcode=gg">SẢN PHẨM GIẢM GIÁ</a></td>
                                                                                    <td width="76%" align="right" class="pages" style="padding-right: 10px">
                                                                                        <a href="../promotion.aspx?pcode=gg">Xem tất cả</a>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <igmisc:WebAsyncRefreshPanel ID="pnlSanPham05" runat="server" Height="" Width="100%"
                                                                                RefreshComplete="RefreshComplete" OnContentRefresh="pnlSanPham05_ContentRefresh">
                                                                                <asp:Table ID="tblSanPham05" runat="server" Width="100%" BorderStyle="none" CellSpacing="0"
                                                                                    CellPadding="0">
                                                                                </asp:Table>
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
                                                                <div onclick="ChangeAdv(8);" style="cursor: hand;">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                                            <td class="red-button">
                                                                                Thay đổi quảng cáo 08</td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <igmisc:WebAsyncRefreshPanel ID="pnlQuangCao08" runat="server" Height="" Width="100%"
                                                                    OnContentRefresh="pnlQuangCao08_ContentRefresh" RefreshComplete="RefreshComplete">
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
                                                                </igmisc:WebAsyncRefreshPanel>
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
                                                                            <div onclick="ChangeProduct(3);" style="cursor: hand; visibility: hidden;">
                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                                                        <td class="red-button">
                                                                                            Thay đổi sản phẩm ưa chuộng 03</td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td width="17%" nowrap="nowrap" class="nd1">
                                                                                        <a href="../promotion.aspx?pcode=uc">SẢN PHẨM ĐƯỢC ƯA CHUỘNG </a>
                                                                                    </td>
                                                                                    <td width="83%" align="right" class="pages" style="padding-right: 10px">
                                                                                        <a href="../promotion.aspx?pcode=uc">Xem tất cả</a>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <igmisc:WebAsyncRefreshPanel ID="pnlSanPham03" runat="server" Height="" Width="100%"
                                                                                RefreshComplete="RefreshComplete" OnContentRefresh="pnlSanPham03_ContentRefresh">
                                                                                <asp:Table ID="tblSanPham03" runat="server" Width="100%" BorderStyle="none" CellSpacing="0"
                                                                                    CellPadding="0">
                                                                                </asp:Table>
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
                                                                <div onclick="ChangeAdv(9);" style="cursor: hand;">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                                            <td class="red-button">
                                                                                Thay đổi quảng cáo 09</td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <igmisc:WebAsyncRefreshPanel ID="pnlQuangCao09" runat="server" Height="" Width="100%"
                                                                    OnContentRefresh="pnlQuangCao09_ContentRefresh" RefreshComplete="RefreshComplete">
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
                                                                </igmisc:WebAsyncRefreshPanel>
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
                                                                        <td rowspan="3" align="center" valign="top">
                                                                            <div onclick="ChangeStore(01);" style="cursor: hand;">
                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                                                        <td class="red-button">
                                                                                            Thay đổi gian hàng 01</td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
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
                                                                                        <igmisc:WebAsyncRefreshPanel ID="pnlGianHang" runat="server" Height="" OnContentRefresh="pnlGianHang_ContentRefresh"
                                                                                            Width="100%" RefreshComplete="RefreshComplete">
                                                                                            <asp:Table ID="tblGianHang" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0">
                                                                                            </asp:Table>
                                                                                        </igmisc:WebAsyncRefreshPanel>
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
                                                        <tr>
                                                            <td style="border-bottom: #CCCCCC dashed 1px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr class="blured">
                                                            <td height="30" style="font-weight: bold; padding-left: 10px; text-align: left">
                                                                <a href="#">GIỚI THIỆU</a> | <a href="#">LIÊN HỆ</a> | <a href="../EstoreHome.aspx">
                                                                    GIAN HÀNG</a> | <a href="#">HƯỚNG DẪN</a> | <a href="#">TIN TỨC</a></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="15" align="left" valign="top" style="background: url(../images/bgrightdoc.jpg) repeat-y left">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="background: url(../images/rightcenterbody.jpg) repeat-y left; width: 5px;">
                                        &nbsp;</td>
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
</asp:Content>

