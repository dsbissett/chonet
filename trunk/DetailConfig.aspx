<%@ Page Language="C#" MasterPageFile="~/Adm/Admin.master" AutoEventWireup="true" CodeFile="DetailConfig.aspx.cs" Inherits="Adm_DetailConfig" Title="Chi tiết sản phẩm" %>
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

function RefreshAdv(aid)
{
    var warp;
    switch(aid)
    {
        case 41: warp = ig$('<%=pnlQuangCao41.ClientID %>'); 
        break;
        case 42: warp = ig$('<%=pnlQuangCao42.ClientID %>'); 
        break;
    }
    
	if(!warp) return;
	    warp.refresh();		
}

function ChangeAdv(aid)
{
    OpenDialogWindow('Thay đổi quảng cáo',680,420,'page','SelectAdv.aspx?aid=' + aid);
}
function RefreshStoreInfo()
{
    var warp = ig$('<%=pnlHoTro.ClientID %>'); 
    if(!warp) return;
	warp.refresh();		
}
function RefreshComplete(oPanel){
	CloseDialogWindow();
}

function EditShopInfo()
{
    OpenDialogWindow('Thay đổi thông tin cửa hàng',560,620,'page','UpdateStore.aspx?sid=<%=CuaHangID.ToString()%>');
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
                <td class="bgbanner"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="21%" align="left" class="blured"><a><img src="../images/logo.jpg" width="208" height="100" border="0" /></a></td>
                    <td width="23%" align="left">
                    <div onclick="ChangeAdv(41);" style="cursor:hand;">
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td><img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                <td class="red-button">Thay đổi quảng cáo 41</td>
                            </tr>
                        </table>  
                   </div>
                   <igmisc:webasyncrefreshpanel id="pnlQuangCao41" runat="server" height="" width="100%" OnContentRefresh="pnlQuangCao41_ContentRefresh" RefreshComplete="RefreshComplete">
                        <span id="spnQuangCao41" runat="server"></span>
                    </igmisc:webasyncrefreshpanel>
                    </td>
                    <td width="56%" align="left" valign="top" class="blured">
					  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                          <td height="50" align="right" valign="top" style="padding-left:20px; padding-right:10px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td width="2%"><img src="../images/menultop.jpg" width="14" height="31" /></td>
                              <td width="95%" background="../images/menuctop.jpg"><table class="topmenu" width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                  <td><a>E-STORE</a></td>
                                  <td><a>Đăng tin </a></td>
                                  <td><a>Diễn đàn </a></td>
								  <td><a>Giúp đỡ </a></td>
                                </tr>
                              </table></td>
                              <td width="3%"><img src="../images/menurtop.jpg" width="14" height="31" /></td>
                            </tr>
                          </table></td>
                        </tr>
                        <tr>
                          <td><table width="100%" border="0" class="cart menu" cellspacing="2" cellpadding="2">
                            <tr>
                              <td width="64%" align="left" class="linkdacbiet" style="padding-top:6px;">Bạn hãy <a>Đăng nhập</a> hoặc <a>Đăng ký</a> thành viên, gian hàng </td>
                              <td width="8%" align="left"><img src="../images/cart.jpg" width="36" height="36" /></td>
                              <td width="28%" align="left"><b><a>Giỏ hàng của bạn</a></b><br />
                                (Chưa có sản phẩm nào) </td>
                            </tr>
                          </table></td>
                        </tr>
                      </table></td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td valign="bottom" class="bgtopmenu" style="-moz-opacity:20; filter:alpha(opacity:20);opacity:20;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="2%"><img src="../images/bgtopmenu1.jpg" width="20" height="35" /></td>
                    <td width="96%" valign="bottom"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td><table class="menu" width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td width="21%"><table class="butactive" width="100" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td class="but_act_left">&nbsp;</td>
                                <td class="but_act_right"><a>Trang chủ </a></td>
                              </tr>
                            </table></td>
                            <td valign="bottom" class="but"><table width="100%" class="button_nor" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td class="butnor">&nbsp;</td>
                                <td class="butnor">&nbsp;</td>
                                <td class="butnor">&nbsp;</td>
                              </tr>
                            </table></td>
                            </tr>
                        </table></td>
                        <td width="50%">&nbsp;</td>
                      </tr>
                    </table></td>
                    <td width="2%" align="right"><img src="../images/bgtopmenu2.jpg" width="20" height="35" /></td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td height="35" align="left" background="../images/bgsearch.jpg" class="blured"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="19"><img src="../images/bgsearch1.jpg" width="19" height="35" /></td>
                    <td><table class="search" border="0" cellspacing="2" cellpadding="0">
                      <tr>
                        <td width="64" class="text_sear">Tìm kiếm </td>
                        <td width="144"><input class="field" type="text" name="textfield" disabled="disabled" /></td>
                        <td width="131"><label>
                          <select name="select" class="field" disabled="disabled">
                            <option>Nhóm sản phẩm</option>
                          </select>
                        </label></td>
                        <td width="73"><input type="submit" class="button" name="Submit" value="Tìm kiếm" disabled="disabled" /></td>
                      </tr>
                    </table></td>
                    <td width="19"><img src="../images/bgsearch2.jpg" width="19" height="35" /></td>
                  </tr>
                </table>				</td>
              </tr>
			  <tr>
			    <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="2%"><img src="../images/bot1.jpg" width="20" height="23" /></td>
                    <td width="96%" background="../images/bot.jpg">&nbsp;</td>
                    <td width="2%"><img src="../images/bot2.jpg" width="20" height="23" /></td>
                  </tr>
                </table></td>
			  </tr>
              <tr>
                <td height="25" align="left">
                    <div onclick="ChangeAdv(42);" style="cursor:hand;">
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td><img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                <td class="red-button">Thay đổi quảng cáo 42</td>
                            </tr>
                        </table>  
                   </div>
                   <igmisc:webasyncrefreshpanel id="pnlQuangCao42" runat="server" height="" width="100%" OnContentRefresh="pnlQuangCao42_ContentRefresh" RefreshComplete="RefreshComplete">
                <table width="100%" border="0" cellspacing="4" cellpadding="0">
                  <tr>
                    <td width="33%" align="left">
                        <span id="spnQuangCao42a" runat="server"></span></td>
                    <td width="33%" align="center">
                        <span id="spnQuangCao42b" runat="server"></span></td>
                    <td width="33%" align="right">
                        <span id="spnQuangCao42c" runat="server"></span></td>
                  </tr>
                </table>
                </igmisc:webasyncrefreshpanel>
                </td>
              </tr>
              <tr>
                <td height="25" align="left" class="blured"><table class="box4" width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td class="box4_name textxanh" style="border-bottom:#CCCCCC 1px solid">NOKIA N90 </td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td height="25" align="left" style="padding-left:20px;" class="blured"><b><a class="pathway">Trang chủ</a></b> &gt; <b>
				<a class="pathway">Điện tử điện lạnh </a></b> > <b><a class="pathway">Máy ảnh kỹ thuật số</a></b></td>
              </tr>
              <tr>
                <td><table width="100%" border="0" cellspacing="6" cellpadding="0">
                  <tr>
                    <td width="31%" align="left" valign="top" class="blured"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td><img src="../images/sp5.jpg" width="323" height="316" hspace="5" vspace="5" style="border:#CCCCCC 1px solid" /></td>
                      </tr>
                      <tr>
                        <td><a><img src="../images/sp6.jpg" width="40" height="29" hspace="5" vspace="5" border="0" style="border:#66FF33 2px solid" /></a><a><img src="../images/sp6.jpg" width="40" height="29" hspace="5" vspace="5" border="0" style="border:#66FF33 2px solid" /></a><a><img src="../images/sp6.jpg" width="40" height="29" hspace="5" vspace="5" border="0" style="border:#66FF33 2px solid" /></a><a><img src="../images/sp6.jpg" width="40" height="29" hspace="5" vspace="5" border="0" style="border:#66FF33 2px solid" /></a><br />
                            <a><img src="../images/sp6.jpg" width="40" height="29" hspace="5" vspace="5" border="0" style="border:#66FF33 2px solid" /></a><a><img src="../images/sp6.jpg" width="40" height="29" hspace="5" vspace="5" border="0" style="border:#66FF33 2px solid" /></a><a><img src="../images/sp6.jpg" width="40" height="29" hspace="5" vspace="5" border="0" style="border:#66FF33 2px solid" /></a></td>
                      </tr>
                    </table></td>
                    <td width="47%" align="left" valign="top" class="blured"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                          <td height="20" align="left"><strong>Mã số sản phẩm : </strong><span class="textcam">125486311 </span> </td>
                        </tr>
                        <tr>
                          <td height="20" align="left"><strong>Giá bán: <span class="textcam">4.500.000 VNĐ</span> </strong></td>
                        </tr>
                        <tr>
                          <td height="20" align="left" style="line-height:18px;"><div align="justify">- Với màn hình  cực rộng 3.2'', độ phân giải 262K màu, ăngten thế hệ mới dài gần 35cm,  được cắm ngầm sau thân máy. Giúp S539 bắt được 15 kênh truyền hình khác  nhau như VTV1, VTV2, VTV3, VTC1, VTC5, HTV. Với độ phân giải rất cao,  S539 đang làm hài lòng tất cả những ai có nhu cầu xem những chương  trình Tivi mình ưa thích khi phải đi công tác, hoặc trên đường đi làm.  Thiết kế đẹp với giao diện được chau chuốt từng đường nét như chiếc  Iphone đình đám. Và hơn nữa đã được Việt hoá giúp cho những người lần  đầu tiên tiếp xúc với thiết bị công nghệ cao sẽ dễ dàng sử dụng sau một  vài ngày làm quen.</div></td>
                        </tr>
                        <tr>
                          <td height="40" align="left"><input type="submit" class="button" name="Submit2" value="Thêm vào giỏ hàng" disabled="disabled" /></td>
                        </tr>
                        <tr>
                          <td height="40" align="left"><table width="100" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td align="center"><a><img src="../images/cn1.jpg" width="96" height="34" hspace="10" vspace="10" border="0" /></a></td>
                              <td align="center"><a><img src="../images/CN3.jpg" width="96" height="34" hspace="10" vspace="10" border="0" /></a></td>
                              <td align="center"><a><img src="../images/CN4.jpg" width="96" height="34" hspace="10" vspace="10" border="0" /></a></td>
                            </tr>
                          </table></td>
                        </tr>
                      </table></td>
                    <td width="22%" align="left" valign="top">
                    <div onclick="EditShopInfo();" style="cursor:hand;">
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td><img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                <td class="red-button">Thay đổi thông tin hỗ trợ</td>
                            </tr>
                        </table>  
                   </div>
                   <igmisc:webasyncrefreshpanel id="pnlHoTro" runat="server" height="" width="100%" OnContentRefresh="pnlHoTro_ContentRefresh" RefreshComplete="RefreshComplete">
                    <table width="100%" border="0" class="box5" cellspacing="0" cellpadding="0">
                      <tr>
                        <td class="box5_name textxanh">NHÀ CUNG CẤP </td>
                      </tr>
                      <tr>
                        <td align="center" class="box5_bor"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td align="center"><img src="../images/chat.jpg" width="167" height="79" /></td>
                          </tr>
                          <tr>
                            <td align="left" class="price" style="padding:5px;">Thông tin nhà cung cấp : </td>
                          </tr>
                          <tr>
                            <td align="left" style="padding:5px;"><strong>
                                <asp:Label ID="lblTenCuaHang" runat="server"></asp:Label></strong> </td>
                          </tr>
                          <tr>
                            <td align="left" style="padding:5px;">Điện thoại : <strong>
                                <asp:Label ID="lblCoDinh" runat="server"></asp:Label>
                            </strong></td>
                          </tr>
                          <tr>
                            <td align="left" style="padding:5px;">Mobile : <strong>
                                <asp:Label ID="lblDiDong" runat="server"></asp:Label>
                            </strong></td>
                          </tr>
                          <tr>
                            <td align="center" style="padding:5px;"><input type="submit" class="button" name="Submit22" value="Ghé thăm gian hàng" disabled="disabled" /></td>
                          </tr>
                        </table></td>
                      </tr>
                    </table>
                    </igmisc:webasyncrefreshpanel>
                    </td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td class="blured"><table width="100%" border="0" class="box6" cellspacing="0" cellpadding="0">
                  <tr>
                    <td align="left" class="box6_name"><table class="tab" width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                          <td width="27%" class="tab_noactive"><a>Thông tin sản phẩm </a> </td>
                          <td width="23%" valign="bottom"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td width="12"><img src="../images/left_tab.jpg" width="12" height="27" /></td>
                                <td class="tab_active">Hỏi đáp </td>
                                <td width="12"><img src="../images/right_tab.jpg" width="12" height="27" /></td>
                              </tr>
                          </table></td>
                          <td width="26%" class="tab_noactive"><a>Nhận xét sản phẩm </a></td>
                          <td width="24%" class="tab_noactive">&nbsp;</td>
                        </tr>
                    </table></td>
                  </tr>
                  <tr>
                    <td class="box6_bor"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td height="20" align="left" bgcolor="#F7F7F7">Mạng </td>
                        <td height="20" align="left" bgcolor="#F7F7F7">GSM 850 / GSM 900 / GSM 1800 / GSM 190</td>
                      </tr>
                      <tr>
                        <td height="20" align="left">Ra mắt</td>
                        <td height="20" align="left">Quý 4 năm 2007</td>
                      </tr>
					  <tr>
                        <td height="20" align="left" bgcolor="#F7F7F7">Mạng </td>
                        <td height="20" align="left" bgcolor="#F7F7F7">GSM 850 / GSM 900 / GSM 1800 / GSM 190</td>
                      </tr>
                      <tr>
                        <td height="20" align="left">Ra mắt</td>
                        <td height="20" align="left">Quý 4 năm 2007</td>
                      </tr>
					  <tr>
                        <td height="20" align="left" bgcolor="#F7F7F7">Mạng </td>
                        <td height="20" align="left" bgcolor="#F7F7F7">GSM 850 / GSM 900 / GSM 1800 / GSM 190</td>
                      </tr>
                      <tr>
                        <td height="20" align="left">Ra mắt</td>
                        <td height="20" align="left">Quý 4 năm 2007</td>
                      </tr>
                    </table></td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td>&nbsp;</td>
              </tr>              
              <tr>
                <td class="blured"><table width="100%" border="0" cellspacing="4" cellpadding="0">
                  <tr>
                    <td height="25" align="center" bgcolor="#398e33" class="footer">
					Bản quyền thuộc Chonet.vn - Phiên bản đang hoạt động thử nghiệm theo giấy phép của BVHTT </td>
                  </tr>
                </table></td>
              </tr>
            </table>
			</td>
		  </tr>
		</table>
	</td>
  </tr>
</table>
</asp:Content>

