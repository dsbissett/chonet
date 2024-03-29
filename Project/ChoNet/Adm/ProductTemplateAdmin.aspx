﻿<%@ Page Language="C#" MasterPageFile="~/Adm/Admin.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="~/Adm/ProductTemplateAdmin.aspx.cs" Inherits="AdminTemplate_Product"
    Title="Sản phẩm mẫu" %>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphAdmin">

    <script id="igClientScript" type="text/javascript">
<!--

function ddl_onchange(i)
{    
     var warp = ig$('<%=pnlSanPham.ClientID%>');
     var hid = document.getElementById('<%=hiddropdown.ClientID %>');
     hid.value=i;	   
    //alert(warp);
    if(!warp)
		return;		
	warp.refresh();	
    
}
function SetTitle(title)
{
    var tdDialogTitle = document.getElementById('tdDialogTitle'); 
    //alert(tdDialogTitle.innerText);
    if(tdDialogTitle != null) tdDialogTitle.innerText = title; 
}

function Add(){                              
        OpenDialogWindow('Thêm sản phẩm',975,1300,'page','AddProductTemplate.aspx');    
}

function Edit(obj){   
        var cell=igtbl_getCellById(obj.parentElement.id);
        var id=cell.Row.getCellFromKey('SanPhamID').getValue();                   
        OpenDialogWindow('Sửa thông tin sản phẩm',975,1300,'page','AddProductTemplate.aspx?id=' + id);// + '&rand=' + rand_no);    
}

function Delete(obj){                      
        var cell=igtbl_getCellById(obj.parentElement.id);
        var id=cell.Row.getCellFromKey('SanPhamID').getValue();
        OpenDialogWindow('Xóa sản phẩm',350,170,'page','Delete.aspx?id=' + id + '&type=sanphammau');    
}

function Refresh()
{  	
    var warp = ig$('<%=pnlSanPham.ClientID%>');	   
    //alert(warp);
    if(!warp)
		return;		
	warp.refresh();	
}

function WebAsyncRefreshPanel1_RefreshComplete(oPanel)
{
	CloseDialogWindow();
}
// -->
    </script>
<igmisc:WebAsyncRefreshPanel ID="pnlSanPham" runat="server" Height="100%" Width="100%"
                    RefreshComplete="WebAsyncRefreshPanel1_RefreshComplete" OnContentRefresh="pnlSanPham_ContentRefresh">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    
                    <tr>
                        <td>
                            Danh mục cấp 1</td>
                        <td>
                            <asp:DropDownList ID="ddlDanhMuc1" runat="server" Width="200px">
                            </asp:DropDownList></td>
                        <td>
                            Danh mục cấp 2</td>
                        <td>
                            <asp:DropDownList ID="ddlDanhMuc2" runat="server" Width="200px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>
                            Danh mục cấp 3</td>
                        <td>
                            <asp:DropDownList ID="ddlDanhMucCap3" runat="server" Width="200px">
                            </asp:DropDownList></td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Hãng sản xuất</td>
                        <td>
                            <asp:DropDownList ID="ddlHangSanXuat" runat="server" Width="200px">
                            </asp:DropDownList></td>
                        <td>
                            Khu vực</td>
                        <td>
                            <asp:DropDownList ID="ddlKhuVuc" runat="server" Width="200px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>
                            Tên sản phẩm</td>
                        <td>
                            <asp:TextBox ID="txtTenSanPham" runat="server" Width="194px"></asp:TextBox></td>
                        <td>
                            Người nhập</td>
                        <td>
                            <asp:TextBox ID="txtNguoiNhap" runat="server" Width="192px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 40px" valign="bottom">
                            <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Tìm kiếm" Width="84px" UseSubmitBehavior="false" />
                            <input id="hiddropdown" runat="server" type="hidden" value="0" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-top: 10px">
                <table width="100%">
                    <tr>
                        <td>
                            <input id="Button1" class="short-button" type="button" value="Thêm mới" onclick="Add();"
                                runat="server" /></td>
                        <td style="text-align: right">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>                
                    <igtbl:UltraWebGrid ID="grdSanPham" runat="server" Width="100%" DataKeyField="SanPhamID" OnPageIndexChanged="grdSanPham_PageIndexChanged" style="top: 0px">
                        <Bands>
                            <igtbl:UltraGridBand DataKeyField="SanPhamID">
                                <Columns>
                                    <igtbl:TemplatedColumn Key="Command" SortIndicator="Disabled" Width="8%">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellTemplate>
                                            <a href="#Edit" onclick="Edit(this);">Sửa</a> <a href="#delete" onclick="Delete(this);">
                                                Xóa</a>
                                        </CellTemplate>
                                        <Header Caption="">
                                        </Header>
                                        <CellStyle Cursor="Hand" HorizontalAlign="Center">
                                        </CellStyle>
                                    </igtbl:TemplatedColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="SanPhamID" DataType="System.Int32" Hidden="True"
                                        Key="SanPhamID">
                                        <Header>
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="TenSanPham" Key="TenSanPham" Width="17%">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="Sản phẩm">
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Footer>
                                        <CellStyle Wrap="True">
                                        </CellStyle>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="GiaSanPham" DataType="System.Decimal" Format="###,###,##0"
                                        Key="GiaSanPham" Width="10%">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="Gi&#225;">
                                            <RowLayoutColumnInfo OriginX="3" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="3" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="TenNhomSanPham" Key="TenNhomSanPham" Width="15%">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="Nh&#243;m ">
                                            <RowLayoutColumnInfo OriginX="4" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="4" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="GiamGia" DataType="System.Boolean" Key="GiamGia"
                                        Width="7%">
                                        <Header Caption="Giảm gi&#225;">
                                            <RowLayoutColumnInfo OriginX="5" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="5" />
                                        </Footer>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="KhuyenMai" Key="KhuyenMai" Width="7%">
                                        <Header Caption="Khuyến m&#227;i">
                                            <RowLayoutColumnInfo OriginX="6" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="6" />
                                        </Footer>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="TenHangSanXuat" Key="TenHangSanXuat" Width="12%">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="H&#227;ng sản xuất">
                                            <RowLayoutColumnInfo OriginX="7" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="7" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="NhomSanPhamID" Hidden="True" Key="NhomSanPhamID">
                                        <Header>
                                            <RowLayoutColumnInfo OriginX="8" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="8" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="AnhSanPham" Hidden="True" Key="AnhSanPham">
                                        <Header>
                                            <RowLayoutColumnInfo OriginX="9" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="9" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="TenKhuVuc" Key="TenKhuVuc" Width="12%">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="KhuVuc">
                                            <RowLayoutColumnInfo OriginX="10" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="10" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:TemplatedColumn Width="12%">
                                        <CellTemplate>
                                            <img alt="" id="imgCell" height="40" src=".<%#Container.Cell.Row.Cells.FromKey("AnhSanPham").Value %>"
                                                width="80" />
                                        </CellTemplate>
                                        <Header Caption="Ảnh">
                                            <RowLayoutColumnInfo OriginX="11" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="11" />
                                        </Footer>
                                    </igtbl:TemplatedColumn>
                                </Columns>
                                <AddNewRow View="NotSet" Visible="NotSet">
                                </AddNewRow>
                            </igtbl:UltraGridBand>
                        </Bands>
                        <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AutoGenerateColumns="False"
                            BorderCollapseDefault="Separate" CellClickActionDefault="RowSelect" ColWidthDefault=""
                            HeaderClickActionDefault="SortMulti" Name="grdSanPham" RowHeightDefault="20px"
                            ScrollBarView="Vertical" Version="4.00" AllowRowNumberingDefault="Continuous"
                            CellPaddingDefault="2">
                            <FrameStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid"
                                BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Width="100%">
                            </FrameStyle>
                            <RowAlternateStyleDefault BackColor="#FAFAFA">
                            </RowAlternateStyleDefault>
                            <Pager AllowPaging="True" PageSize="12" Pattern="Trang [default]" AllowCustomPaging="True"
                                StyleMode="QuickPages" PagerAppearance="Both" QuickPages="10" NextText="..." PrevText="...">
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
                            <SelectedRowStyleDefault ForeColor="Blue">
                            </SelectedRowStyleDefault>
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
                            <FilterOptionsDefault AllowRowFiltering="OnClient" AllString="Tất cả" ContainsString="Chứa"
                                DoesNotContainString="Kh&#244;ng chứa" DoesNotEndWithString="Kh&#244;ng kết th&#250;c bằng"
                                DoesNotStartWithString="Kh&#244;ngbắt đầu bằng" EmptyString="(Trống)" EndsWithString="Kết th&#250;c bằng"
                                EqualsString="Bằng" FilterUIType="FilterRow" GreaterThanOrEqualsString="Lớn hơn hoặc bằng"
                                GreaterThanString="Lớn hơn" LessThanOrEqualsString="Nhỏ hơn hoặc bằng" LessThanString="Nhỏ hơn"
                                LikeString="Giống" NonEmptyString="(Kh&#244;ng trống)" NotEqualsString="Kh&#244;ng bằng"
                                NotLikeString="Kh&#244;ng giống" ShowAllCondition="Yes" ShowEmptyCondition="No"
                                StartsWithString="Bắt đầu bởi" FilterComparisonType="CaseInsensitive">
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
                        </DisplayLayout>
                    </igtbl:UltraWebGrid>               
            </td>
        </tr>
        <tr>
            <td style="padding-top: 10px">
                
                <table width="100%">
                    <tr>
                        <td style="height: 40px" valign="bottom">
                            <input id="btnAdd" class="short-button" type="button" value="Thêm mới" onclick="Add();"
                                runat="server" /></td>
                        <td style="text-align: right" valign="bottom">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
     </igmisc:WebAsyncRefreshPanel>
</asp:Content>
