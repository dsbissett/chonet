<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="eStoreHome.aspx.cs"
    Inherits="eStoreHome" Title="Danh mục gian hàng" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebTab.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebTab" TagPrefix="igtab" %>
<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<%@ MasterType VirtualPath="~/Default.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">

    <script src="Scripts/Common.js" type="text/javascript"></script>

    <script id="igClientScript" type="text/javascript">
        
    function Refresh()
    {        
        CloseDialogWindow();
    } 
    
     function LostPassword()
    {        
        //OpenDialogWindow('Quên mật khẩu', 320, 150, 'page', 'LostPassword.aspx');        
        ShowModalDialog('LostPassword.aspx','Quên mật khẩu', 320, 150);        
    }
    function SearchCuaHang()
    {
        var ddl = document.getElementById('<%=ddlSearch.ClientID%>');  
        //alert(ddl.value); 	 
        TabSelected(ddl.value);
    }
     function TabSelected(tid)
    {
        var warp = ig$('<%=pnlThaiNguyen.ClientID%>'); 
        var hid = document.getElementById('<%=hidTabId.ClientID%>');   	         
 
        if(hid != null)
        {
            hid.value=tid;  
            //alert(tid);          
	        if(!warp) return;
	        warp.refresh();
	    }		    	    	    	    
    }   
    
    function GoToPage(page)
    {
        var hidPage = document.getElementById('<%=hidPage.ClientID %>');
        hidPage.value=page;
        var warp = ig$('<%=pnlThaiNguyen.ClientID%>');
        if(!warp) return;
        warp.refresh();	
    }   
    </script>

    <table width="990px" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="left" valign="top">
                            <table width="100%" border="0" cellspacing="4" cellpadding="0" style="width: 100%">
                                <tr>
                                    <td rowspan="2" align="left" valign="top" style="width: 207px; background: url(images/bgleftmenu.jpg) fixed left top;">
                                        <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td class="title">
                                                                Danh mục sản phẩm
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Table ID="tblDanhMuc" runat="server" CssClass="leftmenu" Width="100%" CellPadding="0"
                                                                    CellSpacing="0">
                                                                </asp:Table>
                                                                <asp:Menu ID="mnuNhomSanPham" runat="server" CssSelectorClass="PrettyMenu" MaximumDynamicDisplayLevels="4"
                                                                    StaticEnableDefaultPopOutImage="False" StaticSubMenuIndent="" Width="100%">
                                                                </asp:Menu>
                                                                <ignav:ultrawebmenu id="uwmMenu" runat="server" enableappstyling="True" javascriptfilename=""
                                                                    javascriptfilenamecommon="" leafitemimageurl="" parentitemimageurl="" stylesetname="Appletini"
                                                                    webmenutarget="VerticalMenu" width="200px">
<ExpandEffects ShadowColor="LightGray"></ExpandEffects>

<MenuClientSideEvents ItemChecked="" ItemClick="" SubMenuDisplay="" ItemHover="" InitializeMenu=""></MenuClientSideEvents>
</ignav:ultrawebmenu>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top">
                                        <asp:Panel ID="Panel1" runat="server" Height="50px" Width="100%" DefaultButton="btnSearch">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <strong>Tìm gian hàng</strong></td>
                                                    <td>
                                                        <asp:TextBox ID="txtKeySearch" runat="server" Width="231px"></asp:TextBox></td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSearch" runat="server" Width="167px">
                                                            <asp:ListItem Value="1">To&#224;n bộ</asp:ListItem>
                                                            <asp:ListItem Value="2">VIP</asp:ListItem>
                                                            <asp:ListItem Value="3">Chuy&#234;n nghiệp</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:Button ID="btnSearch" class="button" runat="server" Text="Tìm kiếm" OnClientClick='return SearchCuaHang();'
                                                            UseSubmitBehavior="False" /></td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 900px" valign="top">
                                        <igmisc:WebAsyncRefreshPanel ID="pnlThaiNguyen" runat="server" Height="100%" Width="100%"
                                            OnContentRefresh="pnlGianHang_ContentRefresh">
                                            <input type="hidden" id="hidTabId" runat="server" value="1" />
                                            <input type="hidden" id="hidPage" runat="server" value="1" />
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td align="left" style="height: 20px" class="title">
                                                        <asp:Table ID="tblTab" runat="server" BorderStyle="none" Width="100%" CellPadding="0"
                                                            CellSpacing="0" CssClass="titleto">
                                                        </asp:Table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Table ID="tblGianHang" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0"
                                                            Width="100%">
                                                        </asp:Table>
                                                        <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                            <tr>
                                                                <td width="82%" nowrap="nowrap">
                                                                    <strong>
                                                                        <asp:Label ID="lblPage" runat="server"></asp:Label></strong></td>
                                                                <td width="18%" style="text-align: right">
                                                                    <select name="ddlPage" id="ddlPage" runat="server" style="width: 50px; font-size: 11px;"
                                                                        onchange="GoToPage(this.value);">
                                                                    </select>
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
        </tr>
    </table>
</asp:Content>
