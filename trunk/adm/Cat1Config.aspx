<%@ Page Language="C#" MasterPageFile="~/Adm/Admin.master" AutoEventWireup="true" CodeFile="Cat1Config.aspx.cs" Inherits="Admin_Cat1Config" Title="Danh mục cấp 1" %>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
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
var catId = '<%=mcid.ToString()%>';
function RefreshAdv(aid)
{  	
    var warp;
    switch(aid)
    {        
        case 12: warp = ig$('<%=pnlQuangCao12.ClientID%>');
        break;
        case 13: warp = ig$('<%=pnlQuangCao13.ClientID%>');
        break;
    }    	
	if(!warp)
		return;
	warp.refresh();		
}
function RefreshProduct(pid)
{
    var warp;
    switch(pid)
    {
        case 11: warp = ig$('<%=pnlSanPham11.ClientID%>');
        break;
        case 12: warp = ig$('<%=pnlSanPham12.ClientID%>');
        break;
        case 13: warp = ig$('<%=pnlSanPham13.ClientID%>');
        break;
        case 14: warp = ig$('<%=pnlSanPham14.ClientID%>');
        break;
    }    	
	if(!warp)
		return;
	warp.refresh();	
}
function ChangeAdv(aid)
{
    var cid = document.getElementById('<%=hidCatId.ClientID%>').value;
    OpenDialogWindow('Thay đổi quảng cáo',680,420,'page','SelectAdv.aspx?aid=' + aid + '&cid=' + cid);
}

function RefreshComplete(oPanel){
	CloseDialogWindow();
}
function ChangeProduct(pid)
{
    OpenDialogWindow('Thay đổi sản phẩm',906,600,'page','SelectProduct.aspx?pid=' + pid + '&cid=' + catId);
}
function ChangeStore(sid)
{
    OpenDialogWindow('Thay đổi gian hàng',780,620,'page','SelectStore.aspx?sid=' + sid);
}
function RefreshStore()
{  	var warp = ig$('<%=pnlGianHang.ClientID %>');	
	if(!warp)
		return;
	warp.refresh();		
}
// -->
</script>
<input type="hidden" id="hidCatId" runat="server" value="0" />
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
                <td height="25" align="left" style="padding-left:20px;"><b><a class="pathway">Trang chủ</a> &gt;
				<a class="pathway"><asp:Label ID="lblDanhMuc" runat="server"></asp:Label></a></b></td>
              </tr>
              <tr>
                <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="230" align="left" valign="top">
					<table width="100%" border="0" cellspacing="4" cellpadding="0">

					  <tr>
						<td><table class="box2" width="100%" border="0" cellspacing="0" cellpadding="0">
						  <tr>
							<td class="box2_name">Danh mục sản phẩm </td>
						  </tr>
						  <tr>
							<td class="box2_bor">
							<asp:Table ID="tblDanhMuc" runat="server" CssClass="listcat" Width="100%" CellPadding="0" CellSpacing="0"></asp:Table>
                            </td>
						  </tr>
						</table></td>
					  </tr>
					  <tr>
					    <td class="blured"><table class="box2" width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td class="box2_name">Tìm kiếm nâng cao </td>
                          </tr>
                          <tr>
                            <td class="box2_bor" style="padding:4px;"><table width="100%" border="0" cellspacing="2" cellpadding="0">
                              <tr>
                                <td width="10%" align="left"><input type="checkbox" name="checkbox" value="checkbox" disabled="disabled" /></td>
                                <td width="90%" align="left" nowrap="nowrap">Từ khóa </td>
                              </tr>
                              <tr>
                                <td colspan="2" align="left"><input name="textfield2" type="text" style=" width:170px; font-size:11px;" disabled="disabled"/></td>
                              </tr>
                              <tr>
                                <td align="left"><input type="checkbox" name="checkbox2" value="checkbox" disabled="disabled" /></td>
                                <td align="left" nowrap="nowrap">Mã sản phẩm </td>
                              </tr>
                              <tr>
                                <td colspan="2" align="left"><input name="textfield22" type="text" style=" width:170px; font-size:11px;" disabled="disabled"/></td>
                              </tr>
                              <tr>
                                <td align="left"><input type="checkbox" name="checkbox22" value="checkbox" disabled="disabled" /></td>
                                <td align="left" nowrap="nowrap">Trong danh mục </td>
                              </tr>
                              <tr>
                                <td colspan="2" align="left"><select name="select2" style=" width:170px; font-size:11px;" disabled="disabled">
                                    <option>Máy tính để bàn nguyên bộ</option>
                                </select></td>
                              </tr>
                              <tr>
                                <td align="left"><input type="checkbox" name="checkbox22" value="checkbox" disabled="disabled" /></td>
                                <td  align="left" nowrap="nowrap">Hãng sản xuất </td>
                              </tr>
                              <tr>
                                <td colspan="2" align="left"><select name="select3" style=" width:170px; font-size:11px;" disabled="disabled">
                                    <option>Hãng sản xuất</option>
                                </select></td>
                              </tr>
                              <tr>
                                <td align="left"><input type="checkbox" name="checkbox22" value="checkbox" disabled="disabled" /></td>
                                <td align="left" nowrap="nowrap">Dòng sản phẩm </td>
                              </tr>
                              <tr>
                                <td colspan="2" align="left"><select name="select2" style=" width:170px; font-size:11px;" disabled="disabled">
                                    <option>Model sản phẩm</option>
                                </select></td>
                              </tr>
                              <tr>
                                <td align="left"><input type="checkbox" name="checkbox22" value="checkbox" disabled="disabled" /></td>
                                <td align="left" nowrap="nowrap">Tại khu vực</td>
                              </tr>
                              <tr>
                                <td colspan="2" align="left"><select name="select2" style=" width:170px; font-size:11px;" disabled="disabled">
                                    <option>Việt Nam</option>
                                </select></td>
                              </tr>
                              <tr>
                                <td height="30" colspan="2" align="left"><input type="submit" class="button" name="Submit2" value="Tìm kiếm" disabled="disabled" /></td>
                              </tr>
                            </table></td>
                          </tr>
                        </table></td>
					    </tr>
					  <tr>
					    <td>
					        <div onclick="ChangeAdv(13);" style="cursor:hand;">                      
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td><img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                        <td class="red-button">Thay đổi quảng cáo 13 (<%=lblDanhMuc.Text%>)</td>
                                    </tr>
                                </table>                        
                          </div>
					    </td>
					  </tr>
					  <tr>
					    <td>
                            <igmisc:WebAsyncRefreshPanel ID="pnlQuangCao13" runat="server" Height="" RefreshComplete="RefreshComplete"
                                Width="100%" OnContentRefresh="pnlQuangCao13_ContentRefresh">
					        <asp:Table ID="tblQuangCao13" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0"></asp:Table>
                            </igmisc:WebAsyncRefreshPanel>
					    </td>
					  </tr>
                    </table></td>
                    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td><table width="100%" border="0" cellspacing="4" cellpadding="0">
                          <tr>
                            <td align="left" valign="top">
							<table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td>                                
                                   <div onclick="ChangeAdv(12);" style="cursor:hand;">                      
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td><img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                <td class="red-button">Thay đổi quảng cáo 12 (<%=lblDanhMuc.Text%>)</td>
                                            </tr>
                                        </table>                        
                                  </div>
                                  <igmisc:WebAsyncRefreshPanel ID="pnlQuangCao12" runat="server" Height="" RefreshComplete="RefreshComplete" Width="" OnContentRefresh="pnlQuangCao12_ContentRefresh">
                                        <span id="spnQuangCao12" runat="server"></span>
                                   </igmisc:WebAsyncRefreshPanel>   
                                </td>
                              </tr>
                              <tr>
                                <td>
                                <div onclick="ChangeProduct(11);" style="cursor:hand; margin-top:3px">                      
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td><img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                <td class="red-button">Thay đổi sản phẩm 11 (<%=lblDanhMuc.Text%>)</td>
                                            </tr>
                                        </table>                        
                                  </div>
                                <igmisc:WebAsyncRefreshPanel ID="pnlSanPham11" runat="server" Height="" Width="" RefreshComplete="RefreshComplete" OnContentRefresh="pnlSanPham11_ContentRefresh">
                                    <asp:Table id="tblSanPham11" runat="server" Width="100%" BorderStyle="none" CellSpacing="0" CellPadding="0"></asp:Table>
                                </igmisc:WebAsyncRefreshPanel>
                               </td>
                              </tr>
                            </table></td>
                            </tr>
                        </table></td>
                      </tr>                      
                      <tr>
                        <td align="left" valign="top" style="padding:4px;"><table width="100%" border="0" class="box4" cellspacing="0" cellpadding="0">
                          <tr>
                            <td class="title"><span>Gian hàng giới thiệu</span>
                            <div onclick="ChangeStore(11);" style="cursor:hand;">                      
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td><img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                <td class="red-button">Thay đổi gian hàng 11</td>
                                            </tr>
                                        </table>                        
                                  </div>
                            </td>
                          </tr>
                          <tr>
                            <td class="box4_bor">
                            <igmisc:WebAsyncRefreshPanel ID="pnlGianHang" runat="server" Height="" OnContentRefresh="pnlGianHang_ContentRefresh"
                               Width="" RefreshComplete="RefreshComplete">
                            <asp:Table ID="tblGianHang" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0"></asp:Table>
                            </igmisc:WebAsyncRefreshPanel>     
                            </td>
                          </tr>
                        </table></td>
                      </tr>
					  <tr>
                        <td align="left" valign="top" style="padding:4px;" class="blured">
						<table width="100%" border="0" class="box4" cellspacing="0" cellpadding="0">
                          <tr>
                            <td class="title"><span>Sản phẩm được ưa chuộng</span>
                            <div onclick="ChangeProduct(12);" style="cursor:hand; visibility:hidden;">                      
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td><img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                <td class="red-button">Thay đổi sản phẩm được ưa chuộng 12 (<%=lblDanhMuc.Text%>)</td>
                                            </tr>
                                        </table>                        
                                  </div>
                            </td>
                          </tr>
                          <tr>
                            <td class="box4_bor">
                            <igmisc:WebAsyncRefreshPanel ID="pnlSanPham12" runat="server" Height="" Width="" RefreshComplete="RefreshComplete" OnContentRefresh="pnlSanPham12_ContentRefresh">
                                    <asp:Table id="tblSanPham12" runat="server" Width="100%" BorderStyle="none" CellSpacing="0" CellPadding="0"></asp:Table>
                            </igmisc:WebAsyncRefreshPanel>
                            </td>
                          </tr>
                        </table></td>
                      </tr>
                      <tr>
                        <td align="left" valign="top" style="padding:4px;" class="blured"><table width="100%" border="0" class="box4" cellspacing="0" cellpadding="0">
                          <tr>
                            <td class="title"><span>Sản phẩm giảm giá</span>
                            <div onclick="ChangeProduct(13);" style="cursor:hand;visibility:hidden;">                      
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td><img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                <td class="red-button">Thay đổi sản phẩm giảm giá 13 (<%=lblDanhMuc.Text%>)</td>
                                            </tr>
                                        </table>                        
                                  </div>
                            </td>
                          </tr>
                          <tr>
                            <td class="box4_bor">
                            <igmisc:WebAsyncRefreshPanel ID="pnlSanPham13" runat="server" Height="" Width="" RefreshComplete="RefreshComplete" OnContentRefresh="pnlSanPham13_ContentRefresh">
                                    <asp:Table id="tblSanPham13" runat="server" Width="100%" BorderStyle="none" CellSpacing="0" CellPadding="0"></asp:Table>
                            </igmisc:WebAsyncRefreshPanel>
                           </td>
                          </tr>
                        </table></td>
                      </tr>
                      <tr>
                        <td align="left" valign="top" style="padding:4px;" class="blured"><table width="100%" border="0" class="box4" cellspacing="0" cellpadding="0">
                          <tr>
                            <td class="title"><span>Sản phẩm mới cập nhật</span>
                            <div onclick="ChangeProduct(14);" style="cursor:hand; visibility:hidden;">                      
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td><img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                <td class="red-button">Thay đổi sản phẩm mới cập nhật 14 (<%=lblDanhMuc.Text%>)</td>
                                            </tr>
                                        </table>                        
                                  </div>
                            </td>
                          </tr>
                          <tr>
                            <td class="box4_bor">
                            <igmisc:WebAsyncRefreshPanel ID="pnlSanPham14" runat="server" Height="" Width="" RefreshComplete="RefreshComplete" OnContentRefresh="pnlSanPham14_ContentRefresh">
                                    <asp:Table id="tblSanPham14" runat="server" Width="100%" BorderStyle="none" CellSpacing="0" CellPadding="0"></asp:Table>
                            </igmisc:WebAsyncRefreshPanel>
                            </td>
                          </tr>
                        </table></td>
                      </tr>
                    </table></td>
                  </tr>
                </table></td>
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

