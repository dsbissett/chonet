<%@ Page Language="C#" MasterPageFile="~/Adm/Admin.master" AutoEventWireup="true"
    CodeFile="PropertyAdmin.aspx.cs" Inherits="Adm_PropertyAdmin" Title="thuộc tính sản phẩm" %>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">

    <script type="text/javascript">
    
    function Add(){
        var hid = document.getElementById('<%=hidSelectedNode.ClientID %>');                           
        //alert(tv.value);        
        if (hid.value != '')                                                                                   
        OpenDialogWindow('Thêm thuộc tính',320,200,'page','AddProperty.aspx?cid='+ hid.value);    
    }

    function AddSub(id,cid){
        
        OpenDialogWindow('Thêm thuộc tính con',320,200,'page','AddSubProperty.aspx?cid='+ cid + '&ppid=' + id);    
    }
    
    function Edit(id){   
        var hid = document.getElementById('<%=hidSelectedNode.ClientID %>');                                                        
        OpenDialogWindow('Thêm tin tức',320,200,'page','AddProperty.aspx?cid='+ hid.value + '&pid=' + id);    
    }

    function Delete(id){                                  
            OpenDialogWindow('Xóa tin tức',350,170,'page','Delete.aspx?id=' + id + '&type=thuoctinh');    
    }

    function Refresh()
    {  	        
        __doPostBack('<%=pnlThuocTinh.ClientID %>','');
        CloseDialogWindow();	
    }
    
    
    </script>

    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="width: 20%" valign="top">
            </td>
            <td valign="top">
            </td>
        </tr>
        <tr>
            <td style="width: 20%" valign="top">
                <asp:TreeView ID="tvNhomSanPham" runat="server" ImageSet="Arrows" OnSelectedNodeChanged="tvNhomSanPham_SelectedNodeChanged"
                    Width="100%">
                    <ParentNodeStyle Font-Bold="False" />
                    <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                    <SelectedNodeStyle BackColor="#C0FFFF" Font-Underline="True" ForeColor="#5555DD"
                        HorizontalPadding="0px" VerticalPadding="0px" />
                    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                        NodeSpacing="0px" VerticalPadding="0px" />
                </asp:TreeView>
                </td>
            <td valign="top">
                <asp:UpdatePanel ID="pnlThuocTinh" runat="server" UpdateMode="Conditional">
                    <ContentTemplate><table width="100%"><tr><td>Thêm thuộc tính cho danh mục sản phẩm:        <asp:Label ID="lblDanhMuc" runat="server" Font-Bold="True"></asp:Label></td></tr>
                        <tr>
                            <td>
                        <input id="btnAdd" class="short-button" onclick="return Add();" type="button" value="Thêm mới" />
                            <asp:Label ID="lblThuocTinh" runat="server" Text="Không có thuộc tính nào" Visible="False" Font-Bold="True"></asp:Label></td>                            
                        </tr>
                        <tr><td>
                        <asp:GridView ID="grdThuocTinh" runat="server" BackColor="White" Width="100%" OnSelectedIndexChanged="grdThuocTinh_SelectedIndexChanged"
                            PageSize="8" GridLines="None" DataKeyNames="ThuocTinhID" CellSpacing="1" CellPadding="2"
                            Caption="<b>THUỘC TÍNH SẢN PHẨM</b>" BorderWidth="1px" BorderStyle="Ridge"
                            BorderColor="White" AutoGenerateColumns="False" AllowPaging="True" AutoGenerateSelectButton="True"
                            OnPageIndexChanging="grdThuocTinh_PageIndexChanging">
                            <PagerSettings Mode="NumericFirstLast"></PagerSettings>
                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black"></FooterStyle>
                            <Columns>
                                <asp:BoundField DataField="ThuocTinhID" Visible="False" HeaderText="ThuocTinhID"></asp:BoundField>
                                <asp:TemplateField>
                                    <ItemStyle Width="15%" HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <a style="cursor: hand" href='javascript:AddSub(<%# DataBinder.Eval(Container.DataItem,"ThuocTinhID"). ToString() %>,<%# DataBinder.Eval(Container.DataItem,"NhomSanPhamID"). ToString() %>);'>
                                            Thêm con </a>&nbsp;&nbsp; <a style="cursor: hand" href='javascript:Edit(<%# DataBinder.Eval(Container.DataItem,"ThuocTinhID"). ToString() %>);'>
                                                Sửa </a>&nbsp;&nbsp; <a style="cursor: hand" href='javascript:Delete(<%# DataBinder.Eval(Container.DataItem,"ThuocTinhID"). ToString() %>);'>
                                                    Xóa</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="TenThuocTinh" HeaderText="Thuộc t&#237;nh">
                                    <ItemStyle Width="75%"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                            <RowStyle BackColor="#DEDFDE" ForeColor="Black"></RowStyle>
                            <SelectedRowStyle BackColor="#9471DE" ForeColor="White" Font-Bold="True"></SelectedRowStyle>
                            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Justify"></PagerStyle>
                            <HeaderStyle BackColor="#4A3C8C" ForeColor="#E7E7FF" Font-Bold="True"></HeaderStyle>
                        </asp:GridView>
                <asp:UpdatePanel ID="pnlThuocTinhCon" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdThuocTinhCon" runat="server" BackColor="White" Width="100%"
                            PageSize="8" GridLines="None" DataKeyNames="ThuocTinhID" CellSpacing="1" CellPadding="2"
                            Caption="<b>THUỘC TÍNH CON</b>" BorderWidth="1px" BorderStyle="Ridge" BorderColor="White"
                            AutoGenerateColumns="False" AllowPaging="True" AutoGenerateSelectButton="True"
                            OnPageIndexChanging="grdThuocTinhCon_PageIndexChanging">
                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemStyle Width="15%" />
                                    <ItemTemplate>
                                        <a href='javascript:Edit(<%# DataBinder.Eval(Container.DataItem,"ThuocTinhID"). ToString() %>);'
                                            style="cursor: hand">Sửa </a><a href='javascript:Delete(<%# DataBinder.Eval(Container.DataItem,"ThuocTinhID"). ToString() %>);'
                                                style="cursor: hand">Xóa</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="TenThuocTinh" HeaderText="Thuộc t&#237;nh" />
                                <asp:BoundField DataField="NhomSanPhamID" HeaderText="Nh&#243;m Sản Phẩm" Visible="False" />
                            </Columns>
                            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Left" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                            <PagerSettings Mode="NumericFirstLast"></PagerSettings>
                        </asp:GridView>
                <input id="hidSelectedNode" runat="server" type="hidden" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdThuocTinh" EventName="SelectedIndexChanged">
                        </asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
                </td></tr></table>
                        &nbsp;&nbsp;
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="tvNhomSanPham" EventName="SelectedNodeChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 20%" valign="top">
            </td>
            <td style="padding-top: 10px" valign="top">
                <table width="100%">
                    <tr>
                        <td>
                        </td>
                        <td style="text-align: right">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
