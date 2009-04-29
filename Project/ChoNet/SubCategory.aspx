<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="SubCategory.aspx.cs"
    Inherits="SubCategory" Title="Danh mục con" %>

<%@ Register Src="wucProperty.ascx" TagName="wucProperty" TagPrefix="uc1" %>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
    
    <%@ OutputCache Duration="30" VaryByParam="mcid;scid;spid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">

    <script type="text/javascript">
    function View(type)
    {
        var hidView = document.getElementById('<%=hidView.ClientID%>');
        var hidPage = document.getElementById('<%=hidPage.ClientID%>');
        hidView.value=type;
        var page = hidPage.value;
        if(type=='list')
        {
            hidPage.value= (parseInt(page,10)-1) * 3 + 1;
        }
        else
        {
            hidPage.value = (parseInt(parseInt(page,10) / 3,10) + 1);
        }   
        var warp = ig$('<%=pnlSanPham.ClientID%>');	
	    if(!warp) return;
	    warp.refresh();
    }
     function GoToPage(page)
    {
        var hidPage = document.getElementById('<%=hidPage.ClientID%>');
        hidPage.value=page;
        var warp = ig$('<%=pnlSanPham.ClientID%>');
        if(!warp) return;
        warp.refresh();	
    }
    
    </script>

    <table width="990px" cellspacing="0" cellpadding="0" style="padding-left:5px">
        <tr>
            <td align="center" style="width: 990px">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>                    
                        <td colspan="2">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr style="height: auto">
                                    <td style="background: url(images/leftcenterbody.jpg) repeat-y right">
                                    </td>
                                    <td colspan="2" style="background: url(images/rightcenterbody.jpg) repeat-y left 50%">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td align="center" width="210">
                                                    <table border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td>
                                                                <a href="#">
                                                                    <img src="images/sky.jpg" width="70" height="29" border="0" /></a></td>
                                                            <td>
                                                                <a href="#">
                                                                    <img src="images/ym.jpg" width="81" height="31" border="0" /></a></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 8px; background-image: url(Images/seperate1.jpg); background-position-y: bottom;
                                                    background-repeat: no-repeat; background-color: transparent;">
                                                </td>
                                                <td align="left">
                                                    <strong><span style="color: #ff6600"><a href="Default.aspx">Trang chủ</a></span> &gt;<asp:HyperLink
                                                        ID="lnkDanhMucCha" runat="server" CssClass="pathway">[lnkDanhMucCha]</asp:HyperLink></strong><b>
                                                    </b><strong>&gt; </strong><b>
                                                        <asp:Label ID="lblDanhMucCon" runat="server"></asp:Label></b></td>
                                                <td style="background-image: url(Images/seperate1.jpg);
                                                    width: 8px; background-repeat: no-repeat; background-color: transparent; background-position: right bottom;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="background-color: #f0aa30; height: 8px;">
                                                </td>
                                                <td style="background-color: #f0aa30;">
                                                </td>
                                                <td style="background-color: #e3e3e3" align="left">
                                                </td>
                                                <td style="background-color: #f0aa30; width: 15px;">
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
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="210" align="left" valign="top" style="background: url(images/bgleftmenu.jpg) fixed left top;">
                                        <table width="100%" border="0" cellspacing="4" cellpadding="0" class="box1">
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                        <tr>
                                                            <td>
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td class="title" >
                                                                            Danh mục sản phẩm
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Table ID="tblDanhMuc" runat="server" CssClass="leftmenu" Width="100%" CellPadding="0"
                                                                                CellSpacing="0" >
                                                                            </asp:Table>
                                                                            <asp:Menu ID="mnuNhomSanPham" runat="server" MaximumDynamicDisplayLevels="4" StaticEnableDefaultPopOutImage="False"
                                                                                StaticSubMenuIndent="" Width="100%" CssSelectorClass="PrettyMenu" >                                                                          
                                                                            </asp:Menu>
                                                                            <asp:Panel ID="pnlThuocTinh" runat="server" Width="100%">
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                &nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
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
                                                                <td width="210" align="left" valign="top">
                                                                    <table border="0" cellpadding="0" cellspacing="2" width="100%">
                                                                        <tr>
                                                                            <td align="left" class="pages" colspan="2" style="height: 13px">
                                                                                Từ khóa
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" colspan="2">
                                                                                <input id="txtTuKhoa" runat="server" name="textfield2" style="font-size: 11px; width: 90%"
                                                                                    type="text" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" class="pages" colspan="2">
                                                                                Tên sản phẩm
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" colspan="2">
                                                                                <input id="txtTenSanPham" runat="server" name="textfield22" style="font-size: 11px;
                                                                                    width: 90%" type="text" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" class="pages" colspan="2">
                                                                                Mã sản phẩm
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" colspan="2">
                                                                                <input id="txtMaSanPham" runat="server" name="textfield22" style="font-size: 11px;
                                                                                    width: 90%" type="text" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" class="pages" colspan="2">
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
                                                                            <td align="left" class="pages" colspan="2">
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
                                                                            <td align="left" class="pages" colspan="2">
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
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Table ID="tblQuangCao22" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0">
                                                    </asp:Table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="left" valign="top">
                                        <table width="100%" border="0" class="box6" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="box6_bor">
                                                    <igmisc:WebAsyncRefreshPanel ID="pnlSanPham" runat="server" Height="" Width="100%" OnContentRefresh="pnlSanPham_ContentRefresh">
                                                        <input type="hidden" id="hidView" runat="server" value="list" />
                                                        <input type="hidden" id="hidPage" runat="server" value="1" />
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
                                                                                            <a href="javascript:View('list');">
                                                                                                <img runat="server" id="imgList" alt="List" src="images/xs1.jpg" width="30" height="25"
                                                                                                    border="0" /></a></td>
                                                                                        <td>
                                                                                            <a href="javascript:View('icon');">
                                                                                                <img runat="server" id="imgIcon" alt="Icon" src="images/xs2.jpg" width="30" height="25"
                                                                                                    border="0" /></a></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td width="52%" align="center">
                                                                                <b>&nbsp;<asp:Panel ID="pnlTop" runat="server" Width="100%">
                                                                                    Trang :
                                                                                </asp:Panel>
                                                                                </b></td>
                                                                            <td width="30%">
                                                                                <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                    <tr>
                                                                                        <td nowrap="nowrap">
                                                                                            <b>Sắp xếp theo</b></td>
                                                                                        <td>
                                                                                            <select name="select4" style="width: 150px; font-size: 11px;">
                                                                                                <option>Mới cập nhật</option>
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
                                                                <td>
                                                                    <asp:Table ID="tblSanPham" runat="server" CellPadding="0" CellSpacing="0" BorderStyle="None"
                                                                        Width="100%">
                                                                    </asp:Table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="82%" align="left">
                                                                                <b>
                                                                                    <asp:Panel ID="pnlBottom" runat="server" Width="100%">
                                                                                        Trang :
                                                                                    </asp:Panel>
                                                                                </b></td>
                                                                            <td width="18%">
                                                                                <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="82%" nowrap="nowrap">
                                                                                            <strong>Đi tới trang </strong>
                                                                                        </td>
                                                                                        <td width="18%">
                                                                                            <select name="ddlPage" id="ddlPage" runat="server" style="width: 50px; font-size: 11px;"
                                                                                                onchange="GoToPage(this.value);">
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
                                                    </igmisc:WebAsyncRefreshPanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="background: url(images/bgrightdoc.jpg) repeat-y left; width: 15px;">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
