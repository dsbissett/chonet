<%@ Page Language="C#" MasterPageFile="~/Adm/Admin.master" AutoEventWireup="true"
    CodeFile="User.aspx.cs" Inherits="Admin_User" Title="Người dùng" %>

<%@ Register Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>
<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">

    <script id="igClientScript" type="text/javascript">

    var gn = null;
    var blCuahang = false;
    function GrdNguoiDung_InitializeLayoutHandler(gridName){
	gn = gridName;
}
function CreateCuaHang(obj)
{                              
        var cell=igtbl_getCellById(obj.parentElement.id);
        var id=cell.Row.getCellFromKey('NguoiDungID').getValue();         
        //OpenDialogWindow('Thêm người dùng',500,329,'page','CreateCuaHang.aspx');
        var pnl = ig$('<%=pnlUser.ClientID%>');
        blCuahang = true;   
        if (!pnl) return;
        var hidid = document.getElementById('<%=hidID.ClientID %>');
        hidid.value = id;
        pnl.refresh();        
}

    function Add(){                              
        OpenDialogWindow('Thêm người dùng',520,348,'page','AddUser.aspx');    
}

function Edit(obj){   
        var cell=igtbl_getCellById(obj.parentElement.id);
        var id=cell.Row.getCellFromKey('NguoiDungID').getValue();                   
        OpenDialogWindow('Sửa thông tin người dùng',510,348,'page','AddUser.aspx?id=' + id);// + '&rand=' + rand_no);    
}

function Delete(obj){                      
        var cell=igtbl_getCellById(obj.parentElement.id);
        var id=cell.Row.getCellFromKey('NguoiDungID').getValue();
        OpenDialogWindow('Xóa người dùng',310,170,'page','Delete.aspx?id=' + id + '&type=nguoidung');    
}
function Refresh()
{  	
    var warp = ig$('<%=pnlUser.ClientID%>');	
    //var grd = ig$('<%=GrdNguoiDung.ClientID%>');	
    //alert(grd);
    if(!warp)
		return;
		blCuahang= false;
	warp.refresh();
	
//	if(gn != null)		
//	    {	    
//	        igtbl_doPostBack(gn);
//	    }
	    		
// var img = document.getElementById('imgClose');
//        if (img != null) img.click();	
}



function wnpCat_RefreshComplete(oPanel){
    if (blCuahang != true)
    {
    	CloseDialogWindow();
	}
	else
	{
	    alert('Đã tạo Cửa Hàng thành công!');
	}
}
    </script>

    <table width="100%">
        <tr>
            <td colspan="4">
                <igmisc:WebAsyncRefreshPanel ID="pnlUser" runat="server" Height="100%"
                    Width="100%" RefreshComplete="wnpCat_RefreshComplete" OnContentRefresh="pnlUser_ContentRefresh" >
                    <igtbl:UltraWebGrid ID="GrdNguoiDung" runat="server" DataKeyField="NguoiDungID" 
                         Width="100%" OnInitializeLayout="GrdNguoiDung_InitializeLayout">
                        <Bands>
                            <igtbl:UltraGridBand DataKeyField="NguoiDungID">
                                <Columns>
                                    <igtbl:TemplatedColumn CellMultiline="No" Key="Command" SortIndicator="Disabled"
                                        Width="15%">
                                        <CellTemplate>
                                            <a href="#Edit" onclick="Edit(this);">Sửa</a> <a href="#delete" onclick="Delete(this);">
                                                Xóa</a> <a href="#CreatCuaHang" onclick="CreateCuaHang(this);" style="visibility: <%#Container.Cell.Row.Cells.FromKey("NoStore").Value %>">
                                                    Tạo cửa hàng</a>
                                        </CellTemplate>
                                        <CellStyle Cursor="Hand" HorizontalAlign="Center">
                                        </CellStyle>
                                        <Header Caption="">
                                        </Header>
                                    </igtbl:TemplatedColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="NguoiDungID" DataType="System.UInt32" Hidden="True"
                                        Key="NguoiDungID">
                                        <Header Caption="">
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="HoVaTen" CellMultiline="Yes" DataType="System.Int32"
                                        Key="HoVaTen" Width="20%">
                                        <CellStyle TextOverflow="Ellipsis" Wrap="True">
                                        </CellStyle>
                                        <Header Caption="T&#234;n người sử dụng">
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="GioiTinh" Key="GioiTinh" Width="7%">
                                        <Header Caption="Giới t&#237;nh">
                                            <RowLayoutColumnInfo OriginX="3" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="3" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="TaiKhoan" Key="TaiKhoan" Width="10%">
                                        <Header Caption="T&#224;i khoản">
                                            <RowLayoutColumnInfo OriginX="4" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="4" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="Email" Key="Email" Width="7%">
                                        <Header Caption="Email">
                                            <RowLayoutColumnInfo OriginX="5" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="5" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="DienThoaiDiDong" Key="DienThoaiDiDong" Width="7%">
                                        <Header Caption="ĐTDĐ">
                                            <RowLayoutColumnInfo OriginX="6" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="6" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="DienThoaiCoDinh" HeaderClickAction="Select"
                                        Key="DienThoaiCoDinh" Width="7%">
                                        <Header Caption="ĐTCĐ" ClickAction="Select">
                                            <RowLayoutColumnInfo OriginX="7" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="7" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="NgaySinh" DataType="System.DateTime" Format="dd/MM/yyyy"
                                        Key="NgaySinh" Width="7%">
                                        <Header Caption="Ng&#224;y Sinh">
                                            <RowLayoutColumnInfo OriginX="8" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="8" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="LoaiNguoiDung" DataType="System.Int32" Key="LoaiNguoiDung"
                                        Type="DropDownList" Width="10%">
                                        <Header Caption="Nh&#243;m">
                                            <RowLayoutColumnInfo OriginX="9" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="9" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="KichHoat" DataType="System.Boolean" Key="KichHoat"
                                        Width="7%">
                                        <Header Caption="K&#237;ch hoạt">
                                            <RowLayoutColumnInfo OriginX="10" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="10" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="LoaiNguoiDungID" DataType="System.Int32" Hidden="True"
                                        Key="LoaiNguoiDungID">
                                        <Header>
                                            <RowLayoutColumnInfo OriginX="11" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="11" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="MatKhau" Hidden="True" Key="MatKhau">
                                        <Header>
                                            <RowLayoutColumnInfo OriginX="12" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="12" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="NoStore" DataType="System.Boolean" Hidden="True"
                                        Key="NoStore">
                                        <Header>
                                            <RowLayoutColumnInfo OriginX="13" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="13" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                </Columns>
                                <RowTemplateStyle BackColor="Window" BorderColor="Window" BorderStyle="None" Height="215px"
                                    Width="481px">
                                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                </RowTemplateStyle>
                                <AddNewRow View="NotSet" Visible="NotSet">
                                </AddNewRow>
                            </igtbl:UltraGridBand>
                        </Bands>
                        <DisplayLayout AllowColSizingDefault="Free" AutoGenerateColumns="False"
                            BorderCollapseDefault="Separate" CellClickActionDefault="RowSelect" ColWidthDefault=""
                            HeaderClickActionDefault="SortMulti" Name="GrdNguoiDung" RowHeightDefault="20px" ScrollBarView="Horizontal" SelectTypeRowDefault="Single"
                            Version="4.00" AllowRowNumberingDefault="Continuous" CellPaddingDefault="2">
                            <FrameStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid"
                                BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt"
                                Width="100%">
                            </FrameStyle>
                            <RowAlternateStyleDefault BackColor="#FAFAFA">
                            </RowAlternateStyleDefault>
                            <Pager MinimumPagesForDisplay="2" AllowPaging="True" PageSize="15" Pattern="Trang [default]">
                            <PagerStyle BackColor="LightGray" BorderWidth="1px" BorderStyle="Solid">
                            <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px"></BorderDetails>
                            </PagerStyle>
                            </Pager>
                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                            </EditCellStyleDefault>
                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                            </FooterStyleDefault>
                            <HeaderStyleDefault BackColor="LightGray" BorderStyle="Solid" HorizontalAlign="Center">
                                <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                            </HeaderStyleDefault>
                            <RowStyleDefault BackColor="Window" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                                Font-Names="Microsoft Sans Serif" Font-Size="8.25pt">
                                <Padding Left="3px" />
                                <BorderDetails ColorLeft="Window" ColorTop="Window" />
                            </RowStyleDefault>
                            <GroupByRowStyleDefault BackColor="Control" BorderColor="Window">
                            </GroupByRowStyleDefault>
                            <GroupByBox Hidden="True">
                                <BoxStyle BackColor="ActiveBorder" BorderColor="Window">
                                </BoxStyle>
                            </GroupByBox>
                            <AddNewBox>
                                <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                    <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                                </BoxStyle>
                            </AddNewBox>
                            <ActivationObject BorderColor="White" BorderWidth="1px">
                                <BorderDetails ColorBottom="Silver" ColorRight="Silver" />
                            </ActivationObject>
                            <FilterOptionsDefault AllowRowFiltering="OnServer" AllString="Tất cả" ContainsString="Chứa" DoesNotContainString="Kh&#244;ng chứa" DoesNotEndWithString="Kh&#244;ng kết th&#250;c bằng" DoesNotStartWithString="Kh&#244;ngbắt đầu bằng" EmptyString="(Trống)" EndsWithString="Kết th&#250;c bằng" EqualsString="Bằng" FilterUIType="FilterRow" GreaterThanOrEqualsString="Lớn hơn hoặc bằng" GreaterThanString="Lớn hơn" LessThanOrEqualsString="Nhỏ hơn hoặc bằng" LessThanString="Nhỏ hơn" LikeString="Giống" NonEmptyString="(Kh&#244;ng trống)" NotEqualsString="Kh&#244;ng bằng" NotLikeString="Kh&#244;ng giống" ShowAllCondition="Yes" ShowEmptyCondition="No" StartsWithString="Bắt đầu bởi" FilterComparisonType="CaseInsensitive">
                                <FilterOperandDropDownStyle BackColor="White" BorderColor="Silver" BorderStyle="Solid"
                                    BorderWidth="1px" CustomRules="overflow:auto;" Font-Names="Verdana,Arial,Helvetica,sans-serif"
                                    Font-Size="11px">
                                    <Padding Left="2px" />
                                </FilterOperandDropDownStyle>
                                <FilterHighlightRowStyle BackColor="#151C55" ForeColor="White">
                                </FilterHighlightRowStyle>
                                <FilterDropDownStyle BackColor="White" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                                    CustomRules="overflow:auto;" Font-Names="Verdana,Arial,Helvetica,sans-serif"
                                    Font-Size="11px" Height="300px" Width="200px">
                                    <Padding Left="2px" />
                                </FilterDropDownStyle>
                                <FilterRowStyle BackColor="#E0E0E0" ForeColor="Black" HorizontalAlign="Left">
                                </FilterRowStyle>
                            </FilterOptionsDefault>
                            <ClientSideEvents BeforeRowTemplateOpenHandler="GrdManagerUsers_BeforeRowTemplateOpenHandler"
                                InitializeLayoutHandler="GrdNguoiDung_InitializeLayoutHandler" />
                            <SelectedRowStyleDefault Font-Bold="False" ForeColor="Blue">
                            </SelectedRowStyleDefault>
                        </DisplayLayout>
                    </igtbl:UltraWebGrid></igmisc:WebAsyncRefreshPanel>
                <input id="hidID" runat="server" type="hidden" /></td>
        </tr>
        <tr>
            <td colspan="4">
                <table width="100%">
                <tr>
                    <td><input id="btnAdd" class="short-button" type="button" value="Thêm mới" onclick="Add();" /></td>
                    <td style="text-align: right">
                        <asp:RadioButton ID="rbtPhanTrang" runat="server" AutoPostBack="True" Checked="True"
                            GroupName="pager" Text="Hiện theo trang" />
                        <asp:RadioButton ID="rbtTatCa" runat="server" AutoPostBack="True" GroupName="pager"
                            Text="Hiện tất cả" /></td>
                    </tr>
                </table>                    
            </td>
        </tr>
    </table>
</asp:Content>
