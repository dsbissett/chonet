
<%@ Page Language="C#" MasterPageFile="~/Adm/Admin.master" AutoEventWireup="true" CodeFile="PropertyAdmin.aspx.cs" Inherits="Adm_PropertyAdmin" Title="thuộc tính sản phẩm" %>
<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
<script type="text/javascript">
    function Add(){                              
        OpenDialogWindow('Thêm tin tức',820,600,'page','AddProperty.aspx');    
    }

    function Edit(obj){   
            var cell=igtbl_getCellById(obj.parentElement.id);
            var id=cell.Row.getCellFromKey('TinTucID').getValue();                   
            OpenDialogWindow('Sửa thông tin tin tức',820,600,'page','AddNews.aspx?nid=' + id);// + '&rand=' + rand_no);    
    }

    function Delete(obj){                      
            var cell=igtbl_getCellById(obj.parentElement.id);
            var id=cell.Row.getCellFromKey('TinTucID').getValue();
            OpenDialogWindow('Xóa tin tức',350,170,'page','Delete.aspx?id=' + id + '&type=tintuc');    
    }

    function RefreshProperty()
    {  	
        __doPostBack('<%=pnlThuocTinh.ClientID %>','');
        CloseDialogWindow();	
    }

    function Refresh()
    {  	
        RefreshProperty();	
    }
    
</script>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <asp:DropDownList ID="ddlNhomSanPham" runat="server" Width="164px" OnSelectedIndexChanged="ddlNhomSanPham_SelectedIndexChanged">
            </asp:DropDownList></td>
    </tr>
    <tr><td>
    <asp:UpdatePanel id="pnlThuocTinh"  runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="grdThuocTinh" runat="server" AutoGenerateColumns="False" CellPadding="4"
                ForeColor="#333333" GridLines="None" Width="100%">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:CommandField >
                        <ItemStyle Width="10%" />
                    </asp:CommandField>
                    <asp:BoundField DataField="ThuocTinhID" HeaderText="ThuocTinhID" Visible="False" />
                    <asp:BoundField DataField="TenThuocTinh" HeaderText="Thuộc t&#237;nh" />
                    <asp:BoundField DataField="NhomSanPhamID" HeaderText="Nh&#243;m Sản Phẩm" Visible="False" />
                </Columns>
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlNhomSanPham" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    </td>
    </tr>
    <tr><td style="padding-top: 10px">
            <table width="100%">
                <tr>
                    <td><input id="btnAdd" class="short-button" type="button" value="Thêm mới" onclick="Add();" /></td>
                    <td style="text-align: right">
                        &nbsp;</td>
                </tr>
            </table>
        </td></tr>
    </table>
</asp:Content>

