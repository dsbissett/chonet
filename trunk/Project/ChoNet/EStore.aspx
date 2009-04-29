<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/EstoreMaster.master"
    CodeFile="eStore.aspx.cs" Inherits="eStore" EnableEventValidation="false" ValidateRequest="false" %>

<%@ Register Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<%@ OutputCache Duration="30" VaryByParam="sid;tblSanPhamDaXem;cid" %>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphEstore">    

    <script id="igClientScript" type="text/javascript">
    <!--
    
    function GoToPage(page)
    {
        var hidPage = document.getElementById('<%=hidPage.ClientID %>');
        hidPage.value=page;
        var warp = ig$('<%=pnlSanPham.ClientID%>');
        if(!warp) return;
        warp.refresh();	
    }
    
    function btntimkiem_click()
    {
        var warp = ig$('<%=pnlSanPham.ClientID%>'); 
        var hid = document.getElementById('<%=hidTabId.ClientID%>');   	        
             
        hid.value='1';            
        if(!warp) return;
        warp.refresh();	    		    	    
    }
    
    function TabSelected(tid)
    {
        var warp = ig$('<%=pnlSanPham.ClientID%>'); 
        var hid = document.getElementById('<%=hidTabId.ClientID%>');   	        
        
        if(hid != null)
        {
            hid.value=tid;            
	        if(!warp) return;
	        warp.refresh();
	    }		    	    
    }
    // -->
    </script>

    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <td align="left" valign="top">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top">
                        <igmisc:WebAsyncRefreshPanel ID="pnlSanPham" runat="server" Height="100%" Width="100%"
                            OnContentRefresh="pnlSanPham_ContentRefresh">
                            <input type="hidden" id="hidTabId" runat="server" value="1" />
                            <input type="hidden" id="hidPage" runat="server" value="1" />&nbsp;
                            <table class="box1" width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="box1_bor" style="text-align: center">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="">
                                            <tr>
                                                <td class="box6_name">
                                                    <asp:Panel ID="Panel1" runat="server" Height="50px" Width="100%">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <table border="0" cellpadding="0" cellspacing="2" width="100%">
                                                                        <tr>
                                                                            <td nowrap="nowrap">
                                                                                Tìm kiếm:
                                                                            </td>
                                                                            <td nowrap="nowrap">
                                                                                <asp:TextBox ID="txtname" runat="server" Height="15px" Width="50px"></asp:TextBox></td>
                                                                            <td nowrap="nowrap">
                                                                                Giá từ :
                                                                            </td>
                                                                            <td nowrap="nowrap">
                                                                                <igtxt:WebNumericEdit ID="txtlp" runat="server" Width="40px">
                                                                                </igtxt:WebNumericEdit>
                                                                            </td>
                                                                            <td nowrap="nowrap">
                                                                                Đến</td>
                                                                            <td nowrap="nowrap" style="width: 48px">
                                                                                <igtxt:WebNumericEdit ID="txtup" runat="server" Width="60px">
                                                                                </igtxt:WebNumericEdit>
                                                                            </td>
                                                                            <td nowrap="nowrap">
                                                                                <asp:Button ID="btnTimKiem" runat="server" Text="Tìm kiếm"
                                                                                    UseSubmitBehavior="False" OnClientClick="btntimkiem_click()" /></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="box6_name">
                                                    <asp:Table ID="tblTab" runat="server" BorderStyle="none" Width="100%" CellPadding="0"
                                                        CellSpacing="0" CssClass="tab">
                                                    </asp:Table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Table ID="tblSanPham" CssClass="box1" runat="server" CellPadding="0" CellSpacing="0"
                                                        BorderWidth="0" Width="100%">
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
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </igmisc:WebAsyncRefreshPanel>
                    </td>
                </tr>
            </table>
        </td>
    </table>
</asp:Content>
