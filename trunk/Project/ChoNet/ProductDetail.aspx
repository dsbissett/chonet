<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs"
    Inherits="ProductDetail" Title="Chi tiết sản phẩm" EnableEventValidation="false"  %>
<%@ Register Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>
<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<%@ OutputCache Duration="30" Location="Client" VaryByParam="id" %> 
   
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table width="985px" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="center" valign="top">
                <table width="985px" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table class="form" width="100%" border="0" cellspacing="0" cellpadding="0">                               
                                <tr height="150px">
                                    <td style="vertical-align:middle">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 150px">
                                            <tr >
                                                <td style="width: 5%;BORDER-TOP: 1px dotted; BORDER-bottom: 1px dotted" >
                                                    <img border="0" height="100" src="images/left_spcl.jpg" style="cursor:hand"
                                                        width="50" /></td>

                                                <td style="width: 90%;BORDER-TOP: 1px dotted; BORDER-bottom: 1px dotted; vertical-align:middle; height: 100%;" valign="middle">
                                                   <igmisc:WebAsyncRefreshPanel ID="pnlAllSanPham" runat="server" Height="100px" OnContentRefresh="pnlAllSanPham_ContentRefresh"
                                                                    Width="100%" RefreshInterval="15000" InitializePanel="autorefreshsanpham">
                                                                     <asp:Table id="tblSanPham01" runat="server" Width="100%" CellPadding="0" CellSpacing="5" BorderStyle="none"></asp:Table></igmisc:WebAsyncRefreshPanel>
                                                </td>
                                           
                                                <td style="width: 5%;BORDER-TOP: 1px dotted; BORDER-bottom: 1px dotted">
                                                    <img border="0" height="100" src="images/right_spcl.jpg" style="cursor:hand"
                                                        width="50" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="left">
                                        <table class="box4" width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="title textxanh" style="border-bottom: #CCCCCC 1px solid">
                                                    <asp:Label ID="lblProdName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="left" style="padding-left: 20px;">
                                        <b><a href="default.aspx" class="pathway">Trang chủ</a></b> &gt; <b>
                                            <asp:LinkButton ID="lnkDanhMucCha" runat="server" CssClass="pathway"></asp:LinkButton></b>
                                        <asp:Label ID="lblArrow" runat="server" Text=">"></asp:Label>
                                        <b>
                                            <asp:Label ID="lblDanhMucCon" runat="server"></asp:Label>
                                        </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="31%" align="left" valign="top">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td><div style="width:323px;height:323px">
                                                                <img hspace="5" vspace="5" style="border: #CCCCCC 1px solid"
                                                                    id="imgSanPham" runat="server" height="0" /></div></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" id="TD1">
                                                                <a href="#"></a><a href="#"></a><a href="#"></a><a href="#"></a>
                                                                <asp:Panel ID="pnlAnhSanPham" runat="server" HorizontalAlign="Center" ScrollBars="Vertical"
                                                                    Width="100%">
                                                                </asp:Panel>
                                                                <igmisc:WebAsyncRefreshPanel ID="warpSuaGia" runat="server" Height="60px" OnContentRefresh="warpSuaGia_ContentRefresh"
                                                                    Width="100%">
                                                                    <br />
                                                                    <a href="" runat="server" id="linkgianhang"><asp:Label ID="lblThongBaoGia" runat="server" Font-Bold="True" ForeColor="Red" Text="Giá tại gian hàng của bạn"></asp:Label>
                                                                    <br />
                                                                    <asp:Label ID="lblGia" runat="server" Font-Bold="True" ForeColor="Red" Text="Label"></asp:Label>
                                                                    <br /></a>
                                                                    <igtxt:WebNumericEdit ID="wceSuaGia" Visible="false" runat="server" Width="100px">
                                                                    </igtxt:WebNumericEdit>
                                                                    <asp:Button ID="btnSuaGia" runat="server" CssClass="button" Text="Sửa" UseSubmitBehavior="False"
                                                                        CausesValidation="False" OnClientClick="luugia()" Visible="False" />
                                                                    <asp:Button ID="btnHuySuaGia" runat="server" CssClass="button" Text="Hủy" UseSubmitBehavior="False"
                                                                        CausesValidation="False" OnClientClick="huysuagia(this)" Visible="False" />
                                                                    <input id="hidsuagia" runat="server" type="hidden" value="false"/>
                                                                </igmisc:WebAsyncRefreshPanel>
                                                                &nbsp;&nbsp;
                                                                <br />
                                                                <br />
                                                                <a href="#"></a><a href="#"></a><a href="#">
                                                                    <img border="0" height="29" src="images/baoloi.jpg" width="137" /></a><a href="javascript:suagia();"
                                                                        style="visibility: <%=GetInvisible("store")%>"><img id="imgSuaGia" runat="server"
                                                                            border="0" height="29" src="images/suagia.jpg" width="89" /></a><a href="#"></a></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="47%" align="left" valign="top">                                                 
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box1_bor" style="padding-left: 5px">
                                                        <tr>
                                                            <td align="left" style="height: 20px; width: 269px;">
                                                                <strong>Tên sản phẩm:</strong>
                                                                <asp:Label ID="lblTenSanPham" runat="server" CssClass="textcam"></asp:Label></td>
                                                            <td align="left" style="width: 200px;" rowspan="4">
                                                                <table width="100%" border="0">
                                                                    <tr>
                                                                        <td align="right" height="20">
                                                                            Có tất cả
                                                                            <asp:Label ID="lblSoCuaHang" runat="server" Text="24"></asp:Label>
                                                                            cửa hàng bán
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" height="20">
                                                                            <a href='javascript:addThisProduct();' style="visibility: <%=GetInvisible("store1")%>">
                                                                                <img border="0" hspace="2" src="images/toimuonban.jpg" vspace="2" /></a>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="height: 20px; width: 269px;">
                                                                <strong>Mã số sản phẩm:
                                                                    <asp:Label ID="lblMaSoSanPham" runat="server" CssClass="textcam"></asp:Label></strong></td>
                                                        </tr>
                                                        <tr>
                                                            <td height="20" align="left" style="width: 269px">
                                                                <strong>
                                                                    <asp:Label ID="lbl1" runat="server"></asp:Label>
                                                                    <asp:Label ID="lblGiaSanPham" runat="server" CssClass="textcam"></asp:Label>
                                                                    <asp:Label ID="lblDonViTienTe" runat="server" Text=""></asp:Label></strong></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" height="20" style="width: 269px">
                                                                <strong>
                                                                    <asp:Label ID="lbl2" runat="server"></asp:Label>
                                                                    <asp:Label ID="lblGiaMoi" runat="server" CssClass="textcam"></asp:Label>
                                                                    <asp:Label ID="lbl3" runat="server" Text="VNĐ"></asp:Label></strong></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" height="20" colspan="2">
                                                                <strong>Giới thiệu:</strong></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" height="20" align="left" style="line-height: 18px;">
                                                                <div align="justify" id="divThongTinSanPham" runat="server" style="padding-left: 10px;
                                                                    padding-top: 5px; height: 280px; overflow: auto;">
                                                                    <br />
                                                                </div>
                                                                <div align="justify">
                                                                </div>
                                                                <table id="tblKhuyenMai" runat="server" border="0" cellpadding="2" cellspacing="2"
                                                                    class="tableKhuyenMai" width="100%">
                                                                    <tr align="left" height="40">
                                                                        <td align="left" valign="top" width="15%">
                                                                            <img height="50" src="images/qua.jpg" width="64" /></td>
                                                                        <td align="left" valign="top" width="85%">
                                                                            <div runat="server" id="divThongTinKhuyenMai">
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" height="40" colspan="2">
                                                                <a href="ShoppingCart.aspx?spid=<%=ViewState["SanPhamID"].ToString() %>" style="visibility: <%=GetInvisible("user")%>">
                                                                    <img border="0" height="29" src="images/toimuon.jpg" width="177" /></a><a href="#"
                                                                        onclick="SendToFriend();"><img border="0" height="29" src="images/guitin.jpg" width="177" /></a></td>
                                                        </tr>
                                                    </table>                                                                                                   
                                                </td>
                                                <td width="22%" align="left" valign="top" rowspan="2">
                                                    <igmisc:WebAsyncRefreshPanel ID="pnlCuaHang" runat="server" Height="100%" Width="100%"
                                                        OnContentRefresh="pnlCuaHang_ContentRefresh">
                                                        <table style="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid;
                                                            border-bottom: gray 1px solid">
                                                            <tr>
                                                                <td class="box5_name textxanh">
                                                                    <table width="100%" border="0" class="box5" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td class="title">
                                                                                NHÀ CUNG CẤP
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <img src="images/haxn.jpg" width="169" height="97"></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="price" style="padding: 5px;" align="center">
                                                                    <span class="price"><span class="price"></span><span class="price">&nbsp;<asp:Panel
                                                                        ID="pnlDamBao" runat="server" Width="80%">
                                                                        <img src="images/kc.jpg" width="17" height="15">
                                                                        <img src="images/kc.jpg" width="17" height="15">
                                                                        <img src="images/kc.jpg" width="17" height="15">
                                                                        <img src="images/kc.jpg" width="17" height="15">
                                                                        <img src="images/kc.jpg" width="17" height="15">
                                                                        <img src="images/kc.jpg" width="17" height="15">
                                                                    </asp:Panel>
                                                                    </span></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; color: rgb(0, 102, 204); font-weight: bold;" align="left">
                                                                    <asp:Label ID="lblNguoiBan" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px;" align="left">
                                                                    Người bán hàng
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="price" style="padding: 5px;" align="left">
                                                                    Thông tin nhà cung cấp :
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px;" align="left">
                                                                    <strong>
                                                                        <asp:Label ID="lblNhaCungCap" runat="server"></asp:Label></strong></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px;" align="left">
                                                                    Đánh giá :
                                                                    <asp:Label ID="lblDiemDanhGia" runat="server" Font-Bold="True"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px;" align="center">
                                                                    <img src="images/dgnb.jpg" width="162" height="26" onclick='rate();' style="cursor: hand"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px;" align="left">
                                                                    Điện thoại : <strong>
                                                                        <asp:Label ID="lblDienThoaiCoDinh" runat="server">dt</asp:Label>
                                                                    </strong>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px;" align="left">
                                                                    Mobile : <strong>
                                                                        <asp:Label ID="lblDienThoaiDiDong" runat="server">dtcd</asp:Label>
                                                                    </strong>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px;" align="left" valign="middle">
                                                                    Hỗ trợ : <a href="ymsgr:sendIM?<%=ViewState["YM"].ToString()%>">
                                                                        <img src="http://opi.yahoo.com/online?u=<%=ViewState["YM"].ToString()%>&t=1" border="0"></a></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px;" align="left">
                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td width="11%">
                                                                                    <img src="images/messa.jpg" width="49" height="32"></td>
                                                                                <td width="89%">
                                                                                    Gửi tin nhắn đến người bán
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px;" align="center">
                                                                    <a runat="server" id="hrefLinkGianHang" href="#">
                                                                        <img src="images/ghetham.jpg" width="162" border="0" height="29"></a></td>
                                                            </tr>
                                                        </table>
                                                    </igmisc:WebAsyncRefreshPanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 16px">
                                        <table runat="server" id="Table1" width="80%" border="0" cellspacing="0" cellpadding="0"
                                            style="border: 1px solid; border-collapse: separate; background-color: #f9f9f9;">
                                            <tbody>
                                                <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                    <td align="center" colspan="5" height="30" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                        font-size: 11px; border: 1pt solid; color: rgb(102, 102, 102);">
                                                        <font class="title">Gian hàng được chonet.vn đảm bảo khi
                                                            mua hàng...<span class="Apple-converted-space"> </span></font>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <div style="height: 200px; overflow: auto; width: 80%;" id="divGianHangDamBao" runat="server">
                                            <table runat="server" id="tblGianHangDuocDamBao" width="100%" border="0" cellspacing="0"
                                                cellpadding="0" style="border: 1px solid; border-collapse: separate; background-color: #f9f9f9;">
                                                <tbody>
                                                    <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                        <td style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);
                                                            height: 38px;" align="center">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tbody>
                                                                    <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                                        <td width="5%" align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                            font-size: 11px; color: rgb(102, 102, 102); height: 25px;">
                                                                            5</td>
                                                                        <td width="2%" align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                            font-size: 11px; color: rgb(102, 102, 102); height: 25px;">
                                                                            <img src="images/m2.jpg" width="22" height="18"></td>
                                                                        <td width="69%" align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                            font-size: 11px; color: rgb(102, 102, 102); height: 25px;">
                                                                            <b>Nhatcuongmobile(Hà Nội)</b><font color="#FF0000">2.200.000 VND</font></td>
                                                                        <td width="24%" style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px;
                                                                            color: rgb(102, 102, 102); height: 25px;">
                                                                            <a href="#" style="font-size: 11px; color: rgb(51, 51, 51); text-decoration: none;
                                                                                font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                                                <img src="Images/muahang.jpg" border="0"></a></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr><td style="height: 16px"></td></tr>
                                                </tbody>
                                            </table>
                                        <asp:Label ID="lblGianHangDamBao" runat="server" Font-Bold="True" Text="Chưa có gian hàng được đảm bảo" Visible="False"></asp:Label></div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table runat="server" id="tblTraGia" class="form" width="100%" border="0" cellspacing="0"
                                            cellpadding="0">
                                            <tbody>
                                                <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                    <td height="30" align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                        font-size: 11px; color: rgb(102, 102, 102);">
                                                        <b>MUỐN MUA RẺ HƠN? HÃY TRẢ GIÁ</b></td>
                                                </tr>
                                                <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                    <td height="30" align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                        font-size: 11px; color: rgb(102, 102, 102);">
                                                        <table width="100%" bgcolor="#EFEFEF" border="0" cellspacing="2" cellpadding="2">
                                                            <tbody>
                                                                <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                                    <td width="10%" align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                        font-size: 11px; color: rgb(102, 102, 102);">
                                                                        <igtxt:WebNumericEdit ID="wneTraGia" runat="server">
                                                                        </igtxt:WebNumericEdit>
                                                                    </td>
                                                                    <td width="16%" align="left" nowrap="nowrap" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                        font-size: 11px; color: rgb(102, 102, 102);">
                                                                        &lt;&lt;<asp:Label ID="lblGiaSanPhamTraGia" runat="server"></asp:Label>
                                                                        VNĐ / 1 chiếc</td>
                                                                    <td width="2%" align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                        font-size: 11px; color: rgb(102, 102, 102);">
                                                                        <img src="images/qy.gif" width="17" height="17"></td>
                                                                    <td width="5%" align="left" nowrap="nowrap" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                        font-size: 11px; color: rgb(102, 102, 102);">
                                                                        Số lượng</td>
                                                                    <td align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px;
                                                                        color: rgb(102, 102, 102); width: 3%;">
                                                                        <igtxt:WebNumericEdit ID="wneSoLuongTraGia" runat="server" ValueText="1">
                                                                        </igtxt:WebNumericEdit>
                                                                    </td>
                                                                    <td width="3%" align="left" nowrap="nowrap" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                        font-size: 11px; color: rgb(102, 102, 102);">
                                                                        Ý kiến:</td>
                                                                    <td width="15%" align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                        font-size: 11px; color: rgb(102, 102, 102);">
                                                                        <input type="text" name="textfield3" id="txtYKienTraGia" runat="server"></td>
                                                                    <td width="46%" align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                        font-size: 11px; color: rgb(102, 102, 102);">
                                                                        <input type="button" name="btnTraGia" value="Trả giá" onclick="tragia();"></td>
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
                                        <igmisc:WebAsyncRefreshPanel ID="pnlProductDetail" runat="server" Height="100%" OnContentRefresh="pnlProductDetail_ContentRefresh"
                                            Width="100%">
                                            <input type="hidden" id="hidTabId" runat="server" value="1" />
                                            <input type="hidden" id="hidKhuVuc" runat="server" value="false" />
                                            <input type="hidden" id="hidLuuCauHoi" runat="server" value="false" />
                                            <input type="hidden" id="Hidden1" runat="server" value="false" />
                                            <input type="hidden" id="hidTraGia" runat="server" value="false" />
                                            <input type="hidden" id="hidKhuVucID" runat="server" value="0" />
                                            <input type="hidden" id="hidTraLoi" runat="server" />
                                            <input type="hidden" id="hidSoSanPham" runat="server" value="0" />
                                            <table width="100%" border="0" class="box6" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td align="left" class="title" style="height: 20px">
                                                        <asp:Table ID="tblTab" runat="server" CssClass="title" BorderStyle="none" Width="100%" CellPadding="0"
                                                            CellSpacing="0" >
                                                        </asp:Table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="box6_bor">
                                                        <table style="border-right: 1px solid; padding-right: 5px; border-top: 1px solid;
                                                            padding-left: 5px; font-size: 11px; padding-bottom: 5px; border-left: 1px solid;
                                                            color: rgb(102,102,102); line-height: 18px; padding-top: 5px; border-bottom: 1px solid;
                                                            font-family: Verdana, Arial, Helvetica, sans-serif" id="tblTraGiaContent" class="chcss"
                                                            cellspacing="1" cellpadding="1" width="100%" border="0" runat="server">
                                                            <tbody>
                                                                <tr style="font-weight: bold; font-size: 11px; color: rgb(102,102,102); font-family: Verdana, Arial, Helvetica, sans-serif">
                                                                    <td class="titlech" align="center" width="5%" bgcolor="#ffffff" height="25" style="border-right: 1pt solid;
                                                                        border-top: 1pt solid; border-left: 1pt solid; border-bottom: 1pt solid">
                                                                        STT</td>
                                                                    <td class="titlech" align="center" width="20%" bgcolor="#ffffff" style="border-right: 1pt solid;
                                                                        border-top: 1pt solid; border-bottom: 1pt solid">
                                                                        Người trả giá</td>
                                                                    <td style="border-right: 1pt solid; border-top: 1pt solid; border-bottom: 1pt solid;"
                                                                        class="titlech" align="center" width="20%" bgcolor="#ffffff">
                                                                        Giá</td>
                                                                    <td style="border-right: 1pt solid; border-top: 1pt solid; border-bottom: 1pt solid;"
                                                                        class="titlech" align="center" width="15%" bgcolor="#ffffff">
                                                                        Số lượng</td>
                                                                    <td style="border-right: 1pt solid; border-top: 1pt solid; border-bottom: 1pt solid;"
                                                                        class="titlech" align="center" width="40%" bgcolor="#ffffff">
                                                                        Chi tiết</td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <table id="tblCacCuaHang" width="100%" runat="server">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="padding: 5px; color: rgb(255, 0, 0); font-weight: bold;" align="left">
                                                                        Quý khách nên gọi điện liên lạc xác nhận về số lượng, giá cả trước khi đến cửa hàng.Nếu
                                                                        quý khách phát hiện cửa hàng nào ghi giá quá rẻ nhưng không có hàng cố ý lừa khách
                                                                        hàng xin thông báo với chúng tôi qua YM thacmaccn, hoặc email info@chonet.vn, hoặc
                                                                        đánh giá trực tiếp vào ngay cửa hàng. Xin cảm ơn .</td>
                                                                </tr>
                                                                <tr>
                                                                    <td bgcolor="#d5eaff">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align="left" width="29%">
                                                                                        <b>Giá các cửa hàng </b>
                                                                                    </td>
                                                                                    <td width="71%">
                                                                                        <table cellspacing="2" cellpadding="2" width="100%" border="0">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td nowrap width="30%">
                                                                                                        <b>Xem giá theo Tỉnh/Thành phố: </b>
                                                                                                    </td>
                                                                                                    <td width="4%">
                                                                                                        <select id="ddlKhuVuc" runat="server" name="ddlKhuVuc" onchange='changekhuvuc(this);'>
                                                                                                            <option selected="selected"></option>
                                                                                                        </select>
                                                                                                    </td>
                                                                                                    <td style="color: rgb(255,0,0)" width="62%">
                                                                                                        &nbsp;</td>
                                                                                                    <td width="4%">
                                                                                                    </td>
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
                                                                    <td align="center">
                                                                        <table runat="server" id="tblcontencuahang" class="chcss" width="100%" border="0"
                                                                            cellspacing="1" cellpadding="1" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                            font-size: 11px; color: rgb(102, 102, 102); line-height: 18px; padding: 5px;
                                                                            border: 1px solid">
                                                                            <tbody>
                                                                                <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-weight: bold;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <td width="5%" height="25" align="center" bgcolor="#ffffff" class="titlech" style="border-right: 1pt solid;
                                                                                        border-top: 1pt solid; border-left: 1pt solid; border-bottom: 1pt solid">
                                                                                        STT</td>
                                                                                    <td width="36%" align="center" bgcolor="#ffffff" class="titlech" style="border-right: 1pt solid;
                                                                                        border-top: 1pt solid; border-left: 1pt solid; border-bottom: 1pt solid">
                                                                                        Tên cửa hàng bán</td>
                                                                                    <td width="23%" style="font-weight: bold; border-right: 1pt solid; border-top: 1pt solid;
                                                                                        border-left: 1pt solid; border-bottom: 1pt solid;" align="center" bgcolor="#ffffff"
                                                                                        class="titlech">
                                                                                        <table border="0" cellspacing="0" cellpadding="0">
                                                                                            <tbody>
                                                                                                <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                                                                    <td style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);
                                                                                                        line-height: 18px; padding-top: 5px; padding-right: 5px; padding-bottom: 5px;
                                                                                                        padding-left: 5px;">
                                                                                                        Giá</td>
                                                                                                    <td style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);
                                                                                                        line-height: 18px; padding-top: 5px; padding-right: 5px; padding-bottom: 5px;
                                                                                                        padding-left: 5px;">
                                                                                                        <img src="images/qy.gif" width="17" height="17"></td>
                                                                                                </tr>
                                                                                            </tbody>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td width="16%" style="font-weight: bold; border-right: 1pt solid; border-top: 1pt solid;
                                                                                        border-left: 1pt solid; border-bottom: 1pt solid;" align="center" bgcolor="#ffffff"
                                                                                        class="titlech">
                                                                                        Đánh giá</td>
                                                                                    <td width="20%" style="font-weight: bold; border-right: 1pt solid; border-top: 1pt solid;
                                                                                        border-left: 1pt solid; border-bottom: 1pt solid;" align="center" bgcolor="#ffffff"
                                                                                        class="titlech">
                                                                                        Địa chỉ, điện thoại cửa hàng</td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                        <asp:Label ID="lblCuaHangBan" runat="server" Text="Không có cửa hàng nào bán sản phẩm này"
                                                                            Font-Bold="True"></asp:Label></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <div>
                                                            <asp:Table ID="tblContent" runat="server" BorderStyle="none" Width="100%" CellPadding="0"
                                                                CellSpacing="0">
                                                            </asp:Table>
                                                        </div>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                                    <td>
                                                                        <table runat="server" style="border: 1px solid" id="tblHoiDapContent" width="100%"
                                                                            border="0" cellspacing="1" cellpadding="2">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td colspan="4" bgcolor="#6fbe27">
                                                                                        <strong><span style="color: #ffffff">CÁC PHẨN HỒI VỀ SẢN PHẨM</span></strong></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="2%">
                                                                                    </td>
                                                                                    <td width="13%">
                                                                                    </td>
                                                                                    <td width="71%">
                                                                                        <strong>
                                                                                            <asp:Label ID="lblHoiDap" runat="server" Text="Chưa có nhận xét, phản hồi nào"></asp:Label></strong></td>
                                                                                    <td width="14%">
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                                    <td>
                                                                        <table width="100%" runat="server" id="tblHoiDap">
                                                                            <tr>
                                                                                <td bgcolor="#6fbe27" height="30">
                                                                                    <b><span style="color: #ffffff">GỬI PHẢN HỒI CỦA BẠN</span> </b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" bgcolor="#ffffff">
                                                                                    <table border="0" cellpadding="2" cellspacing="2" width="80%">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td valign="top" height="30" nowrap="nowrap">
                                                                                                    (*)Câu hỏi của bạn</td>
                                                                                                <td align="left" valign="top" height="30">
                                                                                                    <input style="width: 250px;" name="textfield33" type="text" id="txtCauHoi" runat="server">
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCauHoi"
                                                                                                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td valign="top" height="30" nowrap="nowrap">
                                                                                                    (*) Thông tin chi tiết
                                                                                                </td>
                                                                                                <td align="left" valign="top" height="30">
                                                                                                    <textarea cols="29" rows="10" name="textarea" id="txtChiTietCauHoi" runat="server"></textarea>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtChiTietCauHoi"
                                                                                                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td valign="top" height="30" nowrap="nowrap">
                                                                                                    &nbsp;</td>
                                                                                                <td align="left" height="30">
                                                                                                    <input name="btnSend" value="Gửi đi" type="button" onclick="guicauhoi();" />
                                                                                                    <input name="btnReset" value="Nhập lại" type="button" onclick="resetcauhoi();" /></td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <div style="height: 40px">
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </igmisc:WebAsyncRefreshPanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
    <script src="Scripts/Common.js" type="text/javascript"></script>

    <script type="text/javascript" id="igClientScript">
    
    function autorefreshsanpham()
    {                    
        var warp = ig$('<%=pnlAllSanPham.ClientID%>');
        var pi = warp.getProgressIndicator(); 
               
        if(warp==null)
        {                
            return;            
        }
        else
        {      
            pi.setTemplate(' ');         
            warp.setTimer(15000);          
            warp.refresh();        
        }
    }
    
    function rate()
    {
        ShowModalDialog('RateStore.aspx?sid=<%=ViewState["CuaHangID"].ToString() %>','Đánh giá cửa hàng',525,585);
    }
    
    function addThisProduct()
    {
        ShowModalDialog('AddThisProduct.aspx?pid=<%=ViewState["SanPhamID"].ToString() %>','Thêm sản phẩm',615,445);
    }        
    function SendToFriend()
    {
        //OpenDialogWindow('Gửi thông tin',515,225,'page','SendToFriend.aspx?URL=' + document.URL);
        ShowModalDialog('SendToFriend.aspx?URL=' + document.URL,'Gửi thông tin',515,225);
    }
    function NhanXetSanPham()
    {        
        if ('<%=Session["UserFullName"]%>' != '')
        {
            //OpenDialogWindow('Nhận xét sản phẩm',430,225,'page','Comment.aspx?id=<%=ViewState["SanPhamID"].ToString() %>');    
            ShowModalDialog('Comment.aspx?id=<%=ViewState["SanPhamID"].ToString() %>','Nhận xét sản phẩm',430,225);
        }
    }
    function HoiDapSanPham( )
    {       
        if ('<%=Session["UserFullName"]%>' != '')
        { 
            //OpenDialogWindow('Hỏi đáp',430,225,'page','AskAndAnswer.aspx?id=<%=ViewState["SanPhamID"].ToString() %>');
            ShowModalDialog('AskAndAnswer.aspx?id=<%=ViewState["SanPhamID"].ToString() %>','Hỏi đáp',430,225);        
        }
    }
      function AddToShoppingCart()
    {
        blRefreshShoppingCart = true;
        //OpenDialogWindow('Giỏ hàng của bạn', 410, 320, 'page', 'ShoppingCart.aspx?spid=<%=ViewState["SanPhamID"].ToString() %>');        
        ShowModalDialog('ShoppingCart.aspx?spid=<%=ViewState["SanPhamID"].ToString() %>','Giỏ hàng của bạn', 610, 320);
    }
    function suagia()
    {
       var hidsuagia = document.getElementById('<%=hidsuagia.ClientID %>');
       var warp = ig$('<%=warpSuaGia.ClientID%>');            
       hidsuagia.value = "false";
       if(!warp) return;
            warp.refresh();
       
    }
    function luugia()
    {
       var hidsuagia = document.getElementById('<%=hidsuagia.ClientID %>');
       var warp = ig$('<%=warpSuaGia.ClientID%>');            
       hidsuagia.value = "true";
       
       if(!warp) return;
	        warp.refresh();
	        
    }
    
    function huysuagia(obj)
    {
        var btnSuaGia = document.getElementById('<%=btnSuaGia.ClientID%>');
        var wce = igedit_getById('<%=wceSuaGia.ClientID%>');
        //alert(btnSuaGia);
        //alert(wce);
        btnSuaGia.Visibility = "hidden";
        wce.setVisible(false);
        obj.Visibility = "hidden";
        
    }
    
    function LuuTraLoi(id, ctrl)
    {
        var hid = document.getElementById('<%=hidTabId.ClientID%>');  
        var hidCH = document.getElementById('<%=hidLuuCauHoi.ClientID%>'); 
        //var hidCHID = document.getElementById('<%=hidTraGia.ClientID%>'); 
        var hidTL = document.getElementById('<%=hidTraLoi.ClientID%>');
        var warp = ig$('<%=pnlProductDetail.ClientID%>');
        if(hid != null)
        {
            hid.value='2';
            hidCH.value = 'true';
            //hidCHID.value = id;
            hidTL.value = ctrl.value;
	        if(!warp) return;
	        warp.refresh();
	    }	   
    }
    
       
    function changekhuvuc(obj)
    {
       var hid = document.getElementById('<%=hidKhuVuc.ClientID%>');  
       var hidkhuvuc = document.getElementById('<%=hidKhuVucID.ClientID%>');  
       var warp = ig$('<%=pnlProductDetail.ClientID%>');
        if(hid != null)
        {
            hidkhuvuc.value = obj.selectedIndex;                        
            hid.value='true';            
	        if(!warp) return;
	        warp.refresh();
	    }	    
    }
    
    function Refresh()
    {
        var warp = ig$('<%=pnlProductDetail.ClientID%>'); 
        if(!warp) return;
	        warp.refresh();
    }
    
    function RefreshCuaHang()
    {
        var warp = ig$('<%=pnlCuaHang.ClientID%>');         
        if(!warp) return;
	        warp.refresh();
    }
    
    function TabSelected(tid, bl)
    {
        var warp = ig$('<%=pnlProductDetail.ClientID%>'); 
        var hid = document.getElementById('<%=hidTabId.ClientID%>');   	
        var hidCH = document.getElementById('<%=hidLuuCauHoi.ClientID%>'); 
        var hidtragia = document.getElementById('<%=hidTraGia.ClientID%>'); 
        hidCH.Value = "false"; 
        hidtragia.Value = "false"; 
        if (bl==true)	
        {
	        Refresh();	        
	    }
        if(hid != null)
        {
            hid.value=tid;              
	        if(!warp) return;
	        warp.refresh();
	    }		    	    
    }      
    
    function Enlarge(src)
    {
        var img = document.getElementById('<%=imgSanPham.ClientID %>');
        img.src= src;
    }
      
    function guicauhoi()
    {
        var hidCH = document.getElementById('<%=hidLuuCauHoi.ClientID%>'); 
        var warp = ig$('<%=pnlProductDetail.ClientID%>');
        if (hidCH != null)
        {
            hidCH.value = 'true';
            if (!warp) return;
            warp.refresh();
        }
    }
    
    function resetcauhoi()
    {
        txtcauhoi = document.getElementById('<%=txtCauHoi.ClientID %>');
        txtchitiet = document.getElementById('<%=txtChiTietCauHoi.ClientID %>');
        
        txtcauhoi.value = "";
        txtchitiet.value="";
    }
    
    function tragia()
    {         
        var hidtab = document.getElementById('<%=hidTabId.ClientID%>');         
        var hidtragia = document.getElementById('<%=hidTraGia.ClientID%>'); 
        var warp = ig$('<%=pnlProductDetail.ClientID%>');  
        var wneGia = igedit_getById('<%=wneTraGia.ClientID%>');
        var wneSoLuong = igedit_getById('<%=wneSoLuongTraGia.ClientID%>'); 
        
        if ((wneGia.getValue() != null) && (wneSoLuong.getValue() != null))
        {            
            hidtragia.value = 'true';
            hidtab.value = '4';
            if (!warp) return;
            warp.refresh();        
        }       
    }
    </script>
</asp:Content>
