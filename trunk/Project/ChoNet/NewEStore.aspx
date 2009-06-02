<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/NewEstoreMaster.master"
    CodeFile="NewEStore.aspx.cs" Inherits="NeweStore" EnableEventValidation="false"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<%@ OutputCache Duration="30" VaryByParam="sid;tblSanPhamDaXem;cid" %>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphEstore">
    <div class="content">
        <div>
            <span id="spnQuangCao54" runat="server"></span>
        </div>
        <div class="list-link">
        <ul>
					<li><a href="#">Trang chủ</a>&nbsp;&raquo;</li>					
					<li><a href="#"><b style="color:#c60">Product-detail</b></a></li>
				</ul></div>
        <div class="box-product">
            <span runat="server" id="spnSanPhamHot"></span>
        </div>
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
            <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                <HeaderTemplate>
                    Sản phẩm mới
                </HeaderTemplate>
                <ContentTemplate>
                    <div class="TabbedPanelsContent clearfix">
                        <asp:UpdatePanel ID="pnlSanPham" runat="server" OnLoad="udpSanPham_Load">
                            <ContentTemplate>
                                <span id="spnSanPham" runat="server"></span>
                                <div class="mr-t5 fl t-r">
                                    <ul class="next">
                                        <asp:Label ID="lblPage" runat="server"></asp:Label>
                                        <li>
                                            <asp:DropDownList runat="server" ID="ddlPage" OnSelectedIndexChanged="ddlPage_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList></li>
                                    </ul>
                                </div>
                                <div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>
                    Sản phẩm giảm giá
                </HeaderTemplate>
                <ContentTemplate>
                    <div class="TabbedPanelsContent">
                        <span runat="server" id="spnGiamGia"></span>
                    </div>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                <HeaderTemplate>
                    Sản phẩm khuyến mại
                </HeaderTemplate>
                <ContentTemplate>
                    <div class="TabbedPanelsContent">
                        <span runat="server" id="SpanKhuyenMai"></span>
                    </div>
                </ContentTemplate>
            </cc1:TabPanel>            
        </cc1:TabContainer>
        <input id="hidPage" runat="server" type="hidden" />
        <input id="hidTab" runat="server" type="hidden" />
        
        <script type="text/javascript">
        <!--
        var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels1");
        function GoToPage(page, id)
            {       
                var hidPage = document.getElementById('<%=hidPage.ClientID %>');
                var hidTab = document.getElementById('<%=hidTab.ClientID %>');
                hidPage.value=page;
                hidTab.value = id;
                __doPostBack('<%=pnlSanPham.ClientID %>','');                
            }
        //-->
        </script>
    </div>    

</asp:Content>
