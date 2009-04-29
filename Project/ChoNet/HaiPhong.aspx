<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="HaiPhong.aspx.cs" Inherits="_HaiPhong" Title="Hải Phòng" %>
<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %> 
<%@ MasterType virtualpath="~/Default.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
<script src="Scripts/Common.js" type="text/javascript"></script>
<script id="igClientScript" type="text/javascript">
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
                    </table></td>
                    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td><table width="100%" border="0" cellspacing="4" cellpadding="0">
                          <tr>
                            <td align="left" valign="top" width="596">
							<table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td>
                                    <span id="spnQuangCao02" runat="server"></span>
                                </td>
                              </tr>
                              <tr>
                                <td style="padding-top:4px;">
                                    <asp:Table id="tblSanPham02" runat="server" Width="100%" BorderStyle="none" CellSpacing="0" CellPadding="0"></asp:Table>
                                </td>
                              </tr>
                            </table></td>
                            <td align="left" valign="top">
							<table width="100%" border="0" class="box3" cellspacing="0" cellpadding="0">
                              <tr>
                                <td class="box3_name1">&nbsp;</td>
                              </tr>
                              <tr>
                                <td class="box3_bor">
								<marquee style="height:300px;" onmouseover="stop()" onmouseout="start()" direction="up" scrollamount="5">
								    <asp:Table id="tblSanPham01" runat="server" Width="100%" BorderStyle="none" CellSpacing="5" CellPadding="0"></asp:Table>
								</marquee></td>
                              </tr>
                              <tr>
                                <td class="box3_name2">&nbsp;</td>
                              </tr>
                            </table>
							</td>
                          </tr>
                        </table></td>
                      </tr>
                      <tr>
                        <td align="left" valign="top" style="padding:4px;">
						<table width="100%" border="0" class="box4" cellspacing="0" cellpadding="0">
                          <tr>
                            <td class="box4_name">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td><span class="textxanh">Sản phẩm</span> <span class="textcam">được ưa chuộng</span></td>
                                        <td style="text-align:right;"><a href="promotion.aspx?pcode=uc">[Xem tất cả]</a>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                          </tr>
                          <tr>
                            <td class="box4_bor">
                                <asp:Table id="tblSanPham03" runat="server" Width="100%" BorderStyle="none" CellSpacing="0" CellPadding="0"></asp:Table>
                            </td>
                          </tr>
                        </table></td>
                      </tr>
                    </table></td>
                  </tr>
                </table></td>
              </tr>
        <tr>
                <td><table id="tblQuangCao03" runat="server" width="100%" border="0" cellspacing="4" cellpadding="0">
                  <tr>
                    <td width="33%" align="left">
                        <span id="spnQuangCao03a" runat="server"></span></td>
                    <td width="33%" align="center">
                        <span id="spnQuangCao03b" runat="server"></span></td>
                    <td width="33%" align="right">
                        <span id="spnQuangCao03c" runat="server"></span></td>
                  </tr>
                </table></td>
              </tr>
        <tr>
                <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="230" align="left" valign="top" >
                    <asp:Table ID="tblQuangCao04" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0"></asp:Table>
                    </td>
                    <td align="left" valign="top" style="padding:4px;">
                    <igmisc:WebAsyncRefreshPanel ID="pnlSanPham04" runat="server" Height=""
                                Width="100%" OnContentRefresh="pnlSanPham04_ContentRefresh">  
                    <input type="hidden" id="hidCatId" runat="server" />                  
                    <table width="100%" border="0" class="box6" cellspacing="0" cellpadding="0">
                      <tr>
                        <td class="box6_name">
                            <asp:Table ID="tblDanhMuc04" CssClass="tab" runat="server" CellPadding="0" CellSpacing="0" BorderStyle="none" Width="100%"></asp:Table>
                        </td>
                      </tr>
                      <tr>
                        <td class="box6_bor">    
                            <asp:Table ID="tblSanPham04" CssClass="tab" runat="server" CellPadding="0" CellSpacing="0" BorderStyle="none" Width="100%"></asp:Table>
                       </td>
                      </tr>
                    </table>
                    </igmisc:WebAsyncRefreshPanel>
                    </td>
                  </tr>
                </table></td>
              </tr>
        <tr>
                <td><table id="tblQuangCao05" runat="server" width="100%" border="0" cellspacing="4" cellpadding="0">
                   <tr>
                    <td width="33%" align="left">
                        <span id="spnQuangCao05a" runat="server"></span></td>
                    <td width="33%" align="center">
                        <span id="spnQuangCao05b" runat="server"></span></td>
                    <td width="33%" align="right">
                        <span id="spnQuangCao05c" runat="server"></span></td>
                  </tr>
                </table></td>
              </tr>
        <tr>
                <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="230" valign="top">
                    <asp:Table ID="tblQuangCao06" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0"></asp:Table>
                    </td>
                    <td valign="top"><table width="100%" border="0" cellspacing="4" cellpadding="0">
                      <tr>
                        <td><table width="100%" border="0" class="box4" cellspacing="0" cellpadding="0">
                          <tr>
                            <td class="box4_name">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td><span class="textxanh">Sản phẩm</span> <span class="textcam">giảm giá</span></td>
                                        <td style="text-align:right;"><a href="promotion.aspx?pcode=gg">[Xem tất cả]</a>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                          </tr>
                          <tr>
                            <td class="box4_bor">
                                <asp:Table id="tblSanPham05" runat="server" Width="100%" BorderStyle="none" CellSpacing="0" CellPadding="0"></asp:Table>
                            </td>
                          </tr>
                        </table></td>
                      </tr>
                      <tr>
                        <td><table width="100%" border="0" class="box4" cellspacing="0" cellpadding="0">
                          <tr>
                            <td class="box4_name">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td><span class="textxanh">Sản phẩm</span> <span class="textcam">Khuyến mại</span></td>
                                        <td style="text-align:right;"><a href="promotion.aspx?pcode=km">[Xem tất cả]</a>&nbsp;</td>
                                    </tr>
                                </table>
                             </td>
                          </tr>
                          <tr>
                            <td class="box4_bor">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td align="left" valign="top">
                                    <asp:Table id="tblSanPham06" runat="server" Width="100%" BorderStyle="none" CellSpacing="0" CellPadding="0"></asp:Table>
                                </td>
                                <td align="right" valign="top"><table class="khuyenmai" width="95%" border="0" cellspacing="0" cellpadding="0">
                                  <tr>
                                    <td class="tit_khuyenmai">Khuyến mãi sắp hết hạn </td>
                                  </tr>
                                </table>
                                <asp:Table id="tblSanPham06b" CssClass="khuyenmai" runat="server" Width="95%" BorderStyle="none" CellSpacing="0" CellPadding="0"></asp:Table>
                                </td>
                              </tr>
                            </table></td>
                          </tr>
                        </table></td>
                      </tr>
                      <tr>
                        <td><table width="100%" border="0" class="box4" cellspacing="0" cellpadding="0">
                          <tr>
                            <td class="box4_name"><span class="textxanh">Sản phẩm</span> <span class="textcam">mới cập nhật</span></td>
                          </tr>
                          <tr>
                            <td class="box4_bor">
                                <asp:Table id="tblSanPham07" runat="server" Width="100%" BorderStyle="none" CellSpacing="0" CellPadding="0"></asp:Table>
                            </td>
                          </tr>
                        </table></td>
                      </tr>
                    </table></td>
                  </tr>
                </table></td>
              </tr>
        <tr>
                <td><table class="box4"  width="100%" border="0" cellspacing="4" cellpadding="0">
                  <tr>
                    <td class="box4_bor"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="80" align="left" valign="top"><img src="images/goctt.jpg" width="80" height="80" /></td>
                        <td rowspan="3" align="center" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td align="center"><img src="images/texttt.jpg" width="288" height="34" /></td>
                          </tr>
                          <tr>
                            <td><asp:Table ID="tblGianHang" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0"></asp:Table></td>
                          </tr>
                          <tr>
                            <td height="34">&nbsp;</td>
                          </tr>
                        </table></td>
                        <td width="80" align="right" valign="top"><img src="images/gocpt.jpg" width="80" height="80" /></td>
                      </tr>
                      <tr>
                        <td>&nbsp;</td>
                        <td align="right" valign="top">&nbsp;</td>
                      </tr>
                      <tr>
                        <td width="80" align="left" valign="bottom"><img src="images/goctd.jpg" width="80" height="80" /></td>
                        <td width="80" align="right" valign="bottom"><img src="images/gocpd.jpg" width="80" height="80" /></td>
                      </tr>
                    </table></td>
                  </tr>
                </table></td>
              </tr>
        <tr>
                <td><table id="tblQuangCao07" runat="server" width="100%" border="0" cellspacing="4" cellpadding="0">
                 <tr>
                    <td width="33%" align="left">
                        <span id="spnQuangCao07a" runat="server"></span></td>
                    <td width="33%" align="center">
                        <span id="spnQuangCao07b" runat="server"></span></td>
                    <td width="33%" align="right">
                        <span id="spnQuangCao07c" runat="server"></span></td>
                  </tr>
                </table></td>
              </tr>
    </table>
</asp:Content>

