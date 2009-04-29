<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Default.aspx.cs"
    Inherits="_Default" Title="Trang chủ" EnableEventValidation="false" ValidateRequest="false" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>
<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<%@ MasterType VirtualPath="~/Default.master" %>
<%@ OutputCache Duration="30" Location="Client" VaryByParam="*" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">

    <script src="Scripts/Common.js" type="text/javascript"></script>

    <script id="igClientScript" type="text/javascript">  
var lastFocusedControlId = "";

function focusHandler(e) {
    document.activeElement = e.originalTarget;
}

function appInit() {
    if (typeof(window.addEventListener) !== "undefined") {
        window.addEventListener("focus", focusHandler, true);
    }
    Sys.WebForms.PageRequestManager.getInstance().add_pageLoading(pageLoadingHandler);
    Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(pageLoadedHandler);
}

function pageLoadingHandler(sender, args) {
    lastFocusedControlId = typeof(document.activeElement) === "undefined" 
        ? "" : document.activeElement.id;
}

function focusControl(targetControl) {
    if (Sys.Browser.agent === Sys.Browser.InternetExplorer) {
        var focusTarget = targetControl;
        if (focusTarget && (typeof(focusTarget.contentEditable) !== "undefined")) {
            oldContentEditableSetting = focusTarget.contentEditable;
            focusTarget.contentEditable = false;
        }
        else {
            focusTarget = null;
        }
        targetControl.focus();
        if (focusTarget) {
            focusTarget.contentEditable = oldContentEditableSetting;
        }
    }
    else {
        targetControl.focus();
    }
}

function pageLoadedHandler(sender, args) {
    if (typeof(lastFocusedControlId) !== "undefined" && lastFocusedControlId != "") {
        var newFocused = $get(lastFocusedControlId);
        if (newFocused) {
            focusControl(newFocused);
        }
    }
}

Sys.Application.add_init(appInit);

  
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
    
    function OpenContacts()
    {
        window.open("news.aspx",'contacts');
    }
    </script>
    
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="36000">   
        <Scripts>
            <asp:ScriptReference Path="Scripts/FixFocus.js" />
        </Scripts> 
    </asp:ScriptManager>
    <table width="990px" cellspacing="0" cellpadding="0" style="padding-left: 5px">
        <tr>
            <td align="center">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="background: url(images/bgrightdoc.jpg) repeat-y right">
                        </td>
                        <td style="padding: 2px;">
                            <asp:Timer ID="tmquangcao10" runat="server" OnTick="Timer1_Tick">
                            </asp:Timer>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <span id="spnQuangCao10" runat="server"></span>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="tmquangcao10" EventName="Tick" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: auto">
                        <td style="background: url(images/leftcenterbody.jpg) repeat-y right">
                        </td>
                        <td colspan="2" style="background: url(images/rightcenterbody.jpg) repeat-y left 50%">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="center" width="207">
                                        <table border="0" cellspacing="0" cellpadding="0" onmouseover="document.getElementById('<%=supporters.ClientID %>').style.display='block'"
                                            onmouseout="document.getElementById('<%=supporters.ClientID %>').style.display='none'"
                                            class="questionMark">
                                            <tr>
                                                <td>
                                                    <a href="#">
                                                        <img src="images/sky.jpg" width="70" height="29" border="0" /></a></td>
                                                <td>
                                                    <a href="#">
                                                        <img src="images/ym.jpg" width="81" height="31" border="0" /></a></td>
                                            </tr>
                                        </table>
                                        <div id='supporters' runat="server" class="supporters" onmouseover="document.getElementById(this.id).style.display='block'"
                                            onmouseout="document.getElementById(this.id).style.display='none'">
                                        </div>
                                    </td>
                                    <td style="width: 8px; background-image: url(Images/seperate1.jpg); background-position-y: bottom;
                                        background-repeat: no-repeat; background-color: transparent;">
                                    </td>
                                    <td>
                                        <strong>Trang chủ</strong>
                                    </td>
                                    <td style="background-image: url(Images/seperate1.jpg); width: 8px; background-repeat: no-repeat;
                                        background-color: transparent; background-position: right bottom;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="background-color: #f0aa30; height: 15px;">
                                    </td>
                                    <td style="background-color: #f0aa30;">
                                    </td>
                                    <td style="background-color: #e3e3e3">
                                    </td>
                                    <td style="background-color: #f0aa30; width: 15px;">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="background: url(images/leftcenterbody.jpg) repeat-y right">
                        </td>
                        <td width="977">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="207" align="left" valign="top" style="background: url(images/bgleftmenu.jpg) fixed left top;">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                        <tr>
                                                            <td>
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td class="title" style="height: 25px">
                                                                            Danh mục sản phẩm
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 198px" valign="top">
                                                                            &nbsp;
                                                                            <ignav:UltraWebMenu ID="uwmMenu" runat="server" EnableAppStyling="True" JavaScriptFilename=""
                                                                                JavaScriptFileNameCommon="" LeafItemImageUrl="" ParentItemImageUrl="" StyleSetName="Appletini"
                                                                                WebMenuTarget="VerticalMenu" Width="200px" FileFlags="StylesOnly" SeparatorClass="">
                                                                                <ExpandEffects ShadowColor="LightGray" />
                                                                            </ignav:UltraWebMenu>
                                                                            &nbsp; &nbsp; &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                &nbsp;&nbsp;&nbsp;
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
                                                            <td class="title" style="width: 163px">
                                                                <table border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="28%" align="center">
                                                                            <img src="images/spmoi.png" width="30" height="27" /></td>
                                                                        <td width="72%" nowrap="nowrap" class="title">
                                                                            SẢN PHẨM MỚI
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <span class="pages" style="color: #000099"><a href="promotion.aspx?pcode=km"></a></span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 163px">
                                                                <asp:Table ID="tblSanPham07" runat="server" Width="100%" BorderStyle="none" CellSpacing="0"
                                                                    CellPadding="0">
                                                                </asp:Table>
                                                                <span style="color: #ffffff; text-decoration: underline"></span>
                                                            </td>
                                                        </tr>
                                                        <tr style="color: #ffffff; text-decoration: underline">
                                                            <td align="right" style="height: 13px; width: 163px;">
                                                                &nbsp;&nbsp;
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
                                                                <asp:Timer ID="tmquangcao04" runat="server" OnTick="tmquangcao04_Tick">
                                                                </asp:Timer>
                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <asp:Table ID="tblQuangCao04" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0">
                                                                        </asp:Table>
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="tmquangcao04" EventName="Tick" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
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
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="z-index: 0">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Timer ID="tmquangcao02" runat="server" OnTick="tmquangcao02_Tick">
                                                                            </asp:Timer>
                                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <span id="spnQuangCao02" runat="server" style="z-index: 1"></span>
                                                                                </ContentTemplate>
                                                                                <Triggers>
                                                                                    <asp:AsyncPostBackTrigger ControlID="tmquangcao02" EventName="Tick" />
                                                                                </Triggers>
                                                                            </asp:UpdatePanel>
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
                                                            <td align="left" valign="top" width="25%">
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
                                                                                    <table width="100%">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <strong>THÔNG TIN MỚI TỪ CHỢ NET</strong></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Label ID="lblTieuDe" runat="server"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="center">
                                                                                                <a href="javascript:NewsUpDown('up');">
                                                                                                    <img src="images/len.jpg" width="26" height="25" border="0" id="imgLen" runat="server"></a></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <div align="justify" id="divTinTuc" runat="server" style="overflow: auto; height: 150px;">
                                                                                                </div>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="center">
                                                                                                <a href="javascript:NewsUpDown('down');">
                                                                                                    <img src="images/xuong.jpg" width="26" height="25" border="0" id="imgXuong" runat="server"></a></td>
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
                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <table id="tblQuangCao03" runat="server" width="100%" border="0" cellspacing="4"
                                                                cellpadding="0">
                                                                <tr>
                                                                    <td width="50%" align="left">
                                                                        <span id="spnQuangCao03a" runat="server"></span>
                                                                    </td>
                                                                    <td width="50%" align="left">
                                                                        <span id="spnQuangCao03b" runat="server"></span>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="tmQuangCao3" EventName="Tick" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                    <asp:Timer ID="tmQuangCao3" runat="server" OnTick="Timer1_Tick1">
                                                    </asp:Timer>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td align="left" valign="top" style="padding: 1px;">
                                                                <igmisc:WebAsyncRefreshPanel ID="pnlSanPham04" runat="server" Height="" Width="100%"
                                                                    OnContentRefresh="pnlSanPham04_ContentRefresh">
                                                                    <input type="hidden" id="hidCatId" runat="server" />
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td class="titleto">
                                                                                <asp:Timer ID="tmDanhMuc" runat="server" OnTick="tmDanhMuc_Tick">
                                                                                </asp:Timer>
                                                                                <asp:UpdatePanel ID="pnlDanhMuc" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                                                                    <ContentTemplate>
                                                                                        <asp:Table ID="tblDanhMuc04" CssClass="titleto" runat="server" CellPadding="0" CellSpacing="0"
                                                                                            BorderStyle="none" Width="100%">
                                                                                        </asp:Table>
                                                                                    </ContentTemplate>
                                                                                    <Triggers>
                                                                                        <asp:AsyncPostBackTrigger ControlID="tmDanhMuc" EventName="Tick" />
                                                                                    </Triggers>
                                                                                </asp:UpdatePanel>
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
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 7px">
                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <table id="tblQuangCao05" runat="server" width="100%" border="0" cellspacing="0"
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
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="tmQuangCao5" EventName="Tick" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                    <asp:Timer ID="tmQuangCao5" runat="server" OnTick="tmQuangCao5_Tick">
                                                    </asp:Timer>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td class="titleto" align="left">
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="7%" class="nd1">
                                                                            <img src="images/km.png" width="50" height="44" /></td>
                                                                        <td width="17%" nowrap="nowrap" class="nd1">
                                                                            <a href="promotion.aspx?pcode=km">SẢN PHẨM KHUYẾN MÃI </a>
                                                                        </td>
                                                                        <td align="right" class="pages" style="padding-right: 1px; width: 76%;">
                                                                            <a href="promotion.aspx?pcode=km">Xem tất cả</a>&nbsp;&nbsp;&nbsp;
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
                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <table id="tblQuangCao07" runat="server" width="100%" border="0" cellspacing="2"
                                                                cellpadding="0">
                                                                <tr>
                                                                    <td width="50%" align="left">
                                                                        <span id="spnQuangCao07a" runat="server"></span>
                                                                    </td>
                                                                    <td width="50%" align="left">
                                                                        <span id="spnQuangCao07b" runat="server"></span>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="tmQuangCao7" EventName="Tick" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                    <asp:Timer ID="tmQuangCao7" runat="server" OnTick="tmQuangCao7_Tick">
                                                    </asp:Timer>
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
                                                                            <img src="images/gg.png" width="40" height="44" /></td>
                                                                        <td width="17%" nowrap="nowrap" class="nd1">
                                                                            <a href="promotion.aspx?pcode=gg">SẢN PHẨM GIẢM GIÁ</a></td>
                                                                        <td width="76%" align="right" class="pages" style="padding-right: 1px">
                                                                            <a href="promotion.aspx?pcode=gg">Xem tất cả</a>&nbsp;&nbsp;&nbsp;
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
                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <table id="tblQuangCao08" runat="server" width="100%" border="0" cellspacing="4"
                                                                cellpadding="0">
                                                                <tr>
                                                                    <td width="50%" align="left">
                                                                        <span id="spnQuangCao08a" runat="server"></span>
                                                                    </td>
                                                                    <td width="50%" align="left">
                                                                        <span id="spnQuangCao08b" runat="server"></span>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="tmQuangCao8" EventName="Tick" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                    <asp:Timer ID="tmQuangCao8" runat="server" OnTick="tmQuangCao8_Tick">
                                                    </asp:Timer>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" style="padding: 2px;">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td class="titleto" align="left">
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="17%" nowrap="nowrap" class="nd1">
                                                                            <a href="promotion.aspx?pcode=uc">SẢN PHẨM ĐƯỢC ƯA CHUỘNG </a>
                                                                        </td>
                                                                        <td width="83%" align="right" class="pages" style="padding-right: 1px">
                                                                            <a href="promotion.aspx?pcode=uc">Xem tất cả</a>&nbsp;&nbsp;&nbsp;
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
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <table id="tblQuangCao09" runat="server" width="100%" border="0" cellspacing="4"
                                                                cellpadding="0">
                                                                <tr>
                                                                    <td width="50%" align="left">
                                                                        <span id="spnQuangCao09a" runat="server"></span>
                                                                    </td>
                                                                    <td width="50%" align="left">
                                                                        <span id="spnQuangCao09b" runat="server"></span>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="tmQuangCao9" EventName="Tick" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                    <asp:Timer ID="tmQuangCao9" runat="server" OnTick="tmQuangCao9_Tick">
                                                    </asp:Timer>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
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
                                    <td align="left" valign="top">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="background: url(images/bgrightdoc.jpg) repeat-y left 50%; width: 15px;">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
