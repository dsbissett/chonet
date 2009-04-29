<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Search.aspx.cs"
    Inherits="Search" Title="Kết quả tìm kiếm" %>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">

    <script type="text/javascript">
    function View(type)
    {
        var hid = document.getElementById('<%=hidView.ClientID%>');
        hid.value=type;        
        var warp = ig$('<%=pnlSanPham.ClientID%>');	
	    if(!warp) return;
	    warp.refresh();
    }
    
    function SapXep()
    {
        var opt = document.getElementById('<%=slSapXep.ClientID%>');
        var hid = document.getElementById('<%=hidSapXep.ClientID%>');
        //var hidview = document.getElementById('<%=hidView.ClientID%>');
        var warp = ig$('<%=pnlSanPham.ClientID%>');	
        
        //hidview.value = type;
        hid.value = opt.value;                  
	    if(!warp) return;
	    warp.refresh();
    }
    
    function GoToPage(i)
    {
        var hidPage = document.getElementById('<%=hidPageNumber.ClientID%>');
        hidPage.value = i;
        
        var warp = ig$('<%=pnlSanPham.ClientID%>');
        if(!warp) return;
	    warp.refresh();
    }
    
    function slGoTo_ChangePage(obj)
    {
        GoToPage(obj.value);
    }
    
    </script>

    <input type="hidden" id="hidView" runat="server" /><input type="hidden" id="hidPageNumber"
        runat="server" value="1" />
    <input type="hidden" id="hidSapXep" runat="server" value="GiaSanPham" />
    <table width="980px" cellspacing="0" cellpadding="0">
        <tr><td style="background: url(images/leftcenterbody.jpg) repeat-y left 50%; width:15px;" align="center">
                        </td>
            <td align="center" style="width:970px">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="center" colspan="3">
                                        <strong>Tìm kiếm</strong>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="background-color: #e3e3e3">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        
                        <td>
                            <asp:Label ID="lblMessage" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" border="0" class="box6" cellspacing="0" cellpadding="0">
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
                                                                <img src="images/left_tab.jpg" width="12" height="27" /></td>
                                                            <td class="tab_active">
                                                                Tất cả các sản phẩm
                                                            </td>
                                                            <td width="12">
                                                                <img src="images/right_tab.jpg" width="12" height="27" /></td>
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
                                    <td class="box6_bor" align="center" style="padding-left: 30px">
                                        <igmisc:WebAsyncRefreshPanel ID="pnlSanPham" runat="server" Height="" Width="" OnContentRefresh="pnlSanPham_ContentRefresh">
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
                                                                    <b>
                                                                        <asp:Panel ID="pnlTop" runat="server" Width="100%">
                                                                            Trang :
                                                                        </asp:Panel>
                                                                    </b>
                                                                </td>
                                                                <td width="30%">
                                                                    <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                        <tr>
                                                                            <td nowrap="nowrap">
                                                                                <b>Sắp xếp theo</b></td>
                                                                            <td>
                                                                                <select name="slSapXep" style="width: 150px; font-size: 11px;" onchange="SapXep();"
                                                                                    id="slSapXep" runat="server">
                                                                                    <option value="GiaSanPham">Giá tăng dần</option>
                                                                                    <option value="GiaSanPham DESC">Giá giảm dần</option>
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
                                                                <td width="70%" align="left">
                                                                    <b>
                                                                        <asp:Panel ID="pnlBottom" runat="server" Width="100%">
                                                                            Trang :
                                                                        </asp:Panel>
                                                                    </b>
                                                                </td>
                                                                <td width="30%">
                                                                    <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                        <tr>
                                                                            <td width="70%" nowrap="nowrap" align="right">
                                                                                <strong>Đi tới trang </strong>
                                                                            </td>
                                                                            <td width="30%">
                                                                                <select name="select5" style="width: 50px; font-size: 11px;" id="slGoTo" runat="server"
                                                                                    onchange="slGoTo_ChangePage(this);">
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
            </td><td style="background: url(images/leftcenterbody.jpg) repeat-y left 50%; width: 15px;">
                        </td>
        </tr>
    </table>
</asp:Content>
