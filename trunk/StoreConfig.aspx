<%@ Page Language="C#" MasterPageFile="~/Adm/Admin.master" AutoEventWireup="true" CodeFile="StoreConfig.aspx.cs" Inherits="Adm_StoreConfig" Title="Gian hàng" %>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
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

loadjscssfile("../css/style.css", "css") ////dynamically load and add this .css file

function RefreshAdv(aid)
{
    var warp;
    switch(aid)
    {
        case 51: warp = ig$('<%=pnlQuangCao51.ClientID %>'); 
        break;
        case 52: warp = ig$('<%=pnlQuangCao52.ClientID %>'); 
        break;
        case 53: warp = ig$('<%=pnlQuangCao53.ClientID %>'); 
        break;
        case 54: warp = ig$('<%=pnlQuangCao54.ClientID %>'); 
        break;
    }
    
	if(!warp) return;
	    warp.refresh();		
}
function RefreshStoreInfo()
{
    var warp1 = ig$('<%=pnlThongTin.ClientID%>'); 
    if(!warp1) return;
	warp1.refresh();
	var warp2 = ig$('<%=pnlHoTro.ClientID%>'); 
    if(!warp2) return;
	warp2.refresh();		
}

function RefreshComplete(oPanel){
	CloseDialogWindow();
}
function ChangeAdv(aid)
{
    OpenDialogWindow('Thay đổi quảng cáo',680,420,'page','SelectAdv.aspx?aid=' + aid);
}

function EditShopInfo()
{
    OpenDialogWindow('Thay đổi thông tin cửa hàng',560,620,'page','UpdateStore.aspx?sid=<%=CuaHangID.ToString()%>');
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
function AddHTTT(){                              
        OpenDialogWindow('Thêm hỗ trợ',340,280,'page','AddSupporter.aspx?sid=<%=CuaHangID.ToString()%>');    
}
function EditHTTT(id){                              
        OpenDialogWindow('Sửa thông tin hỗ trợ',340,280,'page','AddSupporter.aspx?sid=<%=CuaHangID.ToString()%>&hid=' + id);    
}
function DeleteHTTT(id){                      
        OpenDialogWindow('Xóa hỗ trợ',350,170,'page','Delete.aspx?id=' + id + '&type=hotrotructuyen');    
}
function Add(){                              
        OpenDialogWindow('Thêm danh mục cha',680,420,'page','SelectStoreCat.aspx?sid=<%=CuaHangID.ToString()%>&did=0');    
}
function AddSub(id){                              
        OpenDialogWindow('Thêm danh mục con',680,420,'page','SelectStoreCat.aspx?sid=<%=CuaHangID.ToString()%>&did=' + id);    
}

function Delete(id){                      
        OpenDialogWindow('Xóa danh mục',350,170,'page','Delete.aspx?id=' + id + '&sid=<%=CuaHangID.ToString() %>&type=cuahangnhomsanpham');    
}
function Refresh()
{  	var warp = ig$('<%=pnlDanhMuc.ClientID%>');
	if(!warp)
		return;
	warp.refresh();	
	var warp2 = ig$('<%=pnlHoTro.ClientID%>'); 
    if(!warp2) return;
	warp2.refresh();	
}
// -->
</script>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="center" valign="top" style="width: 1338px">
		<table width="940" border="0" cellspacing="0" cellpadding="0">
		  <tr>
			<td width="940">
			<table class="form" width="94%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td class="bgbanner"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="22%" align="left" class="blured"><a><img src="../images/logo.jpg" width="208" height="100" border="0" /></a></td>
                    <td width="47%" align="center"><igmisc:webasyncrefreshpanel id="pnlThongTin" runat="server" height="" width="100%" OnContentRefresh="pnlThongTin_ContentRefresh" RefreshComplete="RefreshComplete">
                        <div onclick="EditShopInfo();" style="cursor:hand;">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td><img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                    <td class="red-button">Thay đổi thông tin cửa hàng</td>
                                </tr>
                            </table>  
                       </div>   
                        <asp:Label ID="lblTenCuaHang" CssClass="chuto" runat="server"></asp:Label></igmisc:webasyncrefreshpanel></td>
                    <td width="7%" align="center" class="chuto">&nbsp;</td>
                    <td width="21%" align="center" valign="top" class="blured"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="2%"><img src="../images/menultop.jpg" width="14" height="31" /></td>
                        <td width="95%" background="../images/menuctop.jpg"><table class="topmenu" width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td><a>Đăng ký </a></td>
                              <td><a>Đăng nhập </a></td>
                              </tr>
                        </table></td>
                        <td width="3%"><img src="../images/menurtop.jpg" width="14" height="31" /></td>
                      </tr>
                    </table></td>
                    <td width="3%" align="center" valign="top">&nbsp;</td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td height="35" align="left"><table width="94%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="156">
                        <div onclick="ChangeAdv(51);" style="cursor:hand;">                      
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td><img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                    <td class="red-button">Thay đổi quảng cáo 51</td>
                                </tr>
                            </table>  
                       </div>
                       <igmisc:webasyncrefreshpanel id="pnlQuangCao51" runat="server" height="" width="100%" OnContentRefresh="pnlQuangCao51_ContentRefresh" RefreshComplete="RefreshComplete">
                       <span id="spnQuangCao51" runat="server"></span>
                       </igmisc:webasyncrefreshpanel>
                       </td>
                        <td width="628" >
                        <div onclick="ChangeAdv(52);" style="cursor:hand;">                      
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td><img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                    <td class="red-button">Thay đổi quảng cáo 52</td>
                                </tr>
                            </table>  
                       </div>
                       <igmisc:webasyncrefreshpanel id="pnlQuangCao52" runat="server" height="" width="100%" OnContentRefresh="pnlQuangCao52_ContentRefresh" RefreshComplete="RefreshComplete">
                    <span id="spnQuangCao52" runat="server"></span>
                    </igmisc:webasyncrefreshpanel>
                    </td>
                    <td width="156">
                        <div onclick="ChangeAdv(53);" style="cursor:hand;">                      
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td><img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                    <td class="red-button">Thay đổi quảng cáo 53</td>
                                </tr>
                            </table>  
                       </div>
                       <igmisc:webasyncrefreshpanel id="pnlQuangCao53" runat="server" height="" width="100%" OnContentRefresh="pnlQuangCao53_ContentRefresh" RefreshComplete="RefreshComplete">
                            <span id="spnQuangCao53" runat="server"></span>
                        </igmisc:webasyncrefreshpanel>
                    </td>
                  </tr>
                </table></td>
              </tr>
			  <tr>
			    <td>&nbsp;</td>
			  </tr>
              <tr>
                <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="230" align="left" valign="top">
					<table width="100%" border="0" cellspacing="4" cellpadding="0">

					  <tr>
					    <td class="blured"><table class="box1" width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td class="box1_name"><span class="textxanh">Danh mục chính </span><span class="textcam"></span></td>
                          </tr>
                          <tr>
                            <td class="box1_bor"><table width="100%" class="listcat" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td><a>Trang chủ E-Store </a></td>
                              </tr>

                              <tr>
                                <td><a>Sản phẩm khuyến mãi </a></td>
                              </tr>
                              <tr>
                                <td><a>Thông tin doanh nghiệp </a></td>
                              </tr>
                              <tr>
                                <td><a>Liên hệ </a></td>
                              </tr>
                            </table></td>
                          </tr>
                        </table></td>
					    </tr>
					  <tr>
						<td>
						 <igmisc:WebAsyncRefreshPanel  ID="pnlDanhMuc" runat="server" Width="100%" Height="100%" RefreshComplete="RefreshComplete" OnContentRefresh="pnlDanhMuc_ContentRefresh">
						<table class="box2" width="100%" border="0" cellspacing="0" cellpadding="0">
						  <tr>
							<td class="box2_name" style="height: 26px">Danh mục sản phẩm </td>
							<td  class="box2_name" style="cursor:hand" onclick="Add();"><img src="../Images/Add.gif" alt="Thêm danh mục cha" /></td>
						  </tr>
						  <tr>
							<td class="box2_bor" colspan="2">
							<table width="100%" border="0" cellspacing="0" cellpadding="0" id="tblDanhMuc" runat="server">
                              
                            </table></td>
						  </tr>
						</table>						                            
                            </igmisc:WebAsyncRefreshPanel>
						</td>
					  </tr>
					  <tr>
					    <td>
					    <div onclick="ChangeStore(51);" style="cursor:hand;">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td><img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                    <td class="red-button">Thay đổi gian hàng 51</td>
                                </tr>
                            </table>  
                       </div>   
					    <table class="box1" width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td class="box1_name"><span class="textxanh">Liên kết E-Store</span></td>
                          </tr>
                          <tr>
                            <td class="box1_bor" style="text-align:center;">
                             <igmisc:webasyncrefreshpanel ID="pnlGianHang" runat="server" Height="" OnContentRefresh="pnlGianHang_ContentRefresh"
                               Width="" RefreshComplete="RefreshComplete">
                            <asp:Table ID="tblGianHang" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0"></asp:Table>
                            </igmisc:webasyncrefreshpanel>  
                            </td>
                          </tr>
                        </table></td>
					    </tr>
					  
                    </table></td>
                    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td align="left" valign="top" style="padding:4px;">
                            <div onclick="ChangeAdv(54);" style="cursor:hand;">                      
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td><img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                        <td class="red-button">Thay đổi quảng cáo 54</td>
                                    </tr>
                                </table>  
                            </div>
                            <igmisc:webasyncrefreshpanel id="pnlQuangCao54" runat="server" height="" width="100%" OnContentRefresh="pnlQuangCao54_ContentRefresh" RefreshComplete="RefreshComplete">
                        <span id="spnQuangCao54" runat="server"></span>
                        </igmisc:webasyncrefreshpanel>
                        </td>
                      </tr>
                      <tr>
                        <td align="left" valign="top" style="padding:4px;" class="blured"><table width="100%" border="0" class="box4" cellspacing="0" cellpadding="0">
                          <tr>
                            <td class="box4_name"><span class="textxanh">Gian hàng </span> <span class="textcam">giới thiệu </span></td>
                          </tr>
                          <tr>
                            <td class="box4_bor"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                  <td align="left" valign="top"><table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                    <tr>
                                      <td align="center"><a><img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border:#CCCCCC 1px solid" /></a></td>
                                    </tr>
                                    <tr>
                                      <td align="center"><a>Logitech Z5400</a><br />
                                        Giá: <span class="price">1.450.000</span> VNĐ </td>
                                    </tr>
                                  </table></td>
                                  <td align="left" valign="top"><table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                    <tr>
                                      <td align="center"><a><img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border:#CCCCCC 1px solid" /></a></td>
                                    </tr>
                                    <tr>
                                      <td align="center"><a>Logitech Z5400</a><br />
                                        Giá: <span class="price">1.450.000</span> VNĐ </td>
                                    </tr>
                                  </table></td>
                                  <td align="left" valign="top"><table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                    <tr>
                                      <td align="center"><a><img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border:#CCCCCC 1px solid" /></a></td>
                                    </tr>
                                    <tr>
                                      <td align="center"><a>Logitech Z5400</a><br />
                                        Giá: <span class="price">1.450.000</span> VNĐ </td>
                                    </tr>
                                  </table></td>
                                </tr>
                                <tr>
                                  <td align="left" valign="top"><table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                    <tr>
                                      <td align="center"><a><img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border:#CCCCCC 1px solid" /></a></td>
                                    </tr>
                                    <tr>
                                      <td align="center"><a>Logitech Z5400</a><br />
                                        Giá: <span class="price">1.450.000</span> VNĐ </td>
                                    </tr>
                                  </table></td>
                                  <td align="left" valign="top"><table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                    <tr>
                                      <td align="center"><a><img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border:#CCCCCC 1px solid" /></a></td>
                                    </tr>
                                    <tr>
                                      <td align="center"><a>Logitech Z5400</a><br />
                                        Giá: <span class="price">1.450.000</span> VNĐ </td>
                                    </tr>
                                  </table></td>
                                  <td align="left" valign="top"><table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                    <tr>
                                      <td align="center"><a><img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border:#CCCCCC 1px solid" /></a></td>
                                    </tr>
                                    <tr>
                                      <td align="center"><a>Logitech Z5400</a><br />
                                        Giá: <span class="price">1.450.000</span> VNĐ </td>
                                    </tr>
                                  </table></td>
                                </tr>
                                <tr>
                                  <td align="left" valign="top"><table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                    <tr>
                                      <td align="center"><a><img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border:#CCCCCC 1px solid" /></a></td>
                                    </tr>
                                    <tr>
                                      <td align="center"><a>Logitech Z5400</a><br />
                                        Giá: <span class="price">1.450.000</span> VNĐ </td>
                                    </tr>
                                  </table></td>
                                  <td align="left" valign="top"><table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                    <tr>
                                      <td align="center"><a><img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border:#CCCCCC 1px solid" /></a></td>
                                    </tr>
                                    <tr>
                                      <td align="center"><a>Logitech Z5400</a><br />
                                        Giá: <span class="price">1.450.000</span> VNĐ </td>
                                    </tr>
                                  </table></td>
                                  <td align="left" valign="top"><table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                    <tr>
                                      <td align="center"><a><img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border:#CCCCCC 1px solid" /></a></td>
                                    </tr>
                                    <tr>
                                      <td align="center"><a>Logitech Z5400</a><br />
                                        Giá: <span class="price">1.450.000</span> VNĐ </td>
                                    </tr>
                                  </table></td>
                                </tr>
                                <tr>
                                  <td align="left" valign="top"><table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                    <tr>
                                      <td align="center"><a><img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border:#CCCCCC 1px solid" /></a></td>
                                    </tr>
                                    <tr>
                                      <td align="center"><a>Logitech Z5400</a><br />
                                        Giá: <span class="price">1.450.000</span> VNĐ </td>
                                    </tr>
                                  </table></td>
                                  <td align="left" valign="top"><table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                    <tr>
                                      <td align="center"><a><img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border:#CCCCCC 1px solid" /></a></td>
                                    </tr>
                                    <tr>
                                      <td align="center"><a>Logitech Z5400</a><br />
                                        Giá: <span class="price">1.450.000</span> VNĐ </td>
                                    </tr>
                                  </table></td>
                                  <td align="left" valign="top"><table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                    <tr>
                                      <td align="center"><a><img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border:#CCCCCC 1px solid" /></a></td>
                                    </tr>
                                    <tr>
                                      <td align="center"><a>Logitech Z5400</a><br />
                                        Giá: <span class="price">1.450.000</span> VNĐ </td>
                                    </tr>
                                  </table></td>
                                </tr>
                                <tr>
                                  <td align="left" valign="top"><table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                    <tr>
                                      <td align="center"><a><img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border:#CCCCCC 1px solid" /></a></td>
                                    </tr>
                                    <tr>
                                      <td align="center"><a>Logitech Z5400</a><br />
                                        Giá: <span class="price">1.450.000</span> VNĐ </td>
                                    </tr>
                                  </table></td>
                                  <td align="left" valign="top"><table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                    <tr>
                                      <td align="center"><a><img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border:#CCCCCC 1px solid" /></a></td>
                                    </tr>
                                    <tr>
                                      <td align="center"><a>Logitech Z5400</a><br />
                                        Giá: <span class="price">1.450.000</span> VNĐ </td>
                                    </tr>
                                  </table></td>
                                  <td align="left" valign="top"><table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                    <tr>
                                      <td align="center"><a><img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border:#CCCCCC 1px solid" /></a></td>
                                    </tr>
                                    <tr>
                                      <td align="center"><a>Logitech Z5400</a><br />
                                        Giá: <span class="price">1.450.000</span> VNĐ </td>
                                    </tr>
                                  </table></td>
                                </tr>
                                <tr>
                            <td colspan="3"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td width="82%" align="left"><b>Trang [1] 2 3 4 5 6 7 ... &gt; &gt;&gt; </b></td>
                                <td width="18%"><table width="100%" border="0" cellspacing="4" cellpadding="0">
                                    <tr>
                                      <td width="82%" nowrap="nowrap"><strong>Đi tới trang </strong></td>
                                      <td width="18%"><select name="select5" style=" width:50px; font-size:11px;">
                                          <option>08</option>
                                      </select></td>
                                    </tr>
                                </table></td>
                              </tr>
                            </table></td>
                          </tr>
                            </table></td>
                          </tr>
                        </table></td>
                      </tr>
                    </table></td>
                    <td width="230" align="left" valign="top"><table width="100%" border="0" cellspacing="4" cellpadding="0">
                         <tr>
					    <td>
					    <div onclick="AddHTTT();" style="cursor:hand;">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td><img src="../Images/Add.gif" alt="Thay đổi" /></td>
                                    <td class="red-button">
                                        Thêm hỗ trợ trực tuyến</td>
                                </tr>
                            </table>  
                       </div>   
					    <igmisc:webasyncrefreshpanel id="pnlHoTro" runat="server" height="" width="100%" OnContentRefresh="pnlHoTro_ContentRefresh" RefreshComplete="RefreshComplete">
					    <table class="box1" width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td class="box1_name"><span class="textxanh">Hỗ trợ khách hàng </span><span class="textcam"></span></td>
                          </tr>
                          <tr>
                            <td class="box1_bor">                            
                            <span runat="server" id="spnHoTroTrucTuyen"></span></td>
                          </tr>
                        </table>
                        </igmisc:webasyncrefreshpanel>
                        </td>                                                     
					    </tr>
                      <tr>
                        <td class="blured"><table class="box1" width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td class="box1_name"><span class="textxanh">Sản phẩm xem nhiều nhất </span><span class="textcam"></span></td>
                          </tr>
                          <tr>
                            <td class="box1_bor"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td><table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                  <tr>
                                    <td align="center"><a> <img src="../images/sp1.jpg" alt="#" width="74" height="66" border="0" style="border:#CCCCCC 1px solid" /></a></td>
                                    <td align="left"><a>Logitech Z5400</a><br />
                                      Giá: <span class="price">1.450.000</span> VNĐ </td>
                                  </tr>
                                </table></td>
                              </tr>
                              <tr>
                                <td><table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                  <tr>
                                    <td align="center"><a> <img src="../images/sp1.jpg" alt="#" width="74" height="66" border="0" style="border:#CCCCCC 1px solid" /></a></td>
                                    <td align="left"><a>Logitech Z5400</a><br />
                                      Giá: <span class="price">1.450.000</span> VNĐ </td>
                                  </tr>
                                </table></td>
                              </tr>
                              <tr>
                                <td><table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                  <tr>
                                    <td align="center"><a> <img src="../images/sp1.jpg" alt="#" width="74" height="66" border="0" style="border:#CCCCCC 1px solid" /></a></td>
                                    <td align="left"><a>Logitech Z5400</a><br />
                                      Giá: <span class="price">1.450.000</span> VNĐ </td>
                                  </tr>
                                </table></td>
                              </tr>
                              <tr>
                                <td><table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                  <tr>
                                    <td align="center"><a> <img src="../images/sp1.jpg" alt="#" width="74" height="66" border="0" style="border:#CCCCCC 1px solid" /></a></td>
                                    <td align="left"><a>Logitech Z5400</a><br />
                                      Giá: <span class="price">1.450.000</span> VNĐ </td>
                                  </tr>
                                </table></td>
                              </tr>
                              <tr>
                                <td><table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                  <tr>
                                    <td align="center"><a> <img src="../images/sp1.jpg" alt="#" width="74" height="66" border="0" style="border:#CCCCCC 1px solid" /></a></td>
                                    <td align="left"><a>Logitech Z5400</a><br />
                                      Giá: <span class="price">1.450.000</span> VNĐ </td>
                                  </tr>
                                </table></td>
                              </tr>
                              <tr>
                                <td><table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                  <tr>
                                    <td align="center"><a> <img src="../images/sp1.jpg" alt="#" width="74" height="66" border="0" style="border:#CCCCCC 1px solid" /></a></td>
                                    <td align="left"><a>Logitech Z5400</a><br />
                                      Giá: <span class="price">1.450.000</span> VNĐ </td>
                                  </tr>
                                </table></td>
                              </tr>
                              <tr>
                                <td><table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                  <tr>
                                    <td align="center"><a> <img src="../images/sp1.jpg" alt="#" width="74" height="66" border="0" style="border:#CCCCCC 1px solid" /></a></td>
                                    <td align="left"><a>Logitech Z5400</a><br />
                                      Giá: <span class="price">1.450.000</span> VNĐ </td>
                                  </tr>
                                </table></td>
                              </tr>
                            </table></td>
                          </tr>
                        </table></td>
                      </tr>
                    </table></td>
                  </tr>
                </table></td>
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

