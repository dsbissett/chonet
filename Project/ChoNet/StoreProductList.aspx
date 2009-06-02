<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StoreProductList.aspx.cs"
    Inherits="StoreProductList" MasterPageFile="~/NewEstoreMaster.master" %>

<asp:Content runat="server" ID="ProductContent" ContentPlaceHolderID="cphEstore">
    <div class="content">
        <div class="list-link">
            <ul>
                <li><a href="#">Trang chủ</a>&nbsp;&raquo;</li>
                <li><a href="#"><b style="color: #c60">Product-list</b></a></li>
            </ul>
        </div>
        <div class="TabbedPanelsContent clearfix">
        <asp:UpdatePanel ID="pnlSanPham" runat="server" OnLoad="udpSanPham_Load">
            <ContentTemplate>
                <span id="spnSanPham" runat="server"></span>
                <div class="mr-t5 fl t-r">
                    <ul class="next">
                        <asp:Label ID="lblPage" runat="server"></asp:Label>
                        <li>
                            <asp:DropDownList runat="server" ID="ddlPage" OnSelectedIndexChanged="ddlPage_SelectedIndexChanged"
                                AutoPostBack="True">
                            </asp:DropDownList></li>
                    </ul>
                </div>
                <div>
                </div>
            </ContentTemplate>           
        </asp:UpdatePanel>
        </div>
        <input id="hidPage" runat="server" type="hidden" />

        <script type="text/javascript">
        <!--
        function GoToPage(page)
            {       
                var hidPage = document.getElementById('<%=hidPage.ClientID %>');
                hidPage.value=page;
                __doPostBack('<%=pnlSanPham.ClientID %>','');                
            }
        //-->
        </script>

    </div>
</asp:Content>
